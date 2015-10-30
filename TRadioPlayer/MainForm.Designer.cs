namespace TRadioPlayer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.CategoryList = new System.Windows.Forms.ComboBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.PlayerProcess = new System.Diagnostics.Process();
            this.StationsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StationListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.favUnFavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.VolumePanel = new System.Windows.Forms.Panel();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.LogBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.AddStationBtn = new System.Windows.Forms.Button();
            this.TopBottomPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RotateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.StationListMenu.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.VolumePanel.SuspendLayout();
            this.TopBottomPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryList
            // 
            this.CategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryList.FormattingEnabled = true;
            this.CategoryList.Location = new System.Drawing.Point(8, 4);
            this.CategoryList.Margin = new System.Windows.Forms.Padding(5);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(119, 21);
            this.CategoryList.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CategoryList, "Radio Categories");
            this.CategoryList.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TitleLabel.Location = new System.Drawing.Point(0, 3);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(453, 20);
            this.TitleLabel.TabIndex = 8;
            this.TitleLabel.Text = "TRadioPlayer";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeBar.AutoSize = false;
            this.VolumeBar.LargeChange = 1;
            this.VolumeBar.Location = new System.Drawing.Point(135, 3);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(129, 23);
            this.VolumeBar.TabIndex = 9;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.VolumeBar, "Volume Level");
            this.VolumeBar.Value = 50;
            this.VolumeBar.Scroll += new System.EventHandler(this.VolumeBar_Scroll);
            // 
            // PlayerProcess
            // 
            this.PlayerProcess.EnableRaisingEvents = true;
            this.PlayerProcess.StartInfo.CreateNoWindow = true;
            this.PlayerProcess.StartInfo.Domain = "";
            this.PlayerProcess.StartInfo.LoadUserProfile = false;
            this.PlayerProcess.StartInfo.Password = null;
            this.PlayerProcess.StartInfo.RedirectStandardError = true;
            this.PlayerProcess.StartInfo.RedirectStandardInput = true;
            this.PlayerProcess.StartInfo.RedirectStandardOutput = true;
            this.PlayerProcess.StartInfo.StandardErrorEncoding = null;
            this.PlayerProcess.StartInfo.StandardOutputEncoding = null;
            this.PlayerProcess.StartInfo.UserName = "";
            this.PlayerProcess.StartInfo.UseShellExecute = false;
            this.PlayerProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            this.PlayerProcess.SynchronizingObject = this;
            // 
            // StationsList
            // 
            this.StationsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StationsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.StationsList.ContextMenuStrip = this.StationListMenu;
            this.StationsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StationsList.FullRowSelect = true;
            this.StationsList.HideSelection = false;
            this.StationsList.Location = new System.Drawing.Point(0, 53);
            this.StationsList.Margin = new System.Windows.Forms.Padding(0);
            this.StationsList.Name = "StationsList";
            this.StationsList.Size = new System.Drawing.Size(453, 498);
            this.StationsList.TabIndex = 10;
            this.StationsList.UseCompatibleStateImageBehavior = false;
            this.StationsList.View = System.Windows.Forms.View.Details;
            this.StationsList.VirtualMode = true;
            this.StationsList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.StationsList_RetrieveVirtualItem);
            this.StationsList.SelectedIndexChanged += new System.EventHandler(this.StationsList_SelectedIndexChanged);
            this.StationsList.DoubleClick += new System.EventHandler(this.StationsList_DoubleClick_1);
            this.StationsList.MouseEnter += new System.EventHandler(this.StationsList_MouseEnter);
            this.StationsList.MouseLeave += new System.EventHandler(this.StationsList_MouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Faved";
            // 
            // StationListMenu
            // 
            this.StationListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favUnFavToolStripMenuItem});
            this.StationListMenu.Name = "StationListMenu";
            this.StationListMenu.Size = new System.Drawing.Size(131, 26);
            // 
            // favUnFavToolStripMenuItem
            // 
            this.favUnFavToolStripMenuItem.Name = "favUnFavToolStripMenuItem";
            this.favUnFavToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.favUnFavToolStripMenuItem.Text = "Fav/UnFav";
            this.favUnFavToolStripMenuItem.Click += new System.EventHandler(this.favUnFavToolStripMenuItem_Click);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.VolumeLabel.Location = new System.Drawing.Point(270, 0);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(33, 30);
            this.VolumeLabel.TabIndex = 12;
            this.VolumeLabel.Text = "100%";
            this.VolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.VolumeLabel, "Volume Level");
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.VolumePanel);
            this.TopPanel.Controls.Add(this.SearchBtn);
            this.TopPanel.Controls.Add(this.LogBtn);
            this.TopPanel.Controls.Add(this.StopBtn);
            this.TopPanel.Controls.Add(this.PauseBtn);
            this.TopPanel.Controls.Add(this.AddStationBtn);
            this.TopPanel.Controls.Add(this.TopBottomPanel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(453, 53);
            this.TopPanel.TabIndex = 14;
            // 
            // VolumePanel
            // 
            this.VolumePanel.Controls.Add(this.CategoryList);
            this.VolumePanel.Controls.Add(this.VolumeBar);
            this.VolumePanel.Controls.Add(this.VolumeLabel);
            this.VolumePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VolumePanel.Location = new System.Drawing.Point(60, 0);
            this.VolumePanel.Name = "VolumePanel";
            this.VolumePanel.Size = new System.Drawing.Size(303, 30);
            this.VolumePanel.TabIndex = 13;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchBtn.Image = global::TRadioPlayer.Properties.Resources.search;
            this.SearchBtn.Location = new System.Drawing.Point(363, 0);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(30, 30);
            this.SearchBtn.TabIndex = 4;
            this.toolTip1.SetToolTip(this.SearchBtn, "Search in Stations");
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // LogBtn
            // 
            this.LogBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.LogBtn.Image = global::TRadioPlayer.Properties.Resources.align_justify;
            this.LogBtn.Location = new System.Drawing.Point(393, 0);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(30, 30);
            this.LogBtn.TabIndex = 11;
            this.toolTip1.SetToolTip(this.LogBtn, "See mpv output");
            this.LogBtn.UseVisualStyleBackColor = true;
            this.LogBtn.Click += new System.EventHandler(this.AddNewStationBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.StopBtn.Image = global::TRadioPlayer.Properties.Resources.stop;
            this.StopBtn.Location = new System.Drawing.Point(30, 0);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(30, 30);
            this.StopBtn.TabIndex = 7;
            this.toolTip1.SetToolTip(this.StopBtn, "Stop");
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.PauseBtn.Image = global::TRadioPlayer.Properties.Resources.pause;
            this.PauseBtn.Location = new System.Drawing.Point(0, 0);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(30, 30);
            this.PauseBtn.TabIndex = 6;
            this.toolTip1.SetToolTip(this.PauseBtn, "Pause/Play");
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // AddStationBtn
            // 
            this.AddStationBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddStationBtn.Image = global::TRadioPlayer.Properties.Resources.plus;
            this.AddStationBtn.Location = new System.Drawing.Point(423, 0);
            this.AddStationBtn.Name = "AddStationBtn";
            this.AddStationBtn.Size = new System.Drawing.Size(30, 30);
            this.AddStationBtn.TabIndex = 16;
            this.toolTip1.SetToolTip(this.AddStationBtn, "Add a new station");
            this.AddStationBtn.UseVisualStyleBackColor = true;
            // 
            // TopBottomPanel
            // 
            this.TopBottomPanel.Controls.Add(this.TitleLabel);
            this.TopBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TopBottomPanel.Location = new System.Drawing.Point(0, 30);
            this.TopBottomPanel.Name = "TopBottomPanel";
            this.TopBottomPanel.Size = new System.Drawing.Size(453, 23);
            this.TopBottomPanel.TabIndex = 15;
            // 
            // RotateTimer
            // 
            this.RotateTimer.Interval = 200;
            this.RotateTimer.Tick += new System.EventHandler(this.RotateTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(453, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(48, 17);
            this.StatusLabel.Text = "Ready...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 573);
            this.Controls.Add(this.StationsList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TopPanel);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRadioPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.StationListMenu.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.VolumePanel.ResumeLayout(false);
            this.TopBottomPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CategoryList;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Diagnostics.Process PlayerProcess;
        private System.Windows.Forms.ListView StationsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip StationListMenu;
        private System.Windows.Forms.ToolStripMenuItem favUnFavToolStripMenuItem;
        private System.Windows.Forms.Timer RotateTimer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Panel VolumePanel;
        private System.Windows.Forms.Panel TopBottomPanel;
        private System.Windows.Forms.Button AddStationBtn;
    }
}

