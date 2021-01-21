/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * A Form to show progresses
 * 
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the LGPL General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed WITHOUT ANY WARRANTY; without even the implied
 * warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * LGPL General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not check the GitHub-Repository.
 * 
 * */

using System;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms
{
    /// <summary>
    /// A Form to show progresses
    /// </summary>
    public partial class ProgressForm : Form
    {
        /// <summary>
        /// If this value is set to ProgressBar, the ProgressBarStyle ist set to Marque
        /// </summary>
        public readonly static sbyte PROGRESSBAR_SET_MARQUE = -1;

        #region Events
        /// <summary>
        /// Raised if Cancel Button was clicked
        /// </summary>
        public EventHandler CancelClick;
        #endregion

        #region Fields
        /// <summary>
        /// Repress clsoe form, for example by clicking the "X".
        /// </summary>
        private bool _repressClose = true;
        #endregion

        #region Properties
        /// <summary>
        /// Get or set if the Cancel Button is enabled
        /// </summary>
        public bool CancelButtonEnabled
        {
            get
            {
                return this.btnCancel.Enabled;
            }
            set
            {
                this.btnCancel.Enabled = value;
            }
        }

        /// <summary>
        /// Get or set the form Title
        /// </summary>
        public string FormTitle
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        /// <summary>
        /// Get or set if the Value of the ProgressBar 
        /// </summary>
        public int ProgressBarValue
        {
            get
            {
                return this.pbaProgress.Value;
            }
            set
            {
                if (value == PROGRESSBAR_SET_MARQUE)
                {
                    this.pbaProgress.Style = ProgressBarStyle.Marquee;
                }
                else if (value >= this.pbaProgress.Minimum && value <= this.pbaProgress.Maximum)
                {
                    this.pbaProgress.Style = ProgressBarStyle.Blocks;
                    this.pbaProgress.Value = value;
                }
            }
        }

        /// <summary>
        /// Get or set the progess description
        /// </summary>
        public string ProgessDescription
        {
            get
            {
                return this.lblProgressDescription.Text;
            }
            set
            {
                this.lblProgressDescription.Text = value;
            }
        }
        /// <summary>
        /// Get or set the progress file
        /// </summary>
        public string ProgessFile
        {
            get
            {
                return this.lblProgressFile.Text;
            }
            set
            {
                this.lblProgressFile.Text = value;
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new ProgressForm
        /// </summary>
        public ProgressForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the ProgressForm
        /// </summary>
        public new void Close()
        {
            this._repressClose = false;
            base.Close();
        }

        #region Form events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelClick?.Invoke(this, e);
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._repressClose) e.Cancel = true;
        }
        #endregion
        #endregion
    }
}