/*
 * QuiAbl - Quittungsablage
 * 
 * Copyright:   Oliver Kind - 2021
 * License:     LGPL
 * 
 * Desctiption:
 * Form to manage BillClasses
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OLKI.Programme.QuiAbl.src.Forms.Bills
{
    /// <summary>
    /// Form to manage BillClasses
    /// </summary>
    public partial class ManageBillClass : Form
    {
        #region Events
        /// <summary>
        /// Raised if saving of BillClasses is requested
        /// </summary>
        public event EventHandler BillClassesSaveRequest;
        #endregion

        #region Fields
        /// <summary>
        /// Project to get data from
        /// </summary>
        private readonly Project.Project _project;
        #endregion

        #region Properties
        /// <summary>
        /// List with BillClasses
        /// </summary>
        public Dictionary<int, BillClass> _billClasses;

        /// <summary>
        /// Last insertes BillClass Id
        /// </summary>
        private int _billClassLastInsertedId;
        #endregion

        #region Methodes
        /// <summary>
        /// Initial a new ManageBillClass Form
        /// </summary>
        /// <param name="project">Project to get data from</param>
        public ManageBillClass(Project.Project project)
        {
            InitializeComponent();
            this._project = project;
            this._billClassLastInsertedId = this._project.BillClassLastInsertedId;
            this._billClasses = new Dictionary<int, BillClass>();
            foreach (KeyValuePair<int, BillClass> ClassItem in this._project.BillClasses)
            {
                this._billClasses.Add(ClassItem.Key, ClassItem.Value.Clone());
                this._billClasses[ClassItem.Key].BillClassChanged -= new EventHandler(this._project.ToggleSubItemChanged);
            }

            this.AddTreeViewNodesRecursive(null);
            this.trvBillClasses_AfterSelect(this, new TreeViewEventArgs(null));
            this.trvBillClasses.ShowPlusMinus = Properties.Settings.Default.TreeView_BillClasses_AllowCollaps;
            if (Properties.Settings.Default.TreeView_BillClasses_ExpandAllDefault || !Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) this.trvBillClasses.ExpandAll();
        }

        /// <summary>
        /// Add Nodes to TreeView with BillClasses
        /// </summary>
        /// <param name="parentNode">ParentNode to add new Nodes to</param>
        private void AddTreeViewNodesRecursive(TreeNode parentNode)
        {
            int rootNodeId = 0;
            if (parentNode != null) rootNodeId = ((BillClass)parentNode.Tag).Id;

            TreeNode NewNode;
            foreach (KeyValuePair<int, BillClass> billClassItem in this._billClasses.OrderBy(o => o.Value.Title))
            {
                if (billClassItem.Value.RootId != rootNodeId) continue;

                NewNode = new TreeNode
                {
                    Tag = billClassItem.Value,
                    Text = billClassItem.Value.TitleNoText
                };

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(NewNode);
                }
                else
                {
                    this.trvBillClasses.Nodes.Add(NewNode);
                }
                this.AddTreeViewNodesRecursive(NewNode);
            }
        }

        /// <summary>
        /// Convert the TreeViewNodes to a List of BillClasses
        /// </summary>
        /// <param name="parentNodes">Parent Node to search for sub Nodes.</param>
        private void TreeViewToBillClassList(TreeNodeCollection parentNodes)
        {
            if (parentNodes.Count == 0) return;

            BillClass NewBillClass;
            foreach (TreeNode TreeNode in parentNodes)
            {
                NewBillClass = new BillClass(((BillClass)TreeNode.Tag).Id, 0)
                {
                    Comment = ((BillClass)TreeNode.Tag).Comment,
                    RootId = TreeNode.Parent != null ? ((BillClass)TreeNode.Parent.Tag).Id : 0,
                    Title = ((BillClass)TreeNode.Tag).Title
                };
                this._billClasses.Add(NewBillClass.Id, NewBillClass);
                this.TreeViewToBillClassList(TreeNode.Nodes);
            }
        }

        #region Controle Events
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this._project.BillClassLastInsertedId = this._billClassLastInsertedId;
            this._project.BillClasses.Clear();

            this._billClasses.Clear();
            this.TreeViewToBillClassList(this.trvBillClasses.Nodes);
            this._project.BillClasses = this._billClasses;
            foreach (KeyValuePair<int, BillClass> BillClassItem in this._project.BillClasses)
            {
                BillClassItem.Value.BillClassChanged += new EventHandler(this._project.ToggleSubItemChanged);
            }

            foreach (KeyValuePair<int, Project.Bill.Bill> BillItem in this._project.Bills)
            {
                BillItem.Value.BillClasses = this._billClasses;
            }

            this._project.ToggleSubItemChanged(sender, e);
            this.BillClassesSaveRequest?.Invoke(this, new EventArgs());
        }

        private void btnBillClassAdd_Click(object sender, EventArgs e)
        {
            this._billClassLastInsertedId++;
            BillClass NewBillClass = new BillClass(this._billClassLastInsertedId, 0);   // Ignore RootId. Get RootId from TreeView, while saving classes

            TreeNode NewNode = new TreeNode(NewBillClass.TitleNoText)
            {
                Tag = NewBillClass
            };

            if (this.trvBillClasses.SelectedNode != null)
            {
                this.trvBillClasses.SelectedNode.Nodes.Add(NewNode);
                this.trvBillClasses.SelectedNode.Expand();
            }
            else
            {
                this.trvBillClasses.Nodes.Add(NewNode);
            }
            this.trvBillClasses.SelectedNode = NewNode;
            this.trvBillClasses_AfterSelect(sender, new TreeViewEventArgs(null));
            if (Properties.Settings.Default.TreeView_BillClasses_ExpandAllDefault || !Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) this.trvBillClasses.ExpandAll();
        }

        private void btnBillClassRemove_Click(object sender, EventArgs e)
        {
            if (this.trvBillClasses.SelectedNode != null) this.trvBillClasses.SelectedNode.Remove();
            this.trvBillClasses_AfterSelect(sender, new TreeViewEventArgs(null));
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

        private void trvBillClasses_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (!Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) e.Cancel = true;
        }

        private void trvBillClasses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.grbProperties.Enabled = this.trvBillClasses.SelectedNode != null;
            this.btnBillClassRemove.Enabled = this.trvBillClasses.SelectedNode != null;

            if (this.trvBillClasses.SelectedNode != null)
            {
                this.txtComment.Text = ((BillClass)this.trvBillClasses.SelectedNode.Tag).Comment;
                this.txtTitle.Text = ((BillClass)this.trvBillClasses.SelectedNode.Tag).Title;
            }
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (this.trvBillClasses.SelectedNode == null) return;

            ((BillClass)this.trvBillClasses.SelectedNode.Tag).Comment = this.txtComment.Text;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (this.trvBillClasses.SelectedNode == null) return;

            ((BillClass)this.trvBillClasses.SelectedNode.Tag).Title = this.txtTitle.Text;
            this.trvBillClasses.SelectedNode.Text = ((BillClass)this.trvBillClasses.SelectedNode.Tag).TitleNoText;
        }

        #region trvCategories Drag&Drop nodes
        private void trvCategories_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left) DoDragDrop(e.Item, DragDropEffects.Move);
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void trvCategories_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void trvCategories_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = trvBillClasses.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            trvBillClasses.SelectedNode = trvBillClasses.GetNodeAt(targetPoint);
        }

        private void trvCategories_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = trvBillClasses.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = trvBillClasses.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    if (targetNode != null)
                    {
                        targetNode.Nodes.Add(draggedNode);
                    }
                    else
                    {
                        trvBillClasses.Nodes.Add(draggedNode);
                    }
                }
            }
            if (Properties.Settings.Default.TreeView_BillClasses_ExpandAllDefault || !Properties.Settings.Default.TreeView_BillClasses_AllowCollaps) this.trvBillClasses.ExpandAll();
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2 == null || node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
        #endregion
        #endregion
        #endregion
    }
}