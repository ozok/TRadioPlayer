namespace TRadioPlayer
{
    partial class EQForm
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
            this.EnableEQBtn = new System.Windows.Forms.CheckBox();
            this.PresetsList = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar7 = new System.Windows.Forms.TrackBar();
            this.trackBar8 = new System.Windows.Forms.TrackBar();
            this.trackBar9 = new System.Windows.Forms.TrackBar();
            this.trackBar10 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnableEQBtn
            // 
            this.EnableEQBtn.AutoSize = true;
            this.EnableEQBtn.Location = new System.Drawing.Point(12, 14);
            this.EnableEQBtn.Name = "EnableEQBtn";
            this.EnableEQBtn.Size = new System.Drawing.Size(104, 17);
            this.EnableEQBtn.TabIndex = 0;
            this.EnableEQBtn.Text = "Enable equalizer";
            this.EnableEQBtn.UseVisualStyleBackColor = true;
            this.EnableEQBtn.CheckedChanged += new System.EventHandler(this.EnableEQBtn_CheckedChanged);
            // 
            // PresetsList
            // 
            this.PresetsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PresetsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PresetsList.FormattingEnabled = true;
            this.PresetsList.Items.AddRange(new object[] {
            "Flat",
            "Ballad",
            "Classical",
            "Club",
            "Dance",
            "Full Bass",
            "Full Bass & Treble",
            "Full Treble",
            "Headphone",
            "Heavy Metal",
            "Jazz",
            "Large Hall",
            "Live",
            "Party",
            "Pop",
            "Rap",
            "Reggae",
            "Rock",
            "Ska",
            "Soft",
            "Soft Rock",
            "Techno",
            "Vocal"});
            this.PresetsList.Location = new System.Drawing.Point(241, 12);
            this.PresetsList.Name = "PresetsList";
            this.PresetsList.Size = new System.Drawing.Size(171, 21);
            this.PresetsList.TabIndex = 1;
            this.PresetsList.SelectedIndexChanged += new System.EventHandler(this.PresetsList_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar1.Location = new System.Drawing.Point(320, 0);
            this.trackBar1.Maximum = 1500;
            this.trackBar1.Minimum = -1500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(40, 141);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.AutoSize = false;
            this.trackBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar2.Location = new System.Drawing.Point(240, 0);
            this.trackBar2.Maximum = 1500;
            this.trackBar2.Minimum = -1500;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(40, 141);
            this.trackBar2.TabIndex = 3;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.AutoSize = false;
            this.trackBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar3.Location = new System.Drawing.Point(160, 0);
            this.trackBar3.Maximum = 1500;
            this.trackBar3.Minimum = -1500;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(40, 141);
            this.trackBar3.TabIndex = 4;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.AutoSize = false;
            this.trackBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar4.Location = new System.Drawing.Point(80, 0);
            this.trackBar4.Maximum = 1500;
            this.trackBar4.Minimum = -1500;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar4.Size = new System.Drawing.Size(40, 141);
            this.trackBar4.TabIndex = 5;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar5
            // 
            this.trackBar5.AutoSize = false;
            this.trackBar5.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar5.Location = new System.Drawing.Point(40, 0);
            this.trackBar5.Maximum = 1500;
            this.trackBar5.Minimum = -1500;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar5.Size = new System.Drawing.Size(40, 141);
            this.trackBar5.TabIndex = 6;
            this.trackBar5.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar5.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar6
            // 
            this.trackBar6.AutoSize = false;
            this.trackBar6.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar6.Location = new System.Drawing.Point(0, 0);
            this.trackBar6.Maximum = 1500;
            this.trackBar6.Minimum = -1500;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar6.Size = new System.Drawing.Size(40, 141);
            this.trackBar6.TabIndex = 7;
            this.trackBar6.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar6.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar7
            // 
            this.trackBar7.AutoSize = false;
            this.trackBar7.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar7.Location = new System.Drawing.Point(360, 0);
            this.trackBar7.Maximum = 1500;
            this.trackBar7.Minimum = -1500;
            this.trackBar7.Name = "trackBar7";
            this.trackBar7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar7.Size = new System.Drawing.Size(40, 141);
            this.trackBar7.TabIndex = 8;
            this.trackBar7.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar7.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar8
            // 
            this.trackBar8.AutoSize = false;
            this.trackBar8.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar8.Location = new System.Drawing.Point(120, 0);
            this.trackBar8.Maximum = 1500;
            this.trackBar8.Minimum = -1500;
            this.trackBar8.Name = "trackBar8";
            this.trackBar8.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar8.Size = new System.Drawing.Size(40, 141);
            this.trackBar8.TabIndex = 9;
            this.trackBar8.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar8.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar9
            // 
            this.trackBar9.AutoSize = false;
            this.trackBar9.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar9.Location = new System.Drawing.Point(200, 0);
            this.trackBar9.Maximum = 1500;
            this.trackBar9.Minimum = -1500;
            this.trackBar9.Name = "trackBar9";
            this.trackBar9.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar9.Size = new System.Drawing.Size(40, 141);
            this.trackBar9.TabIndex = 10;
            this.trackBar9.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar9.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // trackBar10
            // 
            this.trackBar10.AutoSize = false;
            this.trackBar10.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar10.Location = new System.Drawing.Point(280, 0);
            this.trackBar10.Maximum = 1500;
            this.trackBar10.Minimum = -1500;
            this.trackBar10.Name = "trackBar10";
            this.trackBar10.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar10.Size = new System.Drawing.Size(40, 141);
            this.trackBar10.TabIndex = 11;
            this.trackBar10.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar10.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "31.25  62.50      125       250        500       1K          2K         4K       " +
    "  8K        16K\r\n";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.trackBar7);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.trackBar10);
            this.panel1.Controls.Add(this.trackBar2);
            this.panel1.Controls.Add(this.trackBar9);
            this.panel1.Controls.Add(this.trackBar3);
            this.panel1.Controls.Add(this.trackBar8);
            this.panel1.Controls.Add(this.trackBar4);
            this.panel1.Controls.Add(this.trackBar5);
            this.panel1.Controls.Add(this.trackBar6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 154);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Presets:";
            // 
            // EQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PresetsList);
            this.Controls.Add(this.EnableEQBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EQForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equalizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EQForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EQForm_FormClosed);
            this.Load += new System.EventHandler(this.EQForm_Load);
            this.Shown += new System.EventHandler(this.EQForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar10)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnableEQBtn;
        private System.Windows.Forms.ComboBox PresetsList;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar7;
        private System.Windows.Forms.TrackBar trackBar8;
        private System.Windows.Forms.TrackBar trackBar9;
        private System.Windows.Forms.TrackBar trackBar10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}