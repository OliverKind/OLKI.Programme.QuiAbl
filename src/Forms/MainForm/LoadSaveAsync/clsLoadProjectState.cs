/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class with state informations while loding a project
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

namespace OLKI.Programme.QuiAbl.src.Forms.MainForm.LoadSaveAsync
{
    /// <summary>
    /// Class with state informations while loding a project
    /// </summary>
    public class LoadProjectState
    {
        #region Properties
        /// <summary>
        /// Get or set the description of the actual state
        /// </summary>
        public string ProgressDescirption { get; set; }

        /// <summary>
        /// Get or set the file to load porject data from
        /// </summary>
        public string ProjectFile { get; set; }

        /// <summary>
        /// Get or set the data of the loaded project
        /// </summary>
        public Project.Project ProjectData { get; set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Clone the state object
        /// </summary>
        /// <returns>The cloned state object</returns>
        public LoadProjectState Clone()
        {
            return (LoadProjectState)this.MemberwiseClone();
        }
        #endregion
    }
}