using SAS.Shared.AddIns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ImportSPListToEG
{
    /// <summary>
    /// This windows form inherits from the TaskForm class, which
    /// includes a bit of special handling for SAS Enterprise Guide.
    /// </summary>
    public partial class ImportFromSharePointListTaskForm : SAS.Tasks.Toolkit.Controls.TaskForm
    {
        public ImportFromSharePointListTaskSettings Settings { get; set; }
        private SPList _selList;
        private SAS.SharedUI.FormatsDialog FormatDialog = new SAS.SharedUI.FormatsDialog();

        public ImportFromSharePointListTaskForm(ISASTaskConsumer3 consumer)
        {
            InitializeComponent();
            
            this.Consumer = consumer;                        
        }

        #region overrides
        // save any values from the dialog into the settings class
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && _selList != null)
            {
                Settings.SharePointList = _selList;
                Settings.removeHtmlFromText = chkRemoveHTML.Checked;
            }

            base.OnClosing(e);
        }
        // initialize the form with the values from the settings
        protected override void OnLoad(EventArgs e)
        {
            btnLists.Enabled = false;
            _selList = Settings.SharePointList;
            if (_selList != null)
                txturl.Text = _selList.siteUrl;
            UpdateListInfo();
            UpdateColInfo();
            UpdateColButtons();

            lblServer.Text = Consumer.AssignedServer;
            lblLib.Text = Settings.outputLibrary;
            lblDS.Text = Settings.outputDataName;
            chkRemoveHTML.Checked = Settings.removeHtmlFromText;

            base.OnLoad(e);
            
        }
        #endregion

        #region event handlers
        private void lvColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColButtons();
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            SPColumn col = lvColumns.SelectedItems[0].Tag as SPColumn;
            _selList.MoveColumn(col, true);
            UpdateColInfo();
            lvColumns.Items[col.SASOrder].Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            SPColumn col = lvColumns.SelectedItems[0].Tag as SPColumn;
            _selList.MoveColumn(col, false);
            UpdateColInfo();
            lvColumns.Items[col.SASOrder].Selected = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddColumn dlg = new AddColumn(_selList, Settings);
            if (DialogResult.OK == dlg.ShowDialog(this))
            {
                UpdateColInfo();
                UpdateColButtons();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvColumns.SelectedItems.Count > 0)
            {
                SPColumn col = lvColumns.SelectedItems[0].Tag as SPColumn;
                if (col != null)
                {
                    _selList.RemoveColumnFromCode(col);
                    UpdateColInfo();
                    UpdateColButtons();
                }                
            }
        }
        private void lvColumns_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedColumnProperties();
        }

        private void btnProps_Click(object sender, EventArgs e)
        {
            EditSelectedColumnProperties();
        }
        private void btnLists_Click(object sender, EventArgs e)
        {
            ListPicker lp = new ListPicker();
            lp.SiteUrl = txturl.Text;

            SPList origList = _selList;
            SPList clone = (origList == null ? null : SPList.Clone(origList));
            lp.SelectedList = clone;
            lp.settings = this.Settings;
            if (DialogResult.OK == lp.ShowDialog(this))
            {
                _selList = lp.SelectedList;                
                UpdateListInfo();
                UpdateColInfo();
                UpdateColButtons();
            }
        }
        private void btnSelectData_Click(object sender, EventArgs e)
        {
            //show select data dialog
            string Cookie = string.Empty;
            ISASTaskDataName opd = this.Consumer.ShowOutputDataSelector(this, ServerAccessMode.AnyServer, lblServer.Text, lblLib.Text, lblDS.Text, ref Cookie);
            if (opd != null)
            {
                if (lblServer.Text != opd.Server)
                {
                    lblServer.Text = opd.Server;
                    FormatDialog = null;
                    this.Consumer.AssignedServer = opd.Server;  
                }
                lblLib.Text = opd.Library;
                lblDS.Text = opd.Member;
                Settings.outputDataName = opd.Member;
                Settings.outputLibrary = opd.Library;
            }
        }
        private void txturl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLists_Click(sender, EventArgs.Empty);
                e.Handled = true;
            }
        }
        private void txturl_TextChanged(object sender, EventArgs e)
        {
            btnLists.Enabled = !(string.IsNullOrEmpty(txturl.Text));
        }
        #endregion

        #region helpers
        public static void DisplayError(string msg, Exception ex)
        {
            MessageBox.Show(string.Format("{0}: {1}", msg, ex.Message));
        }
        private void EditSelectedColumnProperties()
        {
            if (lvColumns.SelectedItems.Count > 0)
            {
                //Show ColProps Dialog
                SPColumn col = lvColumns.SelectedItems[0].Tag as SPColumn;
                if (col != null)
                {
                    SPColumnProperties props = new SPColumnProperties(col, Consumer);
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        if (FormatDialog == null || FormatDialog.SASWorkspace == null)
                        {
                            if (FormatDialog == null)
                                FormatDialog = new SAS.SharedUI.FormatsDialog();
                            FormatDialog.SASWorkspace = (SAS.IWorkspace)Consumer.Workspace(Consumer.AssignedServer);
                        }
                        props.FormatDialog = FormatDialog;
                    }
                    finally
                    { Cursor = Cursors.Default; }
                    if (DialogResult.OK == props.ShowDialog(this))
                    {
                        col.SASName = props.SASName;
                        col.SASType = props.SASType;
                        col.SASFormat = props.SASFormat;
                        col.SASInFormat = props.SASInFormat;
                        UpdateColInfo();
                        UpdateColButtons();
                    }
                }
            }
        }
        private void UpdateColButtons()
        {
            btnMoveUp.Enabled = (lvColumns.SelectedIndices.Count == 1 && lvColumns.SelectedIndices[0] > 0);
            btnDown.Enabled = (lvColumns.SelectedIndices.Count == 1 && lvColumns.SelectedIndices[0] < lvColumns.Items.Count - 1);
            btnDel.Enabled = lvColumns.SelectedIndices.Count == 1;
            btnAdd.Enabled = _selList != null;
            btnProps.Enabled = lvColumns.SelectedIndices.Count == 1;
        }
        private void UpdateColInfo()
        {
            lvColumns.Items.Clear();
            if (_selList != null)
            {
                IList<SPColumn> selColumns = _selList.GetColumnsForCode();
                foreach (SPColumn curCol in selColumns)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = curCol.Title;
                    lvi.SubItems.AddRange(new string[] { curCol.SASName, curCol.SASType,curCol.SASFormat });
                    lvi.Tag = curCol;
                    lvColumns.Items.Add(lvi);
                }
            }
        }
        private void UpdateListInfo()
        {
            if (_selList != null)
            {
                lblTitle.Text = _selList.Title;
                lblCount.Text = _selList.Count.ToString();
                lblDesc.Text = _selList.Description;
                lblID.Text = _selList.ID.ToString();
            }
            else
            {
                lblTitle.Text = string.Empty;
                lblCount.Text = string.Empty;
                lblDesc.Text = string.Empty;
                lblID.Text = string.Empty;
            }
        }
        #endregion

    }
}
