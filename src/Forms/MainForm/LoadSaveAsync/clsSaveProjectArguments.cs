/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class with state informations for BackgroundWorker to save a project
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
    /// Class with state informations for BackgroundWorker to save a project
    /// </summary>
    public class SaveProjectsArguments
    {
        #region Enums
        /// <summary>
        /// Save mode for save file BackgroundWorker
        /// </summary>
        public enum SaveMode
        {
            Save,
            SaveAs
        }
        #endregion

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
        /// Get or set the FilePath of the File to save porject data to
        /// </summary>
        public string ProjectFile { get; set; }

        /// <summary>
        /// Get the ProjectForm of the project to save
        /// </summary>
        public ProjectForm ProjectForm { get; } = null;

        /// <summary>
        /// Get the SaveMode
        /// </summary>
        public SaveMode SaveModeOption { get; } = SaveMode.Save;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new SaveProjectsArguments class
        /// </summary>
        /// <param name="saveModeOption">Set the SaveMode</param>
        /// <param name="projectForm">The ProjectForm of the PRoject to save</param>
        /// <param name="closeFormAfterSave">Shold the ProjectForm closed after saving the project</param>
        internal SaveProjectsArguments(SaveMode saveModeOption, ProjectForm projectForm, bool closeFormAfterSave)
        {
            this.CloseFormAfterSave = closeFormAfterSave;
            this.ProjectForm = projectForm;
            this.SaveModeOption = saveModeOption;
        }
        #endregion
    }
}