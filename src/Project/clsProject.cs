/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains the bill manage project
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
using OLKI.Programme.QuiAbl.src.Forms;
using OLKI.Programme.QuiAbl.src.Forms.MainForm;
using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using OLKI.Toolbox.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OLKI.Programme.QuiAbl.src.Project
{
    /// <summary>
    /// Class that contains the bill manage project
    /// </summary>
    public class Project
    {
        #region Constants
        /// <summary>
        /// Extension for the temporary file, while savein a project to a file
        /// </summary>
        private const string TEMP_FILE_EXTENSION = ".~";
        /// <summary>
        /// The max lengt of the read buffer, to write to a file
        /// </summary>
        private const int WRITE_DATA_BUFFER_LENGTH = 1024;
        #endregion

        #region Events
        /// <summary>
        /// Thrown if the project was changed, settings or data
        /// </summary>
        internal event EventHandler ProjectChanged;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set a list with all bill classes
        /// </summary>
        public Dictionary<int, BillClass> BillClasses { get; set; } = new Dictionary<int, BillClass> { };
        /// <summary>
        /// Get or set the Id of the last added bill class
        /// </summary>
        public int BillClassLastInsertedId { get; set; } = 0;

        /// <summary>
        /// Get or set a list with all bills
        /// </summary>
        public Dictionary<int, Bill.Bill> Bills { get; set; } = new Dictionary<int, Bill.Bill> { };
        /// <summary>
        /// Get or set the Id of the last added bill
        /// </summary>
        public int BillsLastInsertedId { get; set; } = 0;

        /// <summary>
        /// True if the project was changed, settings or data, and the was not saved since this time
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set the change state of the project. True if the project was changed, settings or data, and the was not saved since this time. If setting it to true will raise the ProjectChanged__Event event
        /// </summary>
        public bool Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
                this.ToggleProjectChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Get or set a list with all companies
        /// </summary>
        public Dictionary<int, Company> Companies { get; set; } = new Dictionary<int, Company> { };

        /// <summary>
        /// Get or set the Id of the last added company
        /// </summary>
        public int CompanyLastInsertedId { get; set; } = 0;

        /// <summary>
        /// Get the file of the active project or null if the project did not have a file
        /// </summary>
        internal FileInfo File { get; set; } = null;

        /// <summary>
        /// Get the title of the project. That's the file name or an default text, if the project hasn't a file
        /// </summary>
        internal string ProjectTitle
        {
            get
            {
                return this.File != null ? this.File.Name : Stringtable._0x000B;
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Initialise a new project
        /// </summary>
        /// <param name="path">A string that specifies the path of the project file. If it is an empty project withoud file give an empth string</param>
        internal Project(string path)
        {
            if (!string.IsNullOrEmpty(path)) this.File = new FileInfo(path);
        }

        /// <summary>
        /// Toggle ProjectChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        public void ToggleProjectChanged(object sender, EventArgs e)
        {
            if (this.ProjectChanged != null) ProjectChanged(sender, e);
        }

        /// <summary>
        /// Set Changed to true and call ToggleProjectChanged
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        internal void ToggleSubItemChanged(object sender, EventArgs e)
        {
            this._changed = true;
            this.ToggleProjectChanged(sender, e);
        }

        #region SaveProject
        /// <summary>
        /// Get the max length for the file read buffer, to avoid buffer overflows
        /// </summary>
        /// <param name="dataBufferLength">The length of the full data buffer</param>
        /// <param name="readStart">The actual rad position</param>
        /// <param name="maxBufferLength">Maximum allowed buffer length</param>
        /// <returns>The maximum allowed read buffer length</returns>
        private int GetValidBufferReadLength(int dataBufferLength, int readStart, int maxBufferLength)
        {
            if ((readStart * maxBufferLength + maxBufferLength) > dataBufferLength)
            {
                return maxBufferLength - (readStart * maxBufferLength + maxBufferLength - dataBufferLength);
            }
            return maxBufferLength;
        }

        /// <summary>
        /// Save the active project to the project file or call Project_SaveAs if the project has no file
        /// </summary>
        /// <param name="mainForm">Application MainForm</param>
        /// <param name="worker">The BackgroundWorker to save the project asynchronous</param>
        /// <param name="e">BackgroundWorker DoWorkEventArgs to save the project asynchronous</param>
        /// <returns>True if save of the active project was sucessfull an withoud exceptions</returns>
        internal bool Project_Save(MainForm mainForm, BackgroundWorker worker, DoWorkEventArgs e)
        {
            // Save the actual project file info
            // If an exception occurs the old fileinfo will be restored
            FileInfo ProjectPathBackup = this.File;
            try
            {
                // If there is no project file, call Project_SaveAs() and continue saving by recalling tis function in Project_SaveAs()
                if (this.File == null || string.IsNullOrEmpty(this.File.FullName) || !this.File.Exists)
                {
                    // Nothing to do, beccause no file was specified to save to
                    // Otherwise the Project_SaveAs function will call this function again 
                    if (!this.Project_SaveAs(mainForm, worker, e)) return false;
                }
                else
                {
                    SaveProjectsState State = new SaveProjectsState(null, false)
                    {
                        ProgressDescirption = Stringtable._0x0013,
                        ProjectFile = this.File.FullName
                    };
                    worker?.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());

                    // Write data
                    string Header = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                    char[] Content = this.ToXElement().ToString().ToCharArray();
                    string TempFileName = this.File.FullName + TEMP_FILE_EXTENSION;
                    using (StreamWriter StreamWriter = new StreamWriter(System.IO.File.Open(TempFileName, FileMode.Create), Encoding.UTF8))
                    {
                        StreamWriter.WriteLine(Header);
                        State.ProgressDescirption = Stringtable._0x0014;

                        int ReadLength;
                        int Limit = (int)Math.Ceiling((decimal)Content.Length / (decimal)WRITE_DATA_BUFFER_LENGTH);
                        for (int i = 0; i < Limit; i++)
                        {
                            ReadLength = this.GetValidBufferReadLength(Content.Length, i, WRITE_DATA_BUFFER_LENGTH);
                            StreamWriter.Write(Content, i * WRITE_DATA_BUFFER_LENGTH, ReadLength);
                            worker?.ReportProgress((int)Matehmatics.Percentages(i + 1, Limit), State.Clone());
                        }
                    }

                    //Move temp file to destination file
                    if (this.File.Exists) this.File.Delete();
                    System.IO.File.Move(TempFileName, this.File.FullName);
                    State.ProgressDescirption = Stringtable._0x001C;
                    worker?.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());

                    return true;
                }
                return false;  // Nothing to do, beccause no file was specified to save to
            }
            catch (Exception ex)
            {
                mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(string.Format(Stringtable._0x0004m, new object[] { this.File.FullName, ex.Message }), Stringtable._0x0004c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                this.File = ProjectPathBackup;
                return false;
            }
        }

        /// <summary>
        /// Save the active project to a new file, specified in a SaveAs dialog
        /// </summary>
        /// <param name="mainForm">Application MainForm</param>
        /// <param name="worker">The BackgroundWorker to save the project asynchronous</param>
        /// <param name="e">BackgroundWorker DoWorkEventArgs to save the project asynchronous</param>
        /// <returns>True if save of the active project was sucessfull an withoud exceptions</returns>
        public bool Project_SaveAs(MainForm mainForm, BackgroundWorker worker, DoWorkEventArgs e)
        {
            string NewFilePath = string.Empty;
            try
            {
                SaveFileDialog SaveFileDialog = new SaveFileDialog()
                {
                    DefaultExt = Settings_AppConst.Default.ProjectFile_DefaultExtension,
                    Filter = Settings_AppConst.Default.ProjectFile_FilterList,
                    FilterIndex = Settings_AppConst.Default.ProjectFile_FilterIndex,
                    InitialDirectory = Settings.Default.DirectoryFile_DefaultPath
                };
                DialogResult DialogResult = (DialogResult)mainForm.Invoke((Func<DialogResult>)(() => SaveFileDialog.ShowDialog()));
                if (DialogResult == DialogResult.OK)
                {
                    using (FileStream fswrite = new FileStream(SaveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None, 1))
                    {
                        // Create an new, empty file. Content will be written in Project_Save
                    }
                    this.File = new FileInfo(SaveFileDialog.FileName);
                    return this.Project_Save(mainForm, worker, e);
                }
                else
                {
                    if (worker != null)
                    {
                        e.Cancel = true;
                        worker.CancelAsync();
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (worker != null)
                {
                    e.Cancel = true;
                    worker.CancelAsync();
                }
                mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(string.Format(Stringtable._0x0004m, new object[] { NewFilePath, ex.Message }), Stringtable._0x0004c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                return false;
            }
        }
        #endregion

        #region Read and create XML-Object
        /// <summary>
        /// Converts the project with all data and settings to an XML formated string
        /// </summary>
        /// <returns>An XML-format string that represents the project content</returns>
        internal XElement ToXElement()
        {
            XElement ProjectRoot = new XElement("QuiAbl_ProjectData");
            ProjectRoot.Add(new XAttribute("Version", Settings_AppConst.Default.ProjectFile_Version_Actual));

            //Create BillList
            XElement BillList = new XElement("BillList");
            BillList.Add(new XAttribute("LastInsertedId", this.BillsLastInsertedId));
            foreach (KeyValuePair<int, Bill.Bill> BillItem in this.Bills.OrderBy(o => o.Value.Id))
            {
                BillList.Add(BillItem.Value.ToXElement());
            }
            ProjectRoot.Add(BillList);

            //Create CompanyList
            XElement CompanyList = new XElement("CompanyList");
            CompanyList.Add(new XAttribute("LastInsertedId", this.CompanyLastInsertedId));
            foreach (KeyValuePair<int, Company> CompanyItem in this.Companies.OrderBy(o => o.Value.Id))
            {
                CompanyList.Add(CompanyItem.Value.ToXElement());
            }
            ProjectRoot.Add(CompanyList);

            //Create BillClassList
            XElement BillClassList = new XElement("BillClassList");
            BillClassList.Add(new XAttribute("LastInsertedId", this.BillClassLastInsertedId));
            foreach (KeyValuePair<int, BillClass> BillClassItem in this.BillClasses.OrderBy(o => o.Value.Id))
            {
                BillClassList.Add(BillClassItem.Value.ToXElement());
            }
            ProjectRoot.Add(BillClassList);

            return ProjectRoot;
        }

        #region FromXElement
        /// <summary>
        /// Check if the file to open is compatible or compatible after conwerted, with this application
        /// </summary>
        /// <param name="FileVersion">Version of the file to check</param>
        /// <returns>True if file is compatible or converted, otherwise false</returns>
        private bool CheckFileVersion(string FileVersion, MainForm mainForm)
        {
            // Create list with file Versions
            // Highest Version ist file version, lower versions are for compability with older versions
            List<string> FileVersionList = FileVersion.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            // Full Compatible fileversions
            List<string> FullCompatibleVersionList = Settings_AppConst.Default.ProjectFile_VersionCompatibleNative.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (FileVersionList.Intersect(FullCompatibleVersionList).Count() > 0)
            {
                return true;    // Full Compatible Return true
            }

            // Fileversions they are compatible if the file would been converted
            List<string> ConvCompatibleVersionList = Settings_AppConst.Default.ProjectFile_VersionCompatibleConvert.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (FileVersionList.Intersect(ConvCompatibleVersionList).Count() > 0)
            {
                //TODO: ADD CODE --> in future version to convert if necessary 
                return true;    // Compatible if converted
            }

            // Not Compatible file, return false
            mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(Stringtable._0x0001m, Stringtable._0x0001c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
            return false;
        }

        /// <summary>
        /// Set all project data from an specified XML formated string
        /// </summary>
        /// <param name="inputProject">Specifies an XML format string which represents the project</param>
        internal bool FromXElement(string inputProject, BackgroundWorker worker, LoadProjectState state, Forms.MainForm.MainForm mainForm)
        {
            return this.FromXElement(XElement.Parse(inputProject), worker, state, mainForm);
        }
        /// <summary>
        /// Set all project data from an specified XElement which parsed an XML formated string
        /// </summary>
        /// <param name="inputProject">Specifies XElement XElement which parsed an XML formated string which represents the project</param>
        internal bool FromXElement(XElement inputProject, BackgroundWorker worker, LoadProjectState state, Forms.MainForm.MainForm mainForm)
        {
            try
            {
                state.ProgressDescirption = Stringtable._0x000D;
                worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, state.Clone());
                //Check Fileversion
                if (!this.CheckFileVersion(Serialize.GetFromXElementAttribute(inputProject, "Version", ""), mainForm)) return false;

                //Read Bills
                state.ProgressDescirption = Stringtable._0x000D;
                worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, state.Clone());
                this.Bills.Clear();
                this.BillsLastInsertedId = Serialize.GetFromXElementAttribute(inputProject, "BillList", "LastInsertedId", this.BillsLastInsertedId);
                XElement BillList = Serialize.GetFromXElement(inputProject, "BillList", new XElement("BillList"));
                if (BillList != null)
                {
                    int i = 0;
                    foreach (XElement BillItem in BillList.Elements("BillItem"))
                    {
                        Bill.Bill NewBill = new Bill.Bill(BillItem, this.BillClasses, this.Companies);
                        NewBill.BillChanged += new EventHandler(this.ToggleSubItemChanged);
                        this.Bills.Add(NewBill.Id, NewBill);

                        i++;
                        worker.ReportProgress((int)Matehmatics.Percentages(i, BillList.Elements("BillItem").Count(), 0), state.Clone());
                    }
                }

                //Read Bill Classes
                state.ProgressDescirption = Stringtable._0x000F;
                worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, state.Clone());
                this.BillClasses.Clear();
                this.BillClassLastInsertedId = Serialize.GetFromXElementAttribute(inputProject, "BillClassList", "LastInsertedId", this.BillClassLastInsertedId);
                XElement BillClassList = Serialize.GetFromXElement(inputProject, "BillClassList", new XElement("BillClassList"));
                if (BillClassList != null)
                {
                    foreach (XElement BillClassItem in BillClassList.Elements("BillClassItem"))
                    {
                        BillClass NewBillClass = new BillClass(BillClassItem);
                        NewBillClass.BillClassChanged += new EventHandler(this.ToggleSubItemChanged);
                        this.BillClasses.Add(NewBillClass.Id, NewBillClass);
                    }
                }

                //Read Companies
                state.ProgressDescirption = Stringtable._0x0010;
                worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, state.Clone());
                this.Companies.Clear();
                this.CompanyLastInsertedId = Serialize.GetFromXElementAttribute(inputProject, "CompanyList", "LastInsertedId", this.CompanyLastInsertedId);
                XElement CompanyList = Serialize.GetFromXElement(inputProject, "CompanyList", new XElement("CompanyList"));
                if (CompanyList != null)
                {
                    foreach (XElement CompanyItem in CompanyList.Elements("CompanyItem"))
                    {
                        Company NewCompany = new Company(CompanyItem);
                        NewCompany.CompanyChanged += new EventHandler(this.ToggleSubItemChanged);
                        this.Companies.Add(NewCompany.Id, NewCompany);
                    }
                }
                this._changed = false;
                return true;
            }
            catch (Exception ex)
            {
                mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(string.Format(Stringtable._0x0005m, new object[] { ex.Message }), Stringtable._0x0005c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                return false;
            }
        }
        #endregion
        #endregion
        #endregion
    }
}