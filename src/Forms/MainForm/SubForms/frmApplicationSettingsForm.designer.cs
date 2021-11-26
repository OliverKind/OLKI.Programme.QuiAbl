namespace OLKI.Programme.QuiAbl.src.Forms.MainForm.SubForms
{
    internal partial class ApplicationSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettingsForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.grbProjectFolder = new System.Windows.Forms.GroupBox();
            this.btnDefaultFileOpen_Delete = new System.Windows.Forms.Button();
            this.btnDefaultPath_Delete = new System.Windows.Forms.Button();
            this.btnDefaultFileOpen_Browse = new System.Windows.Forms.Button();
            this.txtDefaultFileOpen = new System.Windows.Forms.TextBox();
            this.lblDefaultFileOpen = new System.Windows.Forms.Label();
            this.btnDefaultPath_Browse = new System.Windows.Forms.Button();
            this.txtDefaultPath = new System.Windows.Forms.TextBox();
            this.lblDefaultPath = new System.Windows.Forms.Label();
            this.grbRecentFiles = new System.Windows.Forms.GroupBox();
            this.btnRecentFilesClear = new System.Windows.Forms.Button();
            this.nudNumRecentFiles = new System.Windows.Forms.NumericUpDown();
            this.lblNumRecentFiles = new System.Windows.Forms.Label();
            this.btnCheckFileAssociation = new System.Windows.Forms.Button();
            this.btnSetDefaults = new System.Windows.Forms.Button();
            this.grbAddTextToFiile = new System.Windows.Forms.GroupBox();
            this.lblDateFormatPreview = new System.Windows.Forms.Label();
            this.lblDateFormat = new System.Windows.Forms.Label();
            this.txtDateFormat = new System.Windows.Forms.TextBox();
            this.chkAutoCheckFileAssociation = new System.Windows.Forms.CheckBox();
            this.erpDateFormat = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbBillClassesTreeView = new System.Windows.Forms.GroupBox();
            this.chkTreeViewBillClassesExpandAllDefault = new System.Windows.Forms.CheckBox();
            this.chkTreeViewBillClassesAllowCollaps = new System.Windows.Forms.CheckBox();
            this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbScanDefault = new System.Windows.Forms.GroupBox();
            this.cboScanDefaultColorMode = new System.Windows.Forms.ComboBox();
            this.lblFileModifyVolor = new System.Windows.Forms.Label();
            this.lblScanDefaultResolution = new System.Windows.Forms.Label();
            this.nudScanDefaultResolution = new System.Windows.Forms.NumericUpDown();
            this.grbProjectFolder.SuspendLayout();
            this.grbRecentFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRecentFiles)).BeginInit();
            this.grbAddTextToFiile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpDateFormat)).BeginInit();
            this.grbBillClassesTreeView.SuspendLayout();
            this.grbScanDefault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanDefaultResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(12, 339);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 24);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grbProjectFolder
            // 
            this.grbProjectFolder.Controls.Add(this.btnDefaultFileOpen_Delete);
            this.grbProjectFolder.Controls.Add(this.btnDefaultPath_Delete);
            this.grbProjectFolder.Controls.Add(this.btnDefaultFileOpen_Browse);
            this.grbProjectFolder.Controls.Add(this.txtDefaultFileOpen);
            this.grbProjectFolder.Controls.Add(this.lblDefaultFileOpen);
            this.grbProjectFolder.Controls.Add(this.btnDefaultPath_Browse);
            this.grbProjectFolder.Controls.Add(this.txtDefaultPath);
            this.grbProjectFolder.Controls.Add(this.lblDefaultPath);
            this.grbProjectFolder.Location = new System.Drawing.Point(12, 12);
            this.grbProjectFolder.Name = "grbProjectFolder";
            this.grbProjectFolder.Size = new System.Drawing.Size(705, 71);
            this.grbProjectFolder.TabIndex = 0;
            this.grbProjectFolder.TabStop = false;
            this.grbProjectFolder.Text = "Standardordner und -dateien";
            // 
            // btnDefaultFileOpen_Delete
            // 
            this.btnDefaultFileOpen_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultFileOpen_Delete.Image")));
            this.btnDefaultFileOpen_Delete.Location = new System.Drawing.Point(664, 42);
            this.btnDefaultFileOpen_Delete.Name = "btnDefaultFileOpen_Delete";
            this.btnDefaultFileOpen_Delete.Size = new System.Drawing.Size(35, 24);
            this.btnDefaultFileOpen_Delete.TabIndex = 7;
            this.btnDefaultFileOpen_Delete.UseVisualStyleBackColor = true;
            this.btnDefaultFileOpen_Delete.Click += new System.EventHandler(this.btnDefaultFileOpen_Delete_Click);
            // 
            // btnDefaultPath_Delete
            // 
            this.btnDefaultPath_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultPath_Delete.Image")));
            this.btnDefaultPath_Delete.Location = new System.Drawing.Point(664, 16);
            this.btnDefaultPath_Delete.Name = "btnDefaultPath_Delete";
            this.btnDefaultPath_Delete.Size = new System.Drawing.Size(35, 24);
            this.btnDefaultPath_Delete.TabIndex = 3;
            this.btnDefaultPath_Delete.UseVisualStyleBackColor = true;
            this.btnDefaultPath_Delete.Click += new System.EventHandler(this.btnDefaultPath_Delete_Click);
            // 
            // btnDefaultFileOpen_Browse
            // 
            this.btnDefaultFileOpen_Browse.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultFileOpen_Browse.Image")));
            this.btnDefaultFileOpen_Browse.Location = new System.Drawing.Point(623, 42);
            this.btnDefaultFileOpen_Browse.Name = "btnDefaultFileOpen_Browse";
            this.btnDefaultFileOpen_Browse.Size = new System.Drawing.Size(35, 24);
            this.btnDefaultFileOpen_Browse.TabIndex = 6;
            this.btnDefaultFileOpen_Browse.UseVisualStyleBackColor = true;
            this.btnDefaultFileOpen_Browse.Click += new System.EventHandler(this.btnDefaultFileOpen_Browse_Click);
            // 
            // txtDefaultFileOpen
            // 
            this.txtDefaultFileOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDefaultFileOpen.Location = new System.Drawing.Point(142, 45);
            this.txtDefaultFileOpen.Name = "txtDefaultFileOpen";
            this.txtDefaultFileOpen.Size = new System.Drawing.Size(475, 20);
            this.txtDefaultFileOpen.TabIndex = 5;
            // 
            // lblDefaultFileOpen
            // 
            this.lblDefaultFileOpen.AutoSize = true;
            this.lblDefaultFileOpen.Location = new System.Drawing.Point(6, 48);
            this.lblDefaultFileOpen.Name = "lblDefaultFileOpen";
            this.lblDefaultFileOpen.Size = new System.Drawing.Size(130, 13);
            this.lblDefaultFileOpen.TabIndex = 4;
            this.lblDefaultFileOpen.Text = "Datei beim Starten öffnen:";
            // 
            // btnDefaultPath_Browse
            // 
            this.btnDefaultPath_Browse.Image = ((System.Drawing.Image)(resources.GetObject("btnDefaultPath_Browse.Image")));
            this.btnDefaultPath_Browse.Location = new System.Drawing.Point(623, 16);
            this.btnDefaultPath_Browse.Name = "btnDefaultPath_Browse";
            this.btnDefaultPath_Browse.Size = new System.Drawing.Size(35, 24);
            this.btnDefaultPath_Browse.TabIndex = 2;
            this.btnDefaultPath_Browse.UseVisualStyleBackColor = true;
            this.btnDefaultPath_Browse.Click += new System.EventHandler(this.btnDefaultPath_Browse_Click);
            // 
            // txtDefaultPath
            // 
            this.txtDefaultPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDefaultPath.Location = new System.Drawing.Point(142, 19);
            this.txtDefaultPath.Name = "txtDefaultPath";
            this.txtDefaultPath.Size = new System.Drawing.Size(475, 20);
            this.txtDefaultPath.TabIndex = 1;
            // 
            // lblDefaultPath
            // 
            this.lblDefaultPath.AutoSize = true;
            this.lblDefaultPath.Location = new System.Drawing.Point(6, 22);
            this.lblDefaultPath.Name = "lblDefaultPath";
            this.lblDefaultPath.Size = new System.Drawing.Size(83, 13);
            this.lblDefaultPath.TabIndex = 0;
            this.lblDefaultPath.Text = "Standardordner:";
            // 
            // grbRecentFiles
            // 
            this.grbRecentFiles.Controls.Add(this.btnRecentFilesClear);
            this.grbRecentFiles.Controls.Add(this.nudNumRecentFiles);
            this.grbRecentFiles.Controls.Add(this.lblNumRecentFiles);
            this.grbRecentFiles.Location = new System.Drawing.Point(12, 233);
            this.grbRecentFiles.Name = "grbRecentFiles";
            this.grbRecentFiles.Size = new System.Drawing.Size(705, 48);
            this.grbRecentFiles.TabIndex = 4;
            this.grbRecentFiles.TabStop = false;
            this.grbRecentFiles.Text = "Zuletzt geöffnete Dateien";
            // 
            // btnRecentFilesClear
            // 
            this.btnRecentFilesClear.Location = new System.Drawing.Point(280, 19);
            this.btnRecentFilesClear.Name = "btnRecentFilesClear";
            this.btnRecentFilesClear.Size = new System.Drawing.Size(110, 23);
            this.btnRecentFilesClear.TabIndex = 2;
            this.btnRecentFilesClear.Text = "Liste leeren";
            this.btnRecentFilesClear.UseVisualStyleBackColor = true;
            this.btnRecentFilesClear.Click += new System.EventHandler(this.btnRecentFilesClear_Click);
            // 
            // nudNumRecentFiles
            // 
            this.nudNumRecentFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudNumRecentFiles.Location = new System.Drawing.Point(245, 19);
            this.nudNumRecentFiles.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudNumRecentFiles.Name = "nudNumRecentFiles";
            this.nudNumRecentFiles.Size = new System.Drawing.Size(29, 20);
            this.nudNumRecentFiles.TabIndex = 1;
            // 
            // lblNumRecentFiles
            // 
            this.lblNumRecentFiles.AutoSize = true;
            this.lblNumRecentFiles.Location = new System.Drawing.Point(6, 21);
            this.lblNumRecentFiles.Name = "lblNumRecentFiles";
            this.lblNumRecentFiles.Size = new System.Drawing.Size(233, 13);
            this.lblNumRecentFiles.TabIndex = 0;
            this.lblNumRecentFiles.Text = "Anzahl der zuletzt geöffneten Dateien anzeigen:";
            // 
            // btnCheckFileAssociation
            // 
            this.btnCheckFileAssociation.Location = new System.Drawing.Point(12, 287);
            this.btnCheckFileAssociation.Name = "btnCheckFileAssociation";
            this.btnCheckFileAssociation.Size = new System.Drawing.Size(134, 23);
            this.btnCheckFileAssociation.TabIndex = 5;
            this.btnCheckFileAssociation.Text = "Dateizuordnung prüfen";
            this.btnCheckFileAssociation.UseVisualStyleBackColor = true;
            this.btnCheckFileAssociation.Click += new System.EventHandler(this.btnCheckFileAssociation_Click);
            // 
            // btnSetDefaults
            // 
            this.btnSetDefaults.Location = new System.Drawing.Point(511, 288);
            this.btnSetDefaults.Name = "btnSetDefaults";
            this.btnSetDefaults.Size = new System.Drawing.Size(206, 23);
            this.btnSetDefaults.TabIndex = 7;
            this.btnSetDefaults.Text = "Standardeinstellungen wiederherstellen";
            this.btnSetDefaults.UseVisualStyleBackColor = true;
            this.btnSetDefaults.Click += new System.EventHandler(this.btnSetDefaults_Click);
            // 
            // grbAddTextToFiile
            // 
            this.grbAddTextToFiile.Controls.Add(this.lblDateFormatPreview);
            this.grbAddTextToFiile.Controls.Add(this.lblDateFormat);
            this.grbAddTextToFiile.Controls.Add(this.txtDateFormat);
            this.grbAddTextToFiile.Location = new System.Drawing.Point(12, 89);
            this.grbAddTextToFiile.Name = "grbAddTextToFiile";
            this.grbAddTextToFiile.Size = new System.Drawing.Size(705, 45);
            this.grbAddTextToFiile.TabIndex = 1;
            this.grbAddTextToFiile.TabStop = false;
            this.grbAddTextToFiile.Text = "Formatierung";
            // 
            // lblDateFormatPreview
            // 
            this.lblDateFormatPreview.AutoSize = true;
            this.lblDateFormatPreview.Location = new System.Drawing.Point(283, 22);
            this.lblDateFormatPreview.Name = "lblDateFormatPreview";
            this.lblDateFormatPreview.Size = new System.Drawing.Size(110, 13);
            this.lblDateFormatPreview.TabIndex = 2;
            this.lblDateFormatPreview.Text = "lblDateFormatPreview";
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.Location = new System.Drawing.Point(6, 22);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(75, 13);
            this.lblDateFormat.TabIndex = 0;
            this.lblDateFormat.Text = "Datumsformat:";
            // 
            // txtDateFormat
            // 
            this.txtDateFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDateFormat.Location = new System.Drawing.Point(87, 19);
            this.txtDateFormat.Name = "txtDateFormat";
            this.txtDateFormat.Size = new System.Drawing.Size(190, 20);
            this.txtDateFormat.TabIndex = 1;
            this.txtDateFormat.TextChanged += new System.EventHandler(this.txtDateFormat_TextChanged);
            // 
            // chkAutoCheckFileAssociation
            // 
            this.chkAutoCheckFileAssociation.AutoSize = true;
            this.chkAutoCheckFileAssociation.Location = new System.Drawing.Point(152, 292);
            this.chkAutoCheckFileAssociation.Name = "chkAutoCheckFileAssociation";
            this.chkAutoCheckFileAssociation.Size = new System.Drawing.Size(229, 17);
            this.chkAutoCheckFileAssociation.TabIndex = 6;
            this.chkAutoCheckFileAssociation.Text = "Dateizuordnung beim Programmstart prüfen";
            this.chkAutoCheckFileAssociation.UseVisualStyleBackColor = true;
            // 
            // erpDateFormat
            // 
            this.erpDateFormat.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpDateFormat.ContainerControl = this;
            // 
            // grbBillClassesTreeView
            // 
            this.grbBillClassesTreeView.Controls.Add(this.chkTreeViewBillClassesExpandAllDefault);
            this.grbBillClassesTreeView.Controls.Add(this.chkTreeViewBillClassesAllowCollaps);
            this.grbBillClassesTreeView.Location = new System.Drawing.Point(12, 140);
            this.grbBillClassesTreeView.Name = "grbBillClassesTreeView";
            this.grbBillClassesTreeView.Size = new System.Drawing.Size(185, 65);
            this.grbBillClassesTreeView.TabIndex = 2;
            this.grbBillClassesTreeView.TabStop = false;
            this.grbBillClassesTreeView.Text = "Kategorienbraum";
            // 
            // chkTreeViewBillClassesExpandAllDefault
            // 
            this.chkTreeViewBillClassesExpandAllDefault.AutoSize = true;
            this.chkTreeViewBillClassesExpandAllDefault.Location = new System.Drawing.Point(6, 42);
            this.chkTreeViewBillClassesExpandAllDefault.Name = "chkTreeViewBillClassesExpandAllDefault";
            this.chkTreeViewBillClassesExpandAllDefault.Size = new System.Drawing.Size(158, 17);
            this.chkTreeViewBillClassesExpandAllDefault.TabIndex = 1;
            this.chkTreeViewBillClassesExpandAllDefault.Text = "Standardmäßig ausgeklappt";
            this.chkTreeViewBillClassesExpandAllDefault.UseVisualStyleBackColor = true;
            // 
            // chkTreeViewBillClassesAllowCollaps
            // 
            this.chkTreeViewBillClassesAllowCollaps.AutoSize = true;
            this.chkTreeViewBillClassesAllowCollaps.Location = new System.Drawing.Point(6, 19);
            this.chkTreeViewBillClassesAllowCollaps.Name = "chkTreeViewBillClassesAllowCollaps";
            this.chkTreeViewBillClassesAllowCollaps.Size = new System.Drawing.Size(117, 17);
            this.chkTreeViewBillClassesAllowCollaps.TabIndex = 0;
            this.chkTreeViewBillClassesAllowCollaps.Text = "Erlaube einklappen";
            this.chkTreeViewBillClassesAllowCollaps.UseVisualStyleBackColor = true;
            // 
            // chkCheckForUpdates
            // 
            this.chkCheckForUpdates.AutoSize = true;
            this.chkCheckForUpdates.Location = new System.Drawing.Point(12, 316);
            this.chkCheckForUpdates.Name = "chkCheckForUpdates";
            this.chkCheckForUpdates.Size = new System.Drawing.Size(245, 17);
            this.chkCheckForUpdates.TabIndex = 8;
            this.chkCheckForUpdates.Text = "Auf neue Progammversionen beim Start prüfen";
            this.chkCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(607, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbScanDefault
            // 
            this.grbScanDefault.Controls.Add(this.cboScanDefaultColorMode);
            this.grbScanDefault.Controls.Add(this.lblFileModifyVolor);
            this.grbScanDefault.Controls.Add(this.lblScanDefaultResolution);
            this.grbScanDefault.Controls.Add(this.nudScanDefaultResolution);
            this.grbScanDefault.Location = new System.Drawing.Point(203, 140);
            this.grbScanDefault.Name = "grbScanDefault";
            this.grbScanDefault.Size = new System.Drawing.Size(508, 65);
            this.grbScanDefault.TabIndex = 3;
            this.grbScanDefault.TabStop = false;
            this.grbScanDefault.Text = "Standard Scaneinstellungen";
            // 
            // cboScanDefaultColorMode
            // 
            this.cboScanDefaultColorMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboScanDefaultColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScanDefaultColorMode.FormattingEnabled = true;
            this.cboScanDefaultColorMode.Items.AddRange(new object[] {
            "Farbe",
            "Graustufen",
            "Schwarz Weiiß"});
            this.cboScanDefaultColorMode.Location = new System.Drawing.Point(184, 18);
            this.cboScanDefaultColorMode.Name = "cboScanDefaultColorMode";
            this.cboScanDefaultColorMode.Size = new System.Drawing.Size(217, 21);
            this.cboScanDefaultColorMode.TabIndex = 3;
            // 
            // lblFileModifyVolor
            // 
            this.lblFileModifyVolor.AutoSize = true;
            this.lblFileModifyVolor.Location = new System.Drawing.Point(141, 21);
            this.lblFileModifyVolor.Name = "lblFileModifyVolor";
            this.lblFileModifyVolor.Size = new System.Drawing.Size(37, 13);
            this.lblFileModifyVolor.TabIndex = 2;
            this.lblFileModifyVolor.Text = "Farbe:";
            // 
            // lblScanDefaultResolution
            // 
            this.lblScanDefaultResolution.AutoSize = true;
            this.lblScanDefaultResolution.Location = new System.Drawing.Point(6, 21);
            this.lblScanDefaultResolution.Name = "lblScanDefaultResolution";
            this.lblScanDefaultResolution.Size = new System.Drawing.Size(57, 13);
            this.lblScanDefaultResolution.TabIndex = 0;
            this.lblScanDefaultResolution.Text = "Auflösung:";
            // 
            // nudScanDefaultResolution
            // 
            this.nudScanDefaultResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudScanDefaultResolution.Location = new System.Drawing.Point(70, 19);
            this.nudScanDefaultResolution.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudScanDefaultResolution.Name = "nudScanDefaultResolution";
            this.nudScanDefaultResolution.Size = new System.Drawing.Size(65, 20);
            this.nudScanDefaultResolution.TabIndex = 1;
            this.nudScanDefaultResolution.ThousandsSeparator = true;
            this.nudScanDefaultResolution.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // ApplicationSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(729, 375);
            this.Controls.Add(this.grbScanDefault);
            this.Controls.Add(this.chkCheckForUpdates);
            this.Controls.Add(this.grbBillClassesTreeView);
            this.Controls.Add(this.chkAutoCheckFileAssociation);
            this.Controls.Add(this.grbAddTextToFiile);
            this.Controls.Add(this.btnSetDefaults);
            this.Controls.Add(this.btnCheckFileAssociation);
            this.Controls.Add(this.grbRecentFiles);
            this.Controls.Add(this.grbProjectFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplicationSettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Programmeinstellungen";
            this.grbProjectFolder.ResumeLayout(false);
            this.grbProjectFolder.PerformLayout();
            this.grbRecentFiles.ResumeLayout(false);
            this.grbRecentFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRecentFiles)).EndInit();
            this.grbAddTextToFiile.ResumeLayout(false);
            this.grbAddTextToFiile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpDateFormat)).EndInit();
            this.grbBillClassesTreeView.ResumeLayout(false);
            this.grbBillClassesTreeView.PerformLayout();
            this.grbScanDefault.ResumeLayout(false);
            this.grbScanDefault.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanDefaultResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grbProjectFolder;
        private System.Windows.Forms.TextBox txtDefaultFileOpen;
        private System.Windows.Forms.Label lblDefaultFileOpen;
        private System.Windows.Forms.TextBox txtDefaultPath;
        private System.Windows.Forms.Label lblDefaultPath;
        private System.Windows.Forms.GroupBox grbRecentFiles;
        private System.Windows.Forms.Button btnDefaultFileOpen_Browse;
        private System.Windows.Forms.Button btnDefaultPath_Browse;
        private System.Windows.Forms.Button btnCheckFileAssociation;
        private System.Windows.Forms.Button btnDefaultPath_Delete;
        private System.Windows.Forms.Button btnDefaultFileOpen_Delete;
        private System.Windows.Forms.Button btnSetDefaults;
        private System.Windows.Forms.GroupBox grbAddTextToFiile;
        private System.Windows.Forms.Button btnRecentFilesClear;
        private System.Windows.Forms.NumericUpDown nudNumRecentFiles;
        private System.Windows.Forms.Label lblNumRecentFiles;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.TextBox txtDateFormat;
        private System.Windows.Forms.CheckBox chkAutoCheckFileAssociation;
        private System.Windows.Forms.ErrorProvider erpDateFormat;
        private System.Windows.Forms.Label lblDateFormatPreview;
        private System.Windows.Forms.GroupBox grbBillClassesTreeView;
        private System.Windows.Forms.CheckBox chkTreeViewBillClassesExpandAllDefault;
        private System.Windows.Forms.CheckBox chkTreeViewBillClassesAllowCollaps;
        private System.Windows.Forms.CheckBox chkCheckForUpdates;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbScanDefault;
        private System.Windows.Forms.Label lblScanDefaultResolution;
        private System.Windows.Forms.NumericUpDown nudScanDefaultResolution;
        private System.Windows.Forms.ComboBox cboScanDefaultColorMode;
        private System.Windows.Forms.Label lblFileModifyVolor;
    }
}