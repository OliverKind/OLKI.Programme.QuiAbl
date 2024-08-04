namespace OLKI.Programme.QuiAbl.src.Forms
{
    partial class Search
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
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblDate2 = new System.Windows.Forms.Label();
            this.txtSearchtext = new System.Windows.Forms.TextBox();
            this.lblSearchtext = new System.Windows.Forms.Label();
            this.lblBillClasses = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.trvBillClasses = new System.Windows.Forms.TreeView();
            this.mtbDateMin = new System.Windows.Forms.MaskedTextBox();
            this.mtbDateMax = new System.Windows.Forms.MaskedTextBox();
            this.mtbExpidationMax = new System.Windows.Forms.MaskedTextBox();
            this.mtbExpidationMin = new System.Windows.Forms.MaskedTextBox();
            this.lblExpidation2 = new System.Windows.Forms.Label();
            this.lblExpidation = new System.Windows.Forms.Label();
            this.chkBillDisposed = new System.Windows.Forms.CheckBox();
            this.chkCloseAfterSucessSearch = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPrice
            // 
            this.nudPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(111, 117);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 20);
            this.nudPrice.TabIndex = 13;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(12, 119);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(93, 23);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Betrag:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(12, 548);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(419, 24);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "&Suchen";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblDate2
            // 
            this.lblDate2.Location = new System.Drawing.Point(197, 42);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(25, 23);
            this.lblDate2.TabIndex = 4;
            this.lblDate2.Text = "bis";
            // 
            // txtSearchtext
            // 
            this.txtSearchtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchtext.Location = new System.Drawing.Point(111, 91);
            this.txtSearchtext.Name = "txtSearchtext";
            this.txtSearchtext.Size = new System.Drawing.Size(320, 20);
            this.txtSearchtext.TabIndex = 11;
            // 
            // lblSearchtext
            // 
            this.lblSearchtext.Location = new System.Drawing.Point(12, 94);
            this.lblSearchtext.Name = "lblSearchtext";
            this.lblSearchtext.Size = new System.Drawing.Size(93, 23);
            this.lblSearchtext.TabIndex = 10;
            this.lblSearchtext.Text = "Suchtext:";
            // 
            // lblBillClasses
            // 
            this.lblBillClasses.Location = new System.Drawing.Point(12, 140);
            this.lblBillClasses.Name = "lblBillClasses";
            this.lblBillClasses.Size = new System.Drawing.Size(215, 23);
            this.lblBillClasses.TabIndex = 14;
            this.lblBillClasses.Text = "Kategorie:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(12, 42);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(93, 23);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Belegdatum:";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(12, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(93, 23);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Firma:";
            // 
            // cboCompany
            // 
            this.cboCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(111, 12);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(320, 21);
            this.cboCompany.TabIndex = 1;
            // 
            // trvBillClasses
            // 
            this.trvBillClasses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvBillClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trvBillClasses.HideSelection = false;
            this.trvBillClasses.Location = new System.Drawing.Point(15, 166);
            this.trvBillClasses.Name = "trvBillClasses";
            this.trvBillClasses.Size = new System.Drawing.Size(416, 353);
            this.trvBillClasses.TabIndex = 15;
            this.trvBillClasses.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBillClasses_BeforeCollapse);
            this.trvBillClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvBillClasses_MouseDown);
            // 
            // mtbDateMin
            // 
            this.mtbDateMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbDateMin.Location = new System.Drawing.Point(111, 39);
            this.mtbDateMin.Mask = "00/00/0000";
            this.mtbDateMin.Name = "mtbDateMin";
            this.mtbDateMin.Size = new System.Drawing.Size(80, 20);
            this.mtbDateMin.TabIndex = 3;
            this.mtbDateMin.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDateMax
            // 
            this.mtbDateMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbDateMax.Location = new System.Drawing.Point(228, 39);
            this.mtbDateMax.Mask = "00/00/0000";
            this.mtbDateMax.Name = "mtbDateMax";
            this.mtbDateMax.Size = new System.Drawing.Size(80, 20);
            this.mtbDateMax.TabIndex = 5;
            this.mtbDateMax.ValidatingType = typeof(System.DateTime);
            // 
            // mtbExpidationMax
            // 
            this.mtbExpidationMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbExpidationMax.Location = new System.Drawing.Point(228, 65);
            this.mtbExpidationMax.Mask = "00/00/0000";
            this.mtbExpidationMax.Name = "mtbExpidationMax";
            this.mtbExpidationMax.Size = new System.Drawing.Size(80, 20);
            this.mtbExpidationMax.TabIndex = 9;
            this.mtbExpidationMax.ValidatingType = typeof(System.DateTime);
            // 
            // mtbExpidationMin
            // 
            this.mtbExpidationMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbExpidationMin.Location = new System.Drawing.Point(111, 65);
            this.mtbExpidationMin.Mask = "00/00/0000";
            this.mtbExpidationMin.Name = "mtbExpidationMin";
            this.mtbExpidationMin.Size = new System.Drawing.Size(80, 20);
            this.mtbExpidationMin.TabIndex = 7;
            this.mtbExpidationMin.ValidatingType = typeof(System.DateTime);
            // 
            // lblExpidation2
            // 
            this.lblExpidation2.Location = new System.Drawing.Point(197, 68);
            this.lblExpidation2.Name = "lblExpidation2";
            this.lblExpidation2.Size = new System.Drawing.Size(25, 23);
            this.lblExpidation2.TabIndex = 8;
            this.lblExpidation2.Text = "bis";
            // 
            // lblExpidation
            // 
            this.lblExpidation.Location = new System.Drawing.Point(12, 68);
            this.lblExpidation.Name = "lblExpidation";
            this.lblExpidation.Size = new System.Drawing.Size(93, 23);
            this.lblExpidation.TabIndex = 6;
            this.lblExpidation.Text = "Relevant bis:";
            // 
            // chkBillDisposed
            // 
            this.chkBillDisposed.AutoSize = true;
            this.chkBillDisposed.Checked = true;
            this.chkBillDisposed.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkBillDisposed.Location = new System.Drawing.Point(314, 67);
            this.chkBillDisposed.Name = "chkBillDisposed";
            this.chkBillDisposed.Size = new System.Drawing.Size(117, 17);
            this.chkBillDisposed.TabIndex = 18;
            this.chkBillDisposed.Text = "Rechnung entsorgt";
            this.chkBillDisposed.ThreeState = true;
            this.chkBillDisposed.UseVisualStyleBackColor = true;
            // 
            // chkCloseAfterSucessSearch
            // 
            this.chkCloseAfterSucessSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCloseAfterSucessSearch.AutoSize = true;
            this.chkCloseAfterSucessSearch.Location = new System.Drawing.Point(12, 525);
            this.chkCloseAfterSucessSearch.Name = "chkCloseAfterSucessSearch";
            this.chkCloseAfterSucessSearch.Size = new System.Drawing.Size(290, 17);
            this.chkCloseAfterSucessSearch.TabIndex = 20;
            this.chkCloseAfterSucessSearch.Text = "Bei erfolgreicher Suche, Formular automatisch schließen";
            this.chkCloseAfterSucessSearch.UseVisualStyleBackColor = true;
            this.chkCloseAfterSucessSearch.CheckedChanged += new System.EventHandler(this.chkCloseAfterSucessSearch_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(334, 166);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 24);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Schließen";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Search
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(443, 584);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chkCloseAfterSucessSearch);
            this.Controls.Add(this.chkBillDisposed);
            this.Controls.Add(this.mtbExpidationMax);
            this.Controls.Add(this.mtbExpidationMin);
            this.Controls.Add(this.lblExpidation2);
            this.Controls.Add(this.lblExpidation);
            this.Controls.Add(this.mtbDateMax);
            this.Controls.Add(this.mtbDateMin);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblDate2);
            this.Controls.Add(this.txtSearchtext);
            this.Controls.Add(this.lblSearchtext);
            this.Controls.Add(this.lblBillClasses);
            this.Controls.Add(this.trvBillClasses);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cboCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Search";
            this.ShowInTaskbar = false;
            this.Text = "Suchen in: {0}";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Search_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblDate2;
        private System.Windows.Forms.TextBox txtSearchtext;
        private System.Windows.Forms.Label lblSearchtext;
        private System.Windows.Forms.Label lblBillClasses;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TreeView trvBillClasses;
        private System.Windows.Forms.MaskedTextBox mtbDateMin;
        private System.Windows.Forms.MaskedTextBox mtbDateMax;
        private System.Windows.Forms.MaskedTextBox mtbExpidationMax;
        private System.Windows.Forms.MaskedTextBox mtbExpidationMin;
        private System.Windows.Forms.Label lblExpidation2;
        private System.Windows.Forms.Label lblExpidation;
        private System.Windows.Forms.CheckBox chkBillDisposed;
        private System.Windows.Forms.CheckBox chkCloseAfterSucessSearch;
        private System.Windows.Forms.Button btnClose;
    }
}