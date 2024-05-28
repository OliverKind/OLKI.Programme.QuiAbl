/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Backgroundworker to exit the application
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

using OLKI.Programme.QuiAbl.Properties;
using OLKI.Programme.QuiAbl.src.Forms.Bills;
using OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    public partial class MainForm
    {
        #region Constants
        /// <summary>
        /// Flag to show that the Application can be closed finally
        /// </summary>
        private const int COMPLETE_FLAG = 1000;
        #endregion

        #region Fields
        /// <summary>
        /// Backgroundworker to exit the application
        /// </summary>
        private readonly BackgroundWorker _bgwExitApp = new BackgroundWorker();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial the Backgroundworker to Exit the Application
        /// </summary>
        private void Initial_bgwExitApp()
        {
            this._bgwExitApp.WorkerReportsProgress = true;
            this._bgwExitApp.WorkerSupportsCancellation = true;
            this._bgwExitApp.DoWork += new DoWorkEventHandler(this._bgwExitApplication_DoWork);
            this._bgwExitApp.ProgressChanged += new ProgressChangedEventHandler(this._bgwExitApplication_ProgressChanged);
            this._bgwExitApp.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._bgwExitApplication_RunWorkerCompleted);
        }

        #region ExitApplication
        private void _bgwExitApplication_DoWork(object sender, DoWorkEventArgs e)
        {
            string ProjectFile;
            ProjectForm ProjectForm;
            SaveProjectsState State;
            BackgroundWorker Worker = (BackgroundWorker)sender;

            this._progressForm = new ProgressForm();

            foreach (Form MdiChield in this.MdiChildren)
            {
                ProjectForm = (ProjectForm)MdiChield;
                ProjectFile = ProjectForm.Project.File != null ? ProjectForm.Project.File.Name : "";
                State = new SaveProjectsState(ProjectForm, true)
                {
                    ProgressDescirption = Stringtable._0x0013,
                    ProjectFile = ProjectFile,
                    Canceled = false
                };

                if (ProjectForm.Project.Changed)
                {
                    DialogResult CloseDialogResult = (DialogResult)ProjectForm.Invoke((Func<DialogResult>)(() => MessageBox.Show(ProjectForm, string.Format(Stringtable._0x0015m, new object[] { ProjectFile }), Stringtable._0x0015c, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)));
                    switch (CloseDialogResult)
                    {
                        case DialogResult.Yes:
                            State.SaveSucess = ProjectForm.Project.Project_Save(this, Worker, e);
                            Worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());
                            if (!State.SaveSucess)
                            {
                                State.Canceled = true;
                                e.Cancel = true;
                                Worker.CancelAsync();
                                return;
                            }
                            break;
                        case DialogResult.No:
                            State.SaveSucess = true;
                            Worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());
                            break;
                        case DialogResult.Cancel:
                            State.SaveSucess = false;
                            State.Canceled = true;
                            e.Cancel = true;
                            Worker.CancelAsync();
                            return;
                        default:
                            throw new NotImplementedException();
                    }
                }
                else
                {
                    State.SaveSucess = true;
                    Worker.ReportProgress(ProgressForm.PROGRESSBAR_SET_MARQUE, State.Clone());
                }
            }

            //Delete Temp files
            foreach (string fileItem in Settings_AppTemp.Default.TempFileList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    System.IO.File.Delete(fileItem);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            Worker.ReportProgress(COMPLETE_FLAG, null);
        }

        private void _bgwExitApplication_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == COMPLETE_FLAG)
            {
                this._bgwExitApplication_RunWorkerCompleted(sender, new RunWorkerCompletedEventArgs(COMPLETE_FLAG, null, false));
                return;
            }

            this._bgwSaveFile_ProgressChanged(sender, e);
            SaveProjectsState State = (SaveProjectsState)e.UserState;
            if (!State.Canceled && State.SaveSucess) State.ProjectForm.Close();
        }

        private void _bgwExitApplication_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this._progressForm != null)
            {
                this._progressForm.Close();
                this._progressForm.Dispose();
            }

            if (!e.Cancelled)
            {
                this.Close(true);
                Application.Exit();
            }
        }
        #endregion
        #endregion
    }
}