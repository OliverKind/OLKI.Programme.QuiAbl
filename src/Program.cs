﻿/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Root object of the application
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
using OLKI.Toolbox.DirectoryAndFile;
using OLKI.Toolbox.UpdateApp;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src
{
    /// <summary>
    /// Root object of the application
    /// </summary>
    internal static class Program
    {
        #region Constants
        /// <summary>
        /// Root path in registry HKEY_CURRENT_USER
        /// </summary>
        const string REGISTRY_USER_ROOT = "HKEY_CURRENT_USER";
        /// <summary>
        /// Key where the settings file path should been stored in registry
        /// </summary>
        const string REGISTRY_SETTINGS_DIRECTORY_KEY = "SettingDir";
        #endregion

        #region Methodes
        /// <summary>
        /// Main entry point of the application
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Start Application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Save settings directory to registry, to make it possible for the uninstaller to delete it
            string RegistryPath = string.Empty;

            System.Configuration.Configuration Config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoaming);
            string[] FilePathSplit = Config.FilePath.Split('\\');
            string ConigFilePathRootDir = string.Empty;
            for (int i = 0; i < FilePathSplit.Length - 2; i++)
            {
                ConigFilePathRootDir += FilePathSplit[i];
                ConigFilePathRootDir += '\\';
            }
            RegistryPath += REGISTRY_USER_ROOT + '\\';
            RegistryPath += "Software" + '\\';
            RegistryPath += Application.CompanyName + '\\';
            RegistryPath += Application.ProductName + '\\';
            Microsoft.Win32.Registry.SetValue(RegistryPath, REGISTRY_SETTINGS_DIRECTORY_KEY, ConigFilePathRootDir);

            // Upgrade Settings
            if (!Settings_AppVar.Default.SettingsUpgradet)
            {
                Settings.Default.Upgrade();
                Settings_AppConst.Default.Upgrade();
                Settings_AppTemp.Default.Upgrade();
                Settings_AppVar.Default.Upgrade();

                Settings_AppVar.Default.SettingsUpgradet = true;
                Settings_AppVar.Default.Save();
            }
            Application.Run(new Forms.MainForm.MainForm(args));
        }

        /// <summary>
        /// Check if the application project file, specified in application stettings, is associated with the application and associates it, if requested
        /// </summary>
        /// <param name="showMessageIfAssociated">Specifies if a message should been shown if the application project file, specified in application stettings, is already associated with application</param>
        internal static void CheckFileAssociationAndSet(bool showMessageIfAssociated)
        {
            // Get Path to Icon
            string IconPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IconPath += @"\";
            IconPath += Settings_AppConst.Default.FileAssociation_ExtensionIconFile;

            // Check File Association
            FileAssociation.CheckMatchWithApplicationAndSet(
                Application.ExecutablePath,
                "." + Settings_AppConst.Default.ProjectFile_DefaultExtension,
                Settings_AppConst.Default.ProjectFile_DefaultExtension,
                Settings_AppConst.Default.FileAssociation_ExtensionFile,
                Settings_AppConst.Default.FileAssociation_ExtensionDescription,
                IconPath,
                showMessageIfAssociated);
        }

        /// <summary>
        /// Check for Updates for the Apllication and Install them if available
        /// <param name="mainForm">MainForm of the Application</param>
        /// <paramref name="hideMessages"/>Hide Messages for no update or if update data can't be determinated</paramref>
        /// </summary>
        internal static void CheckForUpdate(IWin32Window mainForm, bool hideMessages)
        {
            UpdateApp AppUpdater = new UpdateApp();
            ReleaseData LastReleaseData = AppUpdater.GetLastReleaseData(
                Settings_AppConst.Default.AppUpdate_Owner,
                Settings_AppConst.Default.AppUpdate_Name,
                Settings_AppConst.Default.AppUpdate_ChangeLog,
                Settings_AppConst.Default.AppUpdate_SetupSearchPattern,
                out Exception GetDataEx);
            ReleaseVersion ActualVersion = new ReleaseVersion(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            // Exit application if update was downloaded
            if (AppUpdater.UpdateDownload(mainForm, ActualVersion, LastReleaseData, GetDataEx, hideMessages)) Application.Exit();
        }
        #endregion
    }
}