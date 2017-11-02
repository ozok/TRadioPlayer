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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRadioPlayer.Settings;

namespace TRadioPlayer
{
    public partial class EQForm : Form
    {
        private MainForm _mainForm = null;
        private EqSettings _eqSettings = new EqSettings();
        private SettingReadWrite _settingReadWrite;

        public EQForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public void LoadSettings()
        {
            _eqSettings = _settingReadWrite.ReadEqSettings();

            EnableEQBtn.Checked = _eqSettings.Enabled;
            trackBar1.Value = _eqSettings.EqVal1;
            trackBar2.Value = _eqSettings.EqVal2;
            trackBar3.Value = _eqSettings.EqVal3;
            trackBar4.Value = _eqSettings.EqVal4;
            trackBar5.Value = _eqSettings.EqVal5;
            trackBar6.Value = _eqSettings.EqVal6;
            trackBar7.Value = _eqSettings.EqVal7;
            trackBar8.Value = _eqSettings.EqVal8;
            trackBar9.Value = _eqSettings.EqVal9;
            trackBar10.Value = _eqSettings.EqVal10;
            PresetsList.SelectedIndex = _eqSettings.PresetIndex;

            EnableEQBtn_CheckedChanged(this, null);
        }

        public void SaveSettings()
        {
            _eqSettings.Enabled = EnableEQBtn.Checked;
            _eqSettings.EqVal1 = trackBar1.Value;
            _eqSettings.EqVal2 = trackBar2.Value;
            _eqSettings.EqVal3 = trackBar3.Value;
            _eqSettings.EqVal4 = trackBar4.Value;
            _eqSettings.EqVal5 = trackBar5.Value;
            _eqSettings.EqVal6 = trackBar6.Value;
            _eqSettings.EqVal7 = trackBar7.Value;
            _eqSettings.EqVal8 = trackBar8.Value;
            _eqSettings.EqVal9 = trackBar9.Value;
            _eqSettings.EqVal10 = trackBar10.Value;
            _eqSettings.PresetIndex = PresetsList.SelectedIndex;
            _settingReadWrite.WriteEqSettings(_eqSettings);
        }


        private void EQForm_Load(object sender, EventArgs e)
        {
            // todo: load from settings
            PresetsList.SelectedIndex = 0;
            _settingReadWrite = new SettingReadWrite(AppDomain.CurrentDomain.BaseDirectory + "\\settings.json", AppDomain.CurrentDomain.BaseDirectory + "\\eqsettings.json");
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

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            ApplyValues();
        }

        private void EQForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void EnableEQBtn_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = EnableEQBtn.Checked;
            trackBar2.Enabled = EnableEQBtn.Checked;
            trackBar3.Enabled = EnableEQBtn.Checked;
            trackBar4.Enabled = EnableEQBtn.Checked;
            trackBar5.Enabled = EnableEQBtn.Checked;
            trackBar6.Enabled = EnableEQBtn.Checked;
            trackBar7.Enabled = EnableEQBtn.Checked;
            trackBar8.Enabled = EnableEQBtn.Checked;
            trackBar9.Enabled = EnableEQBtn.Checked;
            trackBar10.Enabled = EnableEQBtn.Checked;
            PresetsList.Enabled = EnableEQBtn.Checked;
        }

        private void EQForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void EQForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.EqForm = null;
        }
    }
}
