/*
The MIT License (MIT)

Copyright (c) 2015 ozok26@gmail.com - Okan Özcan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
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
            MainForm.LogForm = null;
        }
    }
}
