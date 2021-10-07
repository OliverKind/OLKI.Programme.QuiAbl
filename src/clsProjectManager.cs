/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that provide tools to manage the projects
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
using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src
{
    /// <summary>
    /// Class that provide tools to manage the project
    /// </summary>
    internal class ProjectManager
    {
        #region Events
        /// <summary>
        /// Occurs if the active project was changed, settings or data
        /// </summary>
        internal event EventHandler ActiveProjecChanged;
        /// <summary>
        /// Occurs if a project was open from file or a new project was created
        /// </summary>
        internal event EventHandler ProjecOpenOrNew;
        #endregion

        #region Fields
        /// <summary>
        /// The application MainForm
        /// </summary>
        private readonly Forms.MainForm.MainForm _mainForm;
        #endregion

        #region Properties
        /// <summary>
        /// Get the active project
        /// </summary>
        internal Project.Project ActiveProject { get; private set; } = null;
        #endregion

        #region Methodes
        /// <summary>
        /// Initialise a new ProjectManager
        /// </summary>
        internal ProjectManager(Forms.MainForm.MainForm mainForm)
        {
            this._mainForm = mainForm;
        }

        /// <summary>
        /// Check if the selected file is already opend
        /// </summary>
        /// <param name="file">File to check if it is opend</param>
        /// <returns>True if the file is opend, otherwiese false</returns>
        private bool CheckFileIsOpen(string file)
        {
            foreach (Form Form in this._mainForm.MdiChildren)
            {
                Forms.Bills.ProjectForm ProjectForm = ((Forms.Bills.ProjectForm)Form);
                if (ProjectForm.Project.File != null && ProjectForm.Project.File.FullName == file) return true;
            }
            return false;
        }

        /// <summary>
        /// Check if there are unsaved changes in active project and ask if the sould been saved.
        /// </summary>
        /// <returns>True if the active project should been overwritten</returns>
        internal bool GetSaveActiveProject()
        {
            if (this.ActiveProject.Changed)
            {
                if (MessageBox.Show(Stringtable._0x0002m, Stringtable._0x0002c, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates a new, empty project
        /// </summary>
        /// <returns>True if a new project was created withoud exceptions</returns>
        internal bool Project_New(BackgroundWorker worker)
        {
            return this.Project_Open("", true, worker);
        }

        /// <summary>
        /// Open a new project with showing the file open dialog
        /// </summary>
        internal bool Project_Open(BackgroundWorker worker)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog()
            {
                DefaultExt = Settings.Default.ProjectFile_DefaultExtension,
                Filter = Settings.Default.ProjectFile_FilterList,
                FilterIndex = Settings.Default.ProjectFile_FilterIndex,
                InitialDirectory = Settings.Default.ProjectFile_DefaultPath
            };

            DialogResult DialogResult = (DialogResult)this._mainForm.Invoke((Func<DialogResult>)(() => OpenFileDialog.ShowDialog()));
            if (DialogResult == DialogResult.OK)
            {
                return this.Project_Open(OpenFileDialog.FileName, worker);
            }
            return false;
        }

        /// <summary>
        /// Open a new specified project with the specified file or shows the file open dialog file file path ist empth
        /// </summary>
        /// <param name="path">A string that specifies the path of the project file to open</param>
        internal bool Project_Open(string path, BackgroundWorker worker)
        {
            return this.Project_Open(path, false, worker);
        }

        /// <summary>
        /// Open a new specified project with the specified file or shows the file open dialog file file path ist empth
        /// </summary>
        /// <param name="path">A string that specifies the path of the project file to open</param>
        /// <param name="newProject">Specifies that the project to open is a new project and no file path is specified</param>
        private bool Project_Open(string path, bool newProject, BackgroundWorker worker)
        {
            try
            {
                Project.Project NewProject = new Project.Project(path);
                LoadProjectState State = new LoadProjectState
                {
                    ProjectData = null,
                    ProgressDescirption = Stringtable._0x000C,
                    ProjectFile = path
                };

                // If it ist not an new project that should been loaded, ask for file to open or open the file if path is given
                if (!newProject)
                {
                    if (string.IsNullOrEmpty(path))
                    {
                        return this.Project_Open(worker);  // Recursive to Project_Open to show the OpenFileDialog
                    }
                    else
                    {
                        if (this.CheckFileIsOpen(path))
                        {
                            this._mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(Stringtable._0x0012m, Stringtable._0x0012c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                            return false;
                        }
                        worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());
                        if (!NewProject.FromXElement(File.ReadAllText(path), worker, State, this._mainForm)) return false;
                    }
                }

                //Final root project to application
                State.ProjectData = NewProject;
                State.ProgressDescirption = Stringtable._0x0011;
                if (worker != null) worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());
                this.ActiveProject = NewProject;
                this.ActiveProject.ProjectChanged += new EventHandler(this.ToggleActiveProjecChanged);

                this.ProjecOpenOrNew?.Invoke(this, new EventArgs());
                return true;
            }
            catch (Exception ex)
            {
                this._mainForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(string.Format(Stringtable._0x0003m, new object[] { path, ex.Message }), Stringtable._0x0003c, MessageBoxButtons.OK, MessageBoxIcon.Error)));
                return false;
            }
        }

        /// <summary>
        /// Event handler for an change event in active project and release the ActiveProjecChanged__Event
        /// </summary>
        internal void ToggleActiveProjecChanged(object sender, EventArgs e)
        {
            if (this.ActiveProjecChanged != null) ActiveProjecChanged(sender, e);
        }
        #endregion
    }
}