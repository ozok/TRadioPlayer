using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRadioPlayer
{
    public partial class EQForm : Form
    {
        private MainForm _mainForm = null;
        private string _eqFolder = String.Empty;

        public EQForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void EQForm_Load(object sender, EventArgs e)
        {
            // todo: load from settings
            PresetsList.SelectedIndex = 0;
            _eqFolder = AppDomain.CurrentDomain.BaseDirectory + "\\EQ\\";
        }

        private void ApplyValues()
        {
            double[] eqValues = new double[10];
            eqValues[0] = trackBar1.Value / 100.0;
            eqValues[1] = trackBar2.Value / 100.0;
            eqValues[2] = trackBar3.Value / 100.0;
            eqValues[3] = trackBar4.Value / 100.0;
            eqValues[4] = trackBar5.Value / 100.0;
            eqValues[5] = trackBar6.Value / 100.0;
            eqValues[6] = trackBar7.Value / 100.0;
            eqValues[7] = trackBar8.Value / 100.0;
            eqValues[8] = trackBar9.Value / 100.0;
            eqValues[9] = trackBar10.Value / 100.0;

            _mainForm.ApplyEq(eqValues);
        }

        private void PresetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string eqFileName = AppDomain.CurrentDomain.BaseDirectory + "EQ\\" + PresetsList.Text + ".txt";
            List<string> eqFileContent = File.ReadAllLines(eqFileName, Encoding.UTF8).ToList();

            trackBar1.Value = Convert.ToInt32(eqFileContent[0]);
            trackBar2.Value = Convert.ToInt32(eqFileContent[1]);
            trackBar3.Value = Convert.ToInt32(eqFileContent[2]);
            trackBar4.Value = Convert.ToInt32(eqFileContent[3]);
            trackBar5.Value = Convert.ToInt32(eqFileContent[4]);
            trackBar6.Value = Convert.ToInt32(eqFileContent[5]);
            trackBar7.Value = Convert.ToInt32(eqFileContent[6]);
            trackBar8.Value = Convert.ToInt32(eqFileContent[7]);
            trackBar9.Value = Convert.ToInt32(eqFileContent[8]);
            trackBar10.Value = Convert.ToInt32(eqFileContent[9]);

            ApplyValues();
        }
    }
}
