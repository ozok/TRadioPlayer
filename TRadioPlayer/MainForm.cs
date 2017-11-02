﻿/*
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using TRadioPlayer.DataAccess;
using TRadioPlayer.Settings;

namespace TRadioPlayer
{
    public partial class MainForm : Form
    {
        private enum PlayerState : short
        {
            Playing = 0,
            Paused = 1,
            Stopped = 2
        }
        public static LogForm LogForm = null;
        public static AddNewStationForm AddNewStationForm = null;
        public static EQForm EqForm = null;
        private bool _failedToOpen = false;
        private bool _muted = false;
        private EqSettings _eqSettings = new EqSettings();
        private EqManager _eqManager;

        // constants are mostly used to parse output from mpv
        private const string SongPlayCmd = " --no-quiet --terminal --no-msg-color --input-file=/dev/stdin --no-fs --hwdec=no --sub-auto=fuzzy --vo=null, --priority=abovenormal --no-input-default-bindings --input-x11-keyboard=no --no-input-cursor --cursor-autohide=no --no-keepaspect --monitorpixelaspect=1 --osd-scale=1 --cache=4096 --osd-level=0 --audio-channels=2 --af-add=scaletempo --af-add=equalizer=0:0:0:0:0:0:0:0:0:0 --softvol=yes --softvol-max=100 --ytdl=no --term-playing-msg=MPV_VERSION=${=mpv-version:} ";
        private const string TitleStart = " icy-title: ";
        private const string ErrorStart = "Failed to open";
        private const string Buffering = "(Buffering) ";
        private const string Exiting = "Exiting...";
        private const string Playing = "Playing";
        private const string PlayingStart = "Playing: ";
        private const string Paused = "(Paused)";

        // taskbar overlay icons
        private Icon playIcon = Icon.FromHandle(Properties.Resources.media_playback_start.GetHicon());
        private Icon pausedIcon = Icon.FromHandle(Properties.Resources.media_playback_pause.GetHicon());
        private Icon stopIcon = Icon.FromHandle(Properties.Resources.media_playback_stop.GetHicon());
        private Icon muteIcon = System.Drawing.Icon.FromHandle(Properties.Resources.audio_volume_muted.GetHicon());

        private ThumbnailToolBarButton _playThumbnailToolBarButton;
        private ThumbnailToolBarButton _stopThumbnailToolBarButton;
        private ThumbnailToolBarButton _muteThumbnailToolBarButton;

        // list of radio stations
        private List<RadioInfo> _radioInfos = new List<RadioInfo>();
        // list of radio station categories
        private List<RadioCategory> _radioCategories = new List<RadioCategory>();

        private RadioDb _radioDb;
        private SettingReadWrite _settingReadWrite;
        private Settings.Settings _settings;

        // paths
        private string _dataFilePath;
        private string _categoryListFilePath;
        private string _mpvPath;
        private string _settingsFilePath;

        private ProcessStartInfo _startInfo;
        private int _volumeLevel;
        private string _consoleOutput;
        private List<string> _log = new List<string>();
        private bool _closing;
        private string _title;
        private int _currentRadioIndex = -1;
        private int _activeCategory;
        private PlayerState _playerState = PlayerState.Stopped;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Writes program settings to a json file
        /// </summary>
        private void SaveSettings()
        {
            _settings.RadioCategory = CategoryList.SelectedIndex;
            _settings.VolumeLevel = VolumeBar.Value;
            _settings.Location = this.Location;
            _settings.FormWindowState = this.WindowState;
            _settings.Size = this.Size;

            _settingReadWrite.WriteSettings(_settings);
        }

        /// <summary>
        /// Reads program settings from a json file
        /// </summary>
        private void LoadSettings()
        {
            _settings = _settingReadWrite.ReadSettings();

            CategoryList.SelectedIndex = _settings.RadioCategory;
            VolumeBar.Value = _settings.VolumeLevel;
            _volumeLevel = _settings.VolumeLevel;
            VolumeLabel.Text = String.Format("{0} %", _volumeLevel);

            if (_settings.Location.X > 0 && _settings.Location.Y > 0)
            {
                this.Location = _settings.Location;
            }
            this.WindowState = _settings.FormWindowState;
            this.Size = _settings.Size;
        }

        public void ReloadStationsAndData()
        {
            _radioDb = new RadioDb(_dataFilePath, _categoryListFilePath);
            LoadStations();
        }

        /// <summary>
        /// Loads stations from json file according to selected radio category
        /// </summary>
        public void LoadStations()
        {
            StationsList.Items.Clear();

            if (CategoryList.SelectedIndex == CategoryList.Items.Count - 1)
            {
                // load only favs
                _radioInfos = _radioDb.GetRadioStationsAccordingToCategory(CategoryList.SelectedIndex, true);
            }
            else
            {
                // load according to category
                _radioInfos = _radioDb.GetRadioStationsAccordingToCategory(CategoryList.SelectedIndex);
            }
            StationsList.VirtualListSize = _radioInfos.Count;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _dataFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\stations.json";
            _categoryListFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\categories.json";
            _settingsFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\settings.json";
            _mpvPath = AppDomain.CurrentDomain.BaseDirectory + "\\mpv\\mpv.exe";

            _radioDb = new RadioDb(_dataFilePath, _categoryListFilePath);
            _settingReadWrite = new SettingReadWrite(_settingsFilePath, AppDomain.CurrentDomain.BaseDirectory + "\\eqsettings.json");

            _startInfo = PlayerProcess.StartInfo;

            _eqManager = new EqManager(PlayerProcess);

            #region taskbar buttons

            _playThumbnailToolBarButton = new ThumbnailToolBarButton(pausedIcon, "Play/Pause");
            _stopThumbnailToolBarButton = new ThumbnailToolBarButton(stopIcon, "Stop");
            _muteThumbnailToolBarButton = new ThumbnailToolBarButton(muteIcon, "Mute");
            _playThumbnailToolBarButton.Click += PlayThumbnailToolBarButtonOnClick;
            _stopThumbnailToolBarButton.Click += StopThumbnailToolBarButtonOnClick;
            _muteThumbnailToolBarButton.Click += MuteThumbnailToolBarButtonOnClick;
            _playThumbnailToolBarButton.Visible = true;
            _playThumbnailToolBarButton.Enabled = true;
            _stopThumbnailToolBarButton.Visible = true;
            _stopThumbnailToolBarButton.Enabled = true;
            _muteThumbnailToolBarButton.Visible = true;
            _muteThumbnailToolBarButton.Enabled = true;
            _playThumbnailToolBarButton.DismissOnClick = true;
            _stopThumbnailToolBarButton.DismissOnClick = true;

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(this.Handle, _playThumbnailToolBarButton,
                _stopThumbnailToolBarButton, _muteThumbnailToolBarButton);

            #endregion

        }

        private void MuteThumbnailToolBarButtonOnClick(object sender, ThumbnailButtonClickedEventArgs thumbnailButtonClickedEventArgs)
        {
            MuteBtn_Click(this, null);
        }

        public void ApplyEq(double[] eqValues)
        {
            try
            {
                if (PlayerProcess.Handle.ToInt32() > 0)
                {
                    string eqStr = _eqManager.GenerateApplyEqCmd(eqValues);
                    PlayerProcess.StandardInput.WriteLine(eqStr);

                    LogForm.Logs.Add(eqStr);
                    if (LogForm != null)
                    {
                        LogForm.VirtualSize = LogForm.Logs.Count;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }

        }

        private void StopThumbnailToolBarButtonOnClick(object sender, ThumbnailButtonClickedEventArgs thumbnailButtonClickedEventArgs)
        {
            StopBtn_Click(sender, null);
        }

        private void PlayThumbnailToolBarButtonOnClick(object sender, ThumbnailButtonClickedEventArgs thumbnailButtonClickedEventArgs)
        {
            PauseBtn_Click(sender, null);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // load radio station categories from json file
            _radioCategories = _radioDb.ReadCategoriesFromFile();
            // fill categories list
            foreach (var category in _radioCategories)
            {
                CategoryList.Items.Add(category.Title);
            }
            CategoryList.SelectedIndex = 0;

            LoadStations();
            _volumeLevel = VolumeBar.Value;

            StationsList.Columns[1].Width = 60;
            StationsList.Columns[0].Width = StationsList.ClientSize.Width - 10 - StationsList.Columns[1].Width;

            // load general program settings
            LoadSettings();
        }

        /// <summary>
        /// displays radio stations according to the selected category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStations();
            int lastPlayedIndex = _radioCategories[CategoryList.SelectedIndex].LastPlayedStationIndex;
            if (lastPlayedIndex > -1 && lastPlayedIndex < _radioInfos.Count)
            {
                StationsList.Items[lastPlayedIndex].EnsureVisible();
                StationsList.Items[lastPlayedIndex].Selected = true;
                _currentRadioIndex = lastPlayedIndex;
            }
            StationsList.Refresh();
            StationsList.Update();
        }

        /// <summary>
        /// Parses output from mpv
        /// </summary>
        /// <param name="consoleMesssage">Message written to console by mpv</param>
        private void HandleConsoleMessage(string consoleMesssage)
        {
            if (consoleMesssage.StartsWith(TitleStart))
            {
                Invoke((MethodInvoker)delegate
                {
                    var tmpStr = consoleMesssage.Replace(TitleStart, "").Trim();
                    if (!String.IsNullOrEmpty(tmpStr))
                    {
                        if (tmpStr.Trim() != "-")
                        {
                            _title = tmpStr + " ";
                            TitleLabel.Text = _title;
                        }
                    }
                });
            }
            else if (consoleMesssage.StartsWith(PlayingStart))
            {
                Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Connecting...";
                });
            }
            else if (consoleMesssage.StartsWith(ErrorStart))
            {
                Invoke((MethodInvoker)delegate
                {
                    StopBtn_Click(null, null);
                    StatusLabel.Text = "Unable to play this station.";
                    _failedToOpen = true;
                });
            }
            else if (consoleMesssage.StartsWith(Buffering))
            {
                Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Buffering...";
                });
            }
            else if (consoleMesssage.StartsWith(Exiting) && !_failedToOpen)
            {
                Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Stopped.";
                });
            }
            else
            {
                if (!_failedToOpen)
                {
                    if (StatusLabel.Text != Playing)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            StatusLabel.Text = Playing;
                        });
                    }
                    if (TitleLabel.Text != _title)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            //TitleLabel.Text = _title;
                        });
                    }

                    if (Text != _title + " - TRadioPlayer")
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            this.Text = _title + " - TRadioPlayer";
                        });
                    }
                }
            }
        }

        /// <summary>
        /// plays given radio index
        /// only called from search form
        /// </summary>
        /// <param name="index">index of the radio station to be placed</param>
        public void PlayFromSearchForm(int index)
        {
            RadioInfo radioInfo = _radioInfos[index];
            if (radioInfo != null)
            {
                // update the last played station for that radio category
                _radioCategories[CategoryList.SelectedIndex].LastPlayedStationIndex = index;
                if (_currentRadioIndex > -1)
                {
                    StationsList.Items[_currentRadioIndex].Selected = false;
                }
                _currentRadioIndex = index;
                _activeCategory = CategoryList.SelectedIndex;
                // make sure list focuses on the station
                StationsList.Items[index].EnsureVisible();
                StationsList.Items[index].Selected = true;
                StationsList.Refresh();

                // play the radio
                PlayUrl(radioInfo.StreamUrl);
            }
            else
            {
                // todo: report this by showing the log    
            }
        }

        /// <summary>
        /// Starts to play given url
        /// </summary>
        /// <param name="url">Url to play</param>
        private void PlayUrl(string url)
        {
            _failedToOpen = false;
            // kill mpv if it is already running
            try
            {
                PlayerProcess.Kill();
            }
            catch (Exception)
            {
                // ignored
            }
            if (_closing)
            {
                return;
            }
            // update UI
            _title = "TRadioPlayer";
            try
            {
                StatusLabel.Text = "Connecting...";
                TitleLabel.Text = "TRadioPlayer";
                this.Text = "TRadioPlayer";
                StationsList.Refresh();
                RotateTimer.Enabled = true;
                TaskbarManager.Instance.SetOverlayIcon(playIcon, "Playing");
            }
            catch (Exception)
            {
                Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = "Connecting...";
                    TitleLabel.Text = "TRadioPlayer";
                    this.Text = "TRadioPlayer";
                    StationsList.Refresh();
                    RotateTimer.Enabled = true;
                    TaskbarManager.Instance.SetOverlayIcon(playIcon, "Playing");
                });
            }
            // start playing radio
            PlayerProcess = new Process();
            // this processtartinfo is copied from the
            // process in the UI. It should never be null.
            if (_startInfo != null)
            {
                PlayerProcess.StartInfo = _startInfo;
            }

            PlayerProcess.StartInfo.FileName = _mpvPath;
            PlayerProcess.StartInfo.Arguments = SongPlayCmd + " --volume " + _volumeLevel.ToString() + " \"" + url + "\"";
            PlayerProcess.ErrorDataReceived += PlayProcess_ErrorDataReceived;
            PlayerProcess.OutputDataReceived += PlayerProcess_OutputDataReceived;
            PlayerProcess.Exited += MusicPlayProcess_Exited;
            PlayerProcess.EnableRaisingEvents = true;
            PlayerProcess.StartInfo.RedirectStandardInput = true;
            PlayerProcess.Start();
            PlayerProcess.BeginErrorReadLine();
            PlayerProcess.BeginOutputReadLine();
            _playerState = PlayerState.Playing;

            #region equalizer

            _eqSettings = _settingReadWrite.ReadEqSettings();
            double[] eqValues = new double[10];
            eqValues[0] = _eqSettings.EqVal1 / 100.0;
            eqValues[1] = _eqSettings.EqVal2 / 100.0;
            eqValues[2] = _eqSettings.EqVal3 / 100.0;
            eqValues[3] = _eqSettings.EqVal4 / 100.0;
            eqValues[4] = _eqSettings.EqVal5 / 100.0;
            eqValues[5] = _eqSettings.EqVal6 / 100.0;
            eqValues[6] = _eqSettings.EqVal7 / 100.0;
            eqValues[7] = _eqSettings.EqVal8 / 100.0;
            eqValues[8] = _eqSettings.EqVal9 / 100.0;
            eqValues[9] = _eqSettings.EqVal10 / 100.0;
            ApplyEq(eqValues);

            #endregion
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            // change volume level
            _volumeLevel = VolumeBar.Value;
            VolumeLabel.Text = String.Format("{0} %", _volumeLevel);
            try
            {
                if (PlayerProcess.Handle.ToInt32() > 0)
                {
                    PlayerProcess.StandardInput.WriteLine("set volume " + _volumeLevel.ToString());
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void PlayProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Application.DoEvents();

            if (!String.IsNullOrEmpty(e.Data))
            {
                _consoleOutput = e.Data;
                if (!e.Data.StartsWith("A: ") && !e.Data.StartsWith(Paused) && !e.Data.StartsWith(Buffering))
                {
                    _log.Add("Error: " + e.Data);
                    LogForm.Logs.Add(e.Data);
                    if (LogForm != null)
                    {
                        LogForm.VirtualSize = LogForm.Logs.Count;
                    }
                }
                HandleConsoleMessage(_consoleOutput);
            }
        }

        private void PlayerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Application.DoEvents();

            if (!String.IsNullOrEmpty(e.Data))
            {
                _consoleOutput = e.Data;
                if (!e.Data.StartsWith("A: ") && !e.Data.StartsWith(Paused) && !e.Data.StartsWith(Buffering))
                {
                    _log.Add("Output " + e.Data);
                    LogForm.Logs.Add(e.Data);
                    if (LogForm != null)
                    {
                        LogForm.VirtualSize = LogForm.Logs.Count;
                    }
                }
                HandleConsoleMessage(_consoleOutput);
            }
        }

        private void MusicPlayProcess_Exited(object sender, EventArgs e)
        {
            _consoleOutput = "Stopped";
            _playerState = PlayerState.Stopped;
            if (!_closing)
            {
                Invoke((MethodInvoker)delegate
                {
                    StatusLabel.Text = _consoleOutput;
                    this.Text = "TRadioPlayer";
                    StationsList.Refresh();
                });
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save log to log.txt file
            // todo: change file path
            File.WriteAllLines("log.txt", _log, Encoding.UTF8);
            _closing = true;
            try
            {
                PlayerProcess.Kill();
            }
            catch (Exception)
            {
                // ignored
            }
            SaveSettings();
            _radioDb.WriteCategoriesToFile(_radioCategories);
            //_radioDb.WriteDataToFile(_radioInfos);
        }

        private void StationsList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // virtual mode
            if (e.ItemIndex < _radioInfos.Count)
            {
                ListViewItem listViewItem = new ListViewItem();
                RadioInfo radioInfo = _radioInfos[e.ItemIndex];
                if (radioInfo != null)
                {
                    listViewItem.Text = radioInfo.Title;
                    listViewItem.SubItems.Add(radioInfo.Faved ? "Yes" : "No");
                    listViewItem.Font = new Font(listViewItem.Font, e.ItemIndex == _currentRadioIndex && _playerState != PlayerState.Stopped && _activeCategory == CategoryList.SelectedIndex ? FontStyle.Bold : FontStyle.Regular);

                    e.Item = listViewItem;
                }
            }
        }

        private void StationsList_DoubleClick_1(object sender, EventArgs e)
        {
            // start playing selected station
            if (StationsList.SelectedIndices.Count > 0)
            {
                // get radio that will be played
                RadioInfo radioInfo = _radioInfos[StationsList.SelectedIndices[0]];

                // update the last played station for that radio category
                _radioCategories[CategoryList.SelectedIndex].LastPlayedStationIndex = StationsList.SelectedIndices[0];
                _currentRadioIndex = StationsList.SelectedIndices[0];
                _activeCategory = CategoryList.SelectedIndex;
                StationsList.Refresh();

                // play the radio
                // todo: check links first
                PlayUrl(radioInfo.StreamUrl);
            }
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            // pause/resume
            try
            {
                if (PlayerProcess.Handle.ToInt32() > 0)
                {
                    if (_playerState != PlayerState.Stopped)
                    {
                        PlayerProcess.StandardInput.WriteLine("PAUSE");
                        _playerState = _playerState == PlayerState.Playing ? PlayerState.Paused : PlayerState.Playing;
                        if (_playerState == PlayerState.Playing)
                        {
                            TaskbarManager.Instance.SetOverlayIcon(playIcon, "Playing");
                        }
                        else if (_playerState == PlayerState.Paused)
                        {
                            TaskbarManager.Instance.SetOverlayIcon(pausedIcon, "Paused");
                        }
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PlayerProcess.Kill();
                _currentRadioIndex = -1;

                _title = "TRadioPlayer";
                TitleLabel.Text = _title;
                TaskbarManager.Instance.SetOverlayIcon(null, "Stopped");
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            StationsList.Columns[1].Width = 60;
            StationsList.Columns[0].Width = StationsList.ClientSize.Width - 10 - StationsList.Columns[1].Width;
        }

        private void StationsList_MouseEnter(object sender, EventArgs e)
        {
            if (LogForm != null)
            {
                if (LogForm.Visible)
                {
                    return;
                }
            }
            if (EqForm != null)
            {
                if (EqForm.Visible)
                {
                    return;
                }
            }
            StationsList.Focus();
        }

        private void StationsList_MouseLeave(object sender, EventArgs e)
        {
            if (LogForm != null)
            {
                if (LogForm.Visible)
                {
                    return;
                }
            }
            if (EqForm != null)
            {
                if (EqForm.Visible)
                {
                    return;
                }
            }
            VolumeBar.Focus();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            // show search form
            SearchForm searchForm = new SearchForm(this);
            for (int i = 0; i < _radioInfos.Count; i++)
            {
                RadioInfo radioInfo = _radioInfos[i];
                if (radioInfo.Active)
                {
                    searchForm.RadioInfos.Add(new SearchItem()
                    {
                        Title = radioInfo.Title,
                        Index = i,
                        TitleLower = radioInfo.Title.ToLower()
                    });
                }
            }
            searchForm.Show();
            this.SendToBack();
            searchForm.BringToFront();
        }

        private void favUnFavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StationsList.SelectedIndices.Count > 0)
            {
                int index = StationsList.SelectedIndices[0];

                _radioDb.UpdateFavState(_radioInfos[index].Index);
                StationsList.Refresh();
            }
        }

        private void RotateTimer_Tick(object sender, EventArgs e)
        {
            if (TitleLabel.Text.Length > 0)
            {
                using (Graphics g = CreateGraphics())
                {
                    SizeF size = g.MeasureString(TitleLabel.Text, TitleLabel.Font);
                    if (size.Width > TitleLabel.Width)
                    {
                        var tempStr = TitleLabel.Text;
                        var lastChar = tempStr.Substring(0, 1);
                        tempStr = tempStr.Remove(0, 1) + lastChar;

                        TitleLabel.Text = tempStr;
                    }
                    else
                    {
                        TitleLabel.Text = _title;
                    }
                }
            }
        }

        private void AddNewStationBtn_Click(object sender, EventArgs e)
        {
            if (LogForm != null)
            {
                LogForm.BringToFront();
            }
            else
            {
                LogForm logForm = new LogForm();
                LogForm = logForm;
                LogForm.Show();
            }
        }

        private void StationsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddStationBtn_Click(object sender, EventArgs e)
        {
            if (AddNewStationForm != null)
            {
                AddNewStationForm.BringToFront();
            }
            else
            {
                AddNewStationForm addNewStationForm = new AddNewStationForm(this);
                AddNewStationForm = addNewStationForm;
                AddNewStationForm.ShowDialog();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && e.Control)
            {
                PauseBtn_Click(sender, null);
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                StopBtn_Click(sender, null);
            }
            else if (e.KeyCode == Keys.M && e.Control)
            {
                MuteBtn_Click(sender, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                SearchBtn_Click(sender, null);
            }
        }

        private void EQBtn_Click(object sender, EventArgs e)
        {
            if (EqForm != null)
            {
                EqForm.BringToFront();
            }
            else
            {
                EQForm eqForm = new EQForm(this);
                EqForm = eqForm;
                EqForm.Show();
            }
        }

        private void MuteBtn_Click(object sender, EventArgs e)
        {
            // mute
            try
            {
                if (PlayerProcess.Handle.ToInt32() > 0)
                {
                    if (_playerState != PlayerState.Stopped)
                    {
                        PlayerProcess.StandardInput.WriteLine("MUTE");
                        _muted = !_muted;
                        MuteBtn.Image = _muted ? Properties.Resources.audio_volume_muted : Properties.Resources.audio_volume_high;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            string msg = "TRadioPlayer Beta 1 " + Environment.NewLine + "2015-2016 ozok26@gmail.com" +
                         Environment.NewLine + "MIT Licence";
            MessageBox.Show(msg, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
