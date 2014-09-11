namespace ImportSPListToEG
{
    partial class SPColumnProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPColumnProperties));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSharePointColName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoChar = new System.Windows.Forms.RadioButton();
            this.rdoNum = new System.Windows.Forms.RadioButton();
            this.txtSASName = new System.Windows.Forms.TextBox();
            this.txtSASFormat = new System.Windows.Forms.TextBox();
            this.txtSASInFormat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDefFormatMsg = new System.Windows.Forms.Label();
            this.lblInFormatMsg = new System.Windows.Forms.Label();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnInformat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(224, 203);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(306, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSharePointColName
            // 
            this.lblSharePointColName.AutoSize = true;
            this.lblSharePointColName.Location = new System.Drawing.Point(6, 32);
            this.lblSharePointColName.Name = "lblSharePointColName";
            this.lblSharePointColName.Size = new System.Drawing.Size(128, 13);
            this.lblSharePointColName.TabIndex = 1;
            this.lblSharePointColName.Text = "SharePoint Column Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the SAS settings to use for the SharePoint Field";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SAS Column Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SAS Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "SAS Format:";
            // 
            // rdoChar
            // 
            this.rdoChar.AutoSize = true;
            this.rdoChar.Checked = true;
            this.rdoChar.Location = new System.Drawing.Point(121, 82);
            this.rdoChar.Name = "rdoChar";
            this.rdoChar.Size = new System.Drawing.Size(71, 17);
            this.rdoChar.TabIndex = 5;
            this.rdoChar.TabStop = true;
            this.rdoChar.Text = "Character";
            this.rdoChar.UseVisualStyleBackColor = true;
            this.rdoChar.CheckedChanged += new System.EventHandler(this.rdoChar_CheckedChanged);
            // 
            // rdoNum
            // 
            this.rdoNum.AutoSize = true;
            this.rdoNum.Location = new System.Drawing.Point(199, 82);
            this.rdoNum.Name = "rdoNum";
            this.rdoNum.Size = new System.Drawing.Size(64, 17);
            this.rdoNum.TabIndex = 6;
            this.rdoNum.TabStop = true;
            this.rdoNum.Text = "Numeric";
            this.rdoNum.UseVisualStyleBackColor = true;
            this.rdoNum.CheckedChanged += new System.EventHandler(this.rdoNum_CheckedChanged);
            // 
            // txtSASName
            // 
            this.txtSASName.Location = new System.Drawing.Point(121, 57);
            this.txtSASName.MaxLength = 36;
            this.txtSASName.Name = "txtSASName";
            this.txtSASName.Size = new System.Drawing.Size(191, 20);
            this.txtSASName.TabIndex = 3;
            // 
            // txtSASFormat
            // 
            this.txtSASFormat.Location = new System.Drawing.Point(9, 123);
            this.txtSASFormat.Name = "txtSASFormat";
            this.txtSASFormat.Size = new System.Drawing.Size(183, 20);
            this.txtSASFormat.TabIndex = 8;
            // 
            // txtSASInFormat
            // 
            this.txtSASInFormat.Location = new System.Drawing.Point(9, 173);
            this.txtSASInFormat.Name = "txtSASInFormat";
            this.txtSASInFormat.Size = new System.Drawing.Size(183, 20);
            this.txtSASInFormat.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "SAS In Format:";
            // 
            // lblDefFormatMsg
            // 
            this.lblDefFormatMsg.AutoSize = true;
            this.lblDefFormatMsg.Location = new System.Drawing.Point(78, 107);
            this.lblDefFormatMsg.Name = "lblDefFormatMsg";
            this.lblDefFormatMsg.Size = new System.Drawing.Size(120, 13);
            this.lblDefFormatMsg.TabIndex = 9;
            this.lblDefFormatMsg.Tag = "If blank format set to {0}";
            this.lblDefFormatMsg.Text = "If blank format set to {0}";
            // 
            // lblInFormatMsg
            // 
            this.lblInFormatMsg.AutoSize = true;
            this.lblInFormatMsg.Location = new System.Drawing.Point(90, 157);
            this.lblInFormatMsg.Name = "lblInFormatMsg";
            this.lblInFormatMsg.Size = new System.Drawing.Size(131, 13);
            this.lblInFormatMsg.TabIndex = 12;
            this.lblInFormatMsg.Tag = "If blank in format set to {0}";
            this.lblInFormatMsg.Text = "If blank in format set to {0}";
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(223, 122);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(89, 23);
            this.btnFormat.TabIndex = 15;
            this.btnFormat.Text = "Select Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnInformat
            // 
            this.btnInformat.Location = new System.Drawing.Point(223, 170);
            this.btnInformat.Name = "btnInformat";
            this.btnInformat.Size = new System.Drawing.Size(89, 23);
            this.btnInformat.TabIndex = 16;
            this.btnInformat.Text = "Select Informat";
            this.btnInformat.UseVisualStyleBackColor = true;
            this.btnInformat.Click += new System.EventHandler(this.btnInformat_Click);
            // 
            // SPColumnProperties
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 231);
            this.Controls.Add(this.btnInformat);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.lblInFormatMsg);
            this.Controls.Add(this.lblDefFormatMsg);
            this.Controls.Add(this.txtSASInFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSASFormat);
            this.Controls.Add(this.txtSASName);
            this.Controls.Add(this.rdoNum);
            this.Controls.Add(this.rdoChar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSharePointColName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SPColumnProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharePoint Field Properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSharePointColName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoChar;
        private System.Windows.Forms.RadioButton rdoNum;
        private System.Windows.Forms.TextBox txtSASName;
        private System.Windows.Forms.TextBox txtSASFormat;
        private System.Windows.Forms.TextBox txtSASInFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDefFormatMsg;
        private System.Windows.Forms.Label lblInFormatMsg;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnInformat;
    }
}