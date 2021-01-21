/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Backgroundworker to load project files at application start up
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
using System.ComponentModel;
using System.IO;

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm
{
    public partial class MainForm
    {
        #region Fields
        /// <summary>
        /// BackgroundWorker to load project files at application start up
        /// </summary>
        private readonly BackgroundWorker _bgwLoadFilesAtStartup = new BackgroundWorker();
        #endregion

        #region Methodes
        /// <summary>
        /// Initial the BackgroundWorker to load project files at application start up
        /// </summary>
        private void Initial_bgwStartupLoadFile()
        {
            this._bgwLoadFilesAtStartup.WorkerReportsProgress = true;
            this._bgwLoadFilesAtStartup.DoWork += new DoWorkEventHandler(this._bgwLoadFilesAtStartup_DoWork);
            this._bgwLoadFilesAtStartup.ProgressChanged += new ProgressChangedEventHandler(this._bgwLoadFilesAtStartup_ProgressChanged);
            this._bgwLoadFilesAtStartup.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._bgwLoadFilesAtStartup_RunWorkerCompleted);
        }

        #region StartUpLoadFile
        private void _bgwLoadFilesAtStartup_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker Worker = (BackgroundWorker)sender;

            this._progressForm = new ProgressForm();

            // Load project file from args
            foreach (string Arg in (string[])e.Argument)
            {
                if (new FileInfo(Arg).Exists)
                {
                    this._projectManager.Project_Open(Arg, Worker);
                    break;
                }
            }

            // Load default project file
            if (this._projectManager.ActiveProject == null && !string.IsNullOrEmpty(Settings.Default.Startup_DefaultFileOpen))
            {
                this._projectManager.Project_Open(Settings.Default.Startup_DefaultFileOpen, Worker);
            }

            // Load empty project
            if (this._projectManager.ActiveProject == null && Settings.Default.Startup_DefaultLoadEmptyProject)
            {
                this._projectManager.Project_New(Worker);
            }
        }

        private void _bgwLoadFilesAtStartup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this._bgwLoadFile_ProgressChanged(sender, e);
        }

        private void _bgwLoadFilesAtStartup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._bgwLoadFile_RunWorkerCompleted(sender, e);
        }
        #endregion
        #endregion
    }
}