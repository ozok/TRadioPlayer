using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRadioPlayer
{
    public partial class EQForm : Form
    {
        private MainForm _mainForm = null;
        public EQForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void EQForm_Load(object sender, EventArgs e)
        {
            // todo: load from settings
            PresetsList.SelectedIndex = 0;
        }
    }
}
