/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Form to manage Companys
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
using OLKI.Programme.QuiAbl.src.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    /// <summary>
    /// Form to manage Companys
    /// </summary>
    public partial class ManageCompany : Form
    {
        #region Events
        /// <summary>
        /// Raised if saving of BillClasses is requested
        /// </summary>
        public event EventHandler CompaniesSaveRequest;
        #endregion

        #region Fields
        /// <summary>
        /// Should the Ok-Clicked action abborted
        /// </summary>
        bool _abbortOk = false;

        /// <summary>
        /// Project to get data from
        /// </summary>
        private readonly Project.Project _project;
        #endregion

        #region Properties
        /// <summary>
        /// List with Companies
        /// </summary>
        public Dictionary<int, Company> _companies;

        /// <summary>
        /// Last insertes Company Id
        /// </summary>
        private int _companyLastInsertedId;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new ManageCompany Form
        /// </summary>
        /// <param name="project">Project to get data from</param>
        /// <param name="preselectComapnyId">Id of an Company to preselect, if Form will open. Set 0 for no preselection.</param>
        public ManageCompany(Project.Project project, int preselectComapnyId)
        {
            InitializeComponent();
            this.chkCheckDoubleNaming.Checked = Settings.Default.Company_CheckDoubleNaming;

            this._project = project;
            this._companyLastInsertedId = this._project.CompanyLastInsertedId;
            this._companies = new Dictionary<int, Company>();

            foreach (KeyValuePair<int, Company> CompanyItem in this._project.Companies)
            {
                this._companies.Add(CompanyItem.Key, CompanyItem.Value.Clone());
                this._companies[CompanyItem.Key].CompanyChanged -= new EventHandler(this._project.ToggleSubItemChanged);
            }
            this.lsvCompanies.BeginUpdate();

            ListViewItem NewItem;
            foreach (KeyValuePair<int, Company> companyItem in this._companies.OrderBy(o => o.Value.Title))
            {
                NewItem = new ListViewItem
                {
                    Tag = companyItem.Value,
                    Text = companyItem.Value.TitleNoText
                };
                this.lsvCompanies.Items.Add(NewItem);
            }

            //Preselect Comapny
            if (preselectComapnyId > 0)
            {
                for (int i = 0; i < this.lsvCompanies.Items.Count; i++)
                {
                    if (((Company)this.lsvCompanies.Items[i].Tag).Id == preselectComapnyId) this.lsvCompanies.Items[i].Selected = true;
                }
            }

            this.lsvCompanies.EndUpdate();
            this.lsvCompanies_SelectedIndexChanged(this, new EventArgs());
        }

        /// <summary>
        /// Convert the ListView to a List of Companys
        /// </summary>
        private void ListViewToCompanyList()
        {
            Company TempCompany;
            foreach (ListViewItem CompanyItem in this.lsvCompanies.Items)
            {
                TempCompany = (Company)CompanyItem.Tag;
                this._companies.Add(TempCompany.Id, TempCompany);
            }
        }

        /// <summary>
        /// Check for double Company Tiltes
        /// </summary>
        /// <returns>True if two or more Companies with the same title were found, otherwise false</returns>
        public bool DoubleCompanies()
        {
            foreach (KeyValuePair<int, Company> CompanyItem in this._companies)
            {
                foreach (KeyValuePair<int, Company> CompanyCheckItem in this._companies)
                {
                    if (CompanyCheckItem.Value.Id != CompanyItem.Value.Id && CompanyCheckItem.Value.Title == CompanyItem.Value.Title) return true;
                }
            }
            return false;
        }

        #region Controle Events
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this._project.CompanyLastInsertedId = this._companyLastInsertedId;
            this._companies.Clear();
            this.ListViewToCompanyList();

            // Check for Double Companies
            if (this.DoubleCompanies() && MessageBox.Show(this, Stringtable._0x001Em, Stringtable._0x001Ec, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                this._abbortOk = true;
                return;
            }

            this._project.Companies.Clear();
            this._project.Companies = this._companies;
            foreach (KeyValuePair<int, Company> CompanyItem in this._project.Companies)
            {
                CompanyItem.Value.CompanyChanged += new EventHandler(this._project.ToggleSubItemChanged);
            }
            this._project.ToggleSubItemChanged(sender, e);
            this.CompaniesSaveRequest?.Invoke(this, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCompanyAdd_Click(object sender, EventArgs e)
        {
            this._companyLastInsertedId++;
            Company NewCompany = new Company(this._companyLastInsertedId);
            ListViewItem NewItem = new ListViewItem
            {
                Tag = NewCompany,
                Text = NewCompany.TitleNoText
            };
            this.lsvCompanies.Items.Add(NewItem);
            Company CompanyItem;
            for (int i = 0; i < this.lsvCompanies.Items.Count; i++)
            {
                CompanyItem = (Company)this.lsvCompanies.Items[i].Tag;
                if (CompanyItem.Id == this._companyLastInsertedId) this.lsvCompanies.Items[i].Selected = true;
            }
            this.txtTitle.Focus();
        }

        private void btnCompanyRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvCompanies.SelectedItems.Count < 1) return;
            this.lsvCompanies.SelectedItems[0].Remove();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this._abbortOk = false;
            this.btnAccept_Click(sender, e);

            if (this._abbortOk) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void chkCheckDoubleNaming_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Company_CheckDoubleNaming = this.chkCheckDoubleNaming.Checked;
            Settings.Default.Save();
        }

        private void lsvCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grbProperties.Enabled = this.lsvCompanies.SelectedItems.Count == 1;
            this.btnCompanyRemove.Enabled = this.lsvCompanies.SelectedItems.Count == 1;
            if (this.lsvCompanies.SelectedItems.Count == 1)
            {
                this.txtComment.Text = ((Company)this.lsvCompanies.SelectedItems[0].Tag).Comment;
                this.txtTitle.Text = ((Company)this.lsvCompanies.SelectedItems[0].Tag).Title;
            }
            else
            {
                this.txtComment.Text = "";
                this.txtTitle.Text = "";
            }
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (this.lsvCompanies.SelectedItems.Count != 1) return;

            ((Company)this.lsvCompanies.SelectedItems[0].Tag).Comment = this.txtComment.Text;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.lsvCompanies.SelectedItems.Count != 1) return;

            ((Company)this.lsvCompanies.SelectedItems[0].Tag).Title = this.txtTitle.Text.Trim();
            this.lsvCompanies.SelectedItems[0].Text = ((Company)this.lsvCompanies.SelectedItems[0].Tag).TitleNoText;
        }
        #endregion
        #endregion
    }
}