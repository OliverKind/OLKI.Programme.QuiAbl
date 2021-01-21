namespace OLKI.Programme.QuiAbl.src.Forms
{
    partial class ProgressForm
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
            this.pbaProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProgressFile = new System.Windows.Forms.Label();
            this.lblProgressDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbaProgress
            // 
            this.pbaProgress.Location = new System.Drawing.Point(11, 42);
            this.pbaProgress.Name = "pbaProgress";
            this.pbaProgress.Size = new System.Drawing.Size(350, 24);
            this.pbaProgress.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::OLKI.Programme.QuiAbl.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProgressFile
            // 
            this.lblProgressFile.AutoEllipsis = true;
            this.lblProgressFile.Location = new System.Drawing.Point(13, 13);
            this.lblProgressFile.Name = "lblProgressFile";
            this.lblProgressFile.Size = new System.Drawing.Size(349, 13);
            this.lblProgressFile.TabIndex = 0;
            this.lblProgressFile.Text = "lblProgressFile";
            // 
            // lblProgressDescription
            // 
            this.lblProgressDescription.AutoEllipsis = true;
            this.lblProgressDescription.Location = new System.Drawing.Point(12, 26);
            this.lblProgressDescription.Name = "lblProgressDescription";
            this.lblProgressDescription.Size = new System.Drawing.Size(349, 13);
            this.lblProgressDescription.TabIndex = 3;
            this.lblProgressDescription.Text = "lblProgressDescription";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 78);
            this.ControlBox = false;
            this.Controls.Add(this.lblProgressDescription);
            this.Controls.Add(this.lblProgressFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbaProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitte warten ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbaProgress;
        private System.Windows.Forms.Label lblProgressFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProgressDescription;
    }
}