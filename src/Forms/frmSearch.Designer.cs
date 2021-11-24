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
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPrice
            // 
            this.nudPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(117, 117);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 20);
            this.nudPrice.TabIndex = 13;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(12, 119);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(99, 23);
            this.lblPrice.TabIndex = 12;
            this.lblPrice.Text = "Betrag:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(12, 525);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(385, 24);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "&Suchen";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblDate2
            // 
            this.lblDate2.Location = new System.Drawing.Point(203, 42);
            this.lblDate2.Name = "lblDate2";
            this.lblDate2.Size = new System.Drawing.Size(25, 23);
            this.lblDate2.TabIndex = 4;
            this.lblDate2.Text = "bis";
            // 
            // txtSearchtext
            // 
            this.txtSearchtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSearchtext.Location = new System.Drawing.Point(117, 91);
            this.txtSearchtext.Name = "txtSearchtext";
            this.txtSearchtext.Size = new System.Drawing.Size(279, 20);
            this.txtSearchtext.TabIndex = 11;
            // 
            // lblSearchtext
            // 
            this.lblSearchtext.Location = new System.Drawing.Point(12, 94);
            this.lblSearchtext.Name = "lblSearchtext";
            this.lblSearchtext.Size = new System.Drawing.Size(100, 23);
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
            this.lblDate.Size = new System.Drawing.Size(100, 23);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Belegdatum:";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(12, 15);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(100, 23);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Firma:";
            // 
            // cboCompany
            // 
            this.cboCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(117, 12);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(279, 21);
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
            this.trvBillClasses.Size = new System.Drawing.Size(385, 353);
            this.trvBillClasses.TabIndex = 15;
            this.trvBillClasses.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBillClasses_BeforeCollapse);
            this.trvBillClasses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvBillClasses_MouseDown);
            // 
            // mtbDateMin
            // 
            this.mtbDateMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbDateMin.Location = new System.Drawing.Point(117, 39);
            this.mtbDateMin.Mask = "00/00/0000";
            this.mtbDateMin.Name = "mtbDateMin";
            this.mtbDateMin.Size = new System.Drawing.Size(80, 20);
            this.mtbDateMin.TabIndex = 3;
            this.mtbDateMin.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDateMax
            // 
            this.mtbDateMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbDateMax.Location = new System.Drawing.Point(234, 39);
            this.mtbDateMax.Mask = "00/00/0000";
            this.mtbDateMax.Name = "mtbDateMax";
            this.mtbDateMax.Size = new System.Drawing.Size(80, 20);
            this.mtbDateMax.TabIndex = 5;
            this.mtbDateMax.ValidatingType = typeof(System.DateTime);
            // 
            // mtbExpidationMax
            // 
            this.mtbExpidationMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbExpidationMax.Location = new System.Drawing.Point(234, 65);
            this.mtbExpidationMax.Mask = "00/00/0000";
            this.mtbExpidationMax.Name = "mtbExpidationMax";
            this.mtbExpidationMax.Size = new System.Drawing.Size(80, 20);
            this.mtbExpidationMax.TabIndex = 9;
            this.mtbExpidationMax.ValidatingType = typeof(System.DateTime);
            // 
            // mtbExpidationMin
            // 
            this.mtbExpidationMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mtbExpidationMin.Location = new System.Drawing.Point(117, 65);
            this.mtbExpidationMin.Mask = "00/00/0000";
            this.mtbExpidationMin.Name = "mtbExpidationMin";
            this.mtbExpidationMin.Size = new System.Drawing.Size(80, 20);
            this.mtbExpidationMin.TabIndex = 7;
            this.mtbExpidationMin.ValidatingType = typeof(System.DateTime);
            // 
            // lblExpidation2
            // 
            this.lblExpidation2.Location = new System.Drawing.Point(203, 68);
            this.lblExpidation2.Name = "lblExpidation2";
            this.lblExpidation2.Size = new System.Drawing.Size(25, 23);
            this.lblExpidation2.TabIndex = 8;
            this.lblExpidation2.Text = "bis";
            // 
            // lblExpidation
            // 
            this.lblExpidation.Location = new System.Drawing.Point(12, 68);
            this.lblExpidation.Name = "lblExpidation";
            this.lblExpidation.Size = new System.Drawing.Size(100, 23);
            this.lblExpidation.TabIndex = 6;
            this.lblExpidation.Text = "Relevant bis:";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 561);
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
            this.Text = "Suchen";
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
    }
}