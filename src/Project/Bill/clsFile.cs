/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains data of an File, belonging to an bill, and provide Methodes to handle them
 * 
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the LGPL General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using OLKI.Programme.QuiAbl.Properties;
using OLKI.Toolbox.ColorAndPicture.Picture;
using OLKI.Toolbox.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OLKI.Programme.QuiAbl.src.Project.Bill
{
    /// <summary>
    /// Class that contains data of an Fle, belonging to an bill, and provide Methodes to handle them
    /// </summary>
    public class File
    {
        #region Constants
        /// <summary>
        /// Default file extension for scaned fieles. Require if the scaned file shold peen saved to an directory
        /// </summary>
        private const string DEFAULT_EXTENSION_FOR_SCANED_FILES = ".jpg";
        #endregion

        #region Events
        /// <summary>
        /// Raised if the File data was changed
        /// </summary>
        public event EventHandler FileChanged;
        #endregion

        #region Enums
        public enum FileSource
        {
            Unknown,
            File,
            Scan,
            Link
        }
        #endregion

        #region Properties
        /// <summary>
        /// True if the Fike data was changed
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set if the File data was changed
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        public bool Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
                this.ToggleFileChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Color Palette of the file (if it is an Image)
        /// </summary>
        private Modify.Palette.ColorPalette _colorPalette = (Modify.Palette.ColorPalette)Settings.Default.Scan_DefaultColorMode;
        /// <summary>
        /// Get or set the Color Palette of the file (if it is an Image)
        /// </summary>
        public Modify.Palette.ColorPalette ColorPalette
        {
            get
            {
                return this._colorPalette;
            }
            set
            {
                this._colorPalette = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The comment to the File
        /// </summary>
        private string _comment;
        /// <summary>
        /// Get or set the comment to the File
        /// </summary>
        [Category("Allgemein")]
        [Description("Kommentar zur Datei.")]
        [DisplayName("Kommentar")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get => _comment;
            set
            {
                this._comment = value;
                this.Changed = true;
                this.ToggleFileChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Get the internal File Id
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [ReadOnly(true)]
        public int Id { get; private set; }

        /// <summary>
        /// The File data as Base64 encoded string
        /// </summary>
        private string _fileBase64;
        /// <summary>
        /// Get or set the File data as Base64 encoded string
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [ReadOnly(true)]
        public string FileBase64
        {
            get => _fileBase64;
            set
            {
                this._fileBase64 = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Original image before it was cropped
        /// </summary>
        private Image _imageBeforeCrop;

        /// <summary>
        /// Get the image if file is an image, or set an image to FileObject
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        public Image Image
        {
            get
            {
                try
                {
                    if (this.Source == FileSource.Link) return Image.FromFile(this.LinkPath);
                    return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(this._fileBase64)));
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                this.LoadFile(value);
            }
        }

        /// <summary>
        /// Get the image with proceded modifications, if file is an image
        /// </summary>
        [Browsable(true)]
        [ReadOnly(true)]
        public Image ImageProcedet
        {
            get
            {
                try
                {

                    if (this.Modification == null || this.Image == null)
                    {
                        return this.Image;
                    }
                    else
                    {
                        return this.ProceedModifications();
                    }
                }
                catch (Exception ex)
                {
                    _ = ex;
                    return null;
                }
                finally
                {
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// Get or set if the File is an new scaned image, need for LengthProcedet calculation
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [ReadOnly(false)]
        public bool IsNewScan { get; set; } = false;

        /// <summary>
        /// Length of the attached file, in Byte.
        /// </summary>
        [Category("Allgemein")]
        [Description("Geschätzte Größe der Datei in Byte.")]
        [DisplayName("Dateigröße")]
        [ReadOnly(true)]
        public long Length
        {
            get
            {
                if (string.IsNullOrEmpty(this._fileBase64)) return 0;
                return this._fileBase64.Length;
            }
        }

        /// <summary>
        /// Size of attached Files, in Bytes, after procedet or as saved if no modification is set
        /// </summary>
        [Category("Allgemein")]
        [Description("Geschätzte Größe der Datei in Byte, nachdem sie bearbeitet wurde oder wie sie gespeichet ist wenn keine Modifikation vorgesehen ist.")]
        [DisplayName("Dateigröße")]
        [ReadOnly(true)]
        public long LengthProcedet
        {
            get
            {
                if (string.IsNullOrEmpty(this._fileBase64)) return 0;
                if (this.ImageProcedet == null) return this._fileBase64.Length;
                if (this.Modification == null) return this._fileBase64.Length;

                bool IsModified = this.IsNewScan ? this.Modification.IsModified(Modify.Palette.ColorPalette.Color) : this.Modification.IsModified(this.Modification.Palette);
                if (!IsModified) return this._fileBase64.Length;

                return Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(this.ImageProcedet, typeof(byte[]))).Length;
            }
        }

        /// <summary>
        /// The path where the file is located, if the source is a linkes file
        /// </summary>
        [Category("Allgemein")]
        [Description("Pfad zur Verknüpften Datei.")]
        [DisplayName("Verknüpfungspfad")]
        public string LinkPath { get; set; }

        /// <summary>
        /// Get or set modifications to store. Modifications will be done, if proceed method is called
        /// </summary>
        [Browsable(false)]
        public ImageModification Modification { get; set; }

        /// <summary>
        /// Source of the file
        /// </summary>
        [Browsable(false)]
        public FileSource Source { get; set; } = FileSource.Unknown;

        /// <summary>
        /// The Name of the File
        /// </summary>
        private string _title;
        /// <summary>
        /// Get or set the Name of the File
        /// </summary>
        [Category("Allgemein")]
        [Description("Benennung der Datei.")]
        [DisplayName("Benennung")]
        public string Title
        {
            get => _title;
            set
            {
                this._title = value.Trim();
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the Name of the File, or an default text if no name is given
        /// </summary>
        [Browsable(false)]
        public string TitleNoText
        {
            get
            {
                return string.IsNullOrEmpty(this._title) ? Stringtable._0x000A : this.Title;
            }
        }

        /// <summary>
        /// Get the original FileName
        /// </summary>
        [Category("Allgemein")]
        [Description("Name der Originaldatei.")]
        [DisplayName("Originalname")]
        public string OriginalFileName { get; private set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Create a new empty File object with an predefined id
        /// </summary>
        /// <param name="id">Id for the new, empty File</param>
        public File(int id)
        {
            this.Id = id;
        }
        /// <summary>
        /// Create a new File object, get data from an XElement object
        /// </summary>
        /// <param name="inputFile">XElement to read File data from</param>
        public File(XElement inputFile)
        {
            this.FromFromXElement(inputFile);
        }

        /// <summary>
        /// Clone the File object
        /// </summary>
        /// <returns>The cloned File object</returns>
        public File Clone()
        {
            return (File)this.MemberwiseClone();
        }

        /// <summary>
        /// If the file is an image, it will be cropped to the defined area
        /// </summary>
        /// <param name="cropArea">Area to crop the image to, if file is an image</param>
        public void Crop(Rectangle? cropArea)
        {
            this.Crop(cropArea, out _);
        }
        /// <summary>
        /// If the file is an image, it will be cropped to the defined area
        /// </summary>
        /// <param name="cropArea">Area to crop the image to, if file is an image</param>
        /// <param name="exception">Exception while cropping the image, if file is an image</param>
        public void Crop(Rectangle? cropArea, out Exception exception)
        {
            try
            {
                exception = null;

                if (this.Image == null || !cropArea.HasValue) return;
                if (this._imageBeforeCrop == null) this._imageBeforeCrop = this.Image;

                this.Image = Modify.Crop(this.Image, cropArea);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        /// <summary>
        /// Undo cropping modificatinos, if file was an image
        /// </summary>
        /// <param name="exception"></param>
        public void CropUndo()
        {
            this.CropUndo(out _);
        }
        /// <summary>
        /// Undo cropping modificatinos, if file was an image
        /// </summary>
        /// <param name="exception">Exception while undo cropping</param>
        public void CropUndo(out Exception exception)
        {
            try
            {
                exception = null;
                if (this._imageBeforeCrop == null) return;
                this.Image = this._imageBeforeCrop;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        /// <summary>
        /// Get the File from an XElement object
        /// </summary>
        /// <param name="inputCompany">XElement to read File data from</param>
        public void FromFromXElement(XElement inputFile)
        {
            this.Id = Serialize.GetFromXElement(inputFile, "Id", 0);
            this._colorPalette = (Modify.Palette.ColorPalette)Serialize.GetFromXElement(inputFile, "ColorPalette", Settings.Default.Scan_DefaultColorMode);
            this._comment = Serialize.GetFromXElement(inputFile, "Comment", "");
            this._fileBase64 = Serialize.GetFromXElement(inputFile, "StreamBase64", "");
            this.LinkPath = Serialize.GetFromXElement(inputFile, "LinkPath", "");
            this.OriginalFileName = Serialize.GetFromXElement(inputFile, "OriginalFileName", "");
            this.Source = (FileSource)Serialize.GetFromXElement(inputFile, "Source", (int)FileSource.Unknown);
            this._title = Serialize.GetFromXElement(inputFile, "Title", "");
        }

        /// <summary>
        /// Load the defined file from fined path to the file object
        /// </summary>
        /// <param name="path">Path to load the file from</param>
        public void LoadFile(string path)
        {
            this._fileBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(path));
            this.OriginalFileName = new System.IO.FileInfo(path).Name;
        }

        /// <summary>
        /// Load the defined image to the file object
        /// </summary>
        /// <param name="image">Image to load to the file object</param>
        public void LoadFile(Image image)
        {
            this._fileBase64 = Convert.ToBase64String((byte[])new ImageConverter().ConvertTo(image, typeof(byte[])));
            this.OriginalFileName = "";
        }

        /// <summary>
        /// Open the linked file
        /// </summary>
        /// <param name="owner">Owner form to show messages modal</param>
        public void OpenFileFromLink(IWin32Window owner)
        {
            try
            {
                System.Diagnostics.Process FileOpener = new System.Diagnostics.Process();
                FileOpener.StartInfo.FileName = "explorer";
                FileOpener.StartInfo.Arguments = "\"" + this.LinkPath + "\"";
                FileOpener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, string.Format(Stringtable._0x0008m, new object[] { ex.Message }), Stringtable._0x0008c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Write the file to an defined directory an open it with system default application
        /// </summary>
        /// <param name="owner">Owner form to show messages modal</param>
        public void OpenFileFromPath(IWin32Window owner)
        {
            try
            {
                string Extension = string.IsNullOrEmpty(this.OriginalFileName) ? DEFAULT_EXTENSION_FOR_SCANED_FILES : new System.IO.FileInfo(this.OriginalFileName).Extension;
                SaveFileDialog SaveFileDialog = new SaveFileDialog
                {
                    DefaultExt = Extension,
                    FileName = string.IsNullOrEmpty(this.OriginalFileName) ? "" : this.OriginalFileName,
                    Filter = string.Format("(*{0}) | *{0}", new object[] { Extension })
                };
                if (SaveFileDialog.ShowDialog(owner) != DialogResult.OK) return;

                string FileToOpen = SaveFileDialog.FileName;
                System.IO.File.WriteAllBytes(FileToOpen, Convert.FromBase64String(this._fileBase64));


                if (MessageBox.Show(owner, Stringtable._0x0018m, Stringtable._0x0018c, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process FileOpener = new System.Diagnostics.Process();
                    FileOpener.StartInfo.FileName = "explorer";
                    FileOpener.StartInfo.Arguments = "\"" + FileToOpen + "\"";
                    FileOpener.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, string.Format(Stringtable._0x0008m, new object[] { ex.Message }), Stringtable._0x0008c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Write the file to temp directory an open it with system default application
        /// </summary>
        /// <param name="owner">Owner form to show messages modal</param>
        public void OpenFileFromTemp(IWin32Window owner)
        {
            try
            {
                string TempFile = System.IO.Path.GetTempFileName();
                string FileToOpen = TempFile;
                if (string.IsNullOrEmpty(this.OriginalFileName))
                {
                    FileToOpen += DEFAULT_EXTENSION_FOR_SCANED_FILES;
                }
                else
                {
                    FileToOpen += new System.IO.FileInfo(this.OriginalFileName).Extension;
                }
                System.IO.File.Move(TempFile, FileToOpen);
                if (this.Image == null)
                {
                    System.IO.File.WriteAllBytes(FileToOpen, Convert.FromBase64String(this._fileBase64));
                }
                else
                {
                    this.ImageProcedet.Save(FileToOpen);
                }

                System.Diagnostics.Process FileOpener = new System.Diagnostics.Process();
                FileOpener.StartInfo.FileName = "explorer";
                FileOpener.StartInfo.Arguments = "\"" + FileToOpen + "\"";
                FileOpener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, string.Format(Stringtable._0x0008m, new object[] { ex.Message }), Stringtable._0x0008c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Procedd stored modifications to the file, if the file is an image
        /// </summary>
        /// <returns>Modified image or null if file is not an image</returns>
        private Image ProceedModifications()
        {
            if (this.Image == null) return null;
            if (this.Modification == null) return this.Image;

            Image ProcedetImage = (Image)this.Image.Clone();

            // Procede resizing
            ProcedetImage = Modify.Resize(ProcedetImage, this.Modification.ResizeFactor, true);

            // Proced brightness and contrast modifications
            ProcedetImage = Modify.BrightnessAndContrast(ProcedetImage, this.Modification.Brightness, this.Modification.Contrast);

            // Proced palette modifications
            switch (this.Modification.Palette)
            {
                case Modify.Palette.ColorPalette.Color:
                    break;
                case Modify.Palette.ColorPalette.Grayscale:
                    ProcedetImage = Modify.Palette.ToGrayscale(ProcedetImage);
                    break;
                case Modify.Palette.ColorPalette.BlackWhite:
                    ProcedetImage = Modify.Palette.ToBlackWhite(ProcedetImage, this.Modification.Threshold);
                    break;
                default:
                    break;
            }

            // Proced rotate modifications
            for (int i = 0; i < this.Modification.RotateLeft; i++) ProcedetImage = Modify.Rotate90Left(ProcedetImage);
            for (int i = 0; i < this.Modification.RotateRight; i++) ProcedetImage = Modify.Rotate90Right(ProcedetImage);

            return ProcedetImage;
        }

        /// <summary>
        /// Try to reduce the length, if an image is attached
        /// </summary>
        public void ReduceImageLength()
        {
            if (this.Image == null) return;
            //Reduce image length (Best results to do it this way. Looks a little strange.)
            File.ImageModification TempModification = new File.ImageModification(Modify.Palette.ColorPalette.Color)
            {
                RotateLeft = 1,
                RotateRight = 1
            };
            this.Modification = TempModification;
            this.LoadFile(this.ImageProcedet);
            this.Modification = null;
        }

        /// <summary>
        /// The the file to an picture box, if it is an image, set the image. If not, set an default image.
        /// </summary>
        /// <param name="pictureBox">PictureBox to set the file to</param>
        public void SetToPictureBox(PictureBox pictureBox)
        {
            if (this.Source == File.FileSource.Link && new System.IO.FileInfo(this.LinkPath).Exists)
            {
                //File is an linkes file
                try
                {
                    pictureBox.Image = Image.FromFile(this.LinkPath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    _ = ex;
                    pictureBox.Image = Resources.GenericDocument;
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            else if (this.Image == null && string.IsNullOrEmpty(this.FileBase64))
            {
                //No data attached to file
                pictureBox.Image = Resources.NoDocument;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else if (this.Image != null)
            {
                //File is an image
                pictureBox.Image = this.ImageProcedet;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                //File is an generic document
                pictureBox.Image = Resources.GenericDocument;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        /// <summary>
        /// Toggle FileChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        private void ToggleFileChanged(object sender, EventArgs e)
        {
            if (this.FileChanged != null) FileChanged(sender, e);
        }

        /// <summary>
        /// Converts the File object to an XElement object
        /// </summary>
        /// <returns>File data as XElement</returns>
        public XElement ToXElement()
        {
            XElement FileRoot = new XElement("FileItem");

            FileRoot.Add(new XElement("Id", this.Id));
            FileRoot.Add(new XElement("ColorPalette", (int)this._colorPalette));
            FileRoot.Add(new XElement("Comment", this._comment));
            FileRoot.Add(new XElement("LinkPath", this.LinkPath));
            FileRoot.Add(new XElement("OriginalFileName", this.OriginalFileName));
            FileRoot.Add(new XElement("Source", (int)this.Source));
            FileRoot.Add(new XElement("StreamBase64", this._fileBase64));
            FileRoot.Add(new XElement("Title", this._title));

            return FileRoot;
        }
        #endregion

        #region SubClasses
        /// <summary>
        /// Store informations how an image should been modified, if changes will be appleyed
        /// </summary>
        public class ImageModification
        {
            /// <summary>
            /// Get or set how the Brightness should been changed
            /// </summary>
            public int Brightness { get; set; } = 0;

            /// <summary>
            /// Get or set how the Contrast should been changed
            /// </summary>
            public int Contrast { get; set; } = 0;

            /// <summary>
            /// Get or set if the Palette should been changed
            /// </summary>
            public Modify.Palette.ColorPalette Palette { get; set; } = (Modify.Palette.ColorPalette)Settings.Default.Scan_DefaultColorMode;

            /// <summary>
            /// Get or set the factor to resiza the image
            /// </summary>
            public decimal ResizeFactor { get; set; } = 100;

            /// <summary>
            /// Get or set the number of times to turn the image to the left
            /// </summary>
            public int RotateLeft { get; set; } = 0;

            /// <summary>
            /// Get or set the number of times to turn the image to the right
            /// </summary>
            public int RotateRight { get; set; } = 0;

            /// <summary>
            /// Get or set the Threshold if an image shold been converted to an Black and White Palette
            /// </summary>
            public int Threshold { get; set; } = Settings.Default.Scan_DefaultThreshold;

            public ImageModification(Modify.Palette.ColorPalette initialPalette)
            {
                this.Palette = initialPalette;
            }

            /// <summary>
            /// Check if an attached image is modified or if no modification is set
            /// </summary>
            /// <param name="originalImagePalette">The original palette of the image</param>
            /// <returns>True, if a modification is set for the image</returns>
            public bool IsModified(Modify.Palette.ColorPalette? originalImagePalette)
            {
                if (originalImagePalette == null) originalImagePalette = (Modify.Palette.ColorPalette)Settings.Default.Scan_DefaultColorMode;

                ImageModification Ref = new ImageModification((Modify.Palette.ColorPalette)originalImagePalette);
                if (this.Brightness != Ref.Brightness) return true;
                if (this.Contrast != Ref.Contrast) return true;
                if (this.Palette != Ref.Palette) return true;
                if (this.ResizeFactor != Ref.ResizeFactor) return true;
                if (this.RotateLeft != Ref.RotateLeft) return true;
                if (this.RotateRight != Ref.RotateRight) return true;
                if (this.Threshold != Ref.Threshold && this.Palette == Modify.Palette.ColorPalette.BlackWhite) return true;

                return false;
            }
        }
        #endregion
    }
}