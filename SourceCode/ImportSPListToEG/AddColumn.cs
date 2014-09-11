using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImportSPListToEG
{
    public partial class AddColumn : Form
    {
        SPList _list;
        ImportFromSharePointListTaskSettings _settings;
        public AddColumn(SPList list, ImportFromSharePointListTaskSettings settings)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (settings == null)
                throw new ArgumentNullException("settings");

            InitializeComponent();
            _list = list;
            _settings = settings;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            chkShowHidden.Checked = _settings.ShowHiddenColumns;
            LoadColumns();
        }

        private void AddColumn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult.OK == this.DialogResult)
            {
                if (lstColumns.SelectedItem != null)
                {
                    _list.AddColumnToCode(lstColumns.SelectedItem as SPColumn);
                }
            }
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = lstColumns.SelectedItem != null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void chkShowHidden_CheckedChanged(object sender, EventArgs e)
        {
            _settings.ShowHiddenColumns = chkShowHidden.Checked;
            LoadColumns();
        }

        private void LoadColumns()
        {
            SPColumn selCol = lstColumns.SelectedItem as SPColumn;
            lstColumns.Items.Clear();
            if (_list != null)
            {
                SortedList<string, SPColumn> sortedCols = new SortedList<string, SPColumn>();
                foreach (SPColumn curCol in _list.GetColumns(true))
                {
                    if (!curCol.includeInCode)
                    {
                        if (!curCol.Hidden || _settings.ShowHiddenColumns)
                            sortedCols.Add(curCol.ToString(), curCol);
                    }
                }
                lstColumns.Items.AddRange(sortedCols.Values.ToArray());
                if (selCol != null && lstColumns.Items.Contains(selCol))
                    lstColumns.SelectedItem = selCol;                                
            }
            btnOK.Enabled = lstColumns.SelectedItem != null;
        }
    }
}
