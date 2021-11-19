/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Form to manage Bills
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
using OLKI.Programme.QuiAbl.src.Project.Bill;
using OLKI.Toolbox.ColorAndPicture.Picture.Scan;
using OLKI.Toolbox.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    /// <summary>
    /// Form to manage Bills
    /// </summary>
    public partial class ManageBill : Form
    {
        #region Constants
        /// <summary>
        /// Seperator for file lists
        /// </summary>
        private const char FILE_SEPERATOR = ';';

        /// <summary>
        /// Format for creating new file names, if more than one file will be uploaded
        /// </summary>
        private const string MULTI_FILENAME_FORMAT = "{0} ({1})";
        #endregion

        #region Events
        /// <summary>
        /// Raised if save bill ist requestd
        /// </summary>
        public event EventHandler BillSaveRequest;

        /// <summary>
        /// Raised if mange BillClasses is requested
        /// </summary>
        public event EventHandler BillClassesManageRequest;

        /// <summary>
        /// Raised if mange Companies is requested
        /// </summary>
        public event EventHandler CompaniesManageRequest;
        #endregion

        #region Fields
        /// <summary>
        /// List with WIA-Scan devices
        /// </summary>
        private readonly List<WIA.DeviceInfo> _scanDeviceList;

        /// <summary>
        /// OpenFileDialog, to load files 
        /// </summary>
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog();

        /// <summary>
        /// Project to get data from
        /// </summary>
        private readonly Project.Project _project;

        /// <summary>
        /// Original text of Label FileModifyBrightnes
        /// </summary>
        private readonly string _lblFileModifyBrightnes_OrgText;

        /// <summary>
        /// Original text of Label FileModifyContrast
        /// </summary>
        private readonly string _lblFileModifyContrast_OrgText;

        /// <summary>
        /// Original text of Label FileModifyThreshold
        /// </summary>
        private readonly string _lblFileModifyThreshold_OrgText;
        #endregion

        #region Properties
        /// <summary>
        /// Bill to manage
        /// </summary>
        public Bill Bill { get; private set; }

        /// <summary>
        /// Dictrionary to convert ComboBoxIndex to ComapnyId
        /// </summary>
        private Dictionary<int, int> _comboToCompanyId;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new ManageBill Form
        /// </summary>
        /// <param name="bill">Bill to manage</param>
        /// <param name="project">Project to get data from</param>
        public ManageBill(Bill bill, Project.Project project)
        {
            InitializeComponent();

            this._lblFileModifyBrightnes_OrgText = this.lblFileModifyBrightnes.Text;
            this._lblFileModifyContrast_OrgText = this.lblFileModifyContrast.Text;
            this._lblFileModifyThreshold_OrgText = this.lblFileModifyThreshold.Text;

            this._project = project;
            this.Bill = bill.Clone();
            this.Bill.BillChanged -= new EventHandler(this._project.ToggleSubItemChanged);

            this.btnAccept.Enabled = this.Bill.Id > 0;

            // Set Controles
            this.txtTitle.Text = this.Bill.Title;
            this.txtTitle_TextChanged(this, new EventArgs());
            this.AddCompaniesToComboBox(false);
            this.mtbDate.Text = this.Bill.Date.ToString();
            this.txtOrgFileLocation.Text = this.Bill.OrgFileLocation;
            this.txtBillNumber.Text = this.Bill.BillNumber;
            this.txtCustomNumber.Text = this.Bill.CustomNumber;
            this.mtbExpidation.Text = this.Bill.Expiration.ToString();
            this.AddBillClassesToTreeViewRecursive(false);
            this.txtComment.Text = this.Bill.Comment;

            // Fill file list
            this.lsvFiles.BeginUpdate();
            ListViewItem NewLsvFileItem;
            foreach (KeyValuePair<int, File> FileItem in this.Bill.Files.OrderBy(o => o.Value.Title))
            {
                FileItem.Value.Modification = null;
                NewLsvFileItem = new ListViewItem
                {
                    Tag = FileItem.Value,
                    Text = FileItem.Value.TitleNoText
                };
                this.lsvFiles.Items.Add(NewLsvFileItem);
            }
            this.lsvFiles_SelectedIndexChanged(this, new EventArgs());
            this.lsvFiles.EndUpdate();

            // Initial scan devices
            this.cboFileScanDevice.Items.Clear();
            this._scanDeviceList = WIAscan.GetDevices();
            for (int i = 0; i < _scanDeviceList.Count; i++)
            {
                this.cboFileScanDevice.Items.Add(_scanDeviceList[i].Properties["Name"].get_Value());
            }
            this.cboFileScanDevice.SelectedIndex = (this.cboFileScanDevice.Items.Count > 0 ? 0 : -1);
            this.nudFileScanResolution.Value = Settings.Default.ScanDefaultResolution;
            this.cboFileModifyColor.SelectedIndex = Settings.Default.ScanDefaultColorMode;

            this.tbaFileModifyBrightnes_Scroll(this, new EventArgs());
            this.tbaFileModifyContrast_Scroll(this, new EventArgs());
            this.cboFileModifyColor_SelectedIndexChanged(this, new EventArgs());
            this.tbaFileModifyThreshold_Scroll(this, new EventArgs());

            // Fill InvoiceItem list
            this.lsvInvoiceItems.BeginUpdate();
            this.lsvInvoiceItems.Items.Clear();
            ListViewItem NewPItem;
            foreach (KeyValuePair<int, InvoiceItem> InvoiceItem in this.Bill.InvoiceItems)
            {
                // Create empty item and fill up by update procedure
                NewPItem = new ListViewItem
                {
                    Tag = InvoiceItem.Value,
                    Text = InvoiceItem.Value.TitleNoText
                };
                this.lsvInvoiceItems.FillUpSubItems(NewPItem);
                this.lsvInvoiceItems.Items.Add(NewPItem);
                this.UpdateInvoiceItemListview(this.GetInvoiceItemListviewItemIndex(InvoiceItem.Value.Id), InvoiceItem.Value);
            }
            this.lsvInvoiceItems_SelectedIndexChanged(this, new EventArgs());
            this.lsvInvoiceItems.EndUpdate();
        }

        /// <summary>
        /// Add Nodes to TreeView with BillClasses
        /// </summary>
        /// <param name="selectLastInsertedBillClass">Select the BillClass last attet to the BillClass list, if no BillClass is slected</param>
        public void AddBillClassesToTreeViewRecursive(bool selectLastInsertedBillClass)
        {
            this.trvBillClasses.Nodes.Clear();
            this.AddBillClassesToTreeViewRecursive(null, selectLastInsertedBillClass);
            this.trvBillClasses.ShowPlusMinus = Settings.Default.TreeView_BillClasses_AllowCollaps;
            if (Settings.Default.TreeView_BillClasses_ExpandAllDefault || !Settings.Default.TreeView_BillClasses_AllowCollaps) this.trvBillClasses.ExpandAll();
        }

        /// <summary>
        /// Add Nodes to TreeView with BillClasses
        /// </summary>
        /// <param name="selectLastInsertedBillClass">Select the BillClass last attet to the BillClass list, if no BillClass is slected</param>
        private void AddBillClassesToTreeViewRecursive(TreeNode parentNode, bool selectLastInsertedBillClass)
        {
            int rootNodeId = 0;
            if (parentNode != null) rootNodeId = ((BillClass)parentNode.Tag).Id;

            TreeNode NewNode;
            foreach (KeyValuePair<int, BillClass> billClassItem in this._project.BillClasses.OrderBy(o => o.Value.Title))
            {
                if (billClassItem.Value.RootId != rootNodeId) continue;

                NewNode = new TreeNode
                {
                    Tag = billClassItem.Value,
                    Text = billClassItem.Value.TitleNoText
                };

                //Add Root Nodes or Sub Nodes
                if (parentNode != null)
                {
                    parentNode.Nodes.Add(NewNode);
                }
                else
                {
                    this.trvBillClasses.Nodes.Add(NewNode);
                }

                //Select BillClasses
                if (selectLastInsertedBillClass && this.Bill.BillClassId == 0 && billClassItem.Value.Id == this._project.BillClassLastInsertedId)
                {
                    this.trvBillClasses.SelectedNode = NewNode;
                }
                else if (                 this.Bill.BillClassId > 0 && billClassItem.Value.Id == this.Bill.BillClassId) {
                        this.trvBillClasses.SelectedNode = NewNode;
                    }

                this.AddBillClassesToTreeViewRecursive(NewNode, selectLastInsertedBillClass);
            }
        }

        /// <summary>
        /// Add Comapnies to the CompanyComboBox
        /// </summary>
        /// <param name="selectLastInsertedCompany">Select the Company last attet to the Company List, if no Company is slected</param>
        public void AddCompaniesToComboBox(bool selectLastInsertedCompany)
        {
            this.cboCompany.Items.Clear();
            this._comboToCompanyId = new Dictionary<int, int>();
            int i = 0;

            //Add empty item for no comapny selected
            this.cboCompany.Items.Add("");
            this._comboToCompanyId.Add(i, 0);

            //Add company items
            foreach (KeyValuePair<int, Company> companyItem in this._project.Companies.OrderBy(o => o.Value.TitleNoText))
            {
                i++;
                this.cboCompany.Items.Add(companyItem.Value.TitleNoText);
                this._comboToCompanyId.Add(i, companyItem.Value.Id);
                if (selectLastInsertedCompany && this.Bill.CompanyId==0 && companyItem.Value.Id == this._project.CompanyLastInsertedId)
                {
                    this.cboCompany.SelectedIndex = i;
                }
                else if (this.Bill.CompanyId > 0 && companyItem.Value.Id == this.Bill.CompanyId)
                {
                    this.cboCompany.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Get the InvoiceListViewItemIndex for an InvoiceItem to search by his Id
        /// </summary>
        /// <param name="itemId">Id of the InvoiceItem to search for</param>
        /// <returns>The Index of the InvoiceItem to search by Id or -1 for no match</returns> 
        private int GetInvoiceItemListviewItemIndex(int itemId)
        {
            InvoiceItem InvoiceItem;
            for (int i = 0; i < this.lsvInvoiceItems.Items.Count; i++)
            {
                InvoiceItem = (InvoiceItem)this.lsvInvoiceItems.Items[i].Tag;
                if (InvoiceItem.Id == itemId) return i;
            }
            return -1;
        }

        /// <summary>
        /// Update the definded Item in InvoiceItemListview
        /// </summary>
        /// <param name="ItemIndex">Index of the ListViewItem to update</param>
        /// <param name="invoiceItem">InvoiceItem to set to ListViewItem</param>
        private void UpdateInvoiceItemListview(int ItemIndex, InvoiceItem invoiceItem)
        {
            if (ItemIndex < 0) return;
            this.lsvInvoiceItems.Items[ItemIndex].Tag = invoiceItem;
            this.lsvInvoiceItems.Items[ItemIndex].Text = invoiceItem.TitleNoText;
            this.lsvInvoiceItems.Items[ItemIndex].SubItems[1].Text = invoiceItem.ArticleNumber;
            this.lsvInvoiceItems.Items[ItemIndex].SubItems[2].Text = invoiceItem.Price.ToString();
            this.lsvInvoiceItems.Items[ItemIndex].SubItems[3].Text = invoiceItem.Quantity.ToString();
            this.lsvInvoiceItems.Items[ItemIndex].SubItems[4].Text = invoiceItem.PriceSum.ToString();
            this.lsvInvoiceItems.Items[ItemIndex].SubItems[5].Text = invoiceItem.Comment;

            this.prgInvoiceItemProperty.Refresh();
        }

        #region Controle Events
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Save file items
            this.Bill.Files.Clear();
            int MaxFileId = 0;
            for (int i = 0; i < this.lsvFiles.Items.Count; i++)
            {
                File FilteItem = (File)this.lsvFiles.Items[i].Tag;
                if (FilteItem.Image != null && FilteItem.Modification != null)
                {
                    //Save procedes image to listview
                    FilteItem.Image = FilteItem.ImageProcedet;
                    FilteItem.Modification = null;
                    this.Bill.Files[FilteItem.Id] = FilteItem;
                    this.lsvFiles.Items[i].Tag = FilteItem;
                }

                if (FilteItem.Id > MaxFileId) MaxFileId = FilteItem.Id;
                if (!this.Bill.Files.ContainsKey(FilteItem.Id))
                {
                    this.Bill.Files.Add(FilteItem.Id, null);
                }
                this.Bill.Files[FilteItem.Id] = FilteItem;
            }
            this.Bill.FilesLastInsertedId = MaxFileId;
            this.lsvFiles_SelectedIndexChanged(sender, e);

            // Save invoice items
            this.Bill.InvoiceItems.Clear();
            int MaxInvoiceItemsId = 0;
            for (int i = 0; i < this.lsvInvoiceItems.Items.Count; i++)
            {
                InvoiceItem InvoiceItem = (InvoiceItem)this.lsvInvoiceItems.Items[i].Tag;
                if (InvoiceItem.Id > MaxInvoiceItemsId) MaxInvoiceItemsId = InvoiceItem.Id;
                this.Bill.InvoiceItems.Add(InvoiceItem.Id, InvoiceItem);
            }
            this.Bill.InvoiceItemLastInsertedId = MaxInvoiceItemsId;

            this.trvBillClasses_AfterSelect(sender, new TreeViewEventArgs(this.trvBillClasses.SelectedNode));
            this.Bill.BillChanged += new EventHandler(this._project.ToggleSubItemChanged);
            this._project.ToggleSubItemChanged(sender, e);

            this.BillSaveRequest?.Invoke(this, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.btnAccept_Click(sender, e);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region Bill Data
        private void btnManageBillClasses_Click(object sender, EventArgs e)
        {
            this.BillClassesManageRequest?.Invoke(this, new EventArgs());
        }

        private void btnManageCompanies_Click(object sender, EventArgs e)
        {
            this.CompaniesManageRequest?.Invoke(this, new EventArgs());
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboCompany.SelectedIndex < 0) this.cboCompany.SelectedIndex = 0;
            this.Bill.CompanyId = this._comboToCompanyId[this.cboCompany.SelectedIndex];
        }

        private void mtbDate_TextChanged(object sender, EventArgs e)
        {
            this.mtbDates_TextChanged(sender, e);
            DateTime.TryParse(this.mtbDate.Text, out DateTime BillDate);
            this.Bill.Date = BillDate;
        }

        private void mtbDates_TextChanged(object sender, EventArgs e)
        {
            string SenderText = ((MaskedTextBox)sender).Text;
            if (string.IsNullOrEmpty(System.Text.RegularExpressions.Regex.Replace(SenderText, @"[^0-9]", "")) || DateTime.TryParse(SenderText, out _))
            {
                this.erpMannageBill.SetError((Control)sender, "");
            }
            else
            {
                this.erpMannageBill.SetError((Control)sender, Stringtable._0x0009);
            }
        }

        private void mtbExpidation_TextChanged(object sender, EventArgs e)
        {
            this.mtbDates_TextChanged(sender, e);
            DateTime.TryParse(this.mtbExpidation.Text, out DateTime BillExpidationDate);
            this.Bill.Expiration = BillExpidationDate;
        }

        private void trvBillClasses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.trvBillClasses.SelectedNode != null)
            {
                this.Bill.BillClassId = ((BillClass)this.trvBillClasses.SelectedNode.Tag).Id;
            }
            else
            {
                this.Bill.BillClassId = 0;
            }
        }

        private void trvBillClasses_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (!Settings.Default.TreeView_BillClasses_AllowCollaps) e.Cancel = true;
        }

        private void trvBillClasses_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.trvBillClasses.SelectedNode != null)
            {
                this.trvBillClasses.SelectedNode = null;
                this.trvBillClasses_AfterSelect(sender, new TreeViewEventArgs(null));
            }
        }

        private void txtBillNumber_TextChanged(object sender, EventArgs e)
        {
            this.Bill.BillNumber = this.txtBillNumber.Text;
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            this.Bill.Comment = this.txtComment.Text;
        }

        private void txtCustomNumber_TextChanged(object sender, EventArgs e)
        {
            this.Bill.CustomNumber = this.txtCustomNumber.Text;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            this.Bill.Title = this.txtTitle.Text;
            this.Text = this.Bill.TitleNoText;
        }

        private void txtOrgFileLocation_TextChanged(object sender, EventArgs e)
        {
            this.Bill.OrgFileLocation = this.txtOrgFileLocation.Text;
        }
        #endregion

        #region Files
        private void btnFileAdd_Click(object sender, EventArgs e)
        {
            // Create new item
            this.Bill.FilesLastInsertedId++;
            File NewFile = new File(this.Bill.FilesLastInsertedId);
            this.Bill.Files.Add(this.Bill.FilesLastInsertedId, NewFile);

            // Add item to ListView
            ListViewItem NewLsvFileItem = new ListViewItem
            {
                Tag = NewFile,
                Text = NewFile.TitleNoText
            };
            this.lsvFiles.Items.Add(NewLsvFileItem);

            // Select new ListViewItem
            this.lsvFiles.Items[this.lsvFiles.Items.Count - 1].Selected = true;
        }

        private void btnFileAttech_Click(object sender, EventArgs e)
        {
            File NewFile;
            ListViewItem NewLsvFileItem;
            int OrgSelectedIndex = this.lsvFiles.SelectedIndices[0];

            List<string> Files = this.txtFilePath.Text.Split(FILE_SEPERATOR).ToList();
            if (!this.OverwriteExistingFileDate(OrgSelectedIndex)) return;
            for (int i = 0; i < Files.Count; i++)
            {
                // Create a new ListViewItem
                if (i > 0)
                {
                    // Add file to list
                    this.Bill.FilesLastInsertedId++;
                    NewFile = new File(this.Bill.FilesLastInsertedId)
                    {
                        LinkPath = "",
                        Source = File.FileSource.File,
                        Title = string.Format(MULTI_FILENAME_FORMAT, new object[] { this.lsvFiles.Items[OrgSelectedIndex].Text, (i + 1) })
                    };
                    this.Bill.Files.Add(this.Bill.FilesLastInsertedId, NewFile);

                    // Add item to list view
                    NewLsvFileItem = new ListViewItem
                    {
                        Tag = NewFile,
                        Text = NewFile.TitleNoText
                    };
                    this.lsvFiles.Items.Insert(OrgSelectedIndex + i, NewLsvFileItem);
                }

                // Add the file
                try
                {
                    ((File)this.lsvFiles.Items[OrgSelectedIndex + i].Tag).LinkPath = "";
                    ((File)this.lsvFiles.Items[OrgSelectedIndex + i].Tag).LoadFile(Files[i]);
                    ((File)this.lsvFiles.Items[OrgSelectedIndex + i].Tag).Source = File.FileSource.File;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format(Stringtable._0x0007m, new object[] { Files[i], ex.Message }), Stringtable._0x0007c, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.txtFilePath.Text = "";
                this.lblOriginalFileName.Text = ((File)this.lsvFiles.Items[OrgSelectedIndex].Tag).OriginalFileName;
                ((File)this.lsvFiles.Items[OrgSelectedIndex].Tag).SetToPictureBox(this.picFilePreview);
            }
        }

        private void btnFileScan_Click(object sender, EventArgs e)
        {
            if (this.cboFileScanDevice.SelectedIndex == -1) return;
            if (!this.OverwriteExistingFileDate(this.lsvFiles.SelectedIndices[0])) return;
            string ScanDeviceId = this._scanDeviceList[this.cboFileScanDevice.SelectedIndex].DeviceID;

            Image NewImage = WIAscan.Scan(ScanDeviceId, (uint)this.nudFileScanResolution.Value, out Exception ScanExteption);

            if (ScanExteption != null)
            {
                MessageBox.Show(this, string.Format(Stringtable._0x0017m, new object[] { ScanExteption.Message }), Stringtable._0x0017c, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (NewImage != null)
            {
                ((File)this.lsvFiles.SelectedItems[0].Tag).LinkPath = "";
                ((File)this.lsvFiles.SelectedItems[0].Tag).LoadFile(NewImage);
                ((File)this.lsvFiles.SelectedItems[0].Tag).Source = File.FileSource.Scan;
            }

            this.cboFileModifyColor_SelectedIndexChanged(sender, e);
            this.SetSelectedFileToControles(false);
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            this._openFileDialog.Multiselect = true;
            if (this._openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.txtFilePath.Text = string.Join(FILE_SEPERATOR.ToString(), this._openFileDialog.FileNames);
                this.btnFileAttech_Click(sender, e);
            }
        }

        private void btnFileLinkBrowse_Click(object sender, EventArgs e)
        {
            this._openFileDialog.Multiselect = false;
            if (this._openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (!this.OverwriteExistingFileDate(this.lsvFiles.SelectedIndices[0])) return;
                this.txtFileLinkPath.Text = this._openFileDialog.FileName;
                ((File)this.lsvFiles.SelectedItems[0].Tag).LinkPath = this._openFileDialog.FileName;
                ((File)this.lsvFiles.SelectedItems[0].Tag).Source = File.FileSource.Link;

                this.SetSelectedFileToControles(false);
            }
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;

            if (FileItem.Source == File.FileSource.Link && new System.IO.FileInfo(FileItem.LinkPath).Exists)
            {
                FileItem.OpenFileFromLink(this);
            }
            else if (FileItem.Image != null || !string.IsNullOrEmpty(FileItem.FileBase64))
            {
                FileItem.OpenFileFromTemp(this);
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;

            if (FileItem.Image == null && string.IsNullOrEmpty(FileItem.FileBase64)) return;
            if (FileItem.Source == File.FileSource.Link) return;
            FileItem.OpenFileFromPath(this);
        }

        private void btnFileRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            this.lsvFiles.SelectedItems[0].Remove();
        }

        private void lsvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool OneSelected = this.lsvFiles.SelectedItems.Count == 1;

            this.btnFileRemove.Enabled = OneSelected;
            this.grbFileData.Enabled = OneSelected;
            if (OneSelected)
            {
                this.btnFileModifyRotateLeft.Tag = 0;
                this.btnFileModifyRotateRight.Tag = 0;
            }
            this.SetSelectedFileToControles(true);
            this.txtFilePath_TextChanged(sender, e);
        }

        private void picFilePreview_DoubleClick(object sender, EventArgs e)
        {
            this.btnFileOpen_Click(sender, e);
        }

        private void txtFileComment_TextChanged(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            ((File)this.lsvFiles.SelectedItems[0].Tag).Comment = this.txtFileComment.Text;
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            this.btnFileAttech.Enabled = !string.IsNullOrEmpty(this.txtFilePath.Text);
        }

        private void txtFileTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;

            ((File)this.lsvFiles.SelectedItems[0].Tag).Title = this.txtFileTitle.Text;
            this.lsvFiles.SelectedItems[0].Text = ((File)this.lsvFiles.SelectedItems[0].Tag).TitleNoText;
        }

        /// <summary>
        /// Get if the selected File has data and if yes if they sould been overwritten
        /// </summary>
        /// <param name="OrgSelectedIndex">Index of the selected file item</param>
        /// <returns></returns>
        private bool OverwriteExistingFileDate(int OrgSelectedIndex)
        {
            return string.IsNullOrEmpty(((File)this.lsvFiles.Items[OrgSelectedIndex].Tag).FileBase64) && string.IsNullOrEmpty(((File)this.lsvFiles.Items[OrgSelectedIndex].Tag).LinkPath) || MessageBox.Show(this, Stringtable._0x0006m, Stringtable._0x0006c, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void SetSelectedFileToControles(bool GetImageModification)
        {
            if (this.lsvFiles.SelectedItems.Count == 1)
            {
                File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;

                this.grbFileModify.Enabled = (FileItem.Image != null && FileItem.Source != File.FileSource.Link);
                this.lblOriginalFileName.Text = FileItem.OriginalFileName;
                this.txtFileComment.Text = FileItem.Comment;
                this.txtFileTitle.Text = FileItem.Title;
                this.txtFileLinkPath.Text = FileItem.LinkPath;
                this.txtFilePath.Text = "";

                if (GetImageModification) this.GetImageModification();
                this.SetSelectedFileToPicturebox();
                if (FileItem.Source == File.FileSource.Link && new System.IO.FileInfo(FileItem.LinkPath).Exists)
                {
                    this.btnFileSave.Enabled = false;
                    this.btnFileOpen.Enabled = true;
                }
                else if (FileItem.Image != null || !string.IsNullOrEmpty(FileItem.FileBase64))
                {
                    this.btnFileSave.Enabled = true;
                    this.btnFileOpen.Enabled = true;
                }
                else
                {
                    this.btnFileSave.Enabled = false;
                    this.btnFileOpen.Enabled = false;
                }
            }
            else
            {
                this.grbFileModify.Enabled = false;
                this.lblOriginalFileName.Text = "";
                this.picFilePreview.Image = null;
                this.prgFilePreview.SelectedObject = null;
                this.txtFileComment.Text = "";
                this.txtFileTitle.Text = "";
                this.txtFileLinkPath.Text = "";
                this.txtFilePath.Text = "";
            }
        }

        #region Image modification
        /// <summary>
        /// Get the image modifications from an selected file, if file is an Image and set the controles
        /// </summary>
        private void GetImageModification()
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;
            if (FileItem.Image == null)
            {
                this.cboFileModifyColor.SelectedIndex = Settings.Default.ScanDefaultColorMode;
                return;
            }

            File.ImageModification Modification = FileItem.Modification ?? new File.ImageModification();

            this.tbaFileModifyBrightnes.Value = Modification.Brightness;
            this.tbaFileModifyContrast.Value = Modification.Contrast;
            this.cboFileModifyColor.SelectedIndex = (int)Modification.Palette;
            this.tbaFileModifyThreshold.Value = Modification.Threshold;
        }

        /// <summary>
        /// Set the selcted image modifications to the image
        /// </summary>
        private void SetImageModification()
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;
            if (FileItem.Image == null) return;

            FileItem.Modification = new File.ImageModification
            {
                Brightness = this.tbaFileModifyBrightnes.Value,
                Contrast = this.tbaFileModifyContrast.Value,
                Palette = (Toolbox.ColorAndPicture.Picture.Modify.Palette.ColorPalette)this.cboFileModifyColor.SelectedIndex,
                RotateLeft = (int)this.btnFileModifyRotateLeft.Tag,
                RotateRight = (int)this.btnFileModifyRotateRight.Tag,
                Threshold = this.tbaFileModifyThreshold.Value
            };
        }

        /// <summary>
        /// Set the selected file to the preview PrictureBox, as image if file is an image
        /// </summary>
        private void SetSelectedFileToPicturebox()
        {
            if (this.lsvFiles.SelectedItems.Count != 1)
            {
                this.picFilePreview.Image = null;
                return;
            }
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;
            FileItem.SetToPictureBox(this.picFilePreview);
            this.prgFilePreview.SelectedObject = FileItem.ImageProcedet;
        }

        private void btnFileModifyCrop_Click(object sender, EventArgs e)
        {
            if (!this.picFilePreview.CropAreaFit.HasValue)
            {
                MessageBox.Show(this, Stringtable._0x0019m, Stringtable._0x0019c, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;
            FileItem.Crop(this.picFilePreview.CropAreaFit.Value);
            this.SetSelectedFileToPicturebox();
        }

        private void btnFileModifyCropUndo_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            File FileItem = (File)this.lsvFiles.SelectedItems[0].Tag;
            FileItem.CropUndo();
            this.SetSelectedFileToPicturebox();
        }

        private void btnFileModifyRotateLeft_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            if (this.btnFileModifyRotateLeft.Tag == null) this.btnFileModifyRotateLeft.Tag = 0;
            this.btnFileModifyRotateLeft.Tag = (int)this.btnFileModifyRotateLeft.Tag + 1;
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
        }

        private void btnFileModifyRotateRight_Click(object sender, EventArgs e)
        {
            if (this.lsvFiles.SelectedItems.Count != 1) return;
            if (this.btnFileModifyRotateRight.Tag == null) this.btnFileModifyRotateRight.Tag = 0;
            this.btnFileModifyRotateRight.Tag = (int)this.btnFileModifyRotateRight.Tag + 1;
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
        }

        private void cboFileModifyColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
            switch (this.cboFileModifyColor.SelectedIndex)
            {
                case 0: //Color
                    this.tbaFileModifyThreshold.Enabled = false;
                    break;
                case 1: //Grayscale
                    this.tbaFileModifyThreshold.Enabled = false;
                    break;
                case 2: //BW
                    this.tbaFileModifyThreshold.Enabled = true;
                    break;
                default:
                    this.tbaFileModifyThreshold.Enabled = false;
                    break;
            }
        }

        private void tbaFileModifyBrightnes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            this.tbaFileModifyBrightnes.Value = 0;
            this.tbaFileModifyBrightnes_Scroll(sender, new EventArgs());
        }

        private void tbaFileModifyBrightnes_Scroll(object sender, EventArgs e)
        {
            this.lblFileModifyBrightnes.Text = string.Format(this._lblFileModifyBrightnes_OrgText, this.tbaFileModifyBrightnes.Value);
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
        }

        private void tbaFileModifyContrast_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.Button == MouseButtons.Right) this.tbaFileModifyContrast.Value = 0;
            this.tbaFileModifyContrast_Scroll(sender, new EventArgs());
        }

        private void tbaFileModifyContrast_Scroll(object sender, EventArgs e)
        {
            this.lblFileModifyContrast.Text = string.Format(this._lblFileModifyContrast_OrgText, this.tbaFileModifyContrast.Value);
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
        }

        private void tbaFileModifyThreshold_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.Button == MouseButtons.Right) this.tbaFileModifyThreshold.Value = 127;
            this.tbaFileModifyThreshold_Scroll(sender, new EventArgs());
        }

        private void tbaFileModifyThreshold_Scroll(object sender, EventArgs e)
        {
            this.lblFileModifyThreshold.Text = string.Format(this._lblFileModifyThreshold_OrgText, this.tbaFileModifyThreshold.Value);
            this.SetImageModification();
            this.SetSelectedFileToPicturebox();
        }
        #endregion
        #endregion

        #region InvoiceItems
        private void btnInvoiceItemAdd_Click(object sender, EventArgs e)
        {
            this.Bill.InvoiceItemLastInsertedId++;
            InvoiceItem NewInvoiceItem = new InvoiceItem(this.Bill.InvoiceItemLastInsertedId);
            this.Bill.InvoiceItems.Add(this.Bill.InvoiceItemLastInsertedId, NewInvoiceItem);
            ListViewItem NewItem = new ListViewItem
            {
                Tag = NewInvoiceItem,
                Text = NewInvoiceItem.TitleNoText
            };
            this.lsvInvoiceItems.FillUpSubItems(NewItem);
            this.lsvInvoiceItems.Items.Add(NewItem);
            int i = 0;
            this.lsvInvoiceItems.MultiSelect = false;
            foreach (ListViewItem Item in this.lsvInvoiceItems.Items)
            {
                if (((InvoiceItem)Item.Tag).Id == this.Bill.InvoiceItemLastInsertedId)
                {
                    this.lsvInvoiceItems.Items[i].Selected = true;
                    this.lsvInvoiceItems.MultiSelect = true;
                    return;
                }
                i++;
            }
        }

        private void btnInvoiceItemRemove_Click(object sender, EventArgs e)
        {
            if (this.lsvInvoiceItems.SelectedItems.Count < 1) return;
            foreach (ListViewItem InvoiceItem in this.lsvInvoiceItems.SelectedItems)
            {
                InvoiceItem.Remove();
            }
        }

        private void btnInvoiceItemImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Stringtable._0x001Bm, Stringtable._0x001Bc, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel) return;

            OpenFileDialog OpenFileDialog = new OpenFileDialog
            {
                DefaultExt = Settings.Default.CSVfile_DefaultExtension,
                Filter = Settings.Default.CSVfile_FilterList,
                FilterIndex = Settings.Default.CSVfile_FilterIndex
            };

            if (OpenFileDialog.ShowDialog(this) != DialogResult.OK) return;

            CSVreader CSVread = new CSVreader();
            if (CSVread.ReadCSVfromFile(OpenFileDialog.FileName, out Exception ImportException))
            {
                foreach (CSVreader.CSVrow CSVrow in CSVread.CSVrows)
                {
                    try
                    {
                        this.Bill.InvoiceItemLastInsertedId++;
                        InvoiceItem NewInvoiceItem = new InvoiceItem(this.Bill.InvoiceItemLastInsertedId)
                        {
                            Title = CSVrow.Columns[0],
                            ArticleNumber = CSVrow.Columns[1],
                            Price = decimal.Parse(CSVrow.Columns[2]),
                            Quantity = int.Parse(CSVrow.Columns[3]),
                            Comment = CSVrow.Columns[4]
                        };

                        this.Bill.InvoiceItems.Add(this.Bill.InvoiceItemLastInsertedId, NewInvoiceItem);
                        ListViewItem NewItem = new ListViewItem
                        {
                            Tag = NewInvoiceItem,
                            Text = NewInvoiceItem.TitleNoText
                        };
                        this.lsvInvoiceItems.FillUpSubItems(NewItem);
                        this.lsvInvoiceItems.Items.Add(NewItem);

                        this.UpdateInvoiceItemListview(this.GetInvoiceItemListviewItemIndex(NewInvoiceItem.Id), NewInvoiceItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, string.Format(Stringtable._0x001Am, new object[] { ex.Message }), Stringtable._0x001Ac, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Bill.InvoiceItemLastInsertedId--;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, string.Format(Stringtable._0x001Am, new object[] { ImportException.Message }), Stringtable._0x001Ac, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvInvoiceItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnInvoiceItemRemove.Enabled = this.lsvInvoiceItems.SelectedItems.Count == 1;
            if (this.lsvInvoiceItems.SelectedItems.Count > 0)
            {
                List<InvoiceItem> SelectedItems = new List<InvoiceItem> { };
                foreach (ListViewItem ListViewItem in this.lsvInvoiceItems.SelectedItems)
                {
                    SelectedItems.Add((InvoiceItem)ListViewItem.Tag);
                }
                this.prgInvoiceItemProperty.SelectedObjects = SelectedItems.ToArray();
            }
            else
            {
                this.prgInvoiceItemProperty.SelectedObject = null;
            }
        }

        private void prgInvoiceItemProperty_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            this.prgInvoiceItemProperty.Refresh();

            InvoiceItem InvoiceItem;
            foreach (object ChangedInvoiceItem in this.prgInvoiceItemProperty.SelectedObjects)
            {
                this.lsvInvoiceItems.BeginUpdate();
                InvoiceItem = (InvoiceItem)ChangedInvoiceItem;
                this.UpdateInvoiceItemListview(this.GetInvoiceItemListviewItemIndex(InvoiceItem.Id), InvoiceItem);
                this.lsvInvoiceItems.EndUpdate();
            }
        }
        #endregion
        #endregion
        #endregion
    }
}