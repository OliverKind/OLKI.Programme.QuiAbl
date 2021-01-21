/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * The MainForm of the application
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
using OLKI.Programme.QuiAbl.src.Forms.Bills;
using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using OLKI.Tools.CommonTools;
using System;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    /// <summary>
    /// The MainForm of the application
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// Application start up arguments
        /// </summary>
        private readonly string[] _args;

        /// <summary>
        /// Schould close form be foreced
        /// </summary>
        private bool _appClose = false;

        /// <summary>
        /// Specifies the application about form
        /// </summary>
        private readonly SubForms.AboutForm _frmAbout = new SubForms.AboutForm();

        /// <summary>
        /// Specifies the application settings form
        /// </summary>
        private SubForms.ApplicationSettingsForm _frmApplicationSettings;

        /// <summary>
        /// Specifies the progress form
        /// </summary>
        ProgressForm _progressForm;

        /// <summary>
        /// Specifies the projectmanager object
        /// </summary>
        private readonly ProjectManager _projectManager;

        /// <summary>
        /// Specifies the recent files object
        /// </summary>
        private readonly RecentFiles _recentFiles = new RecentFiles();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new application MainForm
        /// </summary>
        /// <param name="args">Application start up arguments</param>
        internal MainForm(string[] args)
        {
            InitializeComponent();
            this.MainForm_MdiChildActivate(this, new EventArgs());
            this._args = args;
            this.Text = string.Format(this.Text, new object[] { ProductName });

            // Inital ProjectManager
            this._projectManager = new ProjectManager(this);
            this._projectManager.ActiveProjecChanged += new EventHandler(this.ProjectManager_ProjectChanged);
            this._projectManager.ProjecOpenOrNew += new EventHandler(this.ProjectManager_ProjecOpenOrNew);

            this.Initial_bgwExitApp();
            this.Initial_bgwLoadFile();
            this.Initial_bgwSaveFile();
            this.Initial_bgwStartupLoadFile();
        }

        /// <summary>
        /// Close the application MainForm
        /// </summary>
        /// <param name="appClose">Set that the application is closing</param>
        private void Close(bool appClose)
        {
            this._appClose = appClose;
            this.Close();
        }

        /// <summary>
        /// Load the project on application startup. In the priority from args, from default settings, empy project
        /// </summary>
        /// <param name="args">Application start up arguments</param>
        private void LoadInitialProject(string[] args)
        {
            if (!this._bgwLoadFilesAtStartup.IsBusy) this._bgwLoadFilesAtStartup.RunWorkerAsync(args);
        }

        #region Form Events
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._appClose)
            {
                e.Cancel = false;
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
                if (!this._bgwExitApp.IsBusy) this._bgwExitApp.RunWorkerAsync();
            }
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            Form ActiveMdiChild = this.ActiveMdiChild;
            if (ActiveMdiChild != null)
            {
                this.mnuMain_File_Close.Enabled = true;
                this.mnuMain_File_Save.Enabled = true;
                this.mnuMain_File_SaveAs.Enabled = true;
                this.tolMain_Basedata_BillClass.Enabled = true;
                this.tolMain_Basedata_Company.Enabled = true;
                this.tolMain_File_Save.Enabled = true;
            }
            else
            {
                this.mnuMain_File_Close.Enabled = false;
                this.mnuMain_File_Save.Enabled = false;
                this.mnuMain_File_SaveAs.Enabled = false;
                this.tolMain_Basedata_BillClass.Enabled = false;
                this.tolMain_Basedata_Company.Enabled = false;
                this.tolMain_File_Save.Enabled = false;
            }
        }

        public void MainForm_MdiChildRequestClose(object sender, EventArgs e)
        {
            ProjectForm ProjectForm = (ProjectForm)sender;

            if (ProjectForm.Project.Changed)
            {
                DialogResult CloseDialogResult = MessageBox.Show(string.Format(Stringtable._0x0015m, new object[] { ProjectForm.Project.File != null ? ProjectForm.Project.File.Name : "" }), Stringtable._0x0015c, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                switch (CloseDialogResult)
                {
                    case DialogResult.Yes:
                        if (!this._bgwSaveFile.IsBusy) this._bgwSaveFile.RunWorkerAsync(new SaveProjectsArguments(SaveProjectsArguments.SaveMode.Save, ProjectForm, true));
                        return;
                    case DialogResult.No:
                        ProjectForm.Close(true);
                        return;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                ProjectForm.Close(true);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Initial project on startup
            this.LoadInitialProject(this._args);

            //Check for file association
            if (Settings.Default.FileAssociation_CheckOnStartup) Program.CheckFileAssociationAndSet(true);
        }
        #endregion

        #region Menue and Toolstrip Events
        private void mnuMain_File_New_Click(object sender, EventArgs e)
        {
            this._projectManager.Project_New(null);

            //Load project form
            if (this._projectManager.ActiveProject != null)
            {
                ProjectForm ProjectForm = new ProjectForm(this._projectManager.ActiveProject)
                {
                    MdiParent = this
                };
                ProjectForm.Show();
                ProjectForm.RequestClose += new EventHandler(this.MainForm_MdiChildRequestClose);
            }

            // Raise Events to inital form
            this.ProjectManager_ProjectFileChanged(this, new EventArgs());
        }

        private void mnuMain_File_Open_Click(object sender, EventArgs e)
        {
            if (!this._bgwLoadFile.IsBusy)
            {
                this._bgwLoadFile.RunWorkerAsync();
            }
        }

        private void mnuMain_File_Close_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.Close();
        }

        private void mnuMain_File_Save_Click(object sender, EventArgs e)
        {
            if (!this._bgwSaveFile.IsBusy)
            {
                this._bgwSaveFile.RunWorkerAsync(new SaveProjectsArguments(SaveProjectsArguments.SaveMode.Save, null, false));
            }
        }

        private void mnuMain_File_SaveAs_Click(object sender, EventArgs e)
        {
            if (!this._bgwSaveFile.IsBusy) this._bgwSaveFile.RunWorkerAsync(SaveProjectsArguments.SaveMode.SaveAs);
        }

        private void mnuMain_File_Exit_Click(object sender, EventArgs e)
        {
            if (!this._bgwExitApp.IsBusy) this._bgwExitApp.RunWorkerAsync();
        }

        private void mnuMain_Extras_Options_Click(object sender, EventArgs e)
        {
            this._frmApplicationSettings = new SubForms.ApplicationSettingsForm();
            if (this._frmApplicationSettings.ShowDialog(this) == DialogResult.OK)
            {
                foreach (Form MdiChield in this.MdiChildren)
                {
                    ((ProjectForm)MdiChield).UpdateAllListviewItems();
                }

                if (this._frmApplicationSettings.ClearRecentFiles) this._recentFiles.FileList.Clear();
            }
        }

        private void mnuMain_Window_Cascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuMain_Window_Horizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuMain_Window_Vertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuMain_Window_Statusbar_Click(object sender, EventArgs e)
        {
            this.stsStatus.Visible = this.mnuMain_Window_Statusbar.Checked;
        }

        private void mnuMain_File_Help_Info_Click(object sender, EventArgs e)
        {
            this._frmAbout.ShowDialog(this);
        }

        private void tolMain_Basedata_BillClass_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) ((ProjectForm)this.ActiveMdiChild).mnuBillsForm_Basedata_BillClass_Click(sender, e);
        }

        private void tolMain_Basedata_Company_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) ((ProjectForm)this.ActiveMdiChild).mnuBillsForm_Basedata_Company_Click(sender, e);
        }

        private void tolMain_File_New_Click(object sender, EventArgs e)
        {
            this.mnuMain_File_New_Click(sender, e);
        }

        private void tolMain_File_Open_Click(object sender, EventArgs e)
        {
            this.mnuMain_File_Open_Click(sender, e);
        }

        private void tolMain_File_Save_Click(object sender, EventArgs e)
        {
            this.mnuMain_File_Save_Click(sender, e);
        }
        #endregion

        #region Projec Events
        private void ProjectManager_ProjectChanged(object sender, EventArgs e)
        {
            this.ProjectManager_ProjectFileChanged(sender, e);
        }

        private void ProjectManager_ProjectFileChanged(object sender, EventArgs e)
        {
            //Nothing to do at this application
        }

        private void ProjectManager_ProjecOpenOrNew(object sender, EventArgs e)
        {
            //Nothing to do at this application
        }
        #endregion
        #endregion
    }
}