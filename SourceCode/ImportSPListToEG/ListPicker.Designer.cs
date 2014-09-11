namespace ImportSPListToEG
{
    partial class ListPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPicker));
            this.lblSite = new System.Windows.Forms.Label();
            this.lstLists = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lvColumns = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.chkGallery = new System.Windows.Forms.CheckBox();
            this.chkAppLists = new System.Windows.Forms.CheckBox();
            this.chkHiddenCols = new System.Windows.Forms.CheckBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.status.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(4, 4);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(28, 13);
            this.lblSite.TabIndex = 0;
            this.lblSite.Tag = "{0} &Available Lists:";
            this.lblSite.Text = "Lists";
            // 
            // lstLists
            // 
            this.lstLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLists.FormattingEnabled = true;
            this.lstLists.Location = new System.Drawing.Point(4, 20);
            this.lstLists.Name = "lstLists";
            this.lstLists.Size = new System.Drawing.Size(181, 199);
            this.lstLists.TabIndex = 1;
            this.lstLists.SelectedIndexChanged += new System.EventHandler(this.lstLists_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 263);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(187, 263);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lvColumns
            // 
            this.lvColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.colHeaderHidden,
            this.columnHeader2});
            this.lvColumns.FullRowSelect = true;
            this.lvColumns.HideSelection = false;
            this.lvColumns.Location = new System.Drawing.Point(3, 18);
            this.lvColumns.Name = "lvColumns";
            this.lvColumns.Size = new System.Drawing.Size(304, 240);
            this.lvColumns.TabIndex = 1;
            this.lvColumns.UseCompatibleStateImageBehavior = false;
            this.lvColumns.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            // 
            // colHeaderHidden
            // 
            this.colHeaderHidden.Text = "Hidden";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Select Columns To Include:";
            // 
            // chkHidden
            // 
            this.chkHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHidden.AutoSize = true;
            this.chkHidden.Location = new System.Drawing.Point(4, 247);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(114, 17);
            this.chkHidden.TabIndex = 3;
            this.chkHidden.Text = "Show &Hidden Lists";
            this.chkHidden.UseVisualStyleBackColor = true;
            this.chkHidden.CheckedChanged += new System.EventHandler(this.chkHidden_CheckedChanged);
            // 
            // chkGallery
            // 
            this.chkGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGallery.AutoSize = true;
            this.chkGallery.Location = new System.Drawing.Point(4, 270);
            this.chkGallery.Name = "chkGallery";
            this.chkGallery.Size = new System.Drawing.Size(112, 17);
            this.chkGallery.TabIndex = 4;
            this.chkGallery.Text = "Show &Gallery Lists";
            this.chkGallery.UseVisualStyleBackColor = true;
            this.chkGallery.CheckedChanged += new System.EventHandler(this.chkGallery_CheckedChanged);
            // 
            // chkAppLists
            // 
            this.chkAppLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAppLists.AutoSize = true;
            this.chkAppLists.Location = new System.Drawing.Point(4, 224);
            this.chkAppLists.Name = "chkAppLists";
            this.chkAppLists.Size = new System.Drawing.Size(132, 17);
            this.chkAppLists.TabIndex = 2;
            this.chkAppLists.Text = "Show A&pplication Lists";
            this.chkAppLists.UseVisualStyleBackColor = true;
            this.chkAppLists.CheckedChanged += new System.EventHandler(this.chkAppLists_CheckedChanged);
            // 
            // chkHiddenCols
            // 
            this.chkHiddenCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHiddenCols.AutoSize = true;
            this.chkHiddenCols.Location = new System.Drawing.Point(3, 270);
            this.chkHiddenCols.Name = "chkHiddenCols";
            this.chkHiddenCols.Size = new System.Drawing.Size(133, 17);
            this.chkHiddenCols.TabIndex = 2;
            this.chkHiddenCols.Text = "Show Hidden &Columns";
            this.chkHiddenCols.UseVisualStyleBackColor = true;
            this.chkHiddenCols.CheckedChanged += new System.EventHandler(this.chkHiddenCols_CheckedChanged);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel});
            this.status.Location = new System.Drawing.Point(0, 291);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(503, 22);
            this.status.TabIndex = 10;
            this.status.Text = "Ready...";
            // 
            // tsLabel
            // 
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(201, 17);
            this.tsLabel.Text = "Loading all Lists for {0}. Please Wait...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblSite);
            this.splitContainer1.Panel1.Controls.Add(this.lstLists);
            this.splitContainer1.Panel1.Controls.Add(this.chkGallery);
            this.splitContainer1.Panel1.Controls.Add(this.chkHidden);
            this.splitContainer1.Panel1.Controls.Add(this.chkAppLists);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lvColumns);
            this.splitContainer1.Panel2.Controls.Add(this.chkHiddenCols);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(503, 291);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 1;
            // 
            // ListPicker
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 313);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(519, 351);
            this.Name = "ListPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListPicker_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListPicker_FormClosed);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ListBox lstLists;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvColumns;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.CheckBox chkGallery;
        private System.Windows.Forms.CheckBox chkAppLists;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader colHeaderHidden;
        private System.Windows.Forms.CheckBox chkHiddenCols;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}