namespace ImportSPListToEG
{
    partial class ImportFromSharePointListTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFromSharePointListTaskForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txturl = new System.Windows.Forms.TextBox();
            this.btnLists = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnSelectData = new System.Windows.Forms.Button();
            this.lblLib = new System.Windows.Forms.Label();
            this.lblDS = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnProps = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.lvColumns = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkRemoveHTML = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(559, 557);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(641, 557);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(13, 22);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(102, 17);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "&SharePoint url:";
            // 
            // txturl
            // 
            this.txturl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txturl.Location = new System.Drawing.Point(16, 44);
            this.txturl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(526, 22);
            this.txturl.TabIndex = 1;
            this.txturl.TextChanged += new System.EventHandler(this.txturl_TextChanged);
            this.txturl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txturl_KeyUp);
            // 
            // btnLists
            // 
            this.btnLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLists.Location = new System.Drawing.Point(551, 43);
            this.btnLists.Margin = new System.Windows.Forms.Padding(4);
            this.btnLists.Name = "btnLists";
            this.btnLists.Size = new System.Drawing.Size(152, 28);
            this.btnLists.TabIndex = 2;
            this.btnLists.Text = "Select &List";
            this.btnLists.UseVisualStyleBackColor = true;
            this.btnLists.Click += new System.EventHandler(this.btnLists_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Location = new System.Drawing.Point(16, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(694, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected List";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Item Count:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "List ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Title:";
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.AutoEllipsis = true;
            this.lblID.Location = new System.Drawing.Point(325, 53);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(362, 28);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCount
            // 
            this.lblCount.AutoEllipsis = true;
            this.lblCount.Location = new System.Drawing.Point(109, 53);
            this.lblCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(108, 28);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesc.AutoEllipsis = true;
            this.lblDesc.Location = new System.Drawing.Point(325, 22);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(355, 28);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "desc";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(109, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblServer);
            this.groupBox2.Controls.Add(this.btnSelectData);
            this.groupBox2.Controls.Add(this.lblLib);
            this.groupBox2.Controls.Add(this.lblDS);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 425);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(694, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SAS Dataset:";
            // 
            // lblServer
            // 
            this.lblServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServer.AutoEllipsis = true;
            this.lblServer.Location = new System.Drawing.Point(109, 20);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(417, 26);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "Server";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectData
            // 
            this.btnSelectData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectData.Location = new System.Drawing.Point(534, 18);
            this.btnSelectData.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectData.Name = "btnSelectData";
            this.btnSelectData.Size = new System.Drawing.Size(152, 28);
            this.btnSelectData.TabIndex = 6;
            this.btnSelectData.Text = "Save &As";
            this.btnSelectData.UseVisualStyleBackColor = true;
            this.btnSelectData.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // lblLib
            // 
            this.lblLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLib.AutoEllipsis = true;
            this.lblLib.Location = new System.Drawing.Point(109, 54);
            this.lblLib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLib.Name = "lblLib";
            this.lblLib.Size = new System.Drawing.Size(417, 26);
            this.lblLib.TabIndex = 3;
            this.lblLib.Text = "Lib";
            this.lblLib.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDS
            // 
            this.lblDS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDS.AutoEllipsis = true;
            this.lblDS.Location = new System.Drawing.Point(109, 89);
            this.lblDS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDS.Name = "lblDS";
            this.lblDS.Size = new System.Drawing.Size(417, 26);
            this.lblDS.TabIndex = 5;
            this.lblDS.Text = "DS";
            this.lblDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dataset:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Library:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnProps);
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnDown);
            this.groupBox3.Controls.Add(this.btnMoveUp);
            this.groupBox3.Controls.Add(this.lvColumns);
            this.groupBox3.Location = new System.Drawing.Point(17, 176);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(693, 242);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected &Columns";
            // 
            // btnProps
            // 
            this.btnProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProps.Location = new System.Drawing.Point(534, 198);
            this.btnProps.Margin = new System.Windows.Forms.Padding(4);
            this.btnProps.Name = "btnProps";
            this.btnProps.Size = new System.Drawing.Size(152, 28);
            this.btnProps.TabIndex = 5;
            this.btnProps.Text = "&Properties";
            this.btnProps.UseVisualStyleBackColor = true;
            this.btnProps.Click += new System.EventHandler(this.btnProps_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(534, 162);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(152, 28);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "D&elete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(534, 127);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(152, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "&New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(534, 91);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(152, 28);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Move &Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Location = new System.Drawing.Point(534, 55);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(152, 28);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "Move &Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // lvColumns
            // 
            this.lvColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvColumns.FullRowSelect = true;
            this.lvColumns.HideSelection = false;
            this.lvColumns.Location = new System.Drawing.Point(1, 17);
            this.lvColumns.Margin = new System.Windows.Forms.Padding(4);
            this.lvColumns.MultiSelect = false;
            this.lvColumns.Name = "lvColumns";
            this.lvColumns.Size = new System.Drawing.Size(519, 217);
            this.lvColumns.TabIndex = 0;
            this.lvColumns.UseCompatibleStateImageBehavior = false;
            this.lvColumns.View = System.Windows.Forms.View.Details;
            this.lvColumns.SelectedIndexChanged += new System.EventHandler(this.lvColumns_SelectedIndexChanged);
            this.lvColumns.DoubleClick += new System.EventHandler(this.lvColumns_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SharePoint Column";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SAS Column Name";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SAS Column Type";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SAS Format";
            this.columnHeader4.Width = 70;
            // 
            // chkRemoveHTML
            // 
            this.chkRemoveHTML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRemoveHTML.AutoSize = true;
            this.chkRemoveHTML.Checked = true;
            this.chkRemoveHTML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveHTML.Location = new System.Drawing.Point(18, 557);
            this.chkRemoveHTML.Name = "chkRemoveHTML";
            this.chkRemoveHTML.Size = new System.Drawing.Size(187, 21);
            this.chkRemoveHTML.TabIndex = 8;
            this.chkRemoveHTML.Text = "Remove HTML text fields";
            this.chkRemoveHTML.UseVisualStyleBackColor = true;
            // 
            // ImportFromSharePointListTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(727, 594);
            this.Controls.Add(this.chkRemoveHTML);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLists);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(745, 641);
            this.Name = "ImportFromSharePointListTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Data From SharePoint List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Button btnLists;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblLib;
        private System.Windows.Forms.Label lblDS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvColumns;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnProps;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.CheckBox chkRemoveHTML;
    }
}