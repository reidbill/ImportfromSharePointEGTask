using System;
using System.Windows.Forms;
using SAS.Shared.AddIns;

namespace ImportSPListToEG
{
    public partial class SPColumnProperties : Form
    {
        public SAS.SharedUI.FormatsDialog FormatDialog;
        ISASTaskConsumer3 consumer;
        SPColumn _column = null;
        public string SASName { get { return txtSASName.Text; } }
        public string SASFormat { get { return txtSASFormat.Text; } }
        public string SASType
        {
            get
            {
                if (rdoChar.Checked)
                    return SPColumn.SASChar;

                return SPColumn.SASNum;
            }
        }
        public string SASInFormat { get { return txtSASInFormat.Text; } }

        public SPColumnProperties(SPColumn col,ISASTaskConsumer3 cons)
        {
            _column = col;
            consumer = cons;
            InitializeComponent();
        }

        private void rdoChar_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormatsMsg();
        }

        private void rdoNum_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormatsMsg();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_column != null)
            {
                lblSharePointColName.Text = _column.Title;
                txtSASName.Text = _column.SASName;
                rdoChar.Checked = _column.SASType == SPColumn.SASChar;
                rdoNum.Checked = _column.SASType == SPColumn.SASNum;
                txtSASFormat.Text = _column.SetSASFormat;
                txtSASInFormat.Text = _column.SetSASInFormat;
                UpdateFormatsMsg();
                if (FormatDialog == null)
                {
                    btnFormat.Visible = false;
                    btnInformat.Visible = false;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UpdateFormatsMsg()
        {
            if (rdoChar.Checked)
            {
                lblDefFormatMsg.Text = string.Format((string)lblDefFormatMsg.Tag, SPColumn.DEFAULTCHARFORMAT);
                lblInFormatMsg.Text = string.Format((string)lblInFormatMsg.Tag, SPColumn.DEFAULTCHARFORMAT);
            }
            else
            {
                lblDefFormatMsg.Text = string.Format((string)lblDefFormatMsg.Tag, SPColumn.DEFAULTNUMFORMAT);
                lblInFormatMsg.Text = string.Format((string)lblInFormatMsg.Tag, SPColumn.DEFAULTNUMFORMAT);
            }
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {   
            if (DialogResult.OK == FormatDialog.ShowDialog())
            {
                txtSASFormat.Text = FormatDialog.Format;
            }
        }

        private void btnInformat_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == FormatDialog.ShowDialog())
            {
                txtSASInFormat.Text = FormatDialog.Format;
            }
        }

        

    }
}
