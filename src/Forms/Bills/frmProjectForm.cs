/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * The Form to make a overview of all bills  in an project
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
using OLKI.Programme.QuiAbl.src.Project.Bill;
using OLKI.Toolbox.Widgets.Invoke;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    /// <summary>
    /// The Form to make a overview of all bills  in an project
    /// </summary>
    public partial class ProjectForm : Form
    {
        #region Events
        /// <summary>
        /// Will be raised if form close ist requestd
        /// </summary>
        public event EventHandler RequestClose;
        #endregion

        #region Fields
        /// <summary>
        /// Application or project will be closed
        /// </summary>
        private bool _appOrProjectClose = false;

        /// <summary>
        /// Original design text for the BillNumber Label
        /// </summary>
        private readonly string _lblBillFileNumber_OrgText = "";

        /// <summary>
        /// ManageBill form
        /// </summary>
        private ManageBill _manageBill;

        /// <summary>
        /// ManageBillClass form
        /// </summary>
        private ManageBillClass _manageBillClass;

        /// <summary>
        /// ManageCompany form
        /// </summary>
        private ManageCompany _manageCompany;

        /// <summary>
        /// Search form
        /// </summary>
        private Search _searchBill;

        /// <summary>
        /// Index of the actual selected file in file Preview
        /// </summary>
        private int _selectedFileIndex = 0;
        #endregion

        #region Properteis
        /// <summary>
        /// Get the Project to show the bills of
        /// </summary>
        public Project.Project Project { get; }
        #endregion

        #region Methodes
        /// <summary>
        /// Create a new BillOverviewForm
        /// </summary>
        /// <param name="project">Project to show the bills of</param>
        public ProjectForm(Project.Project project)
        {
            InitializeComponent();
            this._lblBillFileNumber_OrgText = this.lblBillFileNumber.Text;
            this.lsvBills_SelectedIndexChanged(this, new EventArgs());

            //Load Bills
            this.Project = project;
            this.Project.ProjectChanged += new EventHandler(this._project_ProjectChanged);
            this.FillListView(null);

            this.tabBill.SelectedTab = this.tabpBillDocs;

            this._project_ProjectChanged(this, new EventArgs());
        }

        /// <summary>
        /// Close the forme
        /// </summary>
        public void Close(bool appOrProjectClose)
        {
            this._appOrProjectClose = appOrProjectClose;
            this.Close();
        }

        /// <summary>
        /// Get the ListViewItemIndex for an Bill to search by his Id
        /// </summary>
        /// <param name="itemId">Id of the bill to search for</param>
        /// <returns>The Index of the bill to search by Id or -1 for no match</returns> 
        private int GetListViewItemIndex(int itemId)
        {
            Bill BillItem;
            for (int i = 0; i < this.lsvBills.Items.Count; i++)
            {
                BillItem = (Bill)this.lsvBills.Items[i].Tag;
                if (BillItem.Id == itemId) return i;
            }
            return -1;
        }

        /// <summary>
        /// Fill ListView with all items, they are in filter or with all items if filter is NULL
        /// </summary>
        /// <param name="filter">Filter to list BillItems or NULL to list all BillItems</param>
        private void FillListView(List<int> filter)
        {
            this.lsvBills.BeginUpdate();
            this.lsvBills.Items.Clear();
            foreach (KeyValuePair<int, Bill> BillItem in this.Project.Bills.OrderBy(o => o.Value.Title))
            {
                if (filter == null || filter.Contains(BillItem.Value.Id))
                {
                    //Create empty item and fill up by update procedure
                    ListViewItem NewItem = new ListViewItem();
                    NewItem.SubItems.Add("");
                    NewItem.SubItems.Add("");
                    NewItem.SubItems.Add("");
                    NewItem.SubItems.Add("");
                    NewItem.SubItems.Add("");

                    this.lsvBills.Items.Add(NewItem);
                    this.UpdateListviewItem(this.lsvBills.Items.Count - 1, BillItem.Value);
                }
            }
            this.lsvBills.EndUpdate();
        }

        /// <summary>
        /// Set file Preview of the first FileItem of the selected ListViewItem to PictureBox and set Controles
        /// </summary>
        private void SetFilePreview()
        {
            if (this.lsvBills.SelectedItems.Count != 1)
            {
                this.picBilFilePreview.Image = null;
                this.lblBillFileNumber.Text = string.Format(this._lblBillFileNumber_OrgText, new object[] { 0, 0 });
                return;
            }

            Bill SelectedBill = (Bill)this.lsvBills.SelectedItems[0].Tag;
            this.pnlBillFiles.Enabled = (SelectedBill.Files.Count > 0);
            this.lblBillFileNumber.Text = string.Format(this._lblBillFileNumber_OrgText, new object[] { SelectedBill.Files.Count > 0 ? this._selectedFileIndex + 1 : 0, SelectedBill.Files.Count });

            this.btnBillFileNext.Enabled = SelectedBill.Files.Count > 1 && this._selectedFileIndex + 1 < SelectedBill.Files.Count;
            this.btnBillFilePrev.Enabled = SelectedBill.Files.Count > 1 && this._selectedFileIndex > 0;

            if (SelectedBill.Files.Count > 0)
            {
                SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]].SetToPictureBox(this.picBilFilePreview);
            }
            else
            {
                this.picBilFilePreview.Image = null;
            }
        }

        /// <summary>
        /// Update al ListViewItems
        /// </summary>
        public void UpdateAllListviewItems()
        {
            Bill BillItem;
            for (int i = 0; i < this.lsvBills.Items.Count; i++)
            {
                BillItem = (Bill)this.lsvBills.Items[i].Tag;
                this.UpdateListviewItem(i, BillItem);
            }
        }

        /// <summary>
        /// Update the defined ListViewItem
        /// </summary>
        /// <param name="ItemIndex">Index of the Item to update</param>
        /// <param name="billItem">BillItem with new data for ListViewItem</param>
        private void UpdateListviewItem(int ItemIndex, Bill billItem)
        {
            if (ItemIndex < 0) return;
            this.lsvBills.Items[ItemIndex].Tag = billItem;
            this.lsvBills.Items[ItemIndex].Text = billItem.TitleNoText;
            this.lsvBills.Items[ItemIndex].SubItems[1].Tag = billItem.Date;
            this.lsvBills.Items[ItemIndex].SubItems[1].Text = "";
            if (billItem.Date != null) this.lsvBills.Items[ItemIndex].SubItems[1].Text = ((DateTime)billItem.Date).ToString(Settings.Default.DateFormat);
            this.lsvBills.Items[ItemIndex].SubItems[2].Text = billItem.Files.Count.ToString();
            this.lsvBills.Items[ItemIndex].SubItems[3].Text = billItem.BillClassName;
            this.lsvBills.Items[ItemIndex].SubItems[5].Text = billItem.CompanyName;
            this.lsvBills.Items[ItemIndex].SubItems[5].Text = billItem.Comment;

            this.prgBillProperty.Refresh();
        }

        #region Events
        #region Controle events
        #region Bill
        private void btnBillAdd_Click(object sender, EventArgs e)
        {
            this.Project.BillsLastInsertedId++;
            int NewId = -1 * this.Project.BillsLastInsertedId; //Use NegativId for new Items
            this._manageBill = new ManageBill(new Bill(NewId, this.Project.BillClasses, this.Project.Companies), this.Project);
            this._manageBill.BillSaveRequest += new EventHandler(this._manageBill_BillSaveRequest);
            this._manageBill.BillClassesManageRequest += new EventHandler(this._manageBill_BillClassesManageRequest);
            this._manageBill.CompaniesManageRequest += new EventHandler(this._manageBill_CompaniesManageRequest);
            if (this._manageBill.ShowDialog(this) == DialogResult.OK)
            {
                ListViewItem NewItem = new ListViewItem();
                NewItem.SubItems.Add("");
                NewItem.SubItems.Add("");
                NewItem.SubItems.Add("");
                NewItem.SubItems.Add("");

                this.lsvBills.Items.Add(NewItem);
                this.UpdateListviewItem(this.lsvBills.Items.Count - 1, this._manageBill.Bill);
                this.lsvBills_SelectedIndexChanged(sender, e);
                this._manageBill.Bill.BillChanged += new EventHandler(this.Project.ToggleSubItemChanged);
                this.Project.Changed = true;
            }
        }

        private void btnBillEdit_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;

            this._manageBill = new ManageBill(((Bill)this.lsvBills.SelectedItems[0].Tag).Clone(), this.Project);
            this._manageBill.BillSaveRequest += new EventHandler(this._manageBill_BillSaveRequest);
            this._manageBill.BillClassesManageRequest += new EventHandler(this._manageBill_BillClassesManageRequest);
            this._manageBill.CompaniesManageRequest += new EventHandler(this._manageBill_CompaniesManageRequest);
            this._manageBill.ShowDialog(this);

            this.UpdateListviewItem(this.lsvBills.SelectedIndices[0], (Bill)this.lsvBills.SelectedItems[0].Tag);
            this.lsvBills_SelectedIndexChanged(sender, e);
        }

        private void btnBillRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;

            this.lsvBills.SelectedItems[0].Remove();
            this.lsvBills_SelectedIndexChanged(sender, e);
        }

        private void lsvBills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count == 1) this.btnBillEdit_Click(sender, e);
        }

        private void lsvBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnlBillFiles.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.btnBillEdit.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.btnBillRemove.Enabled = this.lsvBills.SelectedItems.Count >= 1;

            List<Bill> BillList = new List<Bill>();
            foreach (ListViewItem Bill in this.lsvBills.SelectedItems)
            {
                BillList.Add((Bill)Bill.Tag);
            }

            this.prgBillProperty.SelectedObjects = BillList.ToArray();
            this._selectedFileIndex = 0;
            this.SetFilePreview();
        }

        private void prgBillProperty_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.prgBillProperty.Refresh();
            foreach (Bill BillItem in this.prgBillProperty.SelectedObjects)
            {
                this.UpdateListviewItem(this.GetListViewItemIndex(BillItem.Id), BillItem);
            }
        }
        #endregion

        #region Bill File
        private void btnBillFileNext_Click(object sender, EventArgs e)
        {
            this._selectedFileIndex += 1;
            this.SetFilePreview();
        }

        private void btnBillFileOpen_Click(object sender, EventArgs e)
        {
            Bill SelectedBill = ((Bill)this.lsvBills.SelectedItems[0].Tag);
            SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]].OpenFileFromTemp(this);
        }

        private void btnBillFileSave_Click(object sender, EventArgs e)
        {
            Bill SelectedBill = ((Bill)this.lsvBills.SelectedItems[0].Tag);
            SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]].OpenFileFromPath(this);
        }

        private void btnBillFilePrev_Click(object sender, EventArgs e)
        {
            this._selectedFileIndex -= 1;
            this.SetFilePreview();
        }

        private void picBilFilePreview_DoubleClick(object sender, EventArgs e)
        {
            this.btnBillFileOpen_Click(sender, e);
        }
        #endregion
        #endregion

        #region From Events
        private void Bills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.ApplicationExitCall ||
                 e.CloseReason == CloseReason.MdiFormClosing ||
                 e.CloseReason == CloseReason.UserClosing
               ) && !this._appOrProjectClose)
            {
                e.Cancel = true;
                if (e.CloseReason == CloseReason.UserClosing) this.RequestClose?.Invoke(this, new EventArgs());
                return;
            }
        }

        private void Bills_Load(object sender, EventArgs e)
        {
            this.Bills_Resize(sender, e);
        }

        private void Bills_Resize(object sender, EventArgs e)
        {
            this.SizeGripStyle = this.WindowState == FormWindowState.Maximized ? SizeGripStyle.Hide : SizeGripStyle.Show;
        }

        private void Bills_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region Menue Events
        internal void mnuBillsForm_Basedata_BillClass_Click(object sender, EventArgs e)
        {
            this._manageBillClass = new ManageBillClass(this.Project);
            this._manageBillClass.ShowDialog(this);

            for (int i = 0; i < this.lsvBills.Items.Count; i++)
            {
                this.UpdateListviewItem(i, (Bill)this.lsvBills.Items[i].Tag);
            }
        }

        internal void mnuBillsForm_Basedata_Company_Click(object sender, EventArgs e)
        {
            this._manageCompany = new ManageCompany(this.Project);
            this._manageCompany.ShowDialog(this);
        }

        private void mnuBillForm_Search_Bill_Click(object sender, EventArgs e)
        {
            this._searchBill = new Search(this.Project);
            this._searchBill.RequestListResults += new EventHandler(this._search_RequestListResults);
            this._searchBill.Show(this);
        }
        #endregion

        private void _manageBill_BillSaveRequest(object sender, EventArgs e)
        {
            if (this._manageBill.Bill.Id < 0)
            {
                this._manageBill.Bill.Id = -1 * this._manageBill.Bill.Id;
                this.Project.BillsLastInsertedId = this._manageBill.Bill.Id;
                this.Project.Bills.Add(this._manageBill.Bill.Id, this._manageBill.Bill);
            }
            else
            {
                this.Project.Bills[this._manageBill.Bill.Id] = this._manageBill.Bill;
                this.UpdateListviewItem(this.lsvBills.SelectedIndices[0], this._manageBill.Bill);
            }
        }

        private void _manageBill_BillClassesManageRequest(object sender, EventArgs e)
        {
            this._manageBillClass = new ManageBillClass(this.Project);
            this._manageBillClass.ShowDialog((IWin32Window)sender);
            this._manageBill.AddBillClassesToTreeViewRecursive();
        }

        private void _manageBill_CompaniesManageRequest(object sender, EventArgs e)
        {
            this._manageCompany = new ManageCompany(this.Project);
            this._manageCompany.ShowDialog((IWin32Window)sender);
            this._manageBill.AddCompaniesToComboBox();
        }

        private void _project_ProjectChanged(object sender, EventArgs e)
        {
            FormInv.Text(this, this.Project.ProjectTitle + (this.Project.Changed ? "*" : ""));
        }

        private void _search_RequestListResults(object sender, EventArgs e)
        {
            this.FillListView(this._searchBill.BillsFound);
        }
        #endregion
        #endregion
    }
}