namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.tslBills = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCompa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslBillC = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslProFi = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMainForm = new System.Windows.Forms.MenuStrip();
            this.mnuMain_File = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_SepRecentFiles = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_File_RecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_RecentFiles_File0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_RecentFiles_File1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_RecentFiles_File2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_RecentFiles_File3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Extras = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Extras_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_File_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Window_Cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Window_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Window_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_Window_Statusbar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_File_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Help_CheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain_Help_SepAbout = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMain_File_Help_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.tolMain = new System.Windows.Forms.ToolStrip();
            this.tolMain_File_New = new System.Windows.Forms.ToolStripButton();
            this.tolMain_File_Open = new System.Windows.Forms.ToolStripButton();
            this.tolMain_File_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tolMain_Basedata_Company = new System.Windows.Forms.ToolStripButton();
            this.tolMain_Basedata_BillClass = new System.Windows.Forms.ToolStripButton();
            this.stsStatus.SuspendLayout();
            this.mnuMainForm.SuspendLayout();
            this.tolMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslBills,
            this.tslFiles,
            this.tslCompa,
            this.tslBillC,
            this.tslProFi});
            this.stsStatus.Location = new System.Drawing.Point(0, 599);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(990, 22);
            this.stsStatus.TabIndex = 3;
            this.stsStatus.Text = "stsStatus";
            // 
            // tslBills
            // 
            this.tslBills.Name = "tslBills";
            this.tslBills.Size = new System.Drawing.Size(87, 17);
            this.tslBills.Text = "Belege: {0} / {1}";
            // 
            // tslFiles
            // 
            this.tslFiles.Name = "tslFiles";
            this.tslFiles.Size = new System.Drawing.Size(125, 17);
            this.tslFiles.Text = "Dateianhänge: {0} ({1})";
            // 
            // tslCompa
            // 
            this.tslCompa.Name = "tslCompa";
            this.tslCompa.Size = new System.Drawing.Size(64, 17);
            this.tslCompa.Text = "Firmen: {0}";
            // 
            // tslBillC
            // 
            this.tslBillC.Name = "tslBillC";
            this.tslBillC.Size = new System.Drawing.Size(84, 17);
            this.tslBillC.Text = "Kategorien: {0}";
            // 
            // tslProFi
            // 
            this.tslProFi.Name = "tslProFi";
            this.tslProFi.Size = new System.Drawing.Size(46, 17);
            this.tslProFi.Text = "{0} ({1})";
            this.tslProFi.Click += new System.EventHandler(this.tslProFi_Click);
            // 
            // mnuMainForm
            // 
            this.mnuMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_File,
            this.mnuMain_Extras,
            this.mnuMain_File_Window,
            this.mnuMain_File_Help});
            this.mnuMainForm.Location = new System.Drawing.Point(0, 0);
            this.mnuMainForm.MdiWindowListItem = this.mnuMain_File_Window;
            this.mnuMainForm.Name = "mnuMainForm";
            this.mnuMainForm.Size = new System.Drawing.Size(990, 24);
            this.mnuMainForm.TabIndex = 5;
            this.mnuMainForm.Text = "menuStrip1";
            // 
            // mnuMain_File
            // 
            this.mnuMain_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_File_New,
            this.mnuMain_File_Open,
            this.mnuMain_File_Close,
            this.toolStripSeparator,
            this.mnuMain_File_Save,
            this.mnuMain_File_SaveAs,
            this.mnuMain_File_SepRecentFiles,
            this.mnuMain_File_RecentFiles,
            this.toolStripSeparator3,
            this.mnuMain_File_Exit});
            this.mnuMain_File.Name = "mnuMain_File";
            this.mnuMain_File.Size = new System.Drawing.Size(46, 20);
            this.mnuMain_File.Text = "&Datei";
            // 
            // mnuMain_File_New
            // 
            this.mnuMain_File_New.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.File;
            this.mnuMain_File_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuMain_File_New.Name = "mnuMain_File_New";
            this.mnuMain_File_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuMain_File_New.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_New.Text = "&Neu";
            this.mnuMain_File_New.Click += new System.EventHandler(this.mnuMain_File_New_Click);
            // 
            // mnuMain_File_Open
            // 
            this.mnuMain_File_Open.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Open;
            this.mnuMain_File_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuMain_File_Open.Name = "mnuMain_File_Open";
            this.mnuMain_File_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuMain_File_Open.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_Open.Text = "Ö&ffnen";
            this.mnuMain_File_Open.Click += new System.EventHandler(this.mnuMain_File_Open_Click);
            // 
            // mnuMain_File_Close
            // 
            this.mnuMain_File_Close.Name = "mnuMain_File_Close";
            this.mnuMain_File_Close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mnuMain_File_Close.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_Close.Text = "S&chließen";
            this.mnuMain_File_Close.Click += new System.EventHandler(this.mnuMain_File_Close_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(279, 6);
            // 
            // mnuMain_File_Save
            // 
            this.mnuMain_File_Save.Image = ((System.Drawing.Image)(resources.GetObject("mnuMain_File_Save.Image")));
            this.mnuMain_File_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuMain_File_Save.Name = "mnuMain_File_Save";
            this.mnuMain_File_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuMain_File_Save.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_Save.Text = "&Speichern";
            this.mnuMain_File_Save.Click += new System.EventHandler(this.mnuMain_File_Save_Click);
            // 
            // mnuMain_File_SaveAs
            // 
            this.mnuMain_File_SaveAs.Name = "mnuMain_File_SaveAs";
            this.mnuMain_File_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuMain_File_SaveAs.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_SaveAs.Text = "Speichern &unter";
            this.mnuMain_File_SaveAs.Click += new System.EventHandler(this.mnuMain_File_SaveAs_Click);
            // 
            // mnuMain_File_SepRecentFiles
            // 
            this.mnuMain_File_SepRecentFiles.Name = "mnuMain_File_SepRecentFiles";
            this.mnuMain_File_SepRecentFiles.Size = new System.Drawing.Size(279, 6);
            // 
            // mnuMain_File_RecentFiles
            // 
            this.mnuMain_File_RecentFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_File_RecentFiles_File0,
            this.mnuMain_File_RecentFiles_File1,
            this.mnuMain_File_RecentFiles_File2,
            this.mnuMain_File_RecentFiles_File3});
            this.mnuMain_File_RecentFiles.Name = "mnuMain_File_RecentFiles";
            this.mnuMain_File_RecentFiles.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_RecentFiles.Text = "&Zuletzt geöffnete Dateien";
            // 
            // mnuMain_File_RecentFiles_File0
            // 
            this.mnuMain_File_RecentFiles_File0.Name = "mnuMain_File_RecentFiles_File0";
            this.mnuMain_File_RecentFiles_File0.Size = new System.Drawing.Size(110, 22);
            this.mnuMain_File_RecentFiles_File0.Text = "Datei 0";
            this.mnuMain_File_RecentFiles_File0.Click += new System.EventHandler(this.mnuMain_File_RecentFiles_File0_Click);
            // 
            // mnuMain_File_RecentFiles_File1
            // 
            this.mnuMain_File_RecentFiles_File1.Name = "mnuMain_File_RecentFiles_File1";
            this.mnuMain_File_RecentFiles_File1.Size = new System.Drawing.Size(110, 22);
            this.mnuMain_File_RecentFiles_File1.Text = "Datei 1";
            this.mnuMain_File_RecentFiles_File1.Click += new System.EventHandler(this.mnuMain_File_RecentFiles_File1_Click);
            // 
            // mnuMain_File_RecentFiles_File2
            // 
            this.mnuMain_File_RecentFiles_File2.Name = "mnuMain_File_RecentFiles_File2";
            this.mnuMain_File_RecentFiles_File2.Size = new System.Drawing.Size(110, 22);
            this.mnuMain_File_RecentFiles_File2.Text = "Datei 2";
            this.mnuMain_File_RecentFiles_File2.Click += new System.EventHandler(this.mnuMain_File_RecentFiles_File2_Click);
            // 
            // mnuMain_File_RecentFiles_File3
            // 
            this.mnuMain_File_RecentFiles_File3.Name = "mnuMain_File_RecentFiles_File3";
            this.mnuMain_File_RecentFiles_File3.Size = new System.Drawing.Size(110, 22);
            this.mnuMain_File_RecentFiles_File3.Text = "Datei 3";
            this.mnuMain_File_RecentFiles_File3.Click += new System.EventHandler(this.mnuMain_File_RecentFiles_File3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(279, 6);
            // 
            // mnuMain_File_Exit
            // 
            this.mnuMain_File_Exit.Name = "mnuMain_File_Exit";
            this.mnuMain_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuMain_File_Exit.Size = new System.Drawing.Size(282, 22);
            this.mnuMain_File_Exit.Text = "&Beenden";
            this.mnuMain_File_Exit.Click += new System.EventHandler(this.mnuMain_File_Exit_Click);
            // 
            // mnuMain_Extras
            // 
            this.mnuMain_Extras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_Extras_Options});
            this.mnuMain_Extras.Name = "mnuMain_Extras";
            this.mnuMain_Extras.Size = new System.Drawing.Size(50, 20);
            this.mnuMain_Extras.Text = "E&xtras";
            // 
            // mnuMain_Extras_Options
            // 
            this.mnuMain_Extras_Options.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Properties;
            this.mnuMain_Extras_Options.Name = "mnuMain_Extras_Options";
            this.mnuMain_Extras_Options.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.mnuMain_Extras_Options.Size = new System.Drawing.Size(252, 22);
            this.mnuMain_Extras_Options.Text = "&Optionen";
            this.mnuMain_Extras_Options.Click += new System.EventHandler(this.mnuMain_Extras_Options_Click);
            // 
            // mnuMain_File_Window
            // 
            this.mnuMain_File_Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_Window_Cascade,
            this.mnuMain_Window_Horizontal,
            this.mnuMain_Window_Vertical,
            this.toolStripSeparator2,
            this.mnuMain_Window_Statusbar,
            this.toolStripSeparator8});
            this.mnuMain_File_Window.Name = "mnuMain_File_Window";
            this.mnuMain_File_Window.Size = new System.Drawing.Size(57, 20);
            this.mnuMain_File_Window.Text = "&Fenster";
            // 
            // mnuMain_Window_Cascade
            // 
            this.mnuMain_Window_Cascade.Image = ((System.Drawing.Image)(resources.GetObject("mnuMain_Window_Cascade.Image")));
            this.mnuMain_Window_Cascade.Name = "mnuMain_Window_Cascade";
            this.mnuMain_Window_Cascade.Size = new System.Drawing.Size(155, 22);
            this.mnuMain_Window_Cascade.Text = "Ü&berlappend";
            this.mnuMain_Window_Cascade.Click += new System.EventHandler(this.mnuMain_Window_Cascade_Click);
            // 
            // mnuMain_Window_Horizontal
            // 
            this.mnuMain_Window_Horizontal.Image = ((System.Drawing.Image)(resources.GetObject("mnuMain_Window_Horizontal.Image")));
            this.mnuMain_Window_Horizontal.Name = "mnuMain_Window_Horizontal";
            this.mnuMain_Window_Horizontal.Size = new System.Drawing.Size(155, 22);
            this.mnuMain_Window_Horizontal.Text = "&Untereinander";
            this.mnuMain_Window_Horizontal.Click += new System.EventHandler(this.mnuMain_Window_Horizontal_Click);
            // 
            // mnuMain_Window_Vertical
            // 
            this.mnuMain_Window_Vertical.Image = ((System.Drawing.Image)(resources.GetObject("mnuMain_Window_Vertical.Image")));
            this.mnuMain_Window_Vertical.Name = "mnuMain_Window_Vertical";
            this.mnuMain_Window_Vertical.Size = new System.Drawing.Size(155, 22);
            this.mnuMain_Window_Vertical.Text = "&Nebeneinander";
            this.mnuMain_Window_Vertical.Click += new System.EventHandler(this.mnuMain_Window_Vertical_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuMain_Window_Statusbar
            // 
            this.mnuMain_Window_Statusbar.Checked = true;
            this.mnuMain_Window_Statusbar.CheckOnClick = true;
            this.mnuMain_Window_Statusbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuMain_Window_Statusbar.Name = "mnuMain_Window_Statusbar";
            this.mnuMain_Window_Statusbar.Size = new System.Drawing.Size(155, 22);
            this.mnuMain_Window_Statusbar.Text = "Status&leiste";
            this.mnuMain_Window_Statusbar.Click += new System.EventHandler(this.mnuMain_Window_Statusbar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuMain_File_Help
            // 
            this.mnuMain_File_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMain_Help_CheckUpdate,
            this.mnuMain_Help_SepAbout,
            this.mnuMain_File_Help_Info});
            this.mnuMain_File_Help.Name = "mnuMain_File_Help";
            this.mnuMain_File_Help.Size = new System.Drawing.Size(44, 20);
            this.mnuMain_File_Help.Text = "&Hilfe";
            // 
            // mnuMain_Help_CheckUpdate
            // 
            this.mnuMain_Help_CheckUpdate.Name = "mnuMain_Help_CheckUpdate";
            this.mnuMain_Help_CheckUpdate.Size = new System.Drawing.Size(235, 22);
            this.mnuMain_Help_CheckUpdate.Text = "Nach Updates suchen";
            this.mnuMain_Help_CheckUpdate.Click += new System.EventHandler(this.mnuMain_Help_CheckUpdate_Click);
            // 
            // mnuMain_Help_SepAbout
            // 
            this.mnuMain_Help_SepAbout.Name = "mnuMain_Help_SepAbout";
            this.mnuMain_Help_SepAbout.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuMain_File_Help_Info
            // 
            this.mnuMain_File_Help_Info.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Help;
            this.mnuMain_File_Help_Info.Name = "mnuMain_File_Help_Info";
            this.mnuMain_File_Help_Info.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F1)));
            this.mnuMain_File_Help_Info.Size = new System.Drawing.Size(235, 22);
            this.mnuMain_File_Help_Info.Text = "Inf&o...";
            this.mnuMain_File_Help_Info.Click += new System.EventHandler(this.mnuMain_File_Help_Info_Click);
            // 
            // tolMain
            // 
            this.tolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolMain_File_New,
            this.tolMain_File_Open,
            this.tolMain_File_Save,
            this.toolStripSeparator6,
            this.tolMain_Basedata_Company,
            this.tolMain_Basedata_BillClass});
            this.tolMain.Location = new System.Drawing.Point(0, 24);
            this.tolMain.Name = "tolMain";
            this.tolMain.Size = new System.Drawing.Size(990, 25);
            this.tolMain.TabIndex = 7;
            this.tolMain.Text = "tolMain";
            // 
            // tolMain_File_New
            // 
            this.tolMain_File_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolMain_File_New.Image = ((System.Drawing.Image)(resources.GetObject("tolMain_File_New.Image")));
            this.tolMain_File_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMain_File_New.Name = "tolMain_File_New";
            this.tolMain_File_New.Size = new System.Drawing.Size(23, 22);
            this.tolMain_File_New.Text = "&Neu";
            this.tolMain_File_New.Click += new System.EventHandler(this.tolMain_File_New_Click);
            // 
            // tolMain_File_Open
            // 
            this.tolMain_File_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolMain_File_Open.Image = ((System.Drawing.Image)(resources.GetObject("tolMain_File_Open.Image")));
            this.tolMain_File_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMain_File_Open.Name = "tolMain_File_Open";
            this.tolMain_File_Open.Size = new System.Drawing.Size(23, 22);
            this.tolMain_File_Open.Text = "Ö&ffnen";
            this.tolMain_File_Open.Click += new System.EventHandler(this.tolMain_File_Open_Click);
            // 
            // tolMain_File_Save
            // 
            this.tolMain_File_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolMain_File_Save.Image = ((System.Drawing.Image)(resources.GetObject("tolMain_File_Save.Image")));
            this.tolMain_File_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMain_File_Save.Name = "tolMain_File_Save";
            this.tolMain_File_Save.Size = new System.Drawing.Size(23, 22);
            this.tolMain_File_Save.Text = "&Speichern";
            this.tolMain_File_Save.Click += new System.EventHandler(this.tolMain_File_Save_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tolMain_Basedata_Company
            // 
            this.tolMain_Basedata_Company.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolMain_Basedata_Company.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Company;
            this.tolMain_Basedata_Company.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMain_Basedata_Company.Name = "tolMain_Basedata_Company";
            this.tolMain_Basedata_Company.Size = new System.Drawing.Size(23, 22);
            this.tolMain_Basedata_Company.Text = "Verwalte Firmen";
            this.tolMain_Basedata_Company.Click += new System.EventHandler(this.tolMain_Basedata_Company_Click);
            // 
            // tolMain_Basedata_BillClass
            // 
            this.tolMain_Basedata_BillClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tolMain_Basedata_BillClass.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Class;
            this.tolMain_Basedata_BillClass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tolMain_Basedata_BillClass.Name = "tolMain_Basedata_BillClass";
            this.tolMain_Basedata_BillClass.Size = new System.Drawing.Size(23, 22);
            this.tolMain_Basedata_BillClass.Text = "Verwalte Kategorien";
            this.tolMain_Basedata_BillClass.Click += new System.EventHandler(this.tolMain_Basedata_BillClass_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 621);
            this.Controls.Add(this.tolMain);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.mnuMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMainForm;
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "MainForm";
            this.Text = "{0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.mnuMainForm.ResumeLayout(false);
            this.mnuMainForm.PerformLayout();
            this.tolMain.ResumeLayout(false);
            this.tolMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.MenuStrip mnuMainForm;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_New;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Save;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_SaveAs;
        private System.Windows.Forms.ToolStripSeparator mnuMain_File_SepRecentFiles;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Help;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Help_Info;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Window;
        private System.Windows.Forms.ToolStrip tolMain;
        private System.Windows.Forms.ToolStripButton tolMain_File_New;
        private System.Windows.Forms.ToolStripButton tolMain_File_Open;
        private System.Windows.Forms.ToolStripButton tolMain_File_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tolMain_Basedata_Company;
        private System.Windows.Forms.ToolStripButton tolMain_Basedata_BillClass;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Window_Cascade;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Window_Horizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Window_Vertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Window_Statusbar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_Close;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Extras;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Extras_Options;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_Help_CheckUpdate;
        private System.Windows.Forms.ToolStripSeparator mnuMain_Help_SepAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_RecentFiles;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_RecentFiles_File0;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_RecentFiles_File1;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_RecentFiles_File2;
        private System.Windows.Forms.ToolStripMenuItem mnuMain_File_RecentFiles_File3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel tslBills;
        private System.Windows.Forms.ToolStripStatusLabel tslFiles;
        private System.Windows.Forms.ToolStripStatusLabel tslCompa;
        private System.Windows.Forms.ToolStripStatusLabel tslBillC;
        private System.Windows.Forms.ToolStripStatusLabel tslProFi;
    }
}