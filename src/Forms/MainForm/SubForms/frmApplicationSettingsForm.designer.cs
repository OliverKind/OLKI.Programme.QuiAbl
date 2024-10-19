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
            this.chkStartupDefaultLoadEmptyProject = new System.Windows.Forms.CheckBox();
            this.btnStartupDefaultFileOpen_Delete = new System.Windows.Forms.Button();
            this.btnProjectFileDefaultPath_Delete = new System.Windows.Forms.Button();
            this.btnStartupDefaultFileOpen_Browse = new System.Windows.Forms.Button();
            this.txtStartupDefaultFileOpen = new System.Windows.Forms.TextBox();
            this.lblStartupDefaultFileOpen = new System.Windows.Forms.Label();
            this.btnProjectFileDefaultPath_Browse = new System.Windows.Forms.Button();
            this.txtProjectFileDefaultPath = new System.Windows.Forms.TextBox();
            this.lblProjectFileDefaultPath = new System.Windows.Forms.Label();
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
            this.chkFileAssociationCheckAtStartup = new System.Windows.Forms.CheckBox();
            this.erpDateFormat = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbBillClassesTreeView = new System.Windows.Forms.GroupBox();
            this.chkTreeViewBillClassesExpandAllDefault = new System.Windows.Forms.CheckBox();
            this.chkTreeViewBillClassesAllowCollaps = new System.Windows.Forms.CheckBox();
            this.chkAppUpdateCheckAtStartUp = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbScanDefault = new System.Windows.Forms.GroupBox();
            this.lblCropAreaSelectionWidth = new System.Windows.Forms.Label();
            this.lblScanDefaultThreshold = new System.Windows.Forms.Label();
            this.nudCropAreaSelectionWidth = new System.Windows.Forms.NumericUpDown();
            this.chkCropAreaAddRemoveWithMouseClick = new System.Windows.Forms.CheckBox();
            this.cboScanDefaultColorMode = new System.Windows.Forms.ComboBox();
            this.tbaScanDefaultThreshold = new System.Windows.Forms.TrackBar();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudCropAreaSelectionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaScanDefaultThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanDefaultResolution)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(12, 398);
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
            this.grbProjectFolder.Controls.Add(this.chkStartupDefaultLoadEmptyProject);
            this.grbProjectFolder.Controls.Add(this.btnStartupDefaultFileOpen_Delete);
            this.grbProjectFolder.Controls.Add(this.btnProjectFileDefaultPath_Delete);
            this.grbProjectFolder.Controls.Add(this.btnStartupDefaultFileOpen_Browse);
            this.grbProjectFolder.Controls.Add(this.txtStartupDefaultFileOpen);
            this.grbProjectFolder.Controls.Add(this.lblStartupDefaultFileOpen);
            this.grbProjectFolder.Controls.Add(this.btnProjectFileDefaultPath_Browse);
            this.grbProjectFolder.Controls.Add(this.txtProjectFileDefaultPath);
            this.grbProjectFolder.Controls.Add(this.lblProjectFileDefaultPath);
            this.grbProjectFolder.Location = new System.Drawing.Point(12, 12);
            this.grbProjectFolder.Name = "grbProjectFolder";
            this.grbProjectFolder.Size = new System.Drawing.Size(705, 94);
            this.grbProjectFolder.TabIndex = 0;
            this.grbProjectFolder.TabStop = false;
            this.grbProjectFolder.Text = "Standardordner und -dateien";
            // 
            // chkStartupDefaultLoadEmptyProject
            // 
            this.chkStartupDefaultLoadEmptyProject.AutoSize = true;
            this.chkStartupDefaultLoadEmptyProject.Location = new System.Drawing.Point(142, 71);
            this.chkStartupDefaultLoadEmptyProject.Name = "chkStartupDefaultLoadEmptyProject";
            this.chkStartupDefaultLoadEmptyProject.Size = new System.Drawing.Size(189, 17);
            this.chkStartupDefaultLoadEmptyProject.TabIndex = 8;
            this.chkStartupDefaultLoadEmptyProject.Text = "Leeres Projekt beim Starten öffnen";
            this.chkStartupDefaultLoadEmptyProject.UseVisualStyleBackColor = true;
            // 
            // btnStartupDefaultFileOpen_Delete
            // 
            this.btnStartupDefaultFileOpen_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnStartupDefaultFileOpen_Delete.Image")));
            this.btnStartupDefaultFileOpen_Delete.Location = new System.Drawing.Point(664, 42);
            this.btnStartupDefaultFileOpen_Delete.Name = "btnStartupDefaultFileOpen_Delete";
            this.btnStartupDefaultFileOpen_Delete.Size = new System.Drawing.Size(35, 24);
            this.btnStartupDefaultFileOpen_Delete.TabIndex = 7;
            this.btnStartupDefaultFileOpen_Delete.UseVisualStyleBackColor = true;
            this.btnStartupDefaultFileOpen_Delete.Click += new System.EventHandler(this.btnStartupDefaultFileOpen_Delete_Click);
            // 
            // btnProjectFileDefaultPath_Delete
            // 
            this.btnProjectFileDefaultPath_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectFileDefaultPath_Delete.Image")));
            this.btnProjectFileDefaultPath_Delete.Location = new System.Drawing.Point(664, 16);
            this.btnProjectFileDefaultPath_Delete.Name = "btnProjectFileDefaultPath_Delete";
            this.btnProjectFileDefaultPath_Delete.Size = new System.Drawing.Size(35, 24);
            this.btnProjectFileDefaultPath_Delete.TabIndex = 3;
            this.btnProjectFileDefaultPath_Delete.UseVisualStyleBackColor = true;
            this.btnProjectFileDefaultPath_Delete.Click += new System.EventHandler(this.btnProjectFileDefaultPath_Delete_Click);
            // 
            // btnStartupDefaultFileOpen_Browse
            // 
            this.btnStartupDefaultFileOpen_Browse.Image = ((System.Drawing.Image)(resources.GetObject("btnStartupDefaultFileOpen_Browse.Image")));
            this.btnStartupDefaultFileOpen_Browse.Location = new System.Drawing.Point(623, 42);
            this.btnStartupDefaultFileOpen_Browse.Name = "btnStartupDefaultFileOpen_Browse";
            this.btnStartupDefaultFileOpen_Browse.Size = new System.Drawing.Size(35, 24);
            this.btnStartupDefaultFileOpen_Browse.TabIndex = 6;
            this.btnStartupDefaultFileOpen_Browse.UseVisualStyleBackColor = true;
            this.btnStartupDefaultFileOpen_Browse.Click += new System.EventHandler(this.btnStartupDefaultFileOpen_Browse_Click);
            // 
            // txtStartupDefaultFileOpen
            // 
            this.txtStartupDefaultFileOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtStartupDefaultFileOpen.Location = new System.Drawing.Point(142, 45);
            this.txtStartupDefaultFileOpen.Name = "txtStartupDefaultFileOpen";
            this.txtStartupDefaultFileOpen.Size = new System.Drawing.Size(475, 20);
            this.txtStartupDefaultFileOpen.TabIndex = 5;
            // 
            // lblStartupDefaultFileOpen
            // 
            this.lblStartupDefaultFileOpen.AutoSize = true;
            this.lblStartupDefaultFileOpen.Location = new System.Drawing.Point(6, 48);
            this.lblStartupDefaultFileOpen.Name = "lblStartupDefaultFileOpen";
            this.lblStartupDefaultFileOpen.Size = new System.Drawing.Size(130, 13);
            this.lblStartupDefaultFileOpen.TabIndex = 4;
            this.lblStartupDefaultFileOpen.Text = "Datei beim Starten öffnen:";
            // 
            // btnProjectFileDefaultPath_Browse
            // 
            this.btnProjectFileDefaultPath_Browse.Image = ((System.Drawing.Image)(resources.GetObject("btnProjectFileDefaultPath_Browse.Image")));
            this.btnProjectFileDefaultPath_Browse.Location = new System.Drawing.Point(623, 16);
            this.btnProjectFileDefaultPath_Browse.Name = "btnProjectFileDefaultPath_Browse";
            this.btnProjectFileDefaultPath_Browse.Size = new System.Drawing.Size(35, 24);
            this.btnProjectFileDefaultPath_Browse.TabIndex = 2;
            this.btnProjectFileDefaultPath_Browse.UseVisualStyleBackColor = true;
            this.btnProjectFileDefaultPath_Browse.Click += new System.EventHandler(this.btnProjectFileDefaultPath_Browse_Click);
            // 
            // txtProjectFileDefaultPath
            // 
            this.txtProjectFileDefaultPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtProjectFileDefaultPath.Location = new System.Drawing.Point(142, 19);
            this.txtProjectFileDefaultPath.Name = "txtProjectFileDefaultPath";
            this.txtProjectFileDefaultPath.Size = new System.Drawing.Size(475, 20);
            this.txtProjectFileDefaultPath.TabIndex = 1;
            // 
            // lblProjectFileDefaultPath
            // 
            this.lblProjectFileDefaultPath.AutoSize = true;
            this.lblProjectFileDefaultPath.Location = new System.Drawing.Point(6, 22);
            this.lblProjectFileDefaultPath.Name = "lblProjectFileDefaultPath";
            this.lblProjectFileDefaultPath.Size = new System.Drawing.Size(83, 13);
            this.lblProjectFileDefaultPath.TabIndex = 0;
            this.lblProjectFileDefaultPath.Text = "Standardordner:";
            // 
            // grbRecentFiles
            // 
            this.grbRecentFiles.Controls.Add(this.btnRecentFilesClear);
            this.grbRecentFiles.Controls.Add(this.nudNumRecentFiles);
            this.grbRecentFiles.Controls.Add(this.lblNumRecentFiles);
            this.grbRecentFiles.Location = new System.Drawing.Point(12, 292);
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
            this.btnCheckFileAssociation.Location = new System.Drawing.Point(12, 346);
            this.btnCheckFileAssociation.Name = "btnCheckFileAssociation";
            this.btnCheckFileAssociation.Size = new System.Drawing.Size(134, 23);
            this.btnCheckFileAssociation.TabIndex = 5;
            this.btnCheckFileAssociation.Text = "Dateizuordnung prüfen";
            this.btnCheckFileAssociation.UseVisualStyleBackColor = true;
            this.btnCheckFileAssociation.Click += new System.EventHandler(this.btnCheckFileAssociation_Click);
            // 
            // btnSetDefaults
            // 
            this.btnSetDefaults.Location = new System.Drawing.Point(511, 346);
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
            this.grbAddTextToFiile.Location = new System.Drawing.Point(12, 112);
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
            // chkFileAssociationCheckAtStartup
            // 
            this.chkFileAssociationCheckAtStartup.AutoSize = true;
            this.chkFileAssociationCheckAtStartup.Location = new System.Drawing.Point(152, 350);
            this.chkFileAssociationCheckAtStartup.Name = "chkFileAssociationCheckAtStartup";
            this.chkFileAssociationCheckAtStartup.Size = new System.Drawing.Size(229, 17);
            this.chkFileAssociationCheckAtStartup.TabIndex = 6;
            this.chkFileAssociationCheckAtStartup.Text = "Dateizuordnung beim Programmstart prüfen";
            this.chkFileAssociationCheckAtStartup.UseVisualStyleBackColor = true;
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
            this.grbBillClassesTreeView.Location = new System.Drawing.Point(12, 163);
            this.grbBillClassesTreeView.Name = "grbBillClassesTreeView";
            this.grbBillClassesTreeView.Size = new System.Drawing.Size(185, 65);
            this.grbBillClassesTreeView.TabIndex = 2;
            this.grbBillClassesTreeView.TabStop = false;
            this.grbBillClassesTreeView.Text = "Kategorienbaum";
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
            // chkAppUpdateCheckAtStartUp
            // 
            this.chkAppUpdateCheckAtStartUp.AutoSize = true;
            this.chkAppUpdateCheckAtStartUp.Location = new System.Drawing.Point(12, 375);
            this.chkAppUpdateCheckAtStartUp.Name = "chkAppUpdateCheckAtStartUp";
            this.chkAppUpdateCheckAtStartUp.Size = new System.Drawing.Size(248, 17);
            this.chkAppUpdateCheckAtStartUp.TabIndex = 8;
            this.chkAppUpdateCheckAtStartUp.Text = "Auf neue Programmversionen beim Start prüfen";
            this.chkAppUpdateCheckAtStartUp.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(607, 398);
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
            this.grbScanDefault.Controls.Add(this.lblCropAreaSelectionWidth);
            this.grbScanDefault.Controls.Add(this.lblScanDefaultThreshold);
            this.grbScanDefault.Controls.Add(this.nudCropAreaSelectionWidth);
            this.grbScanDefault.Controls.Add(this.chkCropAreaAddRemoveWithMouseClick);
            this.grbScanDefault.Controls.Add(this.cboScanDefaultColorMode);
            this.grbScanDefault.Controls.Add(this.tbaScanDefaultThreshold);
            this.grbScanDefault.Controls.Add(this.lblFileModifyVolor);
            this.grbScanDefault.Controls.Add(this.lblScanDefaultResolution);
            this.grbScanDefault.Controls.Add(this.nudScanDefaultResolution);
            this.grbScanDefault.Location = new System.Drawing.Point(203, 163);
            this.grbScanDefault.Name = "grbScanDefault";
            this.grbScanDefault.Size = new System.Drawing.Size(508, 123);
            this.grbScanDefault.TabIndex = 3;
            this.grbScanDefault.TabStop = false;
            this.grbScanDefault.Text = "Standard Scaneinstellungen / Bildzuschneiden";
            // 
            // lblCropAreaSelectionWidth
            // 
            this.lblCropAreaSelectionWidth.AutoSize = true;
            this.lblCropAreaSelectionWidth.Location = new System.Drawing.Point(276, 99);
            this.lblCropAreaSelectionWidth.Name = "lblCropAreaSelectionWidth";
            this.lblCropAreaSelectionWidth.Size = new System.Drawing.Size(185, 13);
            this.lblCropAreaSelectionWidth.TabIndex = 7;
            this.lblCropAreaSelectionWidth.Text = "Auswahlbreite für Zuschneiderahmen:";
            // 
            // lblScanDefaultThreshold
            // 
            this.lblScanDefaultThreshold.AutoSize = true;
            this.lblScanDefaultThreshold.Location = new System.Drawing.Point(175, 46);
            this.lblScanDefaultThreshold.Name = "lblScanDefaultThreshold";
            this.lblScanDefaultThreshold.Size = new System.Drawing.Size(84, 13);
            this.lblScanDefaultThreshold.TabIndex = 4;
            this.lblScanDefaultThreshold.Text = "Schwellwert: {0}";
            // 
            // nudCropAreaSelectionWidth
            // 
            this.nudCropAreaSelectionWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudCropAreaSelectionWidth.Location = new System.Drawing.Point(467, 97);
            this.nudCropAreaSelectionWidth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudCropAreaSelectionWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCropAreaSelectionWidth.Name = "nudCropAreaSelectionWidth";
            this.nudCropAreaSelectionWidth.Size = new System.Drawing.Size(35, 20);
            this.nudCropAreaSelectionWidth.TabIndex = 8;
            this.nudCropAreaSelectionWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkCropAreaAddRemoveWithMouseClick
            // 
            this.chkCropAreaAddRemoveWithMouseClick.AutoSize = true;
            this.chkCropAreaAddRemoveWithMouseClick.Location = new System.Drawing.Point(6, 97);
            this.chkCropAreaAddRemoveWithMouseClick.Name = "chkCropAreaAddRemoveWithMouseClick";
            this.chkCropAreaAddRemoveWithMouseClick.Size = new System.Drawing.Size(222, 17);
            this.chkCropAreaAddRemoveWithMouseClick.TabIndex = 6;
            this.chkCropAreaAddRemoveWithMouseClick.Text = "Bild zuschneiden mit Mausklick aktivieren";
            this.chkCropAreaAddRemoveWithMouseClick.UseVisualStyleBackColor = true;
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
            this.cboScanDefaultColorMode.Location = new System.Drawing.Point(285, 19);
            this.cboScanDefaultColorMode.Name = "cboScanDefaultColorMode";
            this.cboScanDefaultColorMode.Size = new System.Drawing.Size(217, 21);
            this.cboScanDefaultColorMode.TabIndex = 3;
            this.cboScanDefaultColorMode.SelectedIndexChanged += new System.EventHandler(this.cboScanDefaultColorMode_SelectedIndexChanged);
            // 
            // tbaScanDefaultThreshold
            // 
            this.tbaScanDefaultThreshold.LargeChange = 10;
            this.tbaScanDefaultThreshold.Location = new System.Drawing.Point(285, 46);
            this.tbaScanDefaultThreshold.Maximum = 255;
            this.tbaScanDefaultThreshold.Name = "tbaScanDefaultThreshold";
            this.tbaScanDefaultThreshold.Size = new System.Drawing.Size(217, 45);
            this.tbaScanDefaultThreshold.TabIndex = 5;
            this.tbaScanDefaultThreshold.TickFrequency = 85;
            this.tbaScanDefaultThreshold.Value = 127;
            this.tbaScanDefaultThreshold.Scroll += new System.EventHandler(this.tbaScanDefaultThreshold_Scroll);
            // 
            // lblFileModifyVolor
            // 
            this.lblFileModifyVolor.AutoSize = true;
            this.lblFileModifyVolor.Location = new System.Drawing.Point(175, 22);
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
            this.ClientSize = new System.Drawing.Size(729, 434);
            this.Controls.Add(this.grbScanDefault);
            this.Controls.Add(this.chkAppUpdateCheckAtStartUp);
            this.Controls.Add(this.grbBillClassesTreeView);
            this.Controls.Add(this.chkFileAssociationCheckAtStartup);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudCropAreaSelectionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaScanDefaultThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanDefaultResolution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grbProjectFolder;
        private System.Windows.Forms.TextBox txtStartupDefaultFileOpen;
        private System.Windows.Forms.Label lblStartupDefaultFileOpen;
        private System.Windows.Forms.TextBox txtProjectFileDefaultPath;
        private System.Windows.Forms.Label lblProjectFileDefaultPath;
        private System.Windows.Forms.GroupBox grbRecentFiles;
        private System.Windows.Forms.Button btnStartupDefaultFileOpen_Browse;
        private System.Windows.Forms.Button btnProjectFileDefaultPath_Browse;
        private System.Windows.Forms.Button btnCheckFileAssociation;
        private System.Windows.Forms.Button btnProjectFileDefaultPath_Delete;
        private System.Windows.Forms.Button btnStartupDefaultFileOpen_Delete;
        private System.Windows.Forms.Button btnSetDefaults;
        private System.Windows.Forms.GroupBox grbAddTextToFiile;
        private System.Windows.Forms.Button btnRecentFilesClear;
        private System.Windows.Forms.NumericUpDown nudNumRecentFiles;
        private System.Windows.Forms.Label lblNumRecentFiles;
        private System.Windows.Forms.Label lblDateFormat;
        private System.Windows.Forms.TextBox txtDateFormat;
        private System.Windows.Forms.CheckBox chkFileAssociationCheckAtStartup;
        private System.Windows.Forms.ErrorProvider erpDateFormat;
        private System.Windows.Forms.Label lblDateFormatPreview;
        private System.Windows.Forms.GroupBox grbBillClassesTreeView;
        private System.Windows.Forms.CheckBox chkTreeViewBillClassesExpandAllDefault;
        private System.Windows.Forms.CheckBox chkTreeViewBillClassesAllowCollaps;
        private System.Windows.Forms.CheckBox chkAppUpdateCheckAtStartUp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbScanDefault;
        private System.Windows.Forms.Label lblScanDefaultResolution;
        private System.Windows.Forms.NumericUpDown nudScanDefaultResolution;
        private System.Windows.Forms.ComboBox cboScanDefaultColorMode;
        private System.Windows.Forms.Label lblFileModifyVolor;
        private System.Windows.Forms.Label lblScanDefaultThreshold;
        private System.Windows.Forms.TrackBar tbaScanDefaultThreshold;
        private System.Windows.Forms.CheckBox chkStartupDefaultLoadEmptyProject;
        private System.Windows.Forms.CheckBox chkCropAreaAddRemoveWithMouseClick;
        private System.Windows.Forms.Label lblCropAreaSelectionWidth;
        private System.Windows.Forms.NumericUpDown nudCropAreaSelectionWidth;
    }
}