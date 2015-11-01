namespace TRadioPlayer
{
    partial class SearchForm
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
            this.SearchEdit = new System.Windows.Forms.TextBox();
            this.ResultList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // SearchEdit
            // 
            this.SearchEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchEdit.Location = new System.Drawing.Point(12, 12);
            this.SearchEdit.Name = "SearchEdit";
            this.SearchEdit.Size = new System.Drawing.Size(311, 20);
            this.SearchEdit.TabIndex = 0;
            this.SearchEdit.TextChanged += new System.EventHandler(this.SearchEdit_TextChanged);
            // 
            // ResultList
            // 
            this.ResultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ResultList.FullRowSelect = true;
            this.ResultList.Location = new System.Drawing.Point(12, 38);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(311, 266);
            this.ResultList.TabIndex = 1;
            this.ResultList.UseCompatibleStateImageBehavior = false;
            this.ResultList.View = System.Windows.Forms.View.Details;
            this.ResultList.VirtualMode = true;
            this.ResultList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ResultList_RetrieveVirtualItem);
            this.ResultList.DoubleClick += new System.EventHandler(this.ResultList_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 286;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 316);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.SearchEdit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.SearchForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchForm_KeyDown);
            this.Resize += new System.EventHandler(this.SearchForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchEdit;
        private System.Windows.Forms.ListView ResultList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}