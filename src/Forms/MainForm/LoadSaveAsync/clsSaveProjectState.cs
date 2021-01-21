/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class with state informations while save a project
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

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync
{
    /// <summary>
    /// Class with state informations while save a project
    /// </summary>
    public class SaveProjectsState
    {
        #region Properties
        /// <summary>
        /// The loading process was canceled
        /// </summary>
        public bool Canceled { get; set; }

        /// <summary>
        /// Get if the PorjectForm shold been closed after safe
        /// </summary>
        public bool CloseFormAfterSave { get; } = false;

        /// <summary>
        /// The description of the actual state
        /// </summary>
        public string ProgressDescirption { get; set; }

        /// <summary>
        /// Get or set the path for the file to save porject data to
        /// </summary>
        public string ProjectFile { get; set; }

        /// <summary>
        /// The Project Form
        /// </summary>
        public ProjectForm ProjectForm { get; } = null;

        /// <summary>
        /// Get or set if the project was saved with sucess
        /// </summary>
        public bool SaveSucess { get; set; } = false;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new SaveProjectsState class
        /// </summary>
        /// <param name="projectForm">The ProjectForm of the PRoject to save</param>
        /// <param name="closeFormAfterSave">Shold the ProjectForm closed after saving the project</param>
        internal SaveProjectsState(ProjectForm projectForm, bool closeFormAfterSave)
        {
            this.CloseFormAfterSave = closeFormAfterSave;
            this.ProjectForm = projectForm;
        }

        /// <summary>
        /// Clone the state object
        /// </summary>
        /// <returns>The cloned state object</returns>
        public SaveProjectsState Clone()
        {
            return (SaveProjectsState)this.MemberwiseClone();
        }
        #endregion
    }
}