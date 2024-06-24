namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    partial class ManageBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBill));
            this.tabInformation = new System.Windows.Forms.TabControl();
            this.tbpInformationGenerel = new System.Windows.Forms.TabPage();
            this.chkBillDisposed = new System.Windows.Forms.CheckBox();
            this.btnManageBillClasses = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.mtbExpidation = new System.Windows.Forms.MaskedTextBox();
            this.lblExpidation = new System.Windows.Forms.Label();
            this.lblBillClasses = new System.Windows.Forms.Label();
            this.txtCustomNumber = new System.Windows.Forms.TextBox();
            this.trvBillClasses = new System.Windows.Forms.TreeView();
            this.lblCustomNumber = new System.Windows.Forms.Label();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.lblBillNumber = new System.Windows.Forms.Label();
            this.tbpInformationDocument = new System.Windows.Forms.TabPage();
            this.btnFileRemove = new System.Windows.Forms.Button();
            this.grbFileData = new System.Windows.Forms.GroupBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.spcFilePreview = new System.Windows.Forms.SplitContainer();
            this.picFilePreview = new OLKI.Toolbox.Widgets.PictrueBoxCrop();
            this.prgFilePreview = new OLKI.Toolbox.Widgets.ReadOnlyPropertyGrid();
            this.btnFileSave = new System.Windows.Forms.Button();
            this.grbFileModify = new System.Windows.Forms.GroupBox();
            this.lblFileModifyReize = new System.Windows.Forms.Label();
            this.nudFileModifyResize = new System.Windows.Forms.NumericUpDown();
            this.btnFileModifyRotateRight = new System.Windows.Forms.Button();
            this.btnFileModifyRotateLeft = new System.Windows.Forms.Button();
            this.btnFileModifyCropUndo = new System.Windows.Forms.Button();
            this.lblFileModifyThreshold = new System.Windows.Forms.Label();
            this.lblFileModifyContrast = new System.Windows.Forms.Label();
            this.lblFileModifyBrightnes = new System.Windows.Forms.Label();
            this.btnFileModifyCrop = new System.Windows.Forms.Button();
            this.tbaFileModifyThreshold = new System.Windows.Forms.TrackBar();
            this.tbaFileModifyContrast = new System.Windows.Forms.TrackBar();
            this.tbaFileModifyBrightnes = new System.Windows.Forms.TrackBar();
            this.cboFileModifyColor = new System.Windows.Forms.ComboBox();
            this.lblFileModifyVolor = new System.Windows.Forms.Label();
            this.txtFileComment = new System.Windows.Forms.TextBox();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.txtFileTitle = new System.Windows.Forms.TextBox();
            this.lblFileTitle = new System.Windows.Forms.Label();
            this.tabFileSource = new System.Windows.Forms.TabControl();
            this.tbpFileSourceFile = new System.Windows.Forms.TabPage();
            this.lblOriginalFileName = new System.Windows.Forms.Label();
            this.btnFileAttech = new System.Windows.Forms.Button();
            this.btnFileBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.tbpFileSourceScan = new System.Windows.Forms.TabPage();
            this.nudFileScanResolution = new System.Windows.Forms.NumericUpDown();
            this.btnFileScan = new System.Windows.Forms.Button();
            this.lblFileScanResolution = new System.Windows.Forms.Label();
            this.cboFileScanDevice = new System.Windows.Forms.ComboBox();
            this.lblFileScanDevice = new System.Windows.Forms.Label();
            this.tbpFileSourceLink = new System.Windows.Forms.TabPage();
            this.lblFileLinkNote = new System.Windows.Forms.Label();
            this.btnFileLinkBrowse = new System.Windows.Forms.Button();
            this.txtFileLinkPath = new System.Windows.Forms.TextBox();
            this.lblFileLinkPath = new System.Windows.Forms.Label();
            this.imlTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblFileComment = new System.Windows.Forms.Label();
            this.btnFileAdd = new System.Windows.Forms.Button();
            this.lsvFiles = new OLKI.Toolbox.Widgets.SortListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpInformationInvoiceItems = new System.Windows.Forms.TabPage();
            this.lblInvoiceItemsTotalPrice = new System.Windows.Forms.Label();
            this.txtInvoiceItemsTotalPrice = new System.Windows.Forms.TextBox();
            this.btnInvoiceItemImport = new System.Windows.Forms.Button();
            this.prgInvoiceItemProperty = new System.Windows.Forms.PropertyGrid();
            this.btnInvoiceItemRemove = new System.Windows.Forms.Button();
            this.btnInvoiceItemAdd = new System.Windows.Forms.Button();
            this.lsvInvoiceItems = new OLKI.Toolbox.Widgets.SortListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblOrgFileLocation = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.txtOrgFileLocation = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.mtbDate = new System.Windows.Forms.MaskedTextBox();
            this.erpMannageBill = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnManageCompanies = new System.Windows.Forms.Button();
            this.tabInformation.SuspendLayout();
            this.tbpInformationGenerel.SuspendLayout();
            this.tbpInformationDocument.SuspendLayout();
            this.grbFileData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcFilePreview)).BeginInit();
            this.spcFilePreview.Panel1.SuspendLayout();
            this.spcFilePreview.Panel2.SuspendLayout();
            this.spcFilePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilePreview)).BeginInit();
            this.grbFileModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileModifyResize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyBrightnes)).BeginInit();
            this.tabFileSource.SuspendLayout();
            this.tbpFileSourceFile.SuspendLayout();
            this.tbpFileSourceScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileScanResolution)).BeginInit();
            this.tbpFileSourceLink.SuspendLayout();
            this.tbpInformationInvoiceItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpMannageBill)).BeginInit();
            this.SuspendLayout();
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.tbpInformationGenerel);
            this.tabInformation.Controls.Add(this.tbpInformationDocument);
            this.tabInformation.Controls.Add(this.tbpInformationInvoiceItems);
            this.tabInformation.ImageList = this.imlTabIcons;
            this.tabInformation.Location = new System.Drawing.Point(12, 66);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.SelectedIndex = 0;
            this.tabInformation.Size = new System.Drawing.Size(868, 510);
            this.tabInformation.TabIndex = 9;
            // 
            // tbpInformationGenerel
            // 
            this.tbpInformationGenerel.Controls.Add(this.chkBillDisposed);
            this.tbpInformationGenerel.Controls.Add(this.btnManageBillClasses);
            this.tbpInformationGenerel.Controls.Add(this.lblComment);
            this.tbpInformationGenerel.Controls.Add(this.txtComment);
            this.tbpInformationGenerel.Controls.Add(this.mtbExpidation);
            this.tbpInformationGenerel.Controls.Add(this.lblExpidation);
            this.tbpInformationGenerel.Controls.Add(this.lblBillClasses);
            this.tbpInformationGenerel.Controls.Add(this.txtCustomNumber);
            this.tbpInformationGenerel.Controls.Add(this.trvBillClasses);
            this.tbpInformationGenerel.Controls.Add(this.lblCustomNumber);
            this.tbpInformationGenerel.Controls.Add(this.txtBillNumber);
            this.tbpInformationGenerel.Controls.Add(this.lblBillNumber);
            this.tbpInformationGenerel.ImageKey = "Properties.png";
            this.tbpInformationGenerel.Location = new System.Drawing.Point(4, 23);
            this.tbpInformationGenerel.Name = "tbpInformationGenerel";
            this.tbpInformationGenerel.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInformationGenerel.Size = new System.Drawing.Size(860, 483);
            this.tbpInformationGenerel.TabIndex = 0;
            this.tbpInformationGenerel.Text = "Allgemeines";
            // 
            // chkBillDisposed
            // 
            this.chkBillDisposed.AutoSize = true;
            this.chkBillDisposed.Location = new System.Drawing.Point(342, 60);
            this.chkBillDisposed.Name = "chkBillDisposed";
            this.chkBillDisposed.Size = new System.Drawing.Size(117, 17);
            this.chkBillDisposed.TabIndex = 6;
            this.chkBillDisposed.Text = "Rechnung entsorgt";
            this.chkBillDisposed.UseVisualStyleBackColor = true;
            this.chkBillDisposed.CheckedChanged += new System.EventHandler(this.chkBillDisposed_CheckedChanged);
            // 
            // btnManageBillClasses
            // 
            this.btnManageBillClasses.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Class;
            this.btnManageBillClasses.Location = new System.Drawing.Point(77, 84);
            this.btnManageBillClasses.Name = "btnManageBillClasses";
            this.btnManageBillClasses.Size = new System.Drawing.Size(37, 24);
            this.btnManageBillClasses.TabIndex = 8;
            this.btnManageBillClasses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageBillClasses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageBillClasses.UseVisualStyleBackColor = true;
            this.btnManageBillClasses.Click += new System.EventHandler(this.btnManageBillClasses_Click);
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(465, 9);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(100, 23);
            this.lblComment.TabIndex = 10;
            this.lblComment.Text = "Kommentar";
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtComment.Location = new System.Drawing.Point(465, 32);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(389, 445);
            this.txtComment.TabIndex = 11;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // mtbExpidation
            // 
            this.mtbExpidation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbExpidation.Location = new System.Drawing.Point(120, 58);
            this.mtbExpidation.Mask = "00/00/0000";
            this.mtbExpidation.Name = "mtbExpidation";
            this.mtbExpidation.Size = new System.Drawing.Size(80, 20);
            this.mtbExpidation.TabIndex = 5;
            this.mtbExpidation.ValidatingType = typeof(System.DateTime);
            this.mtbExpidation.TextChanged += new System.EventHandler(this.mtbExpidation_TextChanged);
            // 
            // lblExpidation
            // 
            this.lblExpidation.Location = new System.Drawing.Point(6, 61);
            this.lblExpidation.Name = "lblExpidation";
            this.lblExpidation.Size = new System.Drawing.Size(114, 23);
            this.lblExpidation.TabIndex = 4;
            this.lblExpidation.Text = "Relevant bis:";
            // 
            // lblBillClasses
            // 
            this.lblBillClasses.Location = new System.Drawing.Point(6, 84);
            this.lblBillClasses.Name = "lblBillClasses";
            this.lblBillClasses.Size = new System.Drawing.Size(100, 23);
            this.lblBillClasses.TabIndex = 7;
            this.lblBillClasses.Text = "Kategorie:";
            // 
            // txtCustomNumber
            // 
            this.txtCustomNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCustomNumber.Location = new System.Drawing.Point(120, 32);
            this.txtCustomNumber.Name = "txtCustomNumber";
            this.txtCustomNumber.Size = new System.Drawing.Size(339, 20);
            this.txtCustomNumber.TabIndex = 3;
            this.txtCustomNumber.TextChanged += new System.EventHandler(this.txtCustomNumber_TextChanged);
            // 
            // trvBillClasses
            // 
            this.trvBillClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trvBillClasses.HideSelection = false;
            this.trvBillClasses.Location = new System.Drawing.Point(120, 84);
            this.trvBillClasses.Name = "trvBillClasses";
            this.trvBillClasses.Size = new System.Drawing.Size(339, 393);
            this.trvBillClasses.TabIndex = 9;
            this.trvBillClasses.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBillClasses_BeforeCollapse);
            this.trvBillClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvBillClasses_AfterSelect);
            this.trvBillClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvBillClasses_MouseDown);
            // 
            // lblCustomNumber
            // 
            this.lblCustomNumber.Location = new System.Drawing.Point(6, 35);
            this.lblCustomNumber.Name = "lblCustomNumber";
            this.lblCustomNumber.Size = new System.Drawing.Size(114, 23);
            this.lblCustomNumber.TabIndex = 2;
            this.lblCustomNumber.Text = "Kunde Nummer:";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBillNumber.Location = new System.Drawing.Point(120, 6);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.Size = new System.Drawing.Size(339, 20);
            this.txtBillNumber.TabIndex = 1;
            this.txtBillNumber.TextChanged += new System.EventHandler(this.txtBillNumber_TextChanged);
            // 
            // lblBillNumber
            // 
            this.lblBillNumber.Location = new System.Drawing.Point(6, 9);
            this.lblBillNumber.Name = "lblBillNumber";
            this.lblBillNumber.Size = new System.Drawing.Size(114, 23);
            this.lblBillNumber.TabIndex = 0;
            this.lblBillNumber.Text = "Rechnung Nummer:";
            // 
            // tbpInformationDocument
            // 
            this.tbpInformationDocument.Controls.Add(this.btnFileRemove);
            this.tbpInformationDocument.Controls.Add(this.grbFileData);
            this.tbpInformationDocument.Controls.Add(this.btnFileAdd);
            this.tbpInformationDocument.Controls.Add(this.lsvFiles);
            this.tbpInformationDocument.ImageKey = "File.png";
            this.tbpInformationDocument.Location = new System.Drawing.Point(4, 23);
            this.tbpInformationDocument.Name = "tbpInformationDocument";
            this.tbpInformationDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInformationDocument.Size = new System.Drawing.Size(860, 483);
            this.tbpInformationDocument.TabIndex = 1;
            this.tbpInformationDocument.Text = "Dokumente";
            // 
            // btnFileRemove
            // 
            this.btnFileRemove.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Delete;
            this.btnFileRemove.Location = new System.Drawing.Point(112, 6);
            this.btnFileRemove.Name = "btnFileRemove";
            this.btnFileRemove.Size = new System.Drawing.Size(100, 24);
            this.btnFileRemove.TabIndex = 1;
            this.btnFileRemove.Text = "Löschen";
            this.btnFileRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileRemove.UseVisualStyleBackColor = true;
            this.btnFileRemove.Click += new System.EventHandler(this.btnFileRemove_Click);
            // 
            // grbFileData
            // 
            this.grbFileData.Controls.Add(this.lblFileSize);
            this.grbFileData.Controls.Add(this.spcFilePreview);
            this.grbFileData.Controls.Add(this.btnFileSave);
            this.grbFileData.Controls.Add(this.grbFileModify);
            this.grbFileData.Controls.Add(this.txtFileComment);
            this.grbFileData.Controls.Add(this.btnFileOpen);
            this.grbFileData.Controls.Add(this.txtFileTitle);
            this.grbFileData.Controls.Add(this.lblFileTitle);
            this.grbFileData.Controls.Add(this.tabFileSource);
            this.grbFileData.Controls.Add(this.lblFileComment);
            this.grbFileData.Location = new System.Drawing.Point(218, 6);
            this.grbFileData.Name = "grbFileData";
            this.grbFileData.Size = new System.Drawing.Size(636, 471);
            this.grbFileData.TabIndex = 3;
            this.grbFileData.TabStop = false;
            this.grbFileData.Text = "Dokument";
            // 
            // lblFileSize
            // 
            this.lblFileSize.Location = new System.Drawing.Point(355, 425);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(275, 13);
            this.lblFileSize.TabIndex = 12;
            this.lblFileSize.Text = "Größe: {0}";
            // 
            // spcFilePreview
            // 
            this.spcFilePreview.Location = new System.Drawing.Point(355, 19);
            this.spcFilePreview.Name = "spcFilePreview";
            this.spcFilePreview.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcFilePreview.Panel1
            // 
            this.spcFilePreview.Panel1.Controls.Add(this.picFilePreview);
            this.spcFilePreview.Panel1MinSize = 260;
            // 
            // spcFilePreview.Panel2
            // 
            this.spcFilePreview.Panel2.Controls.Add(this.prgFilePreview);
            this.spcFilePreview.Panel2MinSize = 0;
            this.spcFilePreview.Size = new System.Drawing.Size(275, 403);
            this.spcFilePreview.SplitterDistance = 260;
            this.spcFilePreview.TabIndex = 11;
            // 
            // picFilePreview
            // 
            this.picFilePreview.AddRemoveCropAreaWithMouseClick = false;
            this.picFilePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFilePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFilePreview.Image = null;
            this.picFilePreview.InitialCropSize = new System.Drawing.Size(100, 100);
            this.picFilePreview.Location = new System.Drawing.Point(0, 0);
            this.picFilePreview.Name = "picFilePreview";
            this.picFilePreview.Size = new System.Drawing.Size(275, 260);
            this.picFilePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFilePreview.TabIndex = 3;
            this.picFilePreview.TabStop = false;
            this.picFilePreview.DoubleClick += new System.EventHandler(this.picFilePreview_DoubleClick);
            // 
            // prgFilePreview
            // 
            this.prgFilePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgFilePreview.HelpVisible = false;
            this.prgFilePreview.Location = new System.Drawing.Point(0, 0);
            this.prgFilePreview.Name = "prgFilePreview";
            this.prgFilePreview.ReadOnly = true;
            this.prgFilePreview.Size = new System.Drawing.Size(275, 139);
            this.prgFilePreview.TabIndex = 11;
            this.prgFilePreview.ToolbarVisible = false;
            this.prgFilePreview.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnFileSave
            // 
            this.btnFileSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSave.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Save;
            this.btnFileSave.Location = new System.Drawing.Point(530, 441);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(100, 24);
            this.btnFileSave.TabIndex = 8;
            this.btnFileSave.Text = "Speichern";
            this.btnFileSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileSave.UseVisualStyleBackColor = true;
            this.btnFileSave.Click += new System.EventHandler(this.btnFileSave_Click);
            // 
            // grbFileModify
            // 
            this.grbFileModify.Controls.Add(this.lblFileModifyReize);
            this.grbFileModify.Controls.Add(this.nudFileModifyResize);
            this.grbFileModify.Controls.Add(this.btnFileModifyRotateRight);
            this.grbFileModify.Controls.Add(this.btnFileModifyRotateLeft);
            this.grbFileModify.Controls.Add(this.btnFileModifyCropUndo);
            this.grbFileModify.Controls.Add(this.lblFileModifyThreshold);
            this.grbFileModify.Controls.Add(this.lblFileModifyContrast);
            this.grbFileModify.Controls.Add(this.lblFileModifyBrightnes);
            this.grbFileModify.Controls.Add(this.btnFileModifyCrop);
            this.grbFileModify.Controls.Add(this.tbaFileModifyThreshold);
            this.grbFileModify.Controls.Add(this.tbaFileModifyContrast);
            this.grbFileModify.Controls.Add(this.tbaFileModifyBrightnes);
            this.grbFileModify.Controls.Add(this.cboFileModifyColor);
            this.grbFileModify.Controls.Add(this.lblFileModifyVolor);
            this.grbFileModify.Location = new System.Drawing.Point(6, 163);
            this.grbFileModify.Name = "grbFileModify";
            this.grbFileModify.Size = new System.Drawing.Size(343, 229);
            this.grbFileModify.TabIndex = 3;
            this.grbFileModify.TabStop = false;
            this.grbFileModify.Text = "Bild bearbeiten";
            // 
            // lblFileModifyReize
            // 
            this.lblFileModifyReize.AutoSize = true;
            this.lblFileModifyReize.Location = new System.Drawing.Point(88, 205);
            this.lblFileModifyReize.Name = "lblFileModifyReize";
            this.lblFileModifyReize.Size = new System.Drawing.Size(56, 13);
            this.lblFileModifyReize.TabIndex = 10;
            this.lblFileModifyReize.Text = "Größe (%):";
            // 
            // nudFileModifyResize
            // 
            this.nudFileModifyResize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudFileModifyResize.Location = new System.Drawing.Point(150, 203);
            this.nudFileModifyResize.Name = "nudFileModifyResize";
            this.nudFileModifyResize.Size = new System.Drawing.Size(43, 20);
            this.nudFileModifyResize.TabIndex = 11;
            this.nudFileModifyResize.ThousandsSeparator = true;
            this.nudFileModifyResize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudFileModifyResize.ValueChanged += new System.EventHandler(this.nudFileModifyResize_ValueChanged);
            // 
            // btnFileModifyRotateRight
            // 
            this.btnFileModifyRotateRight.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.RotateRight;
            this.btnFileModifyRotateRight.Location = new System.Drawing.Point(47, 199);
            this.btnFileModifyRotateRight.Name = "btnFileModifyRotateRight";
            this.btnFileModifyRotateRight.Size = new System.Drawing.Size(35, 24);
            this.btnFileModifyRotateRight.TabIndex = 9;
            this.btnFileModifyRotateRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileModifyRotateRight.UseVisualStyleBackColor = true;
            this.btnFileModifyRotateRight.Click += new System.EventHandler(this.btnFileModifyRotateRight_Click);
            // 
            // btnFileModifyRotateLeft
            // 
            this.btnFileModifyRotateLeft.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.RotateLeft;
            this.btnFileModifyRotateLeft.Location = new System.Drawing.Point(6, 199);
            this.btnFileModifyRotateLeft.Name = "btnFileModifyRotateLeft";
            this.btnFileModifyRotateLeft.Size = new System.Drawing.Size(35, 24);
            this.btnFileModifyRotateLeft.TabIndex = 8;
            this.btnFileModifyRotateLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileModifyRotateLeft.UseVisualStyleBackColor = true;
            this.btnFileModifyRotateLeft.Click += new System.EventHandler(this.btnFileModifyRotateLeft_Click);
            // 
            // btnFileModifyCropUndo
            // 
            this.btnFileModifyCropUndo.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Undo;
            this.btnFileModifyCropUndo.Location = new System.Drawing.Point(302, 199);
            this.btnFileModifyCropUndo.Name = "btnFileModifyCropUndo";
            this.btnFileModifyCropUndo.Size = new System.Drawing.Size(35, 24);
            this.btnFileModifyCropUndo.TabIndex = 13;
            this.btnFileModifyCropUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileModifyCropUndo.UseVisualStyleBackColor = true;
            this.btnFileModifyCropUndo.Click += new System.EventHandler(this.btnFileModifyCropUndo_Click);
            // 
            // lblFileModifyThreshold
            // 
            this.lblFileModifyThreshold.AutoSize = true;
            this.lblFileModifyThreshold.Location = new System.Drawing.Point(6, 148);
            this.lblFileModifyThreshold.Name = "lblFileModifyThreshold";
            this.lblFileModifyThreshold.Size = new System.Drawing.Size(84, 13);
            this.lblFileModifyThreshold.TabIndex = 6;
            this.lblFileModifyThreshold.Text = "Schwellwert: {0}";
            // 
            // lblFileModifyContrast
            // 
            this.lblFileModifyContrast.AutoSize = true;
            this.lblFileModifyContrast.Location = new System.Drawing.Point(6, 70);
            this.lblFileModifyContrast.Name = "lblFileModifyContrast";
            this.lblFileModifyContrast.Size = new System.Drawing.Size(66, 13);
            this.lblFileModifyContrast.TabIndex = 4;
            this.lblFileModifyContrast.Text = "Kontrast: {0}";
            // 
            // lblFileModifyBrightnes
            // 
            this.lblFileModifyBrightnes.AutoSize = true;
            this.lblFileModifyBrightnes.Location = new System.Drawing.Point(6, 19);
            this.lblFileModifyBrightnes.Name = "lblFileModifyBrightnes";
            this.lblFileModifyBrightnes.Size = new System.Drawing.Size(70, 13);
            this.lblFileModifyBrightnes.TabIndex = 2;
            this.lblFileModifyBrightnes.Text = "Helligkeit: {0}";
            // 
            // btnFileModifyCrop
            // 
            this.btnFileModifyCrop.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Crop;
            this.btnFileModifyCrop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileModifyCrop.Location = new System.Drawing.Point(199, 199);
            this.btnFileModifyCrop.Name = "btnFileModifyCrop";
            this.btnFileModifyCrop.Size = new System.Drawing.Size(97, 24);
            this.btnFileModifyCrop.TabIndex = 12;
            this.btnFileModifyCrop.Text = "Zuschneiden";
            this.btnFileModifyCrop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileModifyCrop.UseVisualStyleBackColor = true;
            this.btnFileModifyCrop.Click += new System.EventHandler(this.btnFileModifyCrop_Click);
            // 
            // tbaFileModifyThreshold
            // 
            this.tbaFileModifyThreshold.LargeChange = 10;
            this.tbaFileModifyThreshold.Location = new System.Drawing.Point(116, 148);
            this.tbaFileModifyThreshold.Maximum = 255;
            this.tbaFileModifyThreshold.Name = "tbaFileModifyThreshold";
            this.tbaFileModifyThreshold.Size = new System.Drawing.Size(217, 45);
            this.tbaFileModifyThreshold.TabIndex = 7;
            this.tbaFileModifyThreshold.TickFrequency = 85;
            this.tbaFileModifyThreshold.Value = 127;
            this.tbaFileModifyThreshold.Scroll += new System.EventHandler(this.tbaFileModifyThreshold_Scroll);
            this.tbaFileModifyThreshold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbaFileModifyThreshold_MouseDown);
            // 
            // tbaFileModifyContrast
            // 
            this.tbaFileModifyContrast.LargeChange = 10;
            this.tbaFileModifyContrast.Location = new System.Drawing.Point(116, 70);
            this.tbaFileModifyContrast.Maximum = 100;
            this.tbaFileModifyContrast.Minimum = -100;
            this.tbaFileModifyContrast.Name = "tbaFileModifyContrast";
            this.tbaFileModifyContrast.Size = new System.Drawing.Size(217, 45);
            this.tbaFileModifyContrast.TabIndex = 5;
            this.tbaFileModifyContrast.TickFrequency = 25;
            this.tbaFileModifyContrast.Scroll += new System.EventHandler(this.tbaFileModifyContrast_Scroll);
            this.tbaFileModifyContrast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbaFileModifyContrast_MouseDown);
            // 
            // tbaFileModifyBrightnes
            // 
            this.tbaFileModifyBrightnes.LargeChange = 10;
            this.tbaFileModifyBrightnes.Location = new System.Drawing.Point(116, 19);
            this.tbaFileModifyBrightnes.Maximum = 255;
            this.tbaFileModifyBrightnes.Minimum = -255;
            this.tbaFileModifyBrightnes.Name = "tbaFileModifyBrightnes";
            this.tbaFileModifyBrightnes.Size = new System.Drawing.Size(217, 45);
            this.tbaFileModifyBrightnes.TabIndex = 3;
            this.tbaFileModifyBrightnes.TickFrequency = 85;
            this.tbaFileModifyBrightnes.Scroll += new System.EventHandler(this.tbaFileModifyBrightnes_Scroll);
            this.tbaFileModifyBrightnes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbaFileModifyBrightnes_MouseDown);
            // 
            // cboFileModifyColor
            // 
            this.cboFileModifyColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboFileModifyColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileModifyColor.FormattingEnabled = true;
            this.cboFileModifyColor.Items.AddRange(new object[] {
            "Farbe",
            "Graustufen",
            "Schwarz Weiiß"});
            this.cboFileModifyColor.Location = new System.Drawing.Point(120, 121);
            this.cboFileModifyColor.Name = "cboFileModifyColor";
            this.cboFileModifyColor.Size = new System.Drawing.Size(217, 21);
            this.cboFileModifyColor.TabIndex = 1;
            this.cboFileModifyColor.SelectedIndexChanged += new System.EventHandler(this.cboFileModifyColor_SelectedIndexChanged);
            // 
            // lblFileModifyVolor
            // 
            this.lblFileModifyVolor.AutoSize = true;
            this.lblFileModifyVolor.Location = new System.Drawing.Point(6, 124);
            this.lblFileModifyVolor.Name = "lblFileModifyVolor";
            this.lblFileModifyVolor.Size = new System.Drawing.Size(37, 13);
            this.lblFileModifyVolor.TabIndex = 0;
            this.lblFileModifyVolor.Text = "Farbe:";
            // 
            // txtFileComment
            // 
            this.txtFileComment.AcceptsReturn = true;
            this.txtFileComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFileComment.Location = new System.Drawing.Point(6, 411);
            this.txtFileComment.Multiline = true;
            this.txtFileComment.Name = "txtFileComment";
            this.txtFileComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileComment.Size = new System.Drawing.Size(343, 54);
            this.txtFileComment.TabIndex = 5;
            this.txtFileComment.TextChanged += new System.EventHandler(this.txtFileComment_TextChanged);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FileOpen;
            this.btnFileOpen.Location = new System.Drawing.Point(355, 441);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(169, 24);
            this.btnFileOpen.TabIndex = 7;
            this.btnFileOpen.Text = "Dokument öffnen";
            this.btnFileOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // txtFileTitle
            // 
            this.txtFileTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFileTitle.Location = new System.Drawing.Point(50, 19);
            this.txtFileTitle.Name = "txtFileTitle";
            this.txtFileTitle.Size = new System.Drawing.Size(299, 20);
            this.txtFileTitle.TabIndex = 1;
            this.txtFileTitle.TextChanged += new System.EventHandler(this.txtFileTitle_TextChanged);
            // 
            // lblFileTitle
            // 
            this.lblFileTitle.AutoSize = true;
            this.lblFileTitle.Location = new System.Drawing.Point(3, 22);
            this.lblFileTitle.Name = "lblFileTitle";
            this.lblFileTitle.Size = new System.Drawing.Size(38, 13);
            this.lblFileTitle.TabIndex = 0;
            this.lblFileTitle.Text = "Name:";
            // 
            // tabFileSource
            // 
            this.tabFileSource.Controls.Add(this.tbpFileSourceFile);
            this.tabFileSource.Controls.Add(this.tbpFileSourceScan);
            this.tabFileSource.Controls.Add(this.tbpFileSourceLink);
            this.tabFileSource.ImageList = this.imlTabIcons;
            this.tabFileSource.Location = new System.Drawing.Point(6, 45);
            this.tabFileSource.Name = "tabFileSource";
            this.tabFileSource.SelectedIndex = 0;
            this.tabFileSource.Size = new System.Drawing.Size(343, 116);
            this.tabFileSource.TabIndex = 2;
            // 
            // tbpFileSourceFile
            // 
            this.tbpFileSourceFile.Controls.Add(this.lblOriginalFileName);
            this.tbpFileSourceFile.Controls.Add(this.btnFileAttech);
            this.tbpFileSourceFile.Controls.Add(this.btnFileBrowse);
            this.tbpFileSourceFile.Controls.Add(this.txtFilePath);
            this.tbpFileSourceFile.Controls.Add(this.lblFilePath);
            this.tbpFileSourceFile.ImageKey = "File.png";
            this.tbpFileSourceFile.Location = new System.Drawing.Point(4, 23);
            this.tbpFileSourceFile.Name = "tbpFileSourceFile";
            this.tbpFileSourceFile.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFileSourceFile.Size = new System.Drawing.Size(335, 89);
            this.tbpFileSourceFile.TabIndex = 0;
            this.tbpFileSourceFile.Text = "Von Datei";
            // 
            // lblOriginalFileName
            // 
            this.lblOriginalFileName.Location = new System.Drawing.Point(6, 32);
            this.lblOriginalFileName.Name = "lblOriginalFileName";
            this.lblOriginalFileName.Size = new System.Drawing.Size(323, 13);
            this.lblOriginalFileName.TabIndex = 4;
            this.lblOriginalFileName.Text = "lblOriginalFileName";
            // 
            // btnFileAttech
            // 
            this.btnFileAttech.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FileOpen;
            this.btnFileAttech.Location = new System.Drawing.Point(112, 60);
            this.btnFileAttech.Name = "btnFileAttech";
            this.btnFileAttech.Size = new System.Drawing.Size(217, 24);
            this.btnFileAttech.TabIndex = 3;
            this.btnFileAttech.Text = "Datei(n) anhängen";
            this.btnFileAttech.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileAttech.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileAttech.UseVisualStyleBackColor = true;
            this.btnFileAttech.Click += new System.EventHandler(this.btnFileAttech_Click);
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Open;
            this.btnFileBrowse.Location = new System.Drawing.Point(229, 6);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(100, 24);
            this.btnFileBrowse.TabIndex = 2;
            this.btnFileBrowse.Text = "Durchsuchen";
            this.btnFileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileBrowse.UseVisualStyleBackColor = true;
            this.btnFileBrowse.Click += new System.EventHandler(this.btnFileBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFilePath.Location = new System.Drawing.Point(47, 9);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(176, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(6, 12);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(35, 13);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "Datei:";
            // 
            // tbpFileSourceScan
            // 
            this.tbpFileSourceScan.Controls.Add(this.nudFileScanResolution);
            this.tbpFileSourceScan.Controls.Add(this.btnFileScan);
            this.tbpFileSourceScan.Controls.Add(this.lblFileScanResolution);
            this.tbpFileSourceScan.Controls.Add(this.cboFileScanDevice);
            this.tbpFileSourceScan.Controls.Add(this.lblFileScanDevice);
            this.tbpFileSourceScan.ImageKey = "Scanner.png";
            this.tbpFileSourceScan.Location = new System.Drawing.Point(4, 23);
            this.tbpFileSourceScan.Name = "tbpFileSourceScan";
            this.tbpFileSourceScan.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFileSourceScan.Size = new System.Drawing.Size(335, 89);
            this.tbpFileSourceScan.TabIndex = 1;
            this.tbpFileSourceScan.Text = "Von Scanner";
            // 
            // nudFileScanResolution
            // 
            this.nudFileScanResolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudFileScanResolution.Location = new System.Drawing.Point(112, 33);
            this.nudFileScanResolution.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudFileScanResolution.Name = "nudFileScanResolution";
            this.nudFileScanResolution.Size = new System.Drawing.Size(217, 20);
            this.nudFileScanResolution.TabIndex = 3;
            this.nudFileScanResolution.ThousandsSeparator = true;
            this.nudFileScanResolution.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnFileScan
            // 
            this.btnFileScan.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Scanner;
            this.btnFileScan.Location = new System.Drawing.Point(112, 59);
            this.btnFileScan.Name = "btnFileScan";
            this.btnFileScan.Size = new System.Drawing.Size(217, 24);
            this.btnFileScan.TabIndex = 4;
            this.btnFileScan.Text = "Scannen";
            this.btnFileScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileScan.UseVisualStyleBackColor = true;
            this.btnFileScan.Click += new System.EventHandler(this.btnFileScan_Click);
            // 
            // lblFileScanResolution
            // 
            this.lblFileScanResolution.AutoSize = true;
            this.lblFileScanResolution.Location = new System.Drawing.Point(6, 35);
            this.lblFileScanResolution.Name = "lblFileScanResolution";
            this.lblFileScanResolution.Size = new System.Drawing.Size(57, 13);
            this.lblFileScanResolution.TabIndex = 2;
            this.lblFileScanResolution.Text = "Auflösung:";
            // 
            // cboFileScanDevice
            // 
            this.cboFileScanDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboFileScanDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFileScanDevice.FormattingEnabled = true;
            this.cboFileScanDevice.Location = new System.Drawing.Point(112, 6);
            this.cboFileScanDevice.Name = "cboFileScanDevice";
            this.cboFileScanDevice.Size = new System.Drawing.Size(217, 21);
            this.cboFileScanDevice.TabIndex = 1;
            // 
            // lblFileScanDevice
            // 
            this.lblFileScanDevice.AutoSize = true;
            this.lblFileScanDevice.Location = new System.Drawing.Point(6, 9);
            this.lblFileScanDevice.Name = "lblFileScanDevice";
            this.lblFileScanDevice.Size = new System.Drawing.Size(50, 13);
            this.lblFileScanDevice.TabIndex = 0;
            this.lblFileScanDevice.Text = "Scanner:";
            // 
            // tbpFileSourceLink
            // 
            this.tbpFileSourceLink.Controls.Add(this.lblFileLinkNote);
            this.tbpFileSourceLink.Controls.Add(this.btnFileLinkBrowse);
            this.tbpFileSourceLink.Controls.Add(this.txtFileLinkPath);
            this.tbpFileSourceLink.Controls.Add(this.lblFileLinkPath);
            this.tbpFileSourceLink.ImageKey = "Link.png";
            this.tbpFileSourceLink.Location = new System.Drawing.Point(4, 23);
            this.tbpFileSourceLink.Name = "tbpFileSourceLink";
            this.tbpFileSourceLink.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFileSourceLink.Size = new System.Drawing.Size(335, 89);
            this.tbpFileSourceLink.TabIndex = 2;
            this.tbpFileSourceLink.Text = "Verknüpfung";
            // 
            // lblFileLinkNote
            // 
            this.lblFileLinkNote.Location = new System.Drawing.Point(6, 32);
            this.lblFileLinkNote.Name = "lblFileLinkNote";
            this.lblFileLinkNote.Size = new System.Drawing.Size(323, 54);
            this.lblFileLinkNote.TabIndex = 6;
            this.lblFileLinkNote.Text = "ACHTUNG: Wird die original Datei gelöscht kann sie nicht mehr geöffnet werden.";
            // 
            // btnFileLinkBrowse
            // 
            this.btnFileLinkBrowse.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Open;
            this.btnFileLinkBrowse.Location = new System.Drawing.Point(229, 6);
            this.btnFileLinkBrowse.Name = "btnFileLinkBrowse";
            this.btnFileLinkBrowse.Size = new System.Drawing.Size(100, 24);
            this.btnFileLinkBrowse.TabIndex = 5;
            this.btnFileLinkBrowse.Text = "Durchsuchen";
            this.btnFileLinkBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileLinkBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileLinkBrowse.UseVisualStyleBackColor = true;
            this.btnFileLinkBrowse.Click += new System.EventHandler(this.btnFileLinkBrowse_Click);
            // 
            // txtFileLinkPath
            // 
            this.txtFileLinkPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFileLinkPath.Enabled = false;
            this.txtFileLinkPath.Location = new System.Drawing.Point(47, 9);
            this.txtFileLinkPath.Name = "txtFileLinkPath";
            this.txtFileLinkPath.Size = new System.Drawing.Size(176, 20);
            this.txtFileLinkPath.TabIndex = 4;
            // 
            // lblFileLinkPath
            // 
            this.lblFileLinkPath.AutoSize = true;
            this.lblFileLinkPath.Location = new System.Drawing.Point(6, 12);
            this.lblFileLinkPath.Name = "lblFileLinkPath";
            this.lblFileLinkPath.Size = new System.Drawing.Size(35, 13);
            this.lblFileLinkPath.TabIndex = 3;
            this.lblFileLinkPath.Text = "Datei:";
            // 
            // imlTabIcons
            // 
            this.imlTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTabIcons.ImageStream")));
            this.imlTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTabIcons.Images.SetKeyName(0, "File.png");
            this.imlTabIcons.Images.SetKeyName(1, "Properties.png");
            this.imlTabIcons.Images.SetKeyName(2, "Comment.png");
            this.imlTabIcons.Images.SetKeyName(3, "List.png");
            this.imlTabIcons.Images.SetKeyName(4, "Scanner.png");
            this.imlTabIcons.Images.SetKeyName(5, "Link.png");
            // 
            // lblFileComment
            // 
            this.lblFileComment.AutoSize = true;
            this.lblFileComment.Location = new System.Drawing.Point(7, 395);
            this.lblFileComment.Name = "lblFileComment";
            this.lblFileComment.Size = new System.Drawing.Size(63, 13);
            this.lblFileComment.TabIndex = 4;
            this.lblFileComment.Text = "Kommentar:";
            // 
            // btnFileAdd
            // 
            this.btnFileAdd.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.New;
            this.btnFileAdd.Location = new System.Drawing.Point(6, 6);
            this.btnFileAdd.Name = "btnFileAdd";
            this.btnFileAdd.Size = new System.Drawing.Size(100, 24);
            this.btnFileAdd.TabIndex = 0;
            this.btnFileAdd.Text = "Hinzufügen";
            this.btnFileAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFileAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileAdd.UseVisualStyleBackColor = true;
            this.btnFileAdd.Click += new System.EventHandler(this.btnFileAdd_Click);
            // 
            // lsvFiles
            // 
            this.lsvFiles.AllowDrop = true;
            this.lsvFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvFiles.ColumnWidths = ((System.Collections.Generic.List<int>)(resources.GetObject("lsvFiles.ColumnWidths")));
            this.lsvFiles.GridLines = true;
            this.lsvFiles.HideSelection = false;
            this.lsvFiles.Location = new System.Drawing.Point(6, 36);
            this.lsvFiles.MultiSelect = false;
            this.lsvFiles.Name = "lsvFiles";
            this.lsvFiles.ShowItemToolTips = true;
            this.lsvFiles.Size = new System.Drawing.Size(206, 441);
            this.lsvFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvFiles.TabIndex = 2;
            this.lsvFiles.UseCompatibleStateImageBehavior = false;
            this.lsvFiles.View = System.Windows.Forms.View.Details;
            this.lsvFiles.SelectedIndexChanged += new System.EventHandler(this.lsvFiles_SelectedIndexChanged);
            this.lsvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragDrop);
            this.lsvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsvFiles_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datei";
            this.columnHeader1.Width = 165;
            // 
            // tbpInformationInvoiceItems
            // 
            this.tbpInformationInvoiceItems.Controls.Add(this.lblInvoiceItemsTotalPrice);
            this.tbpInformationInvoiceItems.Controls.Add(this.txtInvoiceItemsTotalPrice);
            this.tbpInformationInvoiceItems.Controls.Add(this.btnInvoiceItemImport);
            this.tbpInformationInvoiceItems.Controls.Add(this.prgInvoiceItemProperty);
            this.tbpInformationInvoiceItems.Controls.Add(this.btnInvoiceItemRemove);
            this.tbpInformationInvoiceItems.Controls.Add(this.btnInvoiceItemAdd);
            this.tbpInformationInvoiceItems.Controls.Add(this.lsvInvoiceItems);
            this.tbpInformationInvoiceItems.ImageKey = "List.png";
            this.tbpInformationInvoiceItems.Location = new System.Drawing.Point(4, 23);
            this.tbpInformationInvoiceItems.Name = "tbpInformationInvoiceItems";
            this.tbpInformationInvoiceItems.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInformationInvoiceItems.Size = new System.Drawing.Size(860, 483);
            this.tbpInformationInvoiceItems.TabIndex = 2;
            this.tbpInformationInvoiceItems.Text = "Positionen";
            // 
            // lblInvoiceItemsTotalPrice
            // 
            this.lblInvoiceItemsTotalPrice.AutoSize = true;
            this.lblInvoiceItemsTotalPrice.Location = new System.Drawing.Point(420, 460);
            this.lblInvoiceItemsTotalPrice.Name = "lblInvoiceItemsTotalPrice";
            this.lblInvoiceItemsTotalPrice.Size = new System.Drawing.Size(119, 13);
            this.lblInvoiceItemsTotalPrice.TabIndex = 6;
            this.lblInvoiceItemsTotalPrice.Text = "Summe aller Positionen:";
            // 
            // txtInvoiceItemsTotalPrice
            // 
            this.txtInvoiceItemsTotalPrice.Location = new System.Drawing.Point(545, 457);
            this.txtInvoiceItemsTotalPrice.Name = "txtInvoiceItemsTotalPrice";
            this.txtInvoiceItemsTotalPrice.ReadOnly = true;
            this.txtInvoiceItemsTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceItemsTotalPrice.TabIndex = 5;
            // 
            // btnInvoiceItemImport
            // 
            this.btnInvoiceItemImport.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Import;
            this.btnInvoiceItemImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoiceItemImport.Location = new System.Drawing.Point(112, 6);
            this.btnInvoiceItemImport.Name = "btnInvoiceItemImport";
            this.btnInvoiceItemImport.Size = new System.Drawing.Size(100, 24);
            this.btnInvoiceItemImport.TabIndex = 2;
            this.btnInvoiceItemImport.Text = "Importieren";
            this.btnInvoiceItemImport.UseVisualStyleBackColor = true;
            this.btnInvoiceItemImport.Click += new System.EventHandler(this.btnInvoiceItemImport_Click);
            // 
            // prgInvoiceItemProperty
            // 
            this.prgInvoiceItemProperty.Location = new System.Drawing.Point(651, 9);
            this.prgInvoiceItemProperty.Name = "prgInvoiceItemProperty";
            this.prgInvoiceItemProperty.Size = new System.Drawing.Size(206, 471);
            this.prgInvoiceItemProperty.TabIndex = 4;
            this.prgInvoiceItemProperty.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.prgInvoiceItemProperty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prgInvoiceItemProperty_PropertyValueChanged);
            // 
            // btnInvoiceItemRemove
            // 
            this.btnInvoiceItemRemove.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Delete;
            this.btnInvoiceItemRemove.Location = new System.Drawing.Point(542, 6);
            this.btnInvoiceItemRemove.Name = "btnInvoiceItemRemove";
            this.btnInvoiceItemRemove.Size = new System.Drawing.Size(100, 24);
            this.btnInvoiceItemRemove.TabIndex = 3;
            this.btnInvoiceItemRemove.Text = "Löschen";
            this.btnInvoiceItemRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvoiceItemRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoiceItemRemove.UseVisualStyleBackColor = true;
            this.btnInvoiceItemRemove.Click += new System.EventHandler(this.btnInvoiceItemRemove_Click);
            // 
            // btnInvoiceItemAdd
            // 
            this.btnInvoiceItemAdd.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.New;
            this.btnInvoiceItemAdd.Location = new System.Drawing.Point(6, 6);
            this.btnInvoiceItemAdd.Name = "btnInvoiceItemAdd";
            this.btnInvoiceItemAdd.Size = new System.Drawing.Size(100, 24);
            this.btnInvoiceItemAdd.TabIndex = 0;
            this.btnInvoiceItemAdd.Text = "Hinzufügen";
            this.btnInvoiceItemAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInvoiceItemAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInvoiceItemAdd.UseVisualStyleBackColor = true;
            this.btnInvoiceItemAdd.Click += new System.EventHandler(this.btnInvoiceItemAdd_Click);
            // 
            // lsvInvoiceItems
            // 
            this.lsvInvoiceItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvInvoiceItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvInvoiceItems.ColumnWidths = ((System.Collections.Generic.List<int>)(resources.GetObject("lsvInvoiceItems.ColumnWidths")));
            this.lsvInvoiceItems.FullRowSelect = true;
            this.lsvInvoiceItems.GridLines = true;
            this.lsvInvoiceItems.HideSelection = false;
            this.lsvInvoiceItems.Location = new System.Drawing.Point(6, 36);
            this.lsvInvoiceItems.Name = "lsvInvoiceItems";
            this.lsvInvoiceItems.ShowItemToolTips = true;
            this.lsvInvoiceItems.Size = new System.Drawing.Size(636, 415);
            this.lsvInvoiceItems.TabIndex = 1;
            this.lsvInvoiceItems.UseCompatibleStateImageBehavior = false;
            this.lsvInvoiceItems.View = System.Windows.Forms.View.Details;
            this.lsvInvoiceItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvInvoiceItems_ColumnClick);
            this.lsvInvoiceItems.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lsvInvoiceItems_ColumnWidthChanged);
            this.lsvInvoiceItems.SelectedIndexChanged += new System.EventHandler(this.lsvInvoiceItems_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artikel";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Artikelnummer";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Preis";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Anzahl";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Gesamtpreis";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Kommentar";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Position Eintrag";
            // 
            // lblOrgFileLocation
            // 
            this.lblOrgFileLocation.AutoSize = true;
            this.lblOrgFileLocation.Location = new System.Drawing.Point(428, 41);
            this.lblOrgFileLocation.Name = "lblOrgFileLocation";
            this.lblOrgFileLocation.Size = new System.Drawing.Size(43, 13);
            this.lblOrgFileLocation.TabIndex = 7;
            this.lblOrgFileLocation.Text = "Ablage:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(12, 41);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(35, 13);
            this.lblCompany.TabIndex = 4;
            this.lblCompany.Text = "Firma:";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTitle.Location = new System.Drawing.Point(83, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(339, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Benennung:";
            // 
            // cboCompany
            // 
            this.cboCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(83, 38);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(296, 21);
            this.cboCompany.TabIndex = 5;
            this.cboCompany.SelectedIndexChanged += new System.EventHandler(this.cboCompany_SelectedIndexChanged);
            // 
            // txtOrgFileLocation
            // 
            this.txtOrgFileLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOrgFileLocation.Location = new System.Drawing.Point(477, 38);
            this.txtOrgFileLocation.Name = "txtOrgFileLocation";
            this.txtOrgFileLocation.Size = new System.Drawing.Size(403, 20);
            this.txtOrgFileLocation.TabIndex = 8;
            this.txtOrgFileLocation.TextChanged += new System.EventHandler(this.txtOrgFileLocation_TextChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(428, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Datum:";
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(118, 581);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Ü&bernehmen";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(780, 581);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(12, 581);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 24);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "&Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // mtbDate
            // 
            this.mtbDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbDate.Location = new System.Drawing.Point(477, 12);
            this.mtbDate.Mask = "00/00/0000";
            this.mtbDate.Name = "mtbDate";
            this.mtbDate.Size = new System.Drawing.Size(80, 20);
            this.mtbDate.TabIndex = 3;
            this.mtbDate.ValidatingType = typeof(System.DateTime);
            this.mtbDate.TextChanged += new System.EventHandler(this.mtbDate_TextChanged);
            // 
            // erpMannageBill
            // 
            this.erpMannageBill.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.erpMannageBill.ContainerControl = this;
            // 
            // btnManageCompanies
            // 
            this.btnManageCompanies.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Company;
            this.btnManageCompanies.Location = new System.Drawing.Point(385, 38);
            this.btnManageCompanies.Name = "btnManageCompanies";
            this.btnManageCompanies.Size = new System.Drawing.Size(37, 24);
            this.btnManageCompanies.TabIndex = 6;
            this.btnManageCompanies.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageCompanies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageCompanies.UseVisualStyleBackColor = true;
            this.btnManageCompanies.Click += new System.EventHandler(this.btnManageCompanies_Click);
            // 
            // ManageBill
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(892, 617);
            this.Controls.Add(this.btnManageCompanies);
            this.Controls.Add(this.mtbDate);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabInformation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblOrgFileLocation);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.txtOrgFileLocation);
            this.Controls.Add(this.lblDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageBill";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmManageBill";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageBill_FormClosed);
            this.Shown += new System.EventHandler(this.ManageBill_Shown);
            this.tabInformation.ResumeLayout(false);
            this.tbpInformationGenerel.ResumeLayout(false);
            this.tbpInformationGenerel.PerformLayout();
            this.tbpInformationDocument.ResumeLayout(false);
            this.grbFileData.ResumeLayout(false);
            this.grbFileData.PerformLayout();
            this.spcFilePreview.Panel1.ResumeLayout(false);
            this.spcFilePreview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcFilePreview)).EndInit();
            this.spcFilePreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFilePreview)).EndInit();
            this.grbFileModify.ResumeLayout(false);
            this.grbFileModify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileModifyResize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbaFileModifyBrightnes)).EndInit();
            this.tabFileSource.ResumeLayout(false);
            this.tbpFileSourceFile.ResumeLayout(false);
            this.tbpFileSourceFile.PerformLayout();
            this.tbpFileSourceScan.ResumeLayout(false);
            this.tbpFileSourceScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFileScanResolution)).EndInit();
            this.tbpFileSourceLink.ResumeLayout(false);
            this.tbpFileSourceLink.PerformLayout();
            this.tbpInformationInvoiceItems.ResumeLayout(false);
            this.tbpInformationInvoiceItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpMannageBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private OLKI.Toolbox.Widgets.SortListView lsvInvoiceItems;
        private System.Windows.Forms.TabControl tabInformation;
        private System.Windows.Forms.TabPage tbpInformationInvoiceItems;
        private System.Windows.Forms.TabPage tbpInformationGenerel;
        private System.Windows.Forms.Label lblExpidation;
        private System.Windows.Forms.TextBox txtCustomNumber;
        private System.Windows.Forms.Label lblCustomNumber;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.Label lblBillNumber;
        private System.Windows.Forms.Label lblBillClasses;
        private System.Windows.Forms.TreeView trvBillClasses;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblOrgFileLocation;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Label lblFileTitle;
        private System.Windows.Forms.TabControl tabFileSource;
        private System.Windows.Forms.TabPage tbpFileSourceFile;
        private System.Windows.Forms.Button btnFileBrowse;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TabPage tbpFileSourceScan;
        private System.Windows.Forms.Label lblFileScanResolution;
        private System.Windows.Forms.ComboBox cboFileScanDevice;
        private System.Windows.Forms.Label lblFileScanDevice;
        private System.Windows.Forms.TextBox txtFileTitle;
        private OLKI.Toolbox.Widgets.SortListView lsvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private OLKI.Toolbox.Widgets.PictrueBoxCrop picFilePreview;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TextBox txtOrgFileLocation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnFileRemove;
        private System.Windows.Forms.Button btnFileAdd;
        private System.Windows.Forms.Button btnInvoiceItemRemove;
        private System.Windows.Forms.Button btnInvoiceItemAdd;
        private System.Windows.Forms.TabPage tbpInformationDocument;
        private System.Windows.Forms.GroupBox grbFileData;
        private System.Windows.Forms.PropertyGrid prgInvoiceItemProperty;
        private System.Windows.Forms.ImageList imlTabIcons;
        private System.Windows.Forms.TextBox txtFileComment;
        private System.Windows.Forms.Button btnFileScan;
        private System.Windows.Forms.GroupBox grbFileModify;
        private System.Windows.Forms.Label lblFileModifyThreshold;
        private System.Windows.Forms.Label lblFileModifyContrast;
        private System.Windows.Forms.Label lblFileModifyBrightnes;
        private System.Windows.Forms.Button btnFileModifyCrop;
        private System.Windows.Forms.TrackBar tbaFileModifyThreshold;
        private System.Windows.Forms.TrackBar tbaFileModifyContrast;
        private System.Windows.Forms.TrackBar tbaFileModifyBrightnes;
        private System.Windows.Forms.ComboBox cboFileModifyColor;
        private System.Windows.Forms.Label lblFileModifyVolor;
        private System.Windows.Forms.Label lblFileComment;
        private System.Windows.Forms.Button btnFileAttech;
        private System.Windows.Forms.MaskedTextBox mtbDate;
        private System.Windows.Forms.ErrorProvider erpMannageBill;
        private System.Windows.Forms.MaskedTextBox mtbExpidation;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnManageCompanies;
        private System.Windows.Forms.Button btnManageBillClasses;
        private System.Windows.Forms.Button btnFileSave;
        private System.Windows.Forms.NumericUpDown nudFileScanResolution;
        private System.Windows.Forms.Button btnFileModifyCropUndo;
        private System.Windows.Forms.SplitContainer spcFilePreview;
        private OLKI.Toolbox.Widgets.ReadOnlyPropertyGrid prgFilePreview;
        private System.Windows.Forms.TabPage tbpFileSourceLink;
        private System.Windows.Forms.Button btnFileLinkBrowse;
        private System.Windows.Forms.TextBox txtFileLinkPath;
        private System.Windows.Forms.Label lblFileLinkPath;
        private System.Windows.Forms.Label lblFileLinkNote;
        private System.Windows.Forms.Label lblOriginalFileName;
        private System.Windows.Forms.Button btnInvoiceItemImport;
        private System.Windows.Forms.Button btnFileModifyRotateRight;
        private System.Windows.Forms.Button btnFileModifyRotateLeft;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblFileModifyReize;
        private System.Windows.Forms.NumericUpDown nudFileModifyResize;
        private System.Windows.Forms.CheckBox chkBillDisposed;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox txtInvoiceItemsTotalPrice;
        private System.Windows.Forms.Label lblInvoiceItemsTotalPrice;
    }
}