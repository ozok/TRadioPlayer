/*
The MIT License (MIT)

Copyright (c) 2015-2016 ozok26@gmail.com - Okan Özcan

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
using System.Linq;
using System.Windows.Forms;
using TRadioPlayer.DataAccess;

namespace TRadioPlayer
{
    public partial class SearchForm : Form
    {
        public List<SearchItem> RadioInfos = new List<SearchItem>();
        private List<SearchItem> _searchResultInfos = new List<SearchItem>();
        private MainForm _mainForm;

        public SearchForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void SearchEdit_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SearchEdit.Text))
            {
                var query = SearchEdit.Text.ToLower();
                _searchResultInfos =
                    RadioInfos.Where(r => r.TitleLower.Contains(query) || query.Contains(r.TitleLower)).ToList();
            }
            else
            {
                _searchResultInfos.Clear();
            }
            ResultList.VirtualListSize = _searchResultInfos.Count;
        }

        private void ResultList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < _searchResultInfos.Count)
            {
                ListViewItem listViewItem = new ListViewItem { Text = _searchResultInfos[e.ItemIndex].Title };

                e.Item = listViewItem;
            }
        }

        private void SearchForm_Resize(object sender, EventArgs e)
        {
            ResultList.Columns[0].Width = ResultList.ClientSize.Width - 20;
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            ResultList.Columns[0].Width = ResultList.ClientSize.Width - 20;
        }

        private void ResultList_DoubleClick(object sender, EventArgs e)
        {
            if (ResultList.SelectedIndices.Count > 0)
            {
                int index = ResultList.SelectedIndices[0];
                _mainForm.PlayFromSearchForm(_searchResultInfos[index].Index);
                Close();
            }
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
