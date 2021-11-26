/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * A Form to search for bills
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

using OLKI.Programme.QuiAbl.src.Project;
using OLKI.Programme.QuiAbl.src.Project.Bill;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms
{
    /// <summary>
    /// A Form to search for bills
    /// </summary>
    public partial class Search : Form
    {
        #region Events
        public event EventHandler RequestListResults;
        #endregion

        #region Fields
        /// <summary>
        /// Dictionary for ComboBox Index to CompanyId
        /// </summary>
        private Dictionary<int, int> _comboToCompanyId;

        /// <summary>
        /// Bill manage project 
        /// </summary>
        private readonly Project.Project _project;

        /// <summary>
        /// The selected tree Node an his sub nodes
        /// </summary>
        private List<int> _selectedTreeNodeAndSubNodes;
        #endregion

        #region Properties
        /// <summary>
        /// Get the list will id ID's of all found bills
        /// </summary>
        public List<int> BillsFound { get; private set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new search form for bills
        /// </summary>
        /// <param name="project">Project data</param>
        public Search(Project.Project project)
        {
            InitializeComponent();
            this._project = project;
            this.FillCompanyComboBox();
            this.nudPrice.Maximum = decimal.MaxValue;
            this.nudPrice.Minimum = decimal.MinValue;
            this.FillBillClassTreeView(null);
            this.trvBillClasses.ShowPlusMinus = Properties.Settings.Default.TreeView_BillClasses_AllowCollaps;
            if (Properties.Settings.Default.TreeView_BillClasses_ExpandAllDefault || !Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) this.trvBillClasses.ExpandAll();
        }

        /// <summary>
        /// Add bill classes to TreeView
        /// </summary>
        /// <param name="rootNode">Root node to add nodes to</param>
        private void FillBillClassTreeView(TreeNode rootNode)
        {
            int rootNodeId = 0;
            if (rootNode != null) rootNodeId = ((BillClass)rootNode.Tag).Id;

            TreeNode NewNode;
            foreach (KeyValuePair<int, BillClass> billClassItem in this._project.BillClasses.OrderBy(o => o.Value.Title))
            {
                if (billClassItem.Value.RootId != rootNodeId) continue;

                NewNode = new TreeNode
                {
                    Tag = billClassItem.Value,
                    Text = billClassItem.Value.Title
                };


                if (rootNode != null)
                {
                    rootNode.Nodes.Add(NewNode);
                }
                else
                {
                    this.trvBillClasses.Nodes.Add(NewNode);
                }
                this.FillBillClassTreeView(NewNode);
            }
        }

        /// <summary>
        /// Add Companys from project to CompanyComboBox
        /// </summary>
        private void FillCompanyComboBox()
        {
            this.cboCompany.Items.Clear();
            this._comboToCompanyId = new Dictionary<int, int>();
            int i = 0;

            //Add empty item for no comapny selected
            this.cboCompany.Items.Add("");
            this._comboToCompanyId.Add(i, 0);

            //Add company items
            foreach (KeyValuePair<int, Company> companyItem in this._project.Companies.OrderBy(o => o.Value.Title))
            {
                i++;
                this.cboCompany.Items.Add(companyItem.Value.Title);
                this._comboToCompanyId.Add(i, companyItem.Value.Id);
            }
        }

        /// <summary>
        /// Get the Daten from an given string
        /// </summary>
        /// <param name="inputString">String to parse to date or NULL</param>
        /// <returns>Date of the given string or NULL is the string can not pe parsed</returns>
        private DateTime? GetDate(string inputString)
        {
            if (string.IsNullOrEmpty(System.Text.RegularExpressions.Regex.Replace(inputString, @"[^0-9]", ""))) return null;
            DateTime.TryParse(this.mtbDateMax.Text, out DateTime TempDate);
            return TempDate;
        }

        /// <summary>
        /// Get all SubNodes of the given TreeNode recursive
        /// </summary>
        /// <param name="node">TreeNode to geht with his sub nodes</param>
        private void GetTreeNodeSubNodes(TreeNode node)
        {
            if (node == null) return;

            this._selectedTreeNodeAndSubNodes.Add(((BillClass)node.Tag).Id);
            foreach (TreeNode SubNode in node.Nodes)
            {
                this.GetTreeNodeSubNodes(SubNode);
            }
        }

        #region Form Events
        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BillsFound = new List<int>();
            foreach (KeyValuePair<int, Bill> Billtem in this._project.Bills)
            {
                this.BillsFound.Add(Billtem.Value.Id);
            }
            RequestListResults?.Invoke(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.cboCompany.SelectedIndex < 0) this.cboCompany.SelectedIndex = 0;
            this._selectedTreeNodeAndSubNodes = new List<int>();
            this.GetTreeNodeSubNodes(this.trvBillClasses.SelectedNode);

            FilterBill FilterBill = new FilterBill
            {
                Disposed = this.chkBillDisposed.CheckState,
                CompanyId = this._comboToCompanyId[this.cboCompany.SelectedIndex],
                DateMax = this.GetDate(this.mtbDateMax.Text),
                DateMin = this.GetDate(this.mtbDateMin.Text),
                ExpidationMax = this.GetDate(this.mtbExpidationMax.Text),
                ExpidationMin = this.GetDate(this.mtbExpidationMin.Text),
                Searchtext = this.txtSearchtext.Text,
                Price = this.nudPrice.Value,
                BillClasses = this._selectedTreeNodeAndSubNodes
            };

            this.BillsFound = new List<int>();
            foreach (KeyValuePair<int, Bill> Billtem in this._project.Bills)
            {
                if (FilterBill.InFilter(Billtem.Value)) this.BillsFound.Add(Billtem.Value.Id);
            }

            RequestListResults?.Invoke(sender, e);
        }

        private void trvBillClasses_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (!Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) e.Cancel = true;
        }

        private void trvBillClasses_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.trvBillClasses.SelectedNode != null) this.trvBillClasses.SelectedNode = null;
        }
        #endregion
        #endregion

        #region SubClasses
        /// <summary>
        /// Class to check if an bill corresponds to various criteria
        /// </summary>
        private class FilterBill
        {
            #region Properties
            /// <summary>
            /// Id of the company that has to be associated to the bill. Set 0 to not search for.
            /// </summary>
            public int CompanyId { private get; set; }

            /// <summary>
            /// Maximum bill date to search for. Set NULL to not search for.
            /// </summary>
            public DateTime? DateMax { private get; set; }

            /// <summary>
            /// Minimum bill date to search for. Set NULL to not search for.
            /// </summary>
            public DateTime? DateMin { private get; set; }

            /// <summary>
            /// Is the Bill disposed
            /// </summary>
            public CheckState Disposed { private get; set; }

            /// <summary>
            /// Maximum expidation date to search for. Set NULL to not search for.
            /// </summary>
            public DateTime? ExpidationMax { private get; set; }

            /// <summary>
            /// Minimum expidation date to search for. Set NULL to not search for.
            /// </summary>
            public DateTime? ExpidationMin { private get; set; }

            /// <summary>
            /// Text to search as any free text in bill or sub items. Set EMPTY to not seach for.
            /// </summary>
            public string Searchtext { private get; set; }

            /// <summary>
            /// Price that any invoice item in bill has to be. Set 0 to not seach for.
            /// </summary>
            public decimal Price { private get; set; }

            /// <summary>
            /// Bill classes the company has to be associated to. Set an empty list if to not seach for.
            /// </summary>
            public List<int> BillClasses { private get; set; }
            #endregion

            #region Methodes
            /// <summary>
            /// Check if bill matches to all filters
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if bill matches to all filters</returns>
            public bool InFilter(Bill bill)
            {
                if (!this.InFilterCompany(bill)) return false;
                if (!this.InFilterDate(bill)) return false;
                if (!this.InFilterDisposed(bill)) return false;
                if (!this.InFilterExpidation(bill)) return false;
                if (!this.InFilterText(bill)) return false;
                if (!this.InFilterPrice(bill)) return false;
                if (!this.InFilterBillClass(bill)) return false;

                return true;
            }

            /// <summary>
            /// Check if the bill is associated to company
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill is associated to company or if search company is not given</returns>
            public bool InFilterCompany(Bill bill)
            {
                if (this.CompanyId == 0) return true;
                if (this.CompanyId == bill.CompanyId) return true;

                return false;
            }

            /// <summary>
            /// Check if is bill hast the right Disposed state
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill has the same disposed state or TRUE if the reference state is Indeterminate</returns>
            public bool InFilterDisposed(Bill bill)
            {
                if (this.Disposed == CheckState.Indeterminate) return true;
                if (this.Disposed == CheckState.Checked && bill.BillDisposed) return true;
                if (this.Disposed == CheckState.Unchecked && !bill.BillDisposed) return true;

                return false;
            }

            /// <summary>
            /// Check if the bill date date match to range
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill date match to range or if range is not given</returns>
            public bool InFilterDate(Bill bill)
            {
                if (DateMin == null && DateMax == null) return true;
                if (DateMin != null && DateMax == null && bill.Date != null) return DateTime.Compare((DateTime)bill.Date, (DateTime)DateMin) >= 0;
                if (DateMin == null && DateMax != null && bill.Date != null) return DateTime.Compare((DateTime)bill.Date, (DateTime)DateMax) <= 0;
                if (DateMin != null && DateMax != null && bill.Date != null) return DateTime.Compare((DateTime)bill.Date, (DateTime)DateMin) >= 0 && DateTime.Compare((DateTime)bill.Date, (DateTime)DateMax) <= 0;
                return false;
            }

            /// <summary>
            /// Check if the bill expidation date match to range
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill expidation date match to range or if range is not given</returns>
            public bool InFilterExpidation(Bill bill)
            {
                if (ExpidationMin == null && ExpidationMax == null) return true;
                if (ExpidationMin != null && ExpidationMax == null && bill.Expiration != null) return DateTime.Compare((DateTime)bill.Expiration, (DateTime)this.ExpidationMin) >= 0;
                if (ExpidationMin == null && ExpidationMax != null && bill.Expiration != null) return DateTime.Compare((DateTime)bill.Expiration, (DateTime)this.ExpidationMax) <= 0;
                if (ExpidationMin != null && ExpidationMax != null && bill.Expiration != null) return DateTime.Compare((DateTime)bill.Expiration, (DateTime)this.ExpidationMin) >= 0 && DateTime.Compare((DateTime)bill.Expiration, (DateTime)this.ExpidationMax) <= 0;
                return false;
            }

            /// <summary>
            /// Check if the bill or an sub item contains the search text
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill or an sub item contains the search text or if search value is empth</returns>
            public bool InFilterText(Bill bill)
            {
                if (string.IsNullOrEmpty(this.Searchtext)) return true;

                if (!string.IsNullOrEmpty(bill.Comment) && bill.Comment.ToLower().Contains(this.Searchtext.ToLower())) return true;
                if (!string.IsNullOrEmpty(bill.Title) && bill.Title.ToLower().Contains(this.Searchtext.ToLower())) return true;

                foreach (KeyValuePair<int, File> FileItem in bill.Files)
                {
                    if (!string.IsNullOrEmpty(FileItem.Value.Comment) && FileItem.Value.Comment.ToLower().Contains(this.Searchtext.ToLower())) return true;
                    if (!string.IsNullOrEmpty(FileItem.Value.Title) && FileItem.Value.Title.ToLower().Contains(this.Searchtext.ToLower())) return true;
                }
                foreach (KeyValuePair<int, InvoiceItem> InvoiceItemItem in bill.InvoiceItems)
                {
                    if (!string.IsNullOrEmpty(InvoiceItemItem.Value.Comment) && InvoiceItemItem.Value.Comment.ToLower().Contains(this.Searchtext.ToLower())) return true;
                    if (!string.IsNullOrEmpty(InvoiceItemItem.Value.Title) && InvoiceItemItem.Value.Title.ToLower().Contains(this.Searchtext.ToLower())) return true;
                }
                return false;
            }

            /// <summary>
            /// Check if the bill has the search price at an InvoiceItemItem
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill has the search price at an InvoiceItemItem or if search value is 0</returns>
            public bool InFilterPrice(Bill bill)
            {
                if (this.Price == 0) return true;

                foreach (KeyValuePair<int, InvoiceItem> InvoiceItemItem in bill.InvoiceItems)
                {
                    if (InvoiceItemItem.Value.Price == this.Price) return true;
                }
                return false;
            }

            /// <summary>
            /// Check if the bill is associated to BillClass
            /// </summary>
            /// <param name="bill">Bill to check</param>
            /// <returns>True if the bill is associated to BillClass or if search value is empth</returns>
            public bool InFilterBillClass(Bill bill)
            {
                if (this.BillClasses == null || this.BillClasses.Count == 0) return true;

                if (this.BillClasses.Contains(bill.BillClassId)) return true;
                return false;
            }
            #endregion
        }
        #endregion
    }
}