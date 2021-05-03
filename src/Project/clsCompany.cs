/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains data of an Company, belonging to an bill, and provide Methodes to handle them
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
using OLKI.Toolbox.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Xml.Linq;

namespace OLKI.Programme.QuiAbl.src.Project
{
    /// <summary>
    /// Class that contains data of an Company, belonging to an bill, and provide Methodes to handle them
    /// </summary>
    public class Company
    {
        #region Events
        /// <summary>
        /// Raised if the Company data was changed
        /// </summary>
        public event EventHandler CompanyChanged;
        #endregion

        #region Properties
        /// <summary>
        /// True if the Company data was changed
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set if the Company data was changed
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [Category("*Debug")]
        public bool Changed
        {
            get
            {
                return this._changed;
            }
            set
            {
                this._changed = value;
                this.ToggleCompanyChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// The comment to the Company
        /// </summary>
        private string _comment;
        /// <summary>
        /// Get or set the comment to the Company
        /// </summary>
        [Category("Allgemein")]
        [Description("Kommentar zur Firma.")]
        [DisplayName("Kommentar")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get => this._comment;
            set
            {
                this._comment = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the internal Company Id
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int Id { get; private set; }

        /// <summary>
        /// The Name of the Company
        /// </summary>
        private string _title;
        /// <summary>
        /// Get or set the Name of the Company
        /// </summary>
        [Category("Allgemein")]
        [Description("Benennung der Firma.")]
        [DisplayName("Benennung")]
        public string Title
        {
            get => _title;
            set
            {
                this._title = value;
                this.Changed = true;
            }
        }
        /// <summary>
        /// Get the Name of the Company, or an default text if no name is given
        /// </summary>
        [Browsable(false)]
        public string TitleNoText
        {
            get
            {
                return string.IsNullOrEmpty(this._title) ? Stringtable._0x000A : this.Title;
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Create a new empty Company object with an predefined id
        /// </summary>
        /// <param name="id">Id for the new, empty Company</param>
        public Company(int id)
        {
            this.Id = id;
        }
        /// <summary>
        /// Create a new Company object, get data from an XElement object
        /// </summary>
        /// <param name="inputCompany">XElement to read Comapny data from</param>
        public Company(XElement inputCompany)
        {
            this.FromXElement(inputCompany);
        }

        /// <summary>
        /// Clone the Company object
        /// </summary>
        /// <returns>The cloned Company object</returns>
        public Company Clone()
        {
            return (Company)this.MemberwiseClone();
        }

        /// <summary>
        /// Get the Company from an XElement object
        /// </summary>
        /// <param name="inputCompany">XElement to read Comapny data from</param>
        public void FromXElement(XElement inputCompany)
        {
            this.Id = Serialize.GetFromXElement(inputCompany, "Id", 0);
            this._comment = Serialize.GetFromXElement(inputCompany, "Comment", "");
            this._title = Serialize.GetFromXElement(inputCompany, "Title", "");
        }

        /// <summary>
        /// Toggle CompanyChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        private void ToggleCompanyChanged(object sender, EventArgs e)
        {
            if (this.CompanyChanged != null) CompanyChanged(sender, e);
        }

        /// <summary>
        /// Converts the Company object to an XElement object
        /// </summary>
        /// <returns>Comapny data as XElement</returns>
        public XElement ToXElement()
        {
            XElement CompanyRoot = new XElement("CompanyItem");

            CompanyRoot.Add(new XElement("Id", this.Id));
            CompanyRoot.Add(new XElement("Comment", this._comment));
            CompanyRoot.Add(new XElement("Title", this._title));

            return CompanyRoot;
        }
        #endregion
    }
}