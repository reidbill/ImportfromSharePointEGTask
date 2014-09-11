using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImportSPListToEG
{
    public partial class ListPicker : Form
    {
        public SPList SelectedList;
        public List<SPColumn> originalColumns = null;
        public string SiteUrl;
        private List<SPList> _allLists;
        public ImportFromSharePointListTaskSettings settings { get; set; }
        private bool _holdPopulate = true;
        private bool _bNeedRefresh = false;
        public ListPicker()
        {
            InitializeComponent();
        }
        private object SyncLock = new object();
        private System.Threading.Thread _listThread;

        #region List event handlers
        private void lstLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateColumns(_bNeedRefresh);
        }
        #endregion

        #region form event Handlers
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lock (SyncLock)
            {
                if (_listThread != null)
                    _listThread.Abort();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (string.IsNullOrEmpty(SiteUrl))
                return;

            if (settings != null)
            {
                chkAppLists.Checked = settings.ShowApplicationLists;
                chkHidden.Checked = settings.ShowHiddenLists;
                chkGallery.Checked = settings.ShowGalleryLists;
            }
            tsLabel.Text = string.Format(tsLabel.Text, SiteUrl);
            UpdateControlsState(false);
            if (SelectedList != null)
            {
                IList<SPColumn> codeCols = SelectedList.GetColumnsForCode();
                if (codeCols != null && codeCols.Count > 0)
                {
                    originalColumns = new List<SPColumn>(codeCols.Count);
                    foreach (SPColumn col in codeCols)
                    {
                        originalColumns.Add(SPColumn.Clone(col));
                    }
                }
            }
            System.Threading.ThreadStart starter = new System.Threading.ThreadStart(RetrieveLists);
            _listThread = new System.Threading.Thread(starter);
            _listThread.SetApartmentState(System.Threading.ApartmentState.STA);
            _listThread.IsBackground = true;
            _listThread.Start();
            this.Cursor = Cursors.WaitCursor;
        }
        private void ListPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SelectedList = lstLists.SelectedItem as SPList;
                if (lvColumns.Items.Count > 0)
                {                   
                    foreach (ListViewItem lvi in lvColumns.Items)
                    {
                        SPColumn col = lvi.Tag as SPColumn;
                        if (col != null)
                        {
                            if (lvi.Selected)
                            {
                                if (!col.includeInCode)
                                    SelectedList.AddColumnToCode(col);
                            }
                            else //don't include in code
                            {
                                if (col.includeInCode)
                                    SelectedList.RemoveColumnFromCode(col);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ImportFromSharePointListTaskForm.DisplayError("Unexpected Error closing List Form", ex);
            }
        }
        private void ListPicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (lstLists.SelectedItem == null || lvColumns.SelectedIndices.Count == 0)
                {
                    DialogResult dr = MessageBox.Show("A list or Columns to include are not selected.","Are you sure you want to exit?", MessageBoxButtons.YesNo);
                    e.Cancel = (dr == System.Windows.Forms.DialogResult.No);
                }
            }
        }
        #endregion

        #region CheckBox Handlers
        private void chkAppLists_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowApplicationLists = chkAppLists.Checked;
            PopulateLists();
        }

        private void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowHiddenLists = chkHidden.Checked;
            PopulateLists();
        }

        private void chkGallery_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowGalleryLists = chkGallery.Checked;
            PopulateLists();
        }
        private void chkHiddenCols_CheckedChanged(object sender, EventArgs e)
        {
            settings.ShowHiddenColumns = chkHiddenCols.Checked;            
            PopulateColumns(false);
        }

        #endregion

        #region private helpers
        private void ErrorHandler(Exception ex)
        {
            ImportFromSharePointListTaskForm.DisplayError("Error retrieving SharePoint Lists", ex);
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void PopulateColumns(bool refresh)
        {
            Cursor backup = Cursor.Current;
            lvColumns.Items.Clear();
            SPList selList = lstLists.SelectedItem as SPList;
            if (selList != null)
            {
                try
                {
                    lvColumns.Columns.Clear();
                    if (settings.ShowHiddenColumns)
                    {
                        this.lvColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                            this.columnHeader1,
                            this.columnHeader3,
                            this.colHeaderHidden,
                            this.columnHeader2});
                    }
                    else
                    {
                        this.lvColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                            this.columnHeader1,
                            this.columnHeader3,
                            this.columnHeader2});
                    }
                    tsLabel.Text = string.Format("Retrieving Field Information for {0}", selList.Title);
                    Application.DoEvents();
                    Cursor.Current = Cursors.WaitCursor;
                    List<SPColumn> fields = selList.GetColumns(refresh);
                    if (refresh && originalColumns != null && originalColumns.Count > 0)
                    {
                        foreach (SPColumn col in fields)
                        {
                            if (originalColumns.Contains(col))
                            {
                                int ndx = originalColumns.IndexOf(col);
                                SPColumn orig = originalColumns[ndx];
                                col.includeInCode = orig.includeInCode;
                                col.SASOrder = orig.SASOrder;
                                originalColumns.RemoveAt(ndx);
                            }
                            if (originalColumns.Count == 0)
                            {
                                originalColumns = null;
                                break;
                            }
                        }
                    }
                    foreach (SPColumn col in fields)
                    {
                        if (chkHiddenCols.Checked || !col.Hidden)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = col.Title;
                            string[] subranges = null;
                            if (settings.ShowHiddenColumns)
                                subranges = new string[] { col.SPFieldType, col.Hidden.ToString(), col.Description };
                            else
                                subranges = new string[] { col.SPFieldType, col.Description };
                            
                            lvi.SubItems.AddRange(subranges);
                            lvi.Tag = col;                          
                            lvi.Selected = col.includeInCode;
                            lvColumns.Items.Add(lvi);
                        }
                    }
                }
                catch (Exception ex) 
                { 
                    ImportFromSharePointListTaskForm.DisplayError("Error getting list information", ex); 
                }
                finally
                {
                    Cursor.Current = backup;
                    tsLabel.Text = "Ready";
                    _bNeedRefresh = false;
                }
            }
        }        
        private void PopulateLists()
        {
            if (_holdPopulate)
                return;

            //populate the list
            lstLists.Items.Clear();
            foreach (SPList curList in _allLists)
            {
                bool add = true;
                if (!chkAppLists.Checked && curList.IsAppList) 
                    add = false;
                if (!chkGallery.Checked && curList.IsGallery) 
                    add = false;
                if (!chkHidden.Checked && curList.Hidden) 
                    add = false;

                if (add)
                {
                    SPList listToAdd = curList;
                    if (SelectedList != null && SelectedList.ID == curList.ID)
                    {
                        _bNeedRefresh = true;
                        listToAdd = SelectedList;
                    }
                    lstLists.Items.Add(listToAdd);
                }
            }
            lblSite.Text = string.Format((string)lblSite.Tag, lstLists.Items.Count);
            if (SelectedList != null)
            {
                lstLists.SelectedItem = SelectedList;
            }
        }
        private void RetrieveLists()
        {
            try
            {
                _allLists = spWrap.GetLists(SiteUrl);
                this.Invoke(new RetrieveListFinished(RetrieveListComplete));
            }
            catch (System.Threading.ThreadAbortException tex)
            {
                System.Diagnostics.Debug.Assert(false, tex.Message);
            }
            catch (Exception ex)
            {
                this.Invoke(new RetrieveListErrorHandler(ErrorHandler), ex);
            }            
        }
        private void RetrieveListComplete()
        {
            _holdPopulate = false;
            PopulateLists();
            tsLabel.Text = "Ready";
            UpdateControlsState(true);
            this.Cursor = Cursors.Default;
            lock (SyncLock)
            {
                _listThread.Join(500);
                _listThread = null;
            }
        }
        private delegate void RetrieveListHandler();
        private delegate void RetrieveListErrorHandler(Exception ex);
        private delegate void RetrieveListFinished();
        private void UpdateControlsState(bool enable)
        {
            btnOK.Enabled = enable;
            chkAppLists.Enabled = enable;
            chkGallery.Enabled = enable;
            chkHidden.Enabled = enable;
            lstLists.Enabled = enable;
            lvColumns.Enabled = enable;
            chkHiddenCols.Enabled = enable;
        }
        #endregion
    }
}
