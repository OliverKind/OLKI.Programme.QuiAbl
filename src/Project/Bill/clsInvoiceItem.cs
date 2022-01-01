/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Class that contains data of an InvoiceItem, belonging to an bill, and provide Methodes to handle them
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

namespace OLKI.Programme.QuiAbl.src.Project.Bill
{
    /// <summary>
    /// Class that contains data of an InvoiceItem, belonging to an bill, and provide Methodes to handle them
    /// </summary>
    public class InvoiceItem
    {
        #region Constants
        /// <summary>
        /// Decimal digits for prices
        /// </summary>
        private const int DECIMAL_DIGITS = 2;
        #endregion

        #region Events
        /// <summary>
        /// Raised if the InvoiceItem data was changed
        /// </summary>
        public event EventHandler InvoiceItemChanged;
        #endregion

        #region Properties
        /// <summary>
        /// The article number to the InvoiceItem
        /// </summary>
        private string _articleNumber;
        /// <summary>
        /// Get or set the article number to the InvoiceItem
        /// </summary>
        [Category("Allgemein")]
        [Description("Die Nummer des Artikels.")]
        [DisplayName("Artikelnummer")]
        public string ArticleNumber
        {
            get => _articleNumber;
            set
            {
                this._articleNumber = value.Trim();
                this.Changed = true;
            }
        }

        /// <summary>
        /// True if the InvoiceItem data was changed
        /// </summary>
        private bool _changed = false;
        /// <summary>
        /// Get or set if the InvoiceItem data was changed
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
                this.ToggleInvoiceItemChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// The comment to the InvoiceItem
        /// </summary>
        private string _comment;
        /// <summary>
        /// Get or set the comment to the InvoiceItem
        /// </summary>
        [Category("Allgemein")]
        [Description("Kommentar zum Artikels.")]
        [DisplayName("Kommentar")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get => _comment;
            set
            {
                this._comment = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Doesn't the InvoiceItem exist anymore
        /// </summary>
        public bool _disposed = false;
        /// <summary>
        /// Get or set if the InvoiceItem deoesn't exist anymore
        /// </summary>
        [Category("Allgemein")]
        [Description("Gibt an ob der Artikel nicht mehr existiert.")]
        [DisplayName("Entsorgt")]
        public bool Disposed
        {
            get => _disposed;
            set
            {
                this._disposed = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the internal InvoiceItem Id
        /// </summary>
#if !DEBUG
        [Browsable(false)]
#endif
        [Category("*Debug")]
        [ReadOnly(true)]
        public int Id { get; private set; }

        /// <summary>
        /// The single Price of an InvoiceItem
        /// </summary>
        public decimal _price;
        /// <summary>
        /// Get or set the single Price of an InvoiceItem
        /// </summary>
        [Category("Allgemein")]
        [Description("Der Einzelpreis des Artikels.")]
        [DisplayName("Preis")]
        public decimal Price
        {
            get => Math.Round(this._price, DECIMAL_DIGITS);
            set
            {
                this._price = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The the sum price of an InvoiceItem, single price and quantity
        /// </summary>
        [Category("Allgemein")]
        [Description("Der Gesamtpreis aus Einzelpreis und Anzahl.")]
        [DisplayName("Gesamtpreis")]
        [ReadOnly(true)]
        public decimal PriceSum => Math.Round(this._price * this._quantity, DECIMAL_DIGITS);

        /// <summary>
        /// The Quantity of the InvoiceItem
        /// </summary>
        public int _quantity;
        /// <summary>
        /// Get or set the Quantity of the InvoiceItem
        /// </summary>
        [Category("Allgemein")]
        [Description("Die Anzahl des Artikels.")]
        [DisplayName("Menge")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                this._quantity = value;
                this.Changed = true;
            }
        }

        /// <summary>
        /// The Name of the InvoiceItem
        /// </summary>
        private string _title;
        /// <summary>
        /// Get or set the Name of the InvoiceItem
        /// </summary>
        [Category("Allgemein")]
        [Description("Die Benennung des Artikels.")]
        [DisplayName("Benennung")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Title
        {
            get => _title;
            set
            {
                this._title = value.Replace("\r\n", "").Replace("\n", "").Trim();
                this.Changed = true;
            }
        }

        /// <summary>
        /// Get the Name of the InvoiceItem, or an default text if no name is given
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
        /// Create a new empty InvoiceItem object with an predefined id
        /// </summary>
        /// <param name="id">Id for the new, empty InvoiceItem</param>
        public InvoiceItem(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Create a new InvoiceItem object, get data from an XElement object
        /// </summary>
        /// <param name="inputInvoiceItem">XElement to read InvoiceItem data from</param>
        public InvoiceItem(XElement inputInvoiceItem)
        {
            this.FromXElement(inputInvoiceItem);
        }

        /// <summary>
        /// Clone the InvoiceItem object
        /// </summary>
        /// <returns>The cloned BillClass object</returns>
        public InvoiceItem Clone()
        {
            return (InvoiceItem)this.MemberwiseClone();
        }

        /// <summary>
        /// Get the InvoiceItem from an XElement object
        /// </summary>
        /// <param name="inputInvoiceItem">XElement to read InvoiceItem data from</param>
        public void FromXElement(XElement inputInvoiceItem)
        {
            this.Id = Serialize.GetFromXElement(inputInvoiceItem, "Id", 0);
            this._articleNumber = Serialize.GetFromXElement(inputInvoiceItem, "ArticleNumber", "");
            this._comment = Serialize.GetFromXElement(inputInvoiceItem, "Comment", "");
            this._disposed = Serialize.GetFromXElement(inputInvoiceItem, "Disposed", false);
            this._price = Serialize.GetFromXElement(inputInvoiceItem, "Price", (decimal)0);
            this._quantity = Serialize.GetFromXElement(inputInvoiceItem, "Quantity", 0);
            this._title = Serialize.GetFromXElement(inputInvoiceItem, "Title", "");
        }

        /// <summary>
        /// Toggle InvoiceItemChanged event
        /// </summary>
        /// <param name="sender">Sender of changed event</param>
        /// <param name="e">EventArgs of changed event</param>
        private void ToggleInvoiceItemChanged(object sender, EventArgs e)
        {
            if (this.InvoiceItemChanged != null) InvoiceItemChanged(sender, e);
        }

        /// <summary>
        /// Converts the InvoiceItem object to an XElement object
        /// </summary>
        /// <returns>InvoiceItem data as XElement</returns>
        public XElement ToXElement()
        {
            XElement FileRoot = new XElement("InvoiceItem");

            FileRoot.Add(new XElement("Id", this.Id));
            FileRoot.Add(new XElement("ArticleNumber", this._articleNumber));
            FileRoot.Add(new XElement("Comment", this._comment));
            FileRoot.Add(new XElement("Disposed", this._disposed));
            FileRoot.Add(new XElement("Price", this._price.ToString(new System.Globalization.CultureInfo("en-US"))));
            FileRoot.Add(new XElement("Quantity", this._quantity));
            FileRoot.Add(new XElement("Title", this._title));

            return FileRoot;
        }
        #endregion
    }
}