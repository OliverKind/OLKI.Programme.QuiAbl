/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * A form to change the settings of the application
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
using System;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm.SubForms
{
    /// <summary>
    /// A form to change the settings of the application
    /// </summary>
    internal partial class ApplicationSettingsForm : Form
    {
        #region Fields
        /// <summary>
        /// Original text of Label FileModifyThreshold
        /// </summary>
        private readonly string _lblScanDefaultThreshold_OrgText;
        #endregion

        #region Properties
        /// <summary>
        /// True if clearing of the recent file list was requested
        /// </summary>
        private bool _clearRecentFiles = false;
        /// <summary>
        /// True if clearing of the recent file list was requested
        /// </summary>
        internal bool ClearRecentFiles
        {
            get
            {
                return this._clearRecentFiles;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialise a new application SettingsForm
        /// </summary>
        internal ApplicationSettingsForm()
        {
            InitializeComponent();
            this.lblDateFormatPreview.Text = "";
            this._lblScanDefaultThreshold_OrgText = this.lblScanDefaultThreshold.Text;
            this.SetControlesFromSettings();
        }

        /// <summary>
        /// Set the properties of the controls from actual application settings
        /// </summary>
        private void SetControlesFromSettings()
        {
            this.cboScanDefaultColorMode.SelectedIndex = Settings.Default.Scan_DefaultColorMode;
            this.chkAddRemoveCropAreaWithMouseClick.Checked = Settings.Default.AddRemoveCropAreaWithMouseClick;
            this.chkAppUpdateCheckAtStartUp.Checked = Settings.Default.AppUpdate_CheckAtStartUp;
            this.chkFileAssociationCheckAtStartup.Checked = Settings.Default.FileAssociation_CheckAtStartup;
            this.chkStartupDefaultLoadEmptyProject.Checked = Settings.Default.Startup_DefaultLoadEmptyProject;
            this.chkTreeViewBillClassesAllowCollaps.Checked = Settings.Default.TreeView_BillClasses_AllowCollaps;
            this.chkTreeViewBillClassesExpandAllDefault.Checked = Settings.Default.TreeView_BillClasses_ExpandAllDefault;
            this.nudNumRecentFiles.Value = Settings.Default.RecentFiles_MaxLength;
            this.nudScanDefaultResolution.Value = Settings.Default.Scan_DefaultResolution;
            this.tbaScanDefaultThreshold.Value = Settings.Default.Scan_DefaultThreshold;
            this.txtDateFormat.Text = Settings.Default.DateFormat;
            this.txtProjectFileDefaultPath.Text = Settings.Default.ProjectFile_DefaultPath;
            this.txtStartupDefaultFileOpen.Text = Settings.Default.Startup_DefaultFileOpen;

            this.tbaScanDefaultThreshold_Scroll(this, new EventArgs());
        }

        /// <summary>
        /// Set the form OK button, debeding by the error states of the date format textbox contents
        /// </summary>
        private void ValidateDateFormats()
        {
            bool FormatValid;
            this.erpDateFormat.Clear();

            try
            {
                this.lblDateFormatPreview.Text = DateTime.Now.ToString(this.txtDateFormat.Text);
                FormatValid = true;
            }
            catch
            {
                lblDateFormatPreview.Text = "";
                this.erpDateFormat.SetError(this.txtDateFormat, Stringtable._0x0009);
                FormatValid = false;
            }

            this.btnOk.Enabled = FormatValid;
        }

        #region Form events
        private void btnProjectFileDefaultPath_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog
            {
                Description = Stringtable._0x0016,
                SelectedPath = Settings.Default.ProjectFile_DefaultPath
            };
            if (FolderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtProjectFileDefaultPath.Text = FolderBrowserDialog.SelectedPath;
                Settings.Default.ProjectFile_DefaultPath = FolderBrowserDialog.SelectedPath;
            }
        }

        private void btnProjectFileDefaultPath_Delete_Click(object sender, EventArgs e)
        {
            this.txtProjectFileDefaultPath.Text = string.Empty;
        }

        private void btnStartupDefaultFileOpen_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                DefaultExt = Settings_AppConst.Default.ProjectFile_DefaultExtension,
                Filter = Settings_AppConst.Default.ProjectFile_FilterList,
                InitialDirectory = Settings.Default.ProjectFile_DefaultPath,
                Multiselect = false
            };
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtStartupDefaultFileOpen.Text = OpenFileDialog.FileName;
            }
        }

        private void btnStartupDefaultFileOpen_Delete_Click(object sender, EventArgs e)
        {
            this.txtStartupDefaultFileOpen.Text = string.Empty;
        }

        private void btnRecentFilesClear_Click(object sender, EventArgs e)
        {
            this._clearRecentFiles = true;
        }

        private void btnCheckFileAssociation_Click(object sender, EventArgs e)
        {
            Program.CheckFileAssociationAndSet(true);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.AddRemoveCropAreaWithMouseClick = this.chkAddRemoveCropAreaWithMouseClick.Checked;
            Settings.Default.AppUpdate_CheckAtStartUp = this.chkAppUpdateCheckAtStartUp.Checked;
            Settings.Default.DateFormat = this.txtDateFormat.Text;
            Settings.Default.FileAssociation_CheckAtStartup = this.chkFileAssociationCheckAtStartup.Checked;
            Settings.Default.ProjectFile_DefaultPath = this.txtProjectFileDefaultPath.Text;
            Settings.Default.RecentFiles_MaxLength = (int)this.nudNumRecentFiles.Value;
            Settings.Default.Scan_DefaultColorMode = this.cboScanDefaultColorMode.SelectedIndex;
            Settings.Default.Scan_DefaultResolution = (int)this.nudScanDefaultResolution.Value;
            Settings.Default.Scan_DefaultThreshold = this.tbaScanDefaultThreshold.Value;
            Settings.Default.Startup_DefaultFileOpen = this.txtStartupDefaultFileOpen.Text;
            Settings.Default.Startup_DefaultLoadEmptyProject = this.chkStartupDefaultLoadEmptyProject.Checked;
            Settings.Default.TreeView_BillClasses_AllowCollaps = this.chkTreeViewBillClassesAllowCollaps.Checked;
            Settings.Default.TreeView_BillClasses_ExpandAllDefault = this.chkTreeViewBillClassesExpandAllDefault.Checked;

            Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSetDefaults_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            this.SetControlesFromSettings();
        }

        private void cboScanDefaultColorMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cboScanDefaultColorMode.SelectedIndex)
            {
                case 0: //Color
                    this.tbaScanDefaultThreshold.Enabled = false;
                    break;
                case 1: //Grayscale
                    this.tbaScanDefaultThreshold.Enabled = false;
                    break;
                case 2: //BW
                    this.tbaScanDefaultThreshold.Enabled = true;
                    break;
                default:
                    this.tbaScanDefaultThreshold.Enabled = false;
                    break;
            }
        }

        private void tbaScanDefaultThreshold_Scroll(object sender, EventArgs e)
        {
            this.lblScanDefaultThreshold.Text = string.Format(this._lblScanDefaultThreshold_OrgText, this.tbaScanDefaultThreshold.Value);
        }

        private void txtDateFormat_TextChanged(object sender, EventArgs e)
        {
            this.ValidateDateFormats();
        }
        #endregion
        #endregion
    }
}