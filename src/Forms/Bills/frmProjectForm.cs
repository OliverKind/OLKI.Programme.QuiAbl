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

        /// <summary>
        /// Changes are system intern
        /// </summary>
        private bool _systemChanged = false;
        #endregion

        #region Properteis
        /// <summary>
        /// Get the number of listed Bills
        /// </summary>
        public int BillsInList => this.lsvBills.Items.Count;

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
            this._systemChanged = true;
            this._lblBillFileNumber_OrgText = this.lblBillFileNumber.Text;
            this.lsvBills_SelectedIndexChanged(this, new EventArgs());  //Used to initial some Controles

            // Set Column Width
            this.lsvBills.ColumnWidths = Settings_AppVar.Default.BillsColumnWidth.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();

            //Load Bills
            this.Project = project;
            this.Project.ProjectChanged += new EventHandler(this._project_ProjectChanged);
            this.FillListView(null);
            //Load Bill sorting
            this.lsvBills.Sort(Settings_AppVar.Default.BillsSortColumn, Settings_AppVar.Default.BillsSortOrder);    //Saved sorting

            this.tabBill.SelectedTab = this.tabpBillDocs;
            this._project_ProjectChanged(this, new EventArgs());
        }

        /// <summary>
        /// Close the forme
        /// </summary>
        public new void Close()
        {
            if (this._searchBill != null && !this._searchBill.IsDisposed)
            {
                //Avoid Exception on application close
                this._searchBill.Close();
                this._searchBill.Dispose();
                this._searchBill = null;
            }

            this._appOrProjectClose = true;
            base.Close();
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
                    ListViewItem NewItem = new ListViewItem
                    {
                        Tag = BillItem.Value,
                        Text = BillItem.Value.TitleNoText
                    };
                    this.lsvBills.FillUpSubItems(NewItem);
                    this.lsvBills.Items.Add(NewItem);
                    this.UpdateListviewItem(this.GetListViewItemIndex(BillItem.Value.Id), BillItem.Value);
                }
            }
            this.lsvBills.EndUpdate();
            this.lsvBills_SelectedIndexChanged(this, new EventArgs());
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
                this.lblBillFileOriginalFileName.Text = "";
                this.lblBillFileTitle.Text = "";
                return;
            }

            Bill SelectedBill = (Bill)this.lsvBills.SelectedItems[0].Tag;
            this.pnlBillFiles.Enabled = (SelectedBill.Files.Count > 0);
            this.lblBillFileNumber.Text = string.Format(this._lblBillFileNumber_OrgText, new object[] { SelectedBill.Files.Count > 0 ? this._selectedFileIndex + 1 : 0, SelectedBill.Files.Count });

            this.btnBillFileNext.Enabled = SelectedBill.Files.Count > 1 && this._selectedFileIndex + 1 < SelectedBill.Files.Count;
            this.btnBillFilePrev.Enabled = SelectedBill.Files.Count > 1 && this._selectedFileIndex > 0;

            if (SelectedBill.Files.Count > 0)
            {
                File FileItem = SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]];
                FileItem.SetToPictureBox(this.picBilFilePreview);
                this.lblBillFileOriginalFileName.Text = FileItem.OriginalFileName;
                this.lblBillFileTitle.Text = FileItem.Source != File.FileSource.Link ? FileItem.TitleNoText : FileItem.LinkPath;

                if (FileItem.Source == File.FileSource.Link && new System.IO.FileInfo(FileItem.LinkPath).Exists)
                {
                    this.btnBillFileOpen.Enabled = true;
                    this.btnBillFileSave.Enabled = false;
                }
                else if (FileItem.Image != null || !string.IsNullOrEmpty(FileItem.FileBase64))
                {
                    this.btnBillFileOpen.Enabled = true;
                    this.btnBillFileSave.Enabled = true;
                }
                else
                {
                    this.btnBillFileOpen.Enabled = false;
                    this.btnBillFileSave.Enabled = false;
                }
            }
            else
            {
                this.picBilFilePreview.Image = null;
                this.btnBillFileOpen.Enabled = false;
                this.btnBillFileSave.Enabled = false;
            }
        }

        /// <summary>
        /// Update al ListViewItems
        /// </summary>
        public void UpdateAllListviewItems()
        {
            this.lsvBills.BeginUpdate();
            Bill BillItem;
            for (int i = 0; i < this.lsvBills.Items.Count; i++)
            {
                BillItem = (Bill)this.lsvBills.Items[i].Tag;
                this.UpdateListviewItem(i, BillItem);
            }
            this.lsvBills.EndUpdate();
        }

        /// <summary>
        /// Update the defined ListViewItem
        /// </summary>
        /// <param name="ItemIndex">Index of the Item to update</param>
        /// <param name="billItem">BillItem with new data for ListViewItem</param>
        private void UpdateListviewItem(int ItemIndex, Bill billItem)
        {
            billItem.BillClasses = this.Project.BillClasses;
            billItem.Companies = this.Project.Companies;

            if (ItemIndex < 0) return;
            if (billItem.BillDisposed)
            {
                this.lsvBills.Items[ItemIndex].Font = new System.Drawing.Font(this.lsvBills.Items[ItemIndex].Font, System.Drawing.FontStyle.Strikeout);
            }
            else
            {
                this.lsvBills.Items[ItemIndex].Font = new System.Drawing.Font(this.lsvBills.Items[ItemIndex].Font, System.Drawing.FontStyle.Regular);
            }
            this.lsvBills.Items[ItemIndex].Tag = billItem;
            this.lsvBills.Items[ItemIndex].Text = billItem.TitleNoText;
            this.lsvBills.Items[ItemIndex].SubItems[1].Tag = billItem.Date;
            this.lsvBills.Items[ItemIndex].SubItems[1].Text = "";
            if (billItem.Date != null) this.lsvBills.Items[ItemIndex].SubItems[1].Text = ((DateTime)billItem.Date).ToString(Settings.Default.DateFormat);
            this.lsvBills.Items[ItemIndex].SubItems[2].Text = billItem.Files.Count.ToString();
            this.lsvBills.Items[ItemIndex].SubItems[3].Text = billItem.BillClassName;
            this.lsvBills.Items[ItemIndex].SubItems[4].Text = billItem.CompanyName;
            this.lsvBills.Items[ItemIndex].SubItems[5].Text = billItem.Comment;
            this.lsvBills.Items[ItemIndex].SubItems[6].Tag = billItem.FilesLength;
            this.lsvBills.Items[ItemIndex].SubItems[6].Text = Toolbox.DirectoryAndFile.FileSize.Convert(billItem.FilesLength, 2, Toolbox.DirectoryAndFile.FileSize.ByteBase.SI);
            this.lsvBills.Items[ItemIndex].SubItems[7].Tag = billItem.Id;
            this.lsvBills.Items[ItemIndex].SubItems[7].Text = billItem.Id.ToString();

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
                ListViewItem NewItem = new ListViewItem
                {
                    Tag = this._manageBill.Bill,
                    Text = this._manageBill.Bill.TitleNoText
                };
                this.lsvBills.FillUpSubItems(NewItem);
                this.lsvBills.Items.Add(NewItem);

                int NewBillIndex = this.GetListViewItemIndex(this._manageBill.Bill.Id);
                if (NewBillIndex > -1)
                {
                    this.UpdateListviewItem(NewBillIndex, this._manageBill.Bill);
                    this.lsvBills_SelectedIndexChanged(sender, e);
                }
                this._manageBill.Bill.BillChanged += new EventHandler(this.Project.ToggleSubItemChanged);

                foreach (ListViewItem ListViewItem in this.lsvBills.Items)
                {
                    ListViewItem.Selected = ListViewItem.Index == NewBillIndex;
                }
                if (this.lsvBills.Items.Count - 1 >= 0) this.lsvBills.Items[this.lsvBills.Items.Count - 1].EnsureVisible();
                this.Project.Changed = true;
            }
        }

        private void btnBillCopy_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;

            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show(Stringtable._0x001Fm, Stringtable._0x001Fc, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.Cancel) return;

            this.Project.BillsLastInsertedId++;
            Bill BillCopy = ((Bill)this.lsvBills.SelectedItems[0].Tag).Clone();
            BillCopy.Id = this.Project.BillsLastInsertedId;
            this.Project.Bills.Add(BillCopy.Id, BillCopy);
            if (MsgBoxResult == DialogResult.No)
            {
                foreach (KeyValuePair<int, File> FileItem in BillCopy.Files)
                {
                    BillCopy.Files[FileItem.Key].FileBase64 = string.Empty;
                }
            }

            ListViewItem NewItem = new ListViewItem
            {
                Tag = BillCopy,
                Text = BillCopy.TitleNoText
            };
            this.lsvBills.FillUpSubItems(NewItem);
            this.lsvBills.Items.Add(NewItem);

            int NewBillIndex = this.GetListViewItemIndex(BillCopy.Id);
            if (NewBillIndex > -1)
            {
                this.UpdateListviewItem(NewBillIndex, BillCopy);
                this.lsvBills_SelectedIndexChanged(sender, e);
            }
            foreach (ListViewItem ListViewItem in this.lsvBills.Items)
            {
                ListViewItem.Selected = ListViewItem.Index == NewBillIndex;
            }
            if (this.lsvBills.Items.Count - 1 >= 0) this.lsvBills.Items[this.lsvBills.Items.Count - 1].EnsureVisible();
            this.Project.Changed = true;
        }

        private void btnBillEdit_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;

            this._manageBill = new ManageBill(((Bill)this.lsvBills.SelectedItems[0].Tag).Clone(), this.Project);
            this._manageBill.BillSaveRequest += new EventHandler(this._manageBill_BillSaveRequest);
            this._manageBill.BillClassesManageRequest += new EventHandler(this._manageBill_BillClassesManageRequest);
            this._manageBill.CompaniesManageRequest += new EventHandler(this._manageBill_CompaniesManageRequest);
            if (this._manageBill.ShowDialog(this) != DialogResult.Cancel) this.Project.Changed = true;

            this.UpdateListviewItem(this.lsvBills.SelectedIndices[0], (Bill)this.lsvBills.SelectedItems[0].Tag);
            this.lsvBills_SelectedIndexChanged(sender, e);
        }

        private void btnBillRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count < 1) return;
            if (MessageBox.Show(Stringtable._0x0020m, Stringtable._0x0020m, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3) != DialogResult.Yes) return;

            foreach (ListViewItem BillItem in this.lsvBills.SelectedItems)
            {
                this.Project.Bills.Remove(((Bill)BillItem.Tag).Id);
                BillItem.Remove();
            }
            this.lsvBills_SelectedIndexChanged(sender, e);
            this.Project.Changed = true;
        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            this.mnuBillForm_Search_Bill_Click(sender, e);
        }

        private void btnSearchReset_Click(object sender, EventArgs e)
        {
            this.mnuBillForm_Search_Reset_Click(sender, e);
        }

        private void lsvBills_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this._systemChanged) return;

            OLKI.Toolbox.Widgets.SortListView.ColumnSorter Sorter = this.lsvBills.Sorter;
            Settings_AppVar.Default.BillsSortColumn = Sorter.SortColumn;
            Settings_AppVar.Default.BillsSortOrder = (int)Sorter.Order;
            Settings_AppVar.Default.Save();
        }

        private void lsvBills_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (this._systemChanged) return;
            Settings_AppVar.Default.BillsColumnWidth = string.Join(";", this.lsvBills.ColumnWidths);
            Settings_AppVar.Default.Save();
        }

        private void lsvBills_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count == 1) this.btnBillEdit_Click(sender, e);
        }

        private void lsvBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnBillCopy.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.btnBillEdit.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.btnBillRemove.Enabled = this.lsvBills.SelectedItems.Count >= 1;
            this.mnuBillForm_Bill_Copy.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.mnuBillForm_Bill_Edit.Enabled = this.lsvBills.SelectedItems.Count == 1;
            this.mnuBillForm_Bill_Remove.Enabled = this.lsvBills.SelectedItems.Count >= 1;
            this.pnlBillFiles.Enabled = this.lsvBills.SelectedItems.Count == 1;

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
            if (this.lsvBills.SelectedItems.Count != 1) return;
            this._selectedFileIndex += 1;
            this.SetFilePreview();
        }

        private void btnBillFileOpen_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;
            Bill SelectedBill = ((Bill)this.lsvBills.SelectedItems[0].Tag);
            File FileItem = SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]];

            if (FileItem.Source == File.FileSource.Link && new System.IO.FileInfo(FileItem.LinkPath).Exists)
            {
                FileItem.OpenFileFromLink(this);
            }
            else if (FileItem.Image != null || !string.IsNullOrEmpty(FileItem.FileBase64))
            {
                FileItem.OpenFileFromTemp(this);
            }
        }

        private void btnBillFileSave_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;
            Bill SelectedBill = ((Bill)this.lsvBills.SelectedItems[0].Tag);
            File FileItem = SelectedBill.Files[SelectedBill.FilesIdList[this._selectedFileIndex]];

            if (FileItem.Image == null && string.IsNullOrEmpty(FileItem.FileBase64)) return;
            if (FileItem.Source == File.FileSource.Link) return;
            FileItem.OpenFileFromPath(this);
        }

        private void btnBillFilePrev_Click(object sender, EventArgs e)
        {
            if (this.lsvBills.SelectedItems.Count != 1) return;
            this._selectedFileIndex -= 1;
            this.SetFilePreview();
        }

        private void picBilFilePreview_DoubleClick(object sender, EventArgs e)
        {
            this.btnBillFileOpen_Click(sender, e);
        }
        #endregion
        #endregion

        #region Form Events
        private void ProjectForm_Activated(object sender, EventArgs e)
        {
            if (this._searchBill != null && !this._searchBill.IsDisposed && !this._searchBill.Visible)
            {
                this._searchBill.Visible = true;
            }
            this.mnuBillForm_Search_AutoOpen.Checked = Settings.Default.Search_AutoOpen;
        }

        private void ProjectForm_Deactivate(object sender, EventArgs e)
        {
            if (this._searchBill != null && !this._searchBill.IsDisposed)
            {
                this._searchBill.Visible = false;
            }
        }

        private void ProjectForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            this.ProjectForm_Resize(sender, e);
        }

        private void ProjectForm_Resize(object sender, EventArgs e)
        {
            this.SizeGripStyle = this.WindowState == FormWindowState.Maximized ? SizeGripStyle.Hide : SizeGripStyle.Show;
        }

        private void ProjectForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            if (Settings.Default.Search_AutoOpen) this.mnuBillForm_Search_Bill_Click(this, new EventArgs());
            this._systemChanged = false;
        }
        #endregion

        #region Menue Events
        internal void mnuBillsForm_Basedata_BillClass_Click(object sender, EventArgs e)
        {
            this._manageBillClass = new ManageBillClass(this.Project, 0);
            this._manageBillClass.ShowDialog(this);

            for (int i = 0; i < this.lsvBills.Items.Count; i++)
            {
                this.UpdateListviewItem(i, (Bill)this.lsvBills.Items[i].Tag);
            }
        }

        internal void mnuBillsForm_Basedata_Company_Click(object sender, EventArgs e)
        {
            this._manageCompany = new ManageCompany(this.Project, 0);
            this._manageCompany.ShowDialog(this);
        }

        private void mnuBillForm_Bill_Add_Click(object sender, EventArgs e)
        {
            this.btnBillAdd_Click(sender, e);
        }

        private void mnuBillForm_Bill_Copy_Click(object sender, EventArgs e)
        {
            this.btnBillCopy_Click(sender, e);
        }

        private void mnuBillForm_Bill_Edit_Click(object sender, EventArgs e)
        {
            this.btnBillEdit_Click(sender, e);
        }

        private void mnuBillForm_Bill_Remove_Click(object sender, EventArgs e)
        {
            this.btnBillRemove_Click(sender, e);
        }

        private void mnuBillForm_Search_AutoOpen_Click(object sender, EventArgs e)
        {
            this.mnuBillForm_Search_AutoOpen.Checked = !this.mnuBillForm_Search_AutoOpen.Checked;
            Settings.Default.Search_AutoOpen = this.mnuBillForm_Search_AutoOpen.Checked;
            Settings.Default.Save();
        }

        private void mnuBillForm_Search_Bill_Click(object sender, EventArgs e)
        {
            if (this._searchBill == null || this._searchBill.IsDisposed || !this._searchBill.Visible)
            {
                this._searchBill = new Search(this.Project);
                this._searchBill.RequestListResults += new EventHandler(this._search_RequestListResults);
                this._searchBill.Text = string.Format(this._searchBill.Text, new object[] { this.Project.ProjectTitle });
                this._searchBill.Show(this);
            }
        }

        private void mnuBillForm_Search_Reset_Click(object sender, EventArgs e)
        {
            this.FillListView(null);
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
            this._manageBillClass = new ManageBillClass(this.Project, this._manageBill.Bill.BillClassId);
            this._manageBillClass.ShowDialog((IWin32Window)sender);
            this._manageBill.AddBillClassesToTreeViewRecursive(this._manageBillClass.DialogResult == DialogResult.OK);
        }

        private void _manageBill_CompaniesManageRequest(object sender, EventArgs e)
        {
            this._manageCompany = new ManageCompany(this.Project, this._manageBill.Bill.CompanyId);
            this._manageCompany.ShowDialog((IWin32Window)sender);
            this._manageBill.AddCompaniesToComboBox(this._manageCompany.DialogResult == DialogResult.OK);
        }

        private void _project_ProjectChanged(object sender, EventArgs e)
        {
            FormInv.Text(this, this.Project.ProjectTitle + (this.Project.Changed ? "*" : ""));
            if (this._searchBill != null)
            {
                this._searchBill.Text = string.Format(this._searchBill.Text, new object[] { this.Project.ProjectTitle });
            }
        }

        private void _search_RequestListResults(object sender, EventArgs e)
        {
            this.FillListView(this._searchBill.BillsFound);
            this.lsvBills.Sort();
            this.Project.ToggleProjectChanged(this, new EventArgs());
        }
        #endregion
        #endregion
    }
}