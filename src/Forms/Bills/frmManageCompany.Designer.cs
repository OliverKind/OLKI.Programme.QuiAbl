namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    partial class ManageCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCompany));
            this.grbProperties = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCompanyRemove = new System.Windows.Forms.Button();
            this.btnCompanyAdd = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lsvCompanies = new OLKI.Widgets.SortListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbProperties
            // 
            this.grbProperties.Controls.Add(this.lblComment);
            this.grbProperties.Controls.Add(this.txtComment);
            this.grbProperties.Controls.Add(this.txtTitle);
            this.grbProperties.Controls.Add(this.lblTitle);
            this.grbProperties.Location = new System.Drawing.Point(224, 12);
            this.grbProperties.Name = "grbProperties";
            this.grbProperties.Size = new System.Drawing.Size(656, 327);
            this.grbProperties.TabIndex = 3;
            this.grbProperties.TabStop = false;
            this.grbProperties.Text = "Firma";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(6, 42);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(63, 13);
            this.lblComment.TabIndex = 2;
            this.lblComment.Text = "Kommentar:";
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtComment.Location = new System.Drawing.Point(6, 58);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(644, 263);
            this.txtComment.TabIndex = 3;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTitle.Location = new System.Drawing.Point(77, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(573, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Benennung:";
            // 
            // btnCompanyRemove
            // 
            this.btnCompanyRemove.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Delete;
            this.btnCompanyRemove.Location = new System.Drawing.Point(118, 12);
            this.btnCompanyRemove.Name = "btnCompanyRemove";
            this.btnCompanyRemove.Size = new System.Drawing.Size(100, 24);
            this.btnCompanyRemove.TabIndex = 1;
            this.btnCompanyRemove.Text = "Löschen";
            this.btnCompanyRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompanyRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompanyRemove.UseVisualStyleBackColor = true;
            this.btnCompanyRemove.Click += new System.EventHandler(this.btnCompanyRemove_Click);
            // 
            // btnCompanyAdd
            // 
            this.btnCompanyAdd.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.New;
            this.btnCompanyAdd.Location = new System.Drawing.Point(12, 12);
            this.btnCompanyAdd.Name = "btnCompanyAdd";
            this.btnCompanyAdd.Size = new System.Drawing.Size(100, 24);
            this.btnCompanyAdd.TabIndex = 0;
            this.btnCompanyAdd.Text = "Hinzufügen";
            this.btnCompanyAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompanyAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompanyAdd.UseVisualStyleBackColor = true;
            this.btnCompanyAdd.Click += new System.EventHandler(this.btnCompanyAdd_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Accept;
            this.btnAccept.Location = new System.Drawing.Point(118, 345);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 5;
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
            this.btnCancel.Location = new System.Drawing.Point(780, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Ok;
            this.btnOk.Location = new System.Drawing.Point(12, 345);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lsvCompanies
            // 
            this.lsvCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lsvCompanies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvCompanies.GridLines = true;
            this.lsvCompanies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCompanies.HideSelection = false;
            this.lsvCompanies.Location = new System.Drawing.Point(12, 42);
            this.lsvCompanies.MultiSelect = false;
            this.lsvCompanies.Name = "lsvCompanies";
            this.lsvCompanies.ShowItemToolTips = true;
            this.lsvCompanies.Size = new System.Drawing.Size(206, 297);
            this.lsvCompanies.TabIndex = 2;
            this.lsvCompanies.UseCompatibleStateImageBehavior = false;
            this.lsvCompanies.View = System.Windows.Forms.View.Details;
            this.lsvCompanies.SelectedIndexChanged += new System.EventHandler(this.lsvCompanies_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datei";
            this.columnHeader1.Width = 165;
            // 
            // ManageCompany
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(892, 381);
            this.Controls.Add(this.lsvCompanies);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCompanyRemove);
            this.Controls.Add(this.btnCompanyAdd);
            this.Controls.Add(this.grbProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageCompany";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Firmen verwalten";
            this.grbProperties.ResumeLayout(false);
            this.grbProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProperties;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCompanyRemove;
        private System.Windows.Forms.Button btnCompanyAdd;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private OLKI.Widgets.SortListView lsvCompanies;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}