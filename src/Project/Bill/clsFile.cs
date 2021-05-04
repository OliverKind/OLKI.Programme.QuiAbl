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
                if (this.Modification == null || this.Image == null)
                {
                    return this.Image;
                }
                else
                {
                    return this.ProceedModifications();
                }
            }
        }

        /// <summary>
        /// Get or set modifications to store. Modifications will be done, if proceed method is called
        /// </summary>
        [Browsable(false)]
        public ImageModification Modification { get; set; }

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
                this._title = value;
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
            this.FromFromXElementML(inputFile);
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

                this.Image = Toolbox.ColorAndPicture.Picture.Modify.Crop(this.Image, cropArea);
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
        public void FromFromXElementML(XElement inputFile)
        {
            this.Id = Serialize.GetFromXElement(inputFile, "Id", 0);
            this._comment = Serialize.GetFromXElement(inputFile, "Comment", "");
            this._fileBase64 = Serialize.GetFromXElement(inputFile, "StreamBase64", "");
            this.OriginalFileName = Serialize.GetFromXElement(inputFile, "OriginalFileName", "");
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
                    Filter = string.Format("(*.{0}) | *.{0}", new object[] { Extension })
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
                System.IO.File.WriteAllBytes(FileToOpen, Convert.FromBase64String(this._fileBase64));

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

            // Proced brightness and contrast modifications
            ProcedetImage = Toolbox.ColorAndPicture.Picture.Modify.BrightnessAndContrast(ProcedetImage, this.Modification.Brightness, this.Modification.Contrast);

            // Proced palette modifications
            switch (this.Modification.Palette)
            {
                case Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette.Color:
                    break;
                case Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette.Grayscale:
                    ProcedetImage = Toolbox.ColorAndPicture.Picture.Modify.Palette.ToGrayscale(ProcedetImage);
                    break;
                case Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette.BlackWhite:
                    ProcedetImage = Toolbox.ColorAndPicture.Picture.Modify.Palette.ToBlackWhite(ProcedetImage, this.Modification.Threshold);
                    break;
                default:
                    break;
            }
            return ProcedetImage;
        }

        /// <summary>
        /// The the file to an picture box, if it is an image, set the image. If not, set an default image.
        /// </summary>
        /// <param name="pictureBox">PictureBox to set the file to</param>
        public void SetToPictureBox(PictureBox pictureBox)
        {
            if (this.Image != null)
            {
                pictureBox.Image = this.ImageProcedet;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
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
            FileRoot.Add(new XElement("Comment", this._comment));
            FileRoot.Add(new XElement("StreamBase64", this._fileBase64));
            FileRoot.Add(new XElement("OriginalFileName", this.OriginalFileName));
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
            /// Get or set ow the Palette should been changed
            /// </summary>
            public Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette Palette { get; set; } = Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette.Color;

            /// <summary>
            /// Get or set the Threshold if an image shold been converted to an Black and White Palette
            /// </summary>
            public int Threshold { get; set; } = 127;
        }
        #endregion
    }
}