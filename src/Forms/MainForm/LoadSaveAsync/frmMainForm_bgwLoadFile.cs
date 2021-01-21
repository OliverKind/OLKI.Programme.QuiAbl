/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Backgroundworker to load an project file
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

using OLKI.Programme.QuiAbl.src.Forms.Bills;
using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using System;
using System.ComponentModel;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    public partial class MainForm
    {
        #region Fields
        /// <summary>
        /// Backgroundworker to load a project file
        /// </summary>
        private readonly BackgroundWorker _bgwLoadFile = new BackgroundWorker();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial the Backgroundworker to load an project file
        /// </summary>
        private void Initial_bgwLoadFile()
        {
            this._bgwLoadFile.WorkerReportsProgress = true;
            this._bgwLoadFile.DoWork += new DoWorkEventHandler(this._bgwLoadFile_DoWork);
            this._bgwLoadFile.ProgressChanged += new ProgressChangedEventHandler(this._bgwLoadFile_ProgressChanged);
            this._bgwLoadFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._bgwLoadFile_RunWorkerCompleted);
        }

        #region LoadFile
        private void _bgwLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker Worker = (BackgroundWorker)sender;

            this._progressForm = new ProgressForm();
            this._projectManager.Project_Open("", Worker);
        }

        private void _bgwLoadFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LoadProjectState State = (LoadProjectState)e.UserState;

            if (!this._progressForm.Visible) this._progressForm.Show(this);

            this._progressForm.ProgressBarValue = e.ProgressPercentage;
            this._progressForm.ProgessDescription = State.ProgressDescirption;
            this._progressForm.ProgessFile = State.ProjectFile;

            //Project Loaded
            if (State.ProjectData != null)
            {
                ProjectForm ProjectForm = new ProjectForm(State.ProjectData)
                {
                    MdiParent = this
                };
                ProjectForm.Show();
                ProjectForm.RequestClose += new EventHandler(this.MainForm_MdiChildRequestClose);
            }
        }

        private void _bgwLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this._progressForm != null)
            {
                this._progressForm.Close();
                this._progressForm.Dispose();
            }
        }
        #endregion
        #endregion
    }
}