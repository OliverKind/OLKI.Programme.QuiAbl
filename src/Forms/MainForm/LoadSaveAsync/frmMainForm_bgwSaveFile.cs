/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Backgroundworker to save a project to file
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

using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using System;
using System.ComponentModel;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    public partial class MainForm
    {
        #region Fields
        /// <summary>
        /// BackgroundWorker to save a project to file
        /// </summary>
        private readonly BackgroundWorker _bgwSaveFile = new BackgroundWorker();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial the BackgroundWorker to save a project to file
        /// </summary>
        private void Initial_bgwSaveFile()
        {
            this._bgwSaveFile.WorkerReportsProgress = true;
            this._bgwSaveFile.WorkerSupportsCancellation = true;
            this._bgwSaveFile.DoWork += new DoWorkEventHandler(this._bgwSaveFile_DoWork);
            this._bgwSaveFile.ProgressChanged += new ProgressChangedEventHandler(this._bgwSaveFile_ProgressChanged);
            this._bgwSaveFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._bgwSaveFile_RunWorkerCompleted);
        }

        #region SaveFile
        private void _bgwSaveFile_DoWork(object sender, DoWorkEventArgs e)
        {
            SaveProjectsArguments SaveProjectsArguments = (SaveProjectsArguments)e.Argument;
            SaveProjectsState State = new SaveProjectsState(SaveProjectsArguments.ProjectForm, SaveProjectsArguments.CloseFormAfterSave)
            {
                ProjectFile = SaveProjectsArguments.ProjectFile
            };
            BackgroundWorker Worker = (BackgroundWorker)sender;

            this._progressForm = new ProgressForm();

            switch (SaveProjectsArguments.SaveModeOption)
            {
                case SaveProjectsArguments.SaveMode.Save:
                    State.SaveSucess = this._projectManager.ActiveProject.Project_Save(this, Worker, e);
                    break;
                case SaveProjectsArguments.SaveMode.SaveAs:
                    State.SaveSucess = this._projectManager.ActiveProject.Project_SaveAs(this, Worker, e);
                    break;
                default:
                    throw new NotImplementedException();
            }
            _ = State;
            e.Result = State;
        }

        private void _bgwSaveFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this._progressForm == null || this._progressForm.IsDisposed) return;
            if (!this._progressForm.Visible) this._progressForm.Show(this);

            SaveProjectsState State = (SaveProjectsState)e.UserState;
            this._progressForm.ProgressBarValue = e.ProgressPercentage;
            this._progressForm.ProgessDescription = State.ProgressDescirption;
            this._progressForm.ProgessFile = State.ProjectFile;
        }

        private void _bgwSaveFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                SaveProjectsState State = (SaveProjectsState)e.Result;

                //Remove change state, because of changes where saved.
                if (State.SaveSucess) this._projectManager.ActiveProject.Changed = false;

                //Write final State to Progress Form
                this._progressForm.ProgressBarValue = -1;
                this._progressForm.ProgessDescription = Properties.Stringtable._0x001C;
                this._progressForm.ProgessFile = State.ProjectFile;

                //Close Project form if required
                if (State.SaveSucess && State.CloseFormAfterSave && State.ProjectForm != null && !State.ProjectForm.IsDisposed)
                {
                    State.ProjectForm.Close();
                }
                this.SetStatusstripLabels(this.ActiveMdiChild);
            }

            //Close Progress Form
            if (this._progressForm != null && !this._progressForm.IsDisposed)
            {
                this._progressForm.Close();
                this._progressForm.Dispose();
            }
            this.SetRecentFilesSettingsAndMenue();
        }
        #endregion
        #endregion
    }
}