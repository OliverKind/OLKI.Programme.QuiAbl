namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.tabBill = new System.Windows.Forms.TabControl();
            this.tabpBillData = new System.Windows.Forms.TabPage();
            this.prgBillProperty = new System.Windows.Forms.PropertyGrid();
            this.tabpBillDocs = new System.Windows.Forms.TabPage();
            this.pnlBillFiles = new System.Windows.Forms.Panel();
            this.lblBillFileTitle = new System.Windows.Forms.Label();
            this.lblBillFileOriginalFileName = new System.Windows.Forms.Label();
            this.btnBillFileSave = new System.Windows.Forms.Button();
            this.btnBillFileOpen = new System.Windows.Forms.Button();
            this.btnBillFileNext = new System.Windows.Forms.Button();
            this.picBilFilePreview = new System.Windows.Forms.PictureBox();
            this.btnBillFilePrev = new System.Windows.Forms.Button();
            this.lblBillFileNumber = new System.Windows.Forms.Label();
            this.imlTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearchReset = new System.Windows.Forms.Button();
            this.btnSearchBill = new System.Windows.Forms.Button();
            this.lsvBills = new OLKI.Toolbox.Widgets.SortListView();
            this.cohBillsTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsDocuments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsComapny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cohBillsLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBillAdd = new System.Windows.Forms.Button();
            this.btnBillRemove = new System.Windows.Forms.Button();
            this.btnBillEdit = new System.Windows.Forms.Button();
            this.mnuBills = new System.Windows.Forms.MenuStrip();
            this.mnuBillForm_Basedata = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillsForm_Basedata_Company = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillsForm_Basedata_BillClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillForm_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillForm_Search_Bill = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillForm_Search_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBillForm_Search_AutoOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cohBillsId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBill.SuspendLayout();
            this.tabpBillData.SuspendLayout();
            this.tabpBillDocs.SuspendLayout();
            this.pnlBillFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBilFilePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mnuBills.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBill
            // 
            this.tabBill.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabBill.Controls.Add(this.tabpBillData);
            this.tabBill.Controls.Add(this.tabpBillDocs);
            this.tabBill.ImageList = this.imlTabIcons;
            this.tabBill.Location = new System.Drawing.Point(3, 12);
            this.tabBill.Multiline = true;
            this.tabBill.Name = "tabBill";
            this.tabBill.SelectedIndex = 0;
            this.tabBill.Size = new System.Drawing.Size(366, 537);
            this.tabBill.TabIndex = 0;
            // 
            // tabpBillData
            // 
            this.tabpBillData.Controls.Add(this.prgBillProperty);
            this.tabpBillData.ImageKey = "Properties.png";
            this.tabpBillData.Location = new System.Drawing.Point(4, 4);
            this.tabpBillData.Name = "tabpBillData";
            this.tabpBillData.Padding = new System.Windows.Forms.Padding(3);
            this.tabpBillData.Size = new System.Drawing.Size(339, 529);
            this.tabpBillData.TabIndex = 1;
            this.tabpBillData.Text = "Daten";
            // 
            // prgBillProperty
            // 
            this.prgBillProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBillProperty.Location = new System.Drawing.Point(6, 6);
            this.prgBillProperty.Name = "prgBillProperty";
            this.prgBillProperty.Size = new System.Drawing.Size(327, 517);
            this.prgBillProperty.TabIndex = 0;
            this.prgBillProperty.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.prgBillProperty.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.prgBillProperty_PropertyValueChanged);
            // 
            // tabpBillDocs
            // 
            this.tabpBillDocs.Controls.Add(this.pnlBillFiles);
            this.tabpBillDocs.ImageKey = "File.png";
            this.tabpBillDocs.Location = new System.Drawing.Point(4, 4);
            this.tabpBillDocs.Name = "tabpBillDocs";
            this.tabpBillDocs.Padding = new System.Windows.Forms.Padding(3);
            this.tabpBillDocs.Size = new System.Drawing.Size(339, 529);
            this.tabpBillDocs.TabIndex = 0;
            this.tabpBillDocs.Text = "Dokumente";
            // 
            // pnlBillFiles
            // 
            this.pnlBillFiles.Controls.Add(this.lblBillFileTitle);
            this.pnlBillFiles.Controls.Add(this.lblBillFileOriginalFileName);
            this.pnlBillFiles.Controls.Add(this.btnBillFileSave);
            this.pnlBillFiles.Controls.Add(this.btnBillFileOpen);
            this.pnlBillFiles.Controls.Add(this.btnBillFileNext);
            this.pnlBillFiles.Controls.Add(this.picBilFilePreview);
            this.pnlBillFiles.Controls.Add(this.btnBillFilePrev);
            this.pnlBillFiles.Controls.Add(this.lblBillFileNumber);
            this.pnlBillFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBillFiles.Location = new System.Drawing.Point(3, 3);
            this.pnlBillFiles.Name = "pnlBillFiles";
            this.pnlBillFiles.Size = new System.Drawing.Size(333, 523);
            this.pnlBillFiles.TabIndex = 0;
            // 
            // lblBillFileTitle
            // 
            this.lblBillFileTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBillFileTitle.Location = new System.Drawing.Point(3, 441);
            this.lblBillFileTitle.Name = "lblBillFileTitle";
            this.lblBillFileTitle.Size = new System.Drawing.Size(327, 13);
            this.lblBillFileTitle.TabIndex = 21;
            this.lblBillFileTitle.Text = "lblBillFileTitle";
            // 
            // lblBillFileOriginalFileName
            // 
            this.lblBillFileOriginalFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBillFileOriginalFileName.Location = new System.Drawing.Point(3, 454);
            this.lblBillFileOriginalFileName.Name = "lblBillFileOriginalFileName";
            this.lblBillFileOriginalFileName.Size = new System.Drawing.Size(327, 13);
            this.lblBillFileOriginalFileName.TabIndex = 20;
            this.lblBillFileOriginalFileName.Text = "lblBillFileOriginalFileName";
            // 
            // btnBillFileSave
            // 
            this.btnBillFileSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillFileSave.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Save;
            this.btnBillFileSave.Location = new System.Drawing.Point(230, 470);
            this.btnBillFileSave.Name = "btnBillFileSave";
            this.btnBillFileSave.Size = new System.Drawing.Size(100, 24);
            this.btnBillFileSave.TabIndex = 1;
            this.btnBillFileSave.Text = "Speichern";
            this.btnBillFileSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillFileSave.UseVisualStyleBackColor = true;
            this.btnBillFileSave.Click += new System.EventHandler(this.btnBillFileSave_Click);
            // 
            // btnBillFileOpen
            // 
            this.btnBillFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillFileOpen.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FileOpen;
            this.btnBillFileOpen.Location = new System.Drawing.Point(6, 470);
            this.btnBillFileOpen.Name = "btnBillFileOpen";
            this.btnBillFileOpen.Size = new System.Drawing.Size(218, 24);
            this.btnBillFileOpen.TabIndex = 0;
            this.btnBillFileOpen.Text = "Dokument öffnen";
            this.btnBillFileOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBillFileOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillFileOpen.UseVisualStyleBackColor = true;
            this.btnBillFileOpen.Click += new System.EventHandler(this.btnBillFileOpen_Click);
            // 
            // btnBillFileNext
            // 
            this.btnBillFileNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillFileNext.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FileNext;
            this.btnBillFileNext.Location = new System.Drawing.Point(258, 500);
            this.btnBillFileNext.Name = "btnBillFileNext";
            this.btnBillFileNext.Size = new System.Drawing.Size(75, 23);
            this.btnBillFileNext.TabIndex = 4;
            this.btnBillFileNext.UseVisualStyleBackColor = true;
            this.btnBillFileNext.Click += new System.EventHandler(this.btnBillFileNext_Click);
            // 
            // picBilFilePreview
            // 
            this.picBilFilePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBilFilePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBilFilePreview.Location = new System.Drawing.Point(6, 6);
            this.picBilFilePreview.Name = "picBilFilePreview";
            this.picBilFilePreview.Size = new System.Drawing.Size(324, 432);
            this.picBilFilePreview.TabIndex = 19;
            this.picBilFilePreview.TabStop = false;
            this.picBilFilePreview.DoubleClick += new System.EventHandler(this.picBilFilePreview_DoubleClick);
            // 
            // btnBillFilePrev
            // 
            this.btnBillFilePrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBillFilePrev.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FilePrevious;
            this.btnBillFilePrev.Location = new System.Drawing.Point(6, 500);
            this.btnBillFilePrev.Name = "btnBillFilePrev";
            this.btnBillFilePrev.Size = new System.Drawing.Size(75, 23);
            this.btnBillFilePrev.TabIndex = 2;
            this.btnBillFilePrev.UseVisualStyleBackColor = true;
            this.btnBillFilePrev.Click += new System.EventHandler(this.btnBillFilePrev_Click);
            // 
            // lblBillFileNumber
            // 
            this.lblBillFileNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBillFileNumber.Location = new System.Drawing.Point(87, 505);
            this.lblBillFileNumber.Name = "lblBillFileNumber";
            this.lblBillFileNumber.Size = new System.Drawing.Size(165, 23);
            this.lblBillFileNumber.TabIndex = 3;
            this.lblBillFileNumber.Text = "{0} von {1}";
            this.lblBillFileNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imlTabIcons
            // 
            this.imlTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTabIcons.ImageStream")));
            this.imlTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTabIcons.Images.SetKeyName(0, "File.png");
            this.imlTabIcons.Images.SetKeyName(1, "Properties.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSearchReset);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearchBill);
            this.splitContainer1.Panel1.Controls.Add(this.lsvBills);
            this.splitContainer1.Panel1.Controls.Add(this.btnBillAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnBillRemove);
            this.splitContainer1.Panel1.Controls.Add(this.btnBillEdit);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabBill);
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(785, 561);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSearchReset
            // 
            this.btnSearchReset.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FilterReset;
            this.btnSearchReset.Location = new System.Drawing.Point(254, 12);
            this.btnSearchReset.Name = "btnSearchReset";
            this.btnSearchReset.Size = new System.Drawing.Size(24, 24);
            this.btnSearchReset.TabIndex = 5;
            this.btnSearchReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchReset.UseVisualStyleBackColor = true;
            this.btnSearchReset.Click += new System.EventHandler(this.btnSearchReset_Click);
            // 
            // btnSearchBill
            // 
            this.btnSearchBill.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Search;
            this.btnSearchBill.Location = new System.Drawing.Point(224, 12);
            this.btnSearchBill.Name = "btnSearchBill";
            this.btnSearchBill.Size = new System.Drawing.Size(24, 24);
            this.btnSearchBill.TabIndex = 4;
            this.btnSearchBill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchBill.UseVisualStyleBackColor = true;
            this.btnSearchBill.Click += new System.EventHandler(this.btnSearchBill_Click);
            // 
            // lsvBills
            // 
            this.lsvBills.AllowColumnReorder = true;
            this.lsvBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cohBillsTitle,
            this.cohBillsDate,
            this.cohBillsDocuments,
            this.cohBillsCategory,
            this.cohBillsComapny,
            this.cohBillsComment,
            this.cohBillsLength,
            this.cohBillsId});
            this.lsvBills.FullRowSelect = true;
            this.lsvBills.GridLines = true;
            this.lsvBills.HideSelection = false;
            this.lsvBills.Location = new System.Drawing.Point(12, 42);
            this.lsvBills.Name = "lsvBills";
            this.lsvBills.ShowItemToolTips = true;
            this.lsvBills.Size = new System.Drawing.Size(385, 507);
            this.lsvBills.TabIndex = 3;
            this.lsvBills.UseCompatibleStateImageBehavior = false;
            this.lsvBills.View = System.Windows.Forms.View.Details;
            this.lsvBills.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lsvBills_ColumnWidthChanged);
            this.lsvBills.SelectedIndexChanged += new System.EventHandler(this.lsvBills_SelectedIndexChanged);
            this.lsvBills.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvBills_MouseDoubleClick);
            // 
            // cohBillsTitle
            // 
            this.cohBillsTitle.Text = "Rechnung";
            this.cohBillsTitle.Width = 90;
            // 
            // cohBillsDate
            // 
            this.cohBillsDate.Text = "Datum";
            this.cohBillsDate.Width = 90;
            // 
            // cohBillsDocuments
            // 
            this.cohBillsDocuments.Text = "Dokumente";
            this.cohBillsDocuments.Width = 90;
            // 
            // cohBillsCategory
            // 
            this.cohBillsCategory.Text = "Kategorie";
            this.cohBillsCategory.Width = 90;
            // 
            // cohBillsComapny
            // 
            this.cohBillsComapny.Text = "Firma";
            // 
            // cohBillsComment
            // 
            this.cohBillsComment.Text = "Kommentar";
            this.cohBillsComment.Width = 90;
            // 
            // cohBillsLength
            // 
            this.cohBillsLength.Text = "Dokumentgröße";
            this.cohBillsLength.Width = 90;
            // 
            // btnBillAdd
            // 
            this.btnBillAdd.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.New;
            this.btnBillAdd.Location = new System.Drawing.Point(12, 12);
            this.btnBillAdd.Name = "btnBillAdd";
            this.btnBillAdd.Size = new System.Drawing.Size(100, 24);
            this.btnBillAdd.TabIndex = 0;
            this.btnBillAdd.Text = "Hinzufügen";
            this.btnBillAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillAdd.UseVisualStyleBackColor = true;
            this.btnBillAdd.Click += new System.EventHandler(this.btnBillAdd_Click);
            // 
            // btnBillRemove
            // 
            this.btnBillRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBillRemove.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Delete;
            this.btnBillRemove.Location = new System.Drawing.Point(297, 12);
            this.btnBillRemove.Name = "btnBillRemove";
            this.btnBillRemove.Size = new System.Drawing.Size(100, 24);
            this.btnBillRemove.TabIndex = 2;
            this.btnBillRemove.Text = "Löschen";
            this.btnBillRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillRemove.UseVisualStyleBackColor = true;
            this.btnBillRemove.Click += new System.EventHandler(this.btnBillRemove_Click);
            // 
            // btnBillEdit
            // 
            this.btnBillEdit.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Properties;
            this.btnBillEdit.Location = new System.Drawing.Point(118, 12);
            this.btnBillEdit.Name = "btnBillEdit";
            this.btnBillEdit.Size = new System.Drawing.Size(100, 24);
            this.btnBillEdit.TabIndex = 1;
            this.btnBillEdit.Text = "Bearbeiten";
            this.btnBillEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillEdit.UseVisualStyleBackColor = true;
            this.btnBillEdit.Click += new System.EventHandler(this.btnBillEdit_Click);
            // 
            // mnuBills
            // 
            this.mnuBills.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBillForm_Basedata,
            this.mnuBillForm_Search});
            this.mnuBills.Location = new System.Drawing.Point(0, 0);
            this.mnuBills.Name = "mnuBills";
            this.mnuBills.Size = new System.Drawing.Size(785, 24);
            this.mnuBills.TabIndex = 1;
            this.mnuBills.Text = "mnuBills";
            this.mnuBills.Visible = false;
            // 
            // mnuBillForm_Basedata
            // 
            this.mnuBillForm_Basedata.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBillsForm_Basedata_Company,
            this.mnuBillsForm_Basedata_BillClass});
            this.mnuBillForm_Basedata.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuBillForm_Basedata.MergeIndex = 1;
            this.mnuBillForm_Basedata.Name = "mnuBillForm_Basedata";
            this.mnuBillForm_Basedata.Size = new System.Drawing.Size(87, 20);
            this.mnuBillForm_Basedata.Text = "Stammdaten";
            // 
            // mnuBillsForm_Basedata_Company
            // 
            this.mnuBillsForm_Basedata_Company.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Company;
            this.mnuBillsForm_Basedata_Company.Name = "mnuBillsForm_Basedata_Company";
            this.mnuBillsForm_Basedata_Company.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.mnuBillsForm_Basedata_Company.Size = new System.Drawing.Size(197, 22);
            this.mnuBillsForm_Basedata_Company.Text = "&Firmen";
            this.mnuBillsForm_Basedata_Company.Click += new System.EventHandler(this.mnuBillsForm_Basedata_Company_Click);
            // 
            // mnuBillsForm_Basedata_BillClass
            // 
            this.mnuBillsForm_Basedata_BillClass.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Class;
            this.mnuBillsForm_Basedata_BillClass.Name = "mnuBillsForm_Basedata_BillClass";
            this.mnuBillsForm_Basedata_BillClass.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.B)));
            this.mnuBillsForm_Basedata_BillClass.Size = new System.Drawing.Size(197, 22);
            this.mnuBillsForm_Basedata_BillClass.Text = "&Kategorien";
            this.mnuBillsForm_Basedata_BillClass.Click += new System.EventHandler(this.mnuBillsForm_Basedata_BillClass_Click);
            // 
            // mnuBillForm_Search
            // 
            this.mnuBillForm_Search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBillForm_Search_Bill,
            this.mnuBillForm_Search_Reset,
            this.mnuBillForm_Search_AutoOpen});
            this.mnuBillForm_Search.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuBillForm_Search.MergeIndex = 2;
            this.mnuBillForm_Search.Name = "mnuBillForm_Search";
            this.mnuBillForm_Search.Size = new System.Drawing.Size(58, 20);
            this.mnuBillForm_Search.Text = "&Suchen";
            // 
            // mnuBillForm_Search_Bill
            // 
            this.mnuBillForm_Search_Bill.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Search;
            this.mnuBillForm_Search_Bill.Name = "mnuBillForm_Search_Bill";
            this.mnuBillForm_Search_Bill.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuBillForm_Search_Bill.Size = new System.Drawing.Size(345, 22);
            this.mnuBillForm_Search_Bill.Text = "&Rechnung";
            this.mnuBillForm_Search_Bill.Click += new System.EventHandler(this.mnuBillForm_Search_Bill_Click);
            // 
            // mnuBillForm_Search_Reset
            // 
            this.mnuBillForm_Search_Reset.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.FilterReset;
            this.mnuBillForm_Search_Reset.Name = "mnuBillForm_Search_Reset";
            this.mnuBillForm_Search_Reset.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.mnuBillForm_Search_Reset.Size = new System.Drawing.Size(345, 22);
            this.mnuBillForm_Search_Reset.Text = "Gefilterte Liste zurücksetzen";
            this.mnuBillForm_Search_Reset.Click += new System.EventHandler(this.mnuBillForm_Search_Reset_Click);
            // 
            // mnuBillForm_Search_AutoOpen
            // 
            this.mnuBillForm_Search_AutoOpen.Name = "mnuBillForm_Search_AutoOpen";
            this.mnuBillForm_Search_AutoOpen.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F3)));
            this.mnuBillForm_Search_AutoOpen.Size = new System.Drawing.Size(345, 22);
            this.mnuBillForm_Search_AutoOpen.Text = "Suche beim Starten öffnen";
            this.mnuBillForm_Search_AutoOpen.Click += new System.EventHandler(this.mnuBillForm_Search_AutoOpen_Click);
            // 
            // cohBillsId
            // 
            this.cohBillsId.Text = "Rechnung Eintrag";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 561);
            this.Controls.Add(this.mnuBills);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuBills;
            this.MinimumSize = new System.Drawing.Size(801, 300);
            this.Name = "ProjectForm";
            this.ShowInTaskbar = false;
            this.Text = "frmBills";
            this.Activated += new System.EventHandler(this.ProjectForm_Activated);
            this.Deactivate += new System.EventHandler(this.ProjectForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectForm_FormClosing);
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            this.Shown += new System.EventHandler(this.ProjectForm_Shown);
            this.Resize += new System.EventHandler(this.ProjectForm_Resize);
            this.tabBill.ResumeLayout(false);
            this.tabpBillData.ResumeLayout(false);
            this.tabpBillDocs.ResumeLayout(false);
            this.pnlBillFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBilFilePreview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mnuBills.ResumeLayout(false);
            this.mnuBills.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBillEdit;
        private System.Windows.Forms.Button btnBillRemove;
        private System.Windows.Forms.Button btnBillAdd;
        private System.Windows.Forms.ColumnHeader cohBillsComment;
        private System.Windows.Forms.ColumnHeader cohBillsDocuments;
        private System.Windows.Forms.ColumnHeader cohBillsDate;
        private System.Windows.Forms.ColumnHeader cohBillsTitle;
        private OLKI.Toolbox.Widgets.SortListView lsvBills;
        private System.Windows.Forms.ColumnHeader cohBillsCategory;
        private System.Windows.Forms.TabControl tabBill;
        private System.Windows.Forms.TabPage tabpBillData;
        private System.Windows.Forms.TabPage tabpBillDocs;
        private System.Windows.Forms.Button btnBillFileOpen;
        private System.Windows.Forms.Label lblBillFileNumber;
        private System.Windows.Forms.Button btnBillFileNext;
        private System.Windows.Forms.Button btnBillFilePrev;
        private System.Windows.Forms.PictureBox picBilFilePreview;
        private System.Windows.Forms.PropertyGrid prgBillProperty;
        private System.Windows.Forms.ImageList imlTabIcons;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlBillFiles;
        private System.Windows.Forms.MenuStrip mnuBills;
        private System.Windows.Forms.ToolStripMenuItem mnuBillForm_Basedata;
        private System.Windows.Forms.ToolStripMenuItem mnuBillForm_Search;
        private System.Windows.Forms.ToolStripMenuItem mnuBillsForm_Basedata_Company;
        private System.Windows.Forms.ToolStripMenuItem mnuBillsForm_Basedata_BillClass;
        private System.Windows.Forms.ToolStripMenuItem mnuBillForm_Search_Bill;
        private System.Windows.Forms.Button btnBillFileSave;
        private System.Windows.Forms.ColumnHeader cohBillsComapny;
        private System.Windows.Forms.Label lblBillFileTitle;
        private System.Windows.Forms.Label lblBillFileOriginalFileName;
        private System.Windows.Forms.ColumnHeader cohBillsLength;
        private System.Windows.Forms.ToolStripMenuItem mnuBillForm_Search_AutoOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuBillForm_Search_Reset;
        private System.Windows.Forms.Button btnSearchReset;
        private System.Windows.Forms.Button btnSearchBill;
        private System.Windows.Forms.ColumnHeader cohBillsId;
    }
}