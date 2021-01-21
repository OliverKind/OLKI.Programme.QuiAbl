namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    partial class ManageBillClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBillClass));
            this.grbProperties = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.trvBillClasses = new System.Windows.Forms.TreeView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnBillClassRemove = new System.Windows.Forms.Button();
            this.btnBillClassAdd = new System.Windows.Forms.Button();
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
            this.grbProperties.Text = "Kategorie";
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
            // trvBillClasses
            // 
            this.trvBillClasses.AllowDrop = true;
            this.trvBillClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trvBillClasses.HideSelection = false;
            this.trvBillClasses.Location = new System.Drawing.Point(12, 42);
            this.trvBillClasses.Name = "trvBillClasses";
            this.trvBillClasses.Size = new System.Drawing.Size(206, 297);
            this.trvBillClasses.TabIndex = 2;
            this.trvBillClasses.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvBillClasses_BeforeCollapse);
            this.trvBillClasses.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.trvCategories_ItemDrag);
            this.trvBillClasses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvBillClasses_AfterSelect);
            this.trvBillClasses.DragDrop += new System.Windows.Forms.DragEventHandler(this.trvCategories_DragDrop);
            this.trvBillClasses.DragEnter += new System.Windows.Forms.DragEventHandler(this.trvCategories_DragEnter);
            this.trvBillClasses.DragOver += new System.Windows.Forms.DragEventHandler(this.trvCategories_DragOver);
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
            // btnBillClassRemove
            // 
            this.btnBillClassRemove.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Delete;
            this.btnBillClassRemove.Location = new System.Drawing.Point(118, 12);
            this.btnBillClassRemove.Name = "btnBillClassRemove";
            this.btnBillClassRemove.Size = new System.Drawing.Size(100, 24);
            this.btnBillClassRemove.TabIndex = 1;
            this.btnBillClassRemove.Text = "Löschen";
            this.btnBillClassRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBillClassRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillClassRemove.UseVisualStyleBackColor = true;
            this.btnBillClassRemove.Click += new System.EventHandler(this.btnBillClassRemove_Click);
            // 
            // btnBillClassAdd
            // 
            this.btnBillClassAdd.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.New;
            this.btnBillClassAdd.Location = new System.Drawing.Point(12, 12);
            this.btnBillClassAdd.Name = "btnBillClassAdd";
            this.btnBillClassAdd.Size = new System.Drawing.Size(100, 24);
            this.btnBillClassAdd.TabIndex = 0;
            this.btnBillClassAdd.Text = "Hinzufügen";
            this.btnBillClassAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBillClassAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBillClassAdd.UseVisualStyleBackColor = true;
            this.btnBillClassAdd.Click += new System.EventHandler(this.btnBillClassAdd_Click);
            // 
            // ManageBillClass
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(892, 381);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBillClassRemove);
            this.Controls.Add(this.btnBillClassAdd);
            this.Controls.Add(this.grbProperties);
            this.Controls.Add(this.trvBillClasses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageBillClass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kategorien verwalten";
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
        private System.Windows.Forms.TreeView trvBillClasses;
        private System.Windows.Forms.Button btnBillClassRemove;
        private System.Windows.Forms.Button btnBillClassAdd;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}