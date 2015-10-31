using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using TRadioPlayer.DataAccess;

namespace TRadioPlayer
{
    public partial class AddNewStationForm : Form
    {

        private string _datafilePath = AppDomain.CurrentDomain.BaseDirectory + "\\stations.json";
        private string _cateFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\categories.json";
        private RadioDb _radioDb;
        private MainForm _mainForm;

        public AddNewStationForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TitleEdit.Text))
            {
                MessageBox.Show("Radio title cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(StreamUrlEdit.Text))
            {
                MessageBox.Show("Stream url cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RadioInfo radioInfo = new RadioInfo()
            {
                Title = TitleEdit.Text,
                CategoryId = CategoryList.SelectedIndex+1,
                HomePage = HomeEdit.Text,
                StreamUrl = StreamUrlEdit.Text,
                Active = true,
                Faved = false
            };

            _radioDb.Add(radioInfo);
            this.Close();
        }

        private void AddNewStationForm_Shown(object sender, EventArgs e)
        {
            // load radio station categories from json file
            var radioCategories = _radioDb.ReadCategoriesFromFile();
            // fill categories list
            for (int i = 1; i < radioCategories.Count-1; i++)
            {
                var category = radioCategories[i];
                CategoryList.Items.Add(category.Title);
            }
            CategoryList.SelectedIndex = 0;
        }

        private void AddNewStationForm_Load(object sender, EventArgs e)
        {
            _radioDb = new RadioDb(_datafilePath, _cateFilePath);
        }

        private void AddNewStationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm._addNewStationForm = null;
            if (_mainForm != null)
            {
                _mainForm.ReloadStationsAndData();
            }
        }
    }
}
