/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains data of an BillClass, belonging to an bill, and provide Methodes to handle them
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
    /// Class that contains data of an BillClass, belonging to an bill, and provide Methodes to handle them
    /// </summary>
    public class BillClass
    {
        #region Events
        /// <summary>
        /// Raised if the BillClass data was changed
        /// </summary>
        public event EventHandler BillClassChanged;
        #endregion

        #region Properties
        /// <summary>
        /// True if the BillClass data was changed
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set if the BillClass data was changed
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
                this.ToggleBillClassChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// The comment to the BillClass
        /// </summary>
        private string _comment;
        /// <summary>
        /// Get or set the comment to BillClass
        /// </summary>
        [Category("Allgemein")]
        [Description("Kommentar zur Kategorie.")]
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
        /// Get the internal BillClass Id
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int Id { get; private set; }

        /// <summary>
        /// Get or set th internal RootId of the BillClass
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int RootId { get; set; }

        /// <summary>
        /// The Name of the BillClass
        /// </summary>
        private string _title;
        /// <summary>
        /// Get or set the Name of the BillClass
        /// </summary>
        [Category("Allgemein")]
        [Description("Benennung der Kategorie.")]
        [DisplayName("Benennung")]
        public string Title
        {
            get => _title;
            set
            {
                this._title = value.Trim();
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the Name of the BillClass, or an default text if no name is given
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
        /// Create a new empty BillClass object with an predefined id
        /// </summary>
        /// <param name="id">Id for the new, empty BillClass</param>
        /// <param name="rootId">RootId for the new, empty BillClass</param>
        public BillClass(int id, int rootId)
        {
            this.Id = id;
            this.RootId = rootId;
        }
        /// <summary>
        /// Create a new BillClass object, get data from an XElement object
        /// </summary>
        /// <param name="inputBillClass">XElement to read BillClass data from</param>
        public BillClass(XElement inputBillClass)
        {
            this.FromXElement(inputBillClass);
        }

        /// <summary>
        /// Clone the BillClass object
        /// </summary>
        /// <returns>The cloned BillClass object</returns>
        public BillClass Clone()
        {
            return (BillClass)this.MemberwiseClone();
        }

        /// <summary>
        /// Get the BillClass from an XElement object
        /// </summary>
        /// <param name="inputBillClass">XElement to read BillClass data from</param>
        public void FromXElement(XElement inputBillClass)
        {
            this.Id = Serialize.GetFromXElement(inputBillClass, "Id", 0);
            this._comment = Serialize.GetFromXElement(inputBillClass, "Comment", "");
            this.RootId = Serialize.GetFromXElement(inputBillClass, "RootId", 0);
            this._title = Serialize.GetFromXElement(inputBillClass, "Title", "");
        }

        /// <summary>
        /// Toggle ToggleBillClassChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        private void ToggleBillClassChanged(object sender, EventArgs e)
        {
            if (this.BillClassChanged != null) BillClassChanged(sender, e);
        }

        /// <summary>
        /// Converts the BillClass object to an XElement object
        /// </summary>
        /// <returns>BillClass data as XElement</returns>
        public XElement ToXElement()
        {
            XElement CompanyRoot = new XElement("BillClassItem");

            CompanyRoot.Add(new XElement("Id", this.Id));
            CompanyRoot.Add(new XElement("Comment", this._comment));
            CompanyRoot.Add(new XElement("RootId", this.RootId));
            CompanyRoot.Add(new XElement("Title", this._title));

            return CompanyRoot;
        }
        #endregion
    }
}