using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRadioPlayer
{
    public partial class LogForm : Form
    {
        private int _virtualSize = 0;
        public static List<string> Logs = new List<string>();

        public int VirtualSize
        {
            get { return _virtualSize; }
            set
            {
                _virtualSize = value;
                LogList.VirtualListSize = _virtualSize;
            }
        }

        public LogForm()
        {
            InitializeComponent();
        }

        private void LogList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            LogList.VirtualListSize = Logs.Count;
        }

        private void LogList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < Logs.Count)
            {
                ListViewItem listViewItem = new ListViewItem { Text = Logs[e.ItemIndex] };

                e.Item = listViewItem;
            }
        }

        private void LogForm_Resize(object sender, EventArgs e)
        {
            LogList.Columns[0].Width = LogList.ClientSize.Width - 20;
        }

        private void LogForm_Shown(object sender, EventArgs e)
        {
            LogList.Columns[0].Width = LogList.ClientSize.Width - 20;
        }

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm._logForm = null;
        }
    }
}
