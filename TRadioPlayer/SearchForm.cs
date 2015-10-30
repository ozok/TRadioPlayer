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
                ListViewItem listViewItem = new ListViewItem {Text = _searchResultInfos[e.ItemIndex].Title};

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
    }
}
