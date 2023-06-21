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
using OLKI.Toolbox.Common;
using OLKI.Toolbox.Widgets.AboutForm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

        /// <summary>
        /// Original design text for the Statusstrip BillClasses Label
        /// </summary>
        private readonly string _tslBillC_OrgText;

        /// <summary>
        /// Original design text for the Statusstrip Bills Label
        /// </summary>
        private readonly string _tslBills_OrgText;

        /// <summary>
        /// Original design text for the Statusstrip Companies Label
        /// </summary>        
        private readonly string _tslCompa_OrgText;

        /// <summary>
        /// Original design text for the Statusstrip Files Label
        /// </summary>
        private readonly string _tslFiles_OrgText;

        /// <summary>
        /// Original design text for the Statusstrip ProjectFile Label
        /// </summary>
        private readonly string _tslProFi_OrgText;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new application MainForm
        /// </summary>
        /// <param name="args">Application start up arguments</param>
        internal MainForm(string[] args)
        {
            InitializeComponent();
            this._tslBillC_OrgText = this.tslBillC.Text;
            this._tslBills_OrgText = this.tslBills.Text;
            this._tslCompa_OrgText = this.tslCompa.Text;
            this._tslFiles_OrgText = this.tslFiles.Text;
            this._tslProFi_OrgText = this.tslProFi.Text;

            this.SetStatusstripLabels(this.ActiveMdiChild);

            if (Settings_AppVar.Default.MainForm_State != FormWindowState.Minimized) this.WindowState = (FormWindowState)Settings_AppVar.Default.MainForm_State;
            if (Settings_AppVar.Default.MainForm_State == FormWindowState.Normal) this.Size = Settings_AppVar.Default.MainForm_Size;

            this.MainForm_MdiChildActivate(this, new EventArgs());
            this._args = args;
            this.Text = string.Format(this.Text, new object[] { ProductName });

            // Inital ProjectManager
            this._projectManager = new ProjectManager(this);
            this._projectManager.ActiveProjecChanged += new EventHandler(this.ProjectManager_ProjectChanged);
            this._projectManager.ProjecOpenOrNew += new EventHandler(this.ProjectManager_ProjecOpenOrNew);

            // Initial rectent files
            this._recentFiles.MaxLength = Settings.Default.RecentFiles_MaxLength;
            this._recentFiles.Seperator = Settings_AppConst.Default.RecentFiles_Seperator;
            this._recentFiles.SetFromString(Settings_AppVar.Default.RecentFiles_FileList);
            //this.SetRecentFilesSettingsAndMenue(); --> Raisid while loading inital projects

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

        /// <summary>
        /// Open a project from recent file list
        /// </summary>
        /// <param name="index">Index of file list to open</param>
        private void OpenRecentFile(int index)
        {
            if (!string.IsNullOrEmpty(this._recentFiles.FileList[index]) && !this._bgwLoadFile.IsBusy)
            {
                this._bgwLoadFile.RunWorkerAsync(this._recentFiles.FileList[index]);
            }
        }

        /// <summary>
        /// Add a new item to recent file list and sets the menue item
        /// </summary>
        private void SetRecentFilesSettingsAndMenue()
        {
            if (this._projectManager.ActiveProject != null && this._projectManager.ActiveProject.File != null)
            {
                this._recentFiles.AddToList(this._projectManager.ActiveProject.File.FullName);
                Settings_AppVar.Default.RecentFiles_FileList = this._recentFiles.GetAsString();
                Settings_AppVar.Default.Save();
            }

            this._recentFiles.SetMenueItem(new List<ToolStripMenuItem> { this.mnuMain_File_RecentFiles_File0, this.mnuMain_File_RecentFiles_File1, this.mnuMain_File_RecentFiles_File2, this.mnuMain_File_RecentFiles_File3 }, this.mnuMain_File_RecentFiles, this.mnuMain_File_SepRecentFiles);
        }

        private void SetStatusstripLabels(Form ActiveMdiChild)
        {
            if (ActiveMdiChild != null)
            {
                ProjectForm ProjectForm = (ProjectForm)ActiveMdiChild;
                long FileSum = 0;
                long FileLengthSum = 0;

                foreach (KeyValuePair<int, Project.Bill.Bill> BillImten in ProjectForm.Project.Bills)
                {
                    FileSum += BillImten.Value.FileCount;
                    FileLengthSum += BillImten.Value.FilesLength;
                }

                this.tslBillC.Text = string.Format(this._tslBillC_OrgText, new object[] { ProjectForm.Project.BillClasses.Count });
                this.tslBills.Text = string.Format(this._tslBills_OrgText, new object[] { ProjectForm.BillsInList, ProjectForm.Project.Bills.Count });
                this.tslCompa.Text = string.Format(this._tslCompa_OrgText, new object[] { ProjectForm.Project.Companies.Count });
                this.tslFiles.Text = string.Format(this._tslFiles_OrgText, new object[] { FileSum, Toolbox.DirectoryAndFile.FileSize.Convert(FileLengthSum, 2, Toolbox.DirectoryAndFile.FileSize.ByteBase.SI) });
                if (ProjectForm.Project.File != null)
                {
                    FileInfo FileInfo = new FileInfo(ProjectForm.Project.File.FullName);
                    this.tslProFi.Text = string.Format(this._tslProFi_OrgText, new object[] { FileInfo.FullName, Toolbox.DirectoryAndFile.FileSize.Convert(FileInfo.Length, 2, Toolbox.DirectoryAndFile.FileSize.ByteBase.SI) });
                    this.tslProFi.IsLink = true;
                }
                else
                {
                    this.tslFiles.Text = string.Format(this._tslProFi_OrgText, new object[] { "-", "-" });
                    this.tslProFi.IsLink = false;
                }
            }
            else
            {
                this.tslBillC.Text = string.Format(this._tslBillC_OrgText, new object[] { "-" });
                this.tslBills.Text = string.Format(this._tslBills_OrgText, new object[] { "-", "-" });
                this.tslCompa.Text = string.Format(this._tslCompa_OrgText, new object[] { "-" });
                this.tslFiles.Text = string.Format(this._tslFiles_OrgText, new object[] { "-", "-" });
                this.tslProFi.Text = string.Format(this._tslProFi_OrgText, new object[] { "-", "-" });
                this.tslProFi.IsLink = false;
            }
        }

        #region Form Events
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            this.LoadInitialProject(Files);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._appClose)
            {
                if (this.WindowState == FormWindowState.Normal) Settings_AppVar.Default.MainForm_Size = this.Size;
                Settings_AppVar.Default.MainForm_State = this.WindowState;
                Settings_AppVar.Default.Save();

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
            ProjectForm ActiveMdiChild = (ProjectForm)this.ActiveMdiChild;
            if (ActiveMdiChild != null)
            {
                this.mnuMain_File_Close.Enabled = true;
                this.mnuMain_File_Save.Enabled = true;
                this.mnuMain_File_SaveAs.Enabled = true;
                this.tolMain_Basedata_BillClass.Enabled = true;
                this.tolMain_Basedata_Company.Enabled = true;
                this.tolMain_File_Save.Enabled = true;

                this._projectManager.ActiveProject = ActiveMdiChild.Project;
            }
            else
            {
                this.mnuMain_File_Close.Enabled = false;
                this.mnuMain_File_Save.Enabled = false;
                this.mnuMain_File_SaveAs.Enabled = false;
                this.tolMain_Basedata_BillClass.Enabled = false;
                this.tolMain_Basedata_Company.Enabled = false;
                this.tolMain_File_Save.Enabled = false;

                if (this._projectManager != null) this._projectManager.ActiveProject = null;
            }

            this.SetStatusstripLabels(this.ActiveMdiChild);
        }

        public void MainForm_MdiChildRequestClose(object sender, EventArgs e)
        {
            ProjectForm ProjectForm = (ProjectForm)sender;

            if (ProjectForm.Project.Changed)
            {
                DialogResult CloseDialogResult = (DialogResult)ProjectForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(ProjectForm, string.Format(Stringtable._0x0015m, new object[] { ProjectForm.Project.File != null ? ProjectForm.Project.File.Name : "" }), Stringtable._0x0015c, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)));
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
            if (Settings.Default.FileAssociation_CheckAtStartup) Program.CheckFileAssociationAndSet(false);


            // Check for Updates for the Apllication
            if (Settings.Default.AppUpdate_CheckAtStartUp) Program.CheckForUpdate(this, true);
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
            if (this._projectManager.ActiveProject.File == null || string.IsNullOrEmpty(this._projectManager.ActiveProject.File.FullName) || !this._projectManager.ActiveProject.File.Exists)
            {
                //Go to SaveAs if File is not defined or didn't exists
                this.mnuMain_File_SaveAs_Click(sender, e);
            }
            else if (!this._bgwSaveFile.IsBusy)
            {
                this._bgwSaveFile.RunWorkerAsync(new SaveProjectsArguments(SaveProjectsArguments.SaveMode.Save, null, false));
            }
        }

        private void mnuMain_File_SaveAs_Click(object sender, EventArgs e)
        {
            if (!this._bgwSaveFile.IsBusy)
            {
                this._bgwSaveFile.RunWorkerAsync(new SaveProjectsArguments(SaveProjectsArguments.SaveMode.SaveAs, null, false));
            }
        }

        private void mnuMain_File_RecentFiles_File0_Click(object sender, EventArgs e)
        {
            this.OpenRecentFile(0);
        }

        private void mnuMain_File_RecentFiles_File1_Click(object sender, EventArgs e)
        {
            this.OpenRecentFile(1);
        }

        private void mnuMain_File_RecentFiles_File2_Click(object sender, EventArgs e)
        {
            this.OpenRecentFile(2);
        }

        private void mnuMain_File_RecentFiles_File3_Click(object sender, EventArgs e)
        {
            this.OpenRecentFile(3);
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

                if (this._frmApplicationSettings.ClearRecentFiles)
                {
                    this._recentFiles.FileList.Clear();
                    this.SetRecentFilesSettingsAndMenue();
                }
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
            System.Reflection.Assembly Assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Drawing.Image AppImage = Resources.QuiAbl;
            AboutForm AboutForm = new AboutForm(Assembly, AppImage, null)
            {
                Credits = Resources.Credits,
                LicenseDirectory = Path.GetDirectoryName(Assembly.Location) + @"\Licenses\"
            };
            AboutForm.Show(this);
        }

        private void mnuMain_Help_CheckUpdate_Click(object sender, EventArgs e)
        {
            Program.CheckForUpdate(this, false);
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

        private void tslProFi_Click(object sender, EventArgs e)
        {
            if (!this.tslProFi.IsLink) return;
            System.Diagnostics.Process.Start("explorer.exe", "/e,/select,\"" + ((ProjectForm)this.ActiveMdiChild).Project.File.FullName + "\"");
        }
        #endregion

        #region Projec Events
        private void ProjectManager_ProjectChanged(object sender, EventArgs e)
        {
            this.SetStatusstripLabels(this.ActiveMdiChild);
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