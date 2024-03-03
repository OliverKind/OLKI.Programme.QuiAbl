/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains data of an Bill and provide Methodes to handle them
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Xml.Linq;

namespace OLKI.Programme.QuiAbl.src.Project.Bill
{
    /// <summary>
    /// Class that contains data of an Bill and provide Methodes to handle them
    /// </summary>
    public class Bill
    {

        #region Events
        /// <summary>
        /// Raised if the Bill data was changed
        /// </summary>
        public event EventHandler BillChanged;
        #endregion

        #region Fields
        /// <summary>
        /// List with all Companies in project
        /// </summary>
        private Dictionary<int, Company> _companies;
        /// <summary>
        /// Set the list with all Companies in project
        /// </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public Dictionary<int, Company> Companies
        {
            set
            {
                this._companies = value;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The Bill is Disposed
        /// </summary>
        private bool _billDisposed = false;
        /// <summary>
        /// Get or set if the Bill is Disposed
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Die Rechnung wurde entsorgt.")]
        [DisplayName("Entsorgt")]
        public bool BillDisposed
        {
            get => _billDisposed;
            set
            {
                this._billDisposed = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The BillNumber
        /// </summary>
        private string _billNumber;
        /// <summary>
        /// Get or set the BillNumber
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Nummer der Rechnung.")]
        [DisplayName("Rechnungsnummer")]
        public string BillNumber
        {
            get => _billNumber;
            set
            {
                this._billNumber = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// List with all BillClasses in project
        /// </summary>
        private Dictionary<int, BillClass> _billClasses;

        /// <summary>
        /// Set the list with all BillClasses in project
        /// </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public Dictionary<int, BillClass> BillClasses
        {
            set
            {
                this._billClasses = value;
            }
        }

        /// <summary>
        /// The BillClass by Id, belonging to the Bill
        /// </summary>
        private int _billClassId = 0;
        /// <summary>
        /// Get or set the BillClass by Id, belonging to the Bill
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [ReadOnly(true)]
        public int BillClassId
        {
            get => this._billClassId;
            set
            {
                this._billClassId = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the name of the BillClass, belonging to the Bill
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Die Kategorie die der Rechnung zugeordnet wurde.")]
        [DisplayName("Kategorie")]
        [ReadOnly(true)]
        public string BillClassName
        {
            get
            {
                if (this._billClasses != null && this._billClasses.ContainsKey(this.BillClassId))
                {
                    return this.GetClassNamePath(this.BillClassId);
                }
                return "";
            }
        }

        /// <summary>
        /// True if the Bill data was changed
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set if the Bill data was changed
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
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
                this.ToggleBillChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// The comment to the Bill
        /// </summary>
        private string _comment;
        /// <summary>
        /// Get or set the comment to the Bill
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Kommentar zur Rechnung.")]
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
        /// The Company by Id, belonging to the Bill
        /// </summary>
        public int _companyId = 0;
        /// <summary>
        /// Get or set the Company by Id, belonging to the Bill
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int CompanyId
        {
            get => this._companyId;
            set
            {
                this._companyId = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the name of the Company, belonging to the Bill
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Die Firma von der die Rechnung ist.")]
        [DisplayName("Rechnungsfirma")]
        [ReadOnly(true)]
        public string CompanyName
        {
            get
            {
                if (this._companies != null && this._companies.ContainsKey(this.CompanyId))
                {
                    return this._companies[this.CompanyId].Title;
                }
                return "";
            }
        }

        /// <summary>
        /// he date of the customer number of the bill
        /// </summary>
        private string _customNumber;
        /// <summary>
        /// Get or set the date of the customer number of the bill
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Nummer des Kunden.")]
        [DisplayName("Kundennummer")]
        public string CustomNumber
        {
            get => _customNumber;
            set
            {
                this._customNumber = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The date of the bill
        /// </summary>
        private DateTime? _date;
        /// <summary>
        /// Get or set the date of the bill
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Das Datum an dem die Rechnung ausgestellt wurde.")]
        [DisplayName("Rechnungsdatum")]
        [Editor(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Date
        {
            get => this._date;
            set
            {
                this._date = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The date where the bill is expired, and can be dispose and deleted
        /// </summary>
        private DateTime? _expiration;
        /// <summary>
        /// Get or set the date where the bill is expired, and can be dispose and deleted
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Datum bis zu dem die Rechnung gültig ist, ab dem sie vernichtet werden kann.")]
        [DisplayName("Gültigkeitsdatum")]
        [Editor(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Expiration
        {
            get => this._expiration;
            set
            {
                this._expiration = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The File list, belonging to the bill
        /// </summary>
        private Dictionary<int, File> _files = new Dictionary<int, File>();
        /// <summary>
        /// Get or set the File list, belonging to the bill
        /// </summary>
        [Browsable(false)]
        public Dictionary<int, File> Files
        {
            get
            {
                return this._files;
            }
            set
            {
                this._files = value;
                this.SubItemChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Get a list with all file Ids, belonging to the bill
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public List<int> FilesIdList
        {
            get
            {
                List<int> KeyList = new List<int>();
                foreach (KeyValuePair<int, File> FileItem in this._files.OrderBy(o1 => o1.Value.Title).ThenBy(o2 => o2.Value.Id))
                {
                    KeyList.Add(FileItem.Key);
                }
                return KeyList;
            }
        }

        /// <summary>
        /// Get the number if files
        /// </summary>
        [Category("Zusatzinformationen")]
        [Description("Anzahl der angehängten Dateien.")]
        [DisplayName("Dateianhänge")]
        [ReadOnly(true)]
        public int FileCount => this._files.Count;

        /// <summary>
        /// Roughly Size of attached Files
        /// </summary>
        [Category("Zusatzinformationen")]
        [Description("Geschätzte Größe der Dateianhänge in Byte.")]
        [DisplayName("Dateianhänge - Größe")]
        [ReadOnly(true)]
        public long FilesLength
        {
            get
            {
                long TotalLength = 0;
                foreach (KeyValuePair<int, File> FileItem in this._files)
                {
                    TotalLength += FileItem.Value.Length;
                }
                return TotalLength;
            }
        }

        /// <summary>
        /// Get or set the Id of the last added File
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int FilesLastInsertedId { get; set; } = 0;

        /// <summary>
        /// Get the internal Bill Id
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int Id { get; set; } = 0;

        /// <summary>
        /// The location where the original files are located
        /// </summary>
        private string _orgFileLocation;
        /// <summary>
        /// Get or set the location where the original files are located
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Der Ort an dem die Originalrechnung abgelegt wurde.")]
        [DisplayName("Ablageort")]
        public string OrgFileLocation
        {
            get => this._orgFileLocation;
            set
            {
                this._orgFileLocation = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The InvoiceItem list
        /// </summary>
        private Dictionary<int, InvoiceItem> _invoiceItems = new Dictionary<int, InvoiceItem>();
        /// <summary>
        /// Get or set the InvoiceItem list
        /// </summary>
        [Browsable(false)]
        public Dictionary<int, InvoiceItem> InvoiceItems
        {
            get
            {
                return this._invoiceItems;
            }
            set
            {
                this._invoiceItems = value;
                this.SubItemChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Get the number if invoice items
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Anzahl der eingetragenen Rechnungspositionen.")]
        [DisplayName("Positionen")]
        [ReadOnly(true)]
        public int InvoiceItemCount => this._invoiceItems.Count;

        /// <summary>
        /// Get or set the Id of the last added InvoiceItem
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#else
        [Browsable(true)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int InvoiceItemLastInsertedId { get; set; } = 0;

        /// <summary>
        /// Get the total price of all Invoice iitems
        /// </summary>
        [Browsable(true)]
        [Category("Zusatzinformationen")]
        [Description("Die Summe aller Rechnungsbeträge.")]
        [DisplayName("Rechnung Summe")]
        [ReadOnly(true)]
        public decimal InvoiceItemsTotalPrice
        {
            get
            {
                decimal Total = 0;
                foreach (KeyValuePair<int, InvoiceItem> InvItem in this._invoiceItems)
                {
                    Total += InvItem.Value.PriceSum;
                }
                return Total;
            }
        }

        /// <summary>
        /// The Name of the Bill
        /// </summary>
        private string _title;
        /// <summary>
        /// Get or set the Name of the Bill
        /// </summary>
        [Browsable(true)]
        [Category("Allgemein")]
        [Description("Benennung der Rechnung.")]
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
        /// Get the Name of the Bill, or an default text if no name is given
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
        /// Create a new empty Bill object with an predefined id
        /// </summary>
        /// <param name="id">Id for the new, empty Bill</param>
        /// <param name="billClasses">Categories from project</param>
        /// <param name="companys">Companys from project</param>
        public Bill(int id, Dictionary<int, BillClass> billClasses, Dictionary<int, Company> companys)
        {
            this._billClasses = billClasses;
            this._companies = companys;
            this.Id = id;
        }
        /// <summary>
        /// Create a new Bill object, get data from an XElement object
        /// </summary>
        /// <param name="inputBill">XElement to read Bill data from</param>
        /// <param name="billClasses">Categories from project</param>
        /// <param name="companys">Companys from project</param>
        public Bill(XElement inputBill, Dictionary<int, BillClass> billClasses, Dictionary<int, Company> companys)
        {
            this._billClasses = billClasses;
            this._companies = companys;

            this.FromXElement(inputBill);
        }

        /// <summary>
        /// Clone the Bill object and all sub items
        /// </summary>
        /// <returns>The cloned Bill object and all cloned sub items</returns>
        public Bill Clone()
        {
            Bill ThisClone = (Bill)this.MemberwiseClone();

            ThisClone._files = new Dictionary<int, File>();
            foreach (KeyValuePair<int, File> FileItem in this._files)
            {
                ThisClone._files.Add(FileItem.Key, FileItem.Value.Clone());
                ThisClone._files[FileItem.Key].FileChanged -= this.SubItemChanged;
                ThisClone._files[FileItem.Key].FileChanged += new EventHandler(ThisClone.SubItemChanged);
            }

            ThisClone._invoiceItems = new Dictionary<int, InvoiceItem>();
            foreach (KeyValuePair<int, InvoiceItem> InvoiceItem in this._invoiceItems)
            {
                ThisClone._invoiceItems.Add(InvoiceItem.Key, InvoiceItem.Value.Clone());
                ThisClone._invoiceItems[InvoiceItem.Key].InvoiceItemChanged -= this.SubItemChanged;
                ThisClone._invoiceItems[InvoiceItem.Key].InvoiceItemChanged += new EventHandler(ThisClone.SubItemChanged);
            }
            return ThisClone;
        }

        /// <summary>
        /// Get the Bill from an XElement object
        /// </summary>
        /// <param name="inputBill">XElement to read Bill data from</param>
        public void FromXElement(XElement inputBill)
        {
            DateTime DateTimeTemp = DateTime.Now;

            this.Id = Serialize.GetFromXElement(inputBill, "Id", this.Id);
            this._billDisposed = Serialize.GetFromXElement(inputBill, "BillDisposed", this._billDisposed);
            this._billNumber = Serialize.GetFromXElement(inputBill, "BillNumber", this._billNumber);
            this._billClassId = Serialize.GetFromXElement(inputBill, "BillClassId", this._billClassId);
            this._comment = Serialize.GetFromXElement(inputBill, "Comment", this._comment);
            this._companyId = Serialize.GetFromXElement(inputBill, "CompanyId", this._companyId);
            this._customNumber = Serialize.GetFromXElement(inputBill, "CustomNumber", this._customNumber);
            this._date = DateTime.TryParse(Serialize.GetFromXElement(inputBill, "Date", ""), out DateTimeTemp) ? (DateTime?)DateTimeTemp : null;
            this._expiration = DateTime.TryParse(Serialize.GetFromXElement(inputBill, "Expiration", ""), out DateTimeTemp) ? (DateTime?)DateTimeTemp : null;
            this._orgFileLocation = Serialize.GetFromXElement(inputBill, "OrgFileLocation", this._orgFileLocation);
            this._title = Serialize.GetFromXElement(inputBill, "Title", this._title);

            this._files.Clear();
            this.FilesLastInsertedId = Serialize.GetFromXElementAttribute(inputBill, "FileList", "LastInsertedId", this.FilesLastInsertedId);
            XElement FileList = Serialize.GetFromXElement(inputBill, "FileList", new XElement("FileList"));
            if (FileList != null)
            {
                File NewFile;
                foreach (XElement FileItem in FileList.Elements("FileItem"))
                {
                    NewFile = new File(FileItem);
                    NewFile.FileChanged += new EventHandler(this.SubItemChanged);
                    this._files.Add(NewFile.Id, NewFile);
                }
            }

            this._invoiceItems.Clear();
            this.InvoiceItemLastInsertedId = Serialize.GetFromXElementAttribute(inputBill, "InvoiceItemList", "LastInsertedId", this.InvoiceItemLastInsertedId);
            XElement InvoiceItemList = Serialize.GetFromXElement(inputBill, "InvoiceItemList", new XElement("InvoiceItemList"));
            if (InvoiceItemList != null)
            {
                InvoiceItem NewInvoiceItem;
                foreach (XElement InvoiceItem in InvoiceItemList.Elements("InvoiceItem"))
                {
                    NewInvoiceItem = new InvoiceItem(InvoiceItem);
                    NewInvoiceItem.InvoiceItemChanged += new EventHandler(this.SubItemChanged);
                    this._invoiceItems.Add(NewInvoiceItem.Id, NewInvoiceItem);
                }
            }
        }

        /// <summary>
        /// Get the full path of the class names, from the selected class to the root classes
        /// </summary>
        /// <param name="ClassId">Id of the class to get the name and root names</param>
        /// <returns>Full path of the class names, from the selected class to the root classes</returns>
        private string GetClassNamePath(int ClassId)
        {
            if (this._billClasses[ClassId].RootId > 0)
            {
                return this.GetClassNamePath(this._billClasses[ClassId].RootId) + "->" + this._billClasses[ClassId].Title;
            }
            return this._billClasses[ClassId].Title;
        }

        /// <summary>
        /// Set Changed to true and toggle bill changed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">EventArgs</param>
        private void SubItemChanged(object sender, EventArgs e)
        {
            this._changed = true;
            this.ToggleBillChanged(sender, e);
        }

        /// <summary>
        /// Toggle BillChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        private void ToggleBillChanged(object sender, EventArgs e)
        {
            if (this.BillChanged != null) BillChanged(sender, e);
        }

        /// <summary>
        /// Converts the Bill object to an XElement object
        /// </summary>
        /// <returns>Bill data as XElement</returns>
        public XElement ToXElement()
        {
            XElement BillRoot = new XElement("BillItem");

            BillRoot.Add(new XElement("Id", this.Id));
            BillRoot.Add(new XElement("BillDisposed", this._billDisposed));
            BillRoot.Add(new XElement("BillNumber", this._billNumber));
            BillRoot.Add(new XElement("BillClassId", this._billClassId));
            BillRoot.Add(new XElement("Comment", this._comment));
            BillRoot.Add(new XElement("CompanyId", this._companyId));
            BillRoot.Add(new XElement("CustomNumber", this._customNumber));
            BillRoot.Add(new XElement("Date", this._date.ToString()));
            BillRoot.Add(new XElement("Expiration", this._expiration.ToString()));
            BillRoot.Add(new XElement("OrgFileLocation", this._orgFileLocation));
            BillRoot.Add(new XElement("Title", this._title));

            // Create FileList
            XElement FileList = new XElement("FileList");
            FileList.Add(new XAttribute("LastInsertedId", this.FilesLastInsertedId));
            foreach (KeyValuePair<int, File> FileItem in this._files.OrderBy(o => o.Value.Id))
            {
                FileList.Add(FileItem.Value.ToXElement());
            }
            BillRoot.Add(FileList);

            // Create InvoiceItemList
            XElement InvoiceItemList = new XElement("InvoiceItemList");
            InvoiceItemList.Add(new XAttribute("LastInsertedId", this.InvoiceItemLastInsertedId));
            foreach (KeyValuePair<int, InvoiceItem> InvoiceItemItem in this._invoiceItems.OrderBy(o => o.Value.Id))
            {
                InvoiceItemList.Add(InvoiceItemItem.Value.ToXElement());
            }
            BillRoot.Add(InvoiceItemList);

            return BillRoot;
        }
        #endregion
    }
}