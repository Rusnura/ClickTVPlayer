using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Click_TV
{
    public class OSD
    {
        private static TabControl tvArchiveOSDComponent;
        private static Button channelNameOSDComponent;
        private static MetroTrackBar tvVolumeOSDComponent;
        private static Button tvCurrentShowName;
        private static Button tvIndicator;
        private static Button tvSwitchChannelNumber;
        private static Button osdEPGUpdate;
        private static Button[] osdLoadButtons;

        private static int loadOSDID = 0;
        private static int archiveSelectedProgramID = -1;
        private static Timer _osdTimer = new Timer();
        private static Timer _volumeTimer = new Timer();
        private static Timer _switcherTimer = new Timer();
        private static System.Timers.Timer _loadTimer = new System.Timers.Timer();
        private static List<EPG> __tmpEPGS = new List<EPG>();
        private static EPG __currentAechivePlayingEPG = new EPG();

        public static void Init(TabControl tvArchive, Button _channelNameOSDComponent, MetroTrackBar _tvVolumeOSDComponent, Button _currentShowName, Button _indicator, Button _tvSwitchChannelNumber, Button _osdEPGUpdate,
            Button[] osd_loadButtons)
        {
            tvArchiveOSDComponent = tvArchive;
            tvArchiveOSDComponent.SelectedIndexChanged += new EventHandler(tvArchiveOSDComponent_SelectedIndexChanged);

            channelNameOSDComponent = _channelNameOSDComponent;
            tvVolumeOSDComponent = _tvVolumeOSDComponent;
            tvCurrentShowName = _currentShowName;
            tvIndicator = _indicator;
            tvSwitchChannelNumber = _tvSwitchChannelNumber;
            osdEPGUpdate = _osdEPGUpdate;
            osdLoadButtons = osd_loadButtons;

            // Set volume event handler
            tvVolumeOSDComponent.ValueChanged += new EventHandler(tvVolumeOSDComponent_ValueChanged);

            // Init OSD timer
            _osdTimer.Tick += new EventHandler(_osdTimer_Tick);
            _osdTimer.Interval = 5000;

            // Init volume Timer
            _volumeTimer.Tick += new EventHandler(_volumeTimer_Tick);
            _volumeTimer.Interval = 5000;

            // Init a TV channel switcher timer
            _switcherTimer.Tick += new EventHandler(_switcherTimer_Tick);
            _switcherTimer.Interval = 3000;

            // Init a load timer tick
            _loadTimer.Elapsed += new System.Timers.ElapsedEventHandler(_loadTimer_Elapsed);
            _loadTimer.Interval = 300;

            // Set mouse moving event handler
            for (int i = 0; i < tvArchiveOSDComponent.TabCount; i++)
            {
                tvArchiveOSDComponent.TabPages[i].MouseMove += new MouseEventHandler((sender, e) => { ((Control)sender).Focus(); });
            }
        }

        static void _loadTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (loadOSDID > 0)
            {
                osdLoadButtons[loadOSDID - 1].BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                osdLoadButtons[osdLoadButtons.Length - 1].BackColor = System.Drawing.Color.Gray;
            }
            osdLoadButtons[loadOSDID].BackColor = System.Drawing.Color.White;
            loadOSDID++;
            if (loadOSDID > osdLoadButtons.Length - 1)
            {
                loadOSDID = 0;
            }
        }

        /* Timer of switcher OSD */
        static void _switcherTimer_Tick(object sender, EventArgs e)
        {
            // If timer is ends
            int switchToChannel = -1;
            int.TryParse(tvSwitchChannelNumber.Text, out switchToChannel);
            if (switchToChannel >= 0)
            {
                Interface.switchChannel(null, switchToChannel);
            }
            _switcherTimer.Enabled = false;
            tvSwitchChannelNumber.Text = "";
            tvSwitchChannelNumber.Hide();
        }

        static void tvVolumeOSDComponent_ValueChanged(object sender, EventArgs e)
        {
            Player.Volume = tvVolumeOSDComponent.Value;
        }

        static void _volumeTimer_Tick(object sender, EventArgs e)
        {
            // If timer is ends
            _volumeTimer.Enabled = false;
            tvVolumeOSDComponent.Hide();
        }

        static void _osdTimer_Tick(object sender, EventArgs e)
        {
            // If timer is ends...
            _osdTimer.Enabled = false;

            channelNameOSDComponent.Hide();
            tvCurrentShowName.Hide();
            tvIndicator.Hide();
        }

        static void osdTimerStart()
        {
            // Reset the timer
            _osdTimer.Enabled = false;
            _osdTimer.Enabled = true;
        }

        static void volumeOsdTimerStart()
        {
            // Reset the volume timer
            _volumeTimer.Enabled = false;
            _volumeTimer.Enabled = true;
        }

        // Change tab of EPG
        static void tvArchiveOSDComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentShow = 0;
            if (Channels.currentPlayingChannel.Id > 0)
            {
                __tmpEPGS.Clear();
                tvArchiveOSDComponent.SelectedTab.Controls.Clear();
                // Get tv program by this day
                string tabDateText = tvArchiveOSDComponent.SelectedTab.Text;
                if (tabDateText == "Сегодня") tabDateText = DateTime.Today.ToString();

                EPG[] _epgs = API.getTVProgram(Channels.currentPlayingChannel, UnixTime.getUnixTimeStamp(DateTime.Parse(tabDateText).AddHours(-7)), 
                    UnixTime.getUnixTimeStamp(DateTime.Parse(tabDateText).AddDays(1).AddHours(-7)));

                for (int i = 0, j = 0; i < _epgs.Length; i++, j++)
                {
                    if (UnixTime.UnixTimeStampToDateTime(_epgs[i].Start).ToShortDateString() != DateTime.Parse(tabDateText).ToShortDateString()) { j--; }
                    if ( _epgs[i].inArchive == 1 )
                    {
                        // -> PictureBox: Play button
                        PictureBox _buttonPlay = new PictureBox();
                        _buttonPlay.Cursor = Cursors.Hand;
                        _buttonPlay.Name = "btnPlayArchive_" + i;
                        _buttonPlay.Size = new System.Drawing.Size(32, 41);
                        _buttonPlay.Location = new System.Drawing.Point(5, 45 * j);
                        _buttonPlay.ImageLocation = "images/1478529714_ARCHIVE_PLAY.png";
                        _buttonPlay.Enabled = _epgs[i].inArchive == 1 ? true : false;
                        _buttonPlay.Click += new EventHandler((s, ev) => { ArchiveSelectedEvent(s, e); });
                        tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.SelectedIndex].Controls.Add(_buttonPlay);
                    }
                    __tmpEPGS.Add(_epgs[i]);
                }

                for (int i = 0, j = 0; i < _epgs.Length; i++, j++)
                {
                    if (UnixTime.UnixTimeStampToDateTime(_epgs[i].Start).ToShortDateString() != DateTime.Parse(tabDateText).ToShortDateString()) { j--; }
                    // -> Label: TV Show Name
                    Label _EPGName = new Label();
                    _EPGName.Name = "epgShowName_" + i;
                    if (j % 2 == 0)
                    {
                        _EPGName.BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        _EPGName.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
                    }
                    _EPGName.Font = new System.Drawing.Font("Tahoma", 12.0f, System.Drawing.FontStyle.Bold);
                    _EPGName.ForeColor = System.Drawing.Color.FromArgb(102, 155, 192);
                    if (_epgs[i].Id == __currentAechivePlayingEPG.Id)
                    {
                        _EPGName.BackColor = System.Drawing.Color.FromArgb(203, 218, 233);
                        _EPGName.ForeColor = System.Drawing.Color.Black;
                    }

                    if (UnixTime.getUnixTimeStamp(DateTime.UtcNow) >= _epgs[i].Start && UnixTime.getUnixTimeStamp(DateTime.UtcNow) <= _epgs[i].End)
                    {
                        _EPGName.ForeColor = System.Drawing.Color.Silver;
                        currentShow = i;
                    }
                    _EPGName.Size = new System.Drawing.Size(tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.SelectedIndex].Width - 54, 20);
                    _EPGName.Location = new System.Drawing.Point(34, 45 * j);
                    _EPGName.Text = _epgs[i].Name;
                    if (_epgs[i].inArchive == 1)
                    {
                        _EPGName.Click += new EventHandler((s, ev) => { ArchiveSelectedEvent(s, e); });
                        _EPGName.Cursor = Cursors.Hand;
                    }
                    tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.SelectedIndex].Controls.Add(_EPGName);
                }

                for (int i = 0, j = 0; i < _epgs.Length; i++, j++)
                {
                    if (UnixTime.UnixTimeStampToDateTime(_epgs[i].Start).ToShortDateString() != DateTime.Parse(tabDateText).ToShortDateString()) { j--; }
                    // -> Label: TV Show Time
                    Label _EPGTime = new Label();
                    _EPGTime.Name = "epgShowTime_" + i;

                    if (j % 2 == 0)
                    {
                        _EPGTime.BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        _EPGTime.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
                    }
                    _EPGTime.ForeColor = System.Drawing.Color.White;
                    if (_epgs[i].Id == __currentAechivePlayingEPG.Id)
                    {
                        _EPGTime.BackColor = System.Drawing.Color.FromArgb(203, 218, 233);
                        _EPGTime.ForeColor = System.Drawing.Color.Black;
                    }
                    _EPGTime.Size = new System.Drawing.Size(tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.SelectedIndex].Width - 54, 20);
                    _EPGTime.Location = new System.Drawing.Point(34, 45 * j + 20);
                    _EPGTime.Text = UnixTime.UnixTimeStampToDateTime(_epgs[i].Start).ToShortTimeString() + " - " + UnixTime.UnixTimeStampToDateTime(_epgs[i].End).ToShortTimeString();
                    if (_epgs[i].inArchive == 1)
                    {
                        _EPGTime.Click += new EventHandler((s, ev) => { ArchiveSelectedEvent(s, e); });
                        _EPGTime.Cursor = Cursors.Hand;
                    }
                    tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.SelectedIndex].Controls.Add(_EPGTime);
                }
            }

            //tvArchiveOSDComponent.SelectedTab.AutoScrollPosition = new System.Drawing.Point(tvArchiveOSDComponent.SelectedTab.AutoScrollPosition.X, (currentShow - 3) * 45);
        }

        static void ArchiveSelectedEvent(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            int id = 1;
            if (int.TryParse(btn.Name.Split('_')[1], out id))
            {
                try
                {
                    __currentAechivePlayingEPG = __tmpEPGS[id];
                    Player.Play(__tmpEPGS[id]);

                    // Selected new design
                    if (archiveSelectedProgramID > -1)
                    {
                        tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowName_" + archiveSelectedProgramID, true)[0].BackColor = (archiveSelectedProgramID % 2 == 0) ? System.Drawing.Color.Black : System.Drawing.Color.FromArgb(16, 16, 16);
                        tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowName_" + archiveSelectedProgramID, true)[0].ForeColor = System.Drawing.Color.FromArgb(102, 155, 192);

                        tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowTime_" + archiveSelectedProgramID, true)[0].BackColor = (archiveSelectedProgramID % 2 == 0) ? System.Drawing.Color.Black : System.Drawing.Color.FromArgb(16, 16, 16);
                        tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowTime_" + archiveSelectedProgramID, true)[0].ForeColor = System.Drawing.Color.White;
                    }
                    // Set new colors
                    tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowName_" + id, true)[0].BackColor = System.Drawing.Color.FromArgb(203, 218, 233);
                    tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowName_" + id, true)[0].ForeColor = System.Drawing.Color.Black;

                    tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowTime_" + id, true)[0].BackColor = System.Drawing.Color.FromArgb(203, 218, 233);
                    tvArchiveOSDComponent.SelectedTab.Controls.Find("epgShowTime_" + id, true)[0].ForeColor = System.Drawing.Color.Black;

                    archiveSelectedProgramID = id;

                    OSD.ShowOSD(1); // Hide TV archive
                }
                catch { } 
            }
        }

        public static void setVolumeOSD(int volume)
        {
            tvVolumeOSDComponent.Value = volume;
            volumeOsdTimerStart();
            tvVolumeOSDComponent.Show();
        }

        public static void setSwitcherOSD(int number)
        {
            if (tvIndicator.Visible)
            {
                tvSwitchChannelNumber.Location = new System.Drawing.Point(tvSwitchChannelNumber.Location.X, 56);
            }
            else
            {
                tvSwitchChannelNumber.Location = new System.Drawing.Point(tvSwitchChannelNumber.Location.X, 13);
            }
            tvSwitchChannelNumber.Show();
            if (number >= 0)
            {
                if (tvSwitchChannelNumber.Text.Length > 3)
                {
                    tvSwitchChannelNumber.Text = "";
                }
                tvSwitchChannelNumber.Text += number;
            }
            else
            {
                if (tvSwitchChannelNumber.Text.Length > 1)
                {
                    tvSwitchChannelNumber.Text = tvSwitchChannelNumber.Text.Substring(0, tvSwitchChannelNumber.Text.Length - 1);
                }
                else
                {
                    tvSwitchChannelNumber.Text = "";
                    tvSwitchChannelNumber.Visible = false;
                    tvSwitchChannelNumber.Size = new System.Drawing.Size(33, tvSwitchChannelNumber.Size.Height);
                }
            }
            _switcherTimer.Enabled = true;
        }

        public static void ShowLoadOSD(bool show)
        {
            if (show)
            {
                if (_loadTimer.Enabled == false)
                {
                    foreach (Control _control in osdLoadButtons)
                    {
                        _control.Invoke(new Action(() => { _control.Visible = true; }));
                    }

                    _loadTimer.Start();
                }
            }
            else
            {
                _loadTimer.Stop();
                foreach (Control _control in osdLoadButtons)
                {
                    _control.Invoke(new Action(() => { _control.Visible = false; }));
                }
            }
        }

        public static void ShowOSD(int ID)
        {
            switch (ID)
            {
                case 1: // TV Archive
                    try
                    {
                        if (!tvArchiveOSDComponent.Visible)
                        {
                            if (Channels.currentPlayingChannel.Id > 0)
                            {
                                // Background color of tabs:
                                System.Drawing.Color backColor = System.Drawing.Color.Black;

                                // First, rename tabs:
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 1].Text = DateTime.Today.AddDays(1).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 1].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 2].Text = "Сегодня";
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 2].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 3].Text = DateTime.Today.AddDays(-1).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 3].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 4].Text = DateTime.Today.AddDays(-2).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 4].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 5].Text = DateTime.Today.AddDays(-3).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 5].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 6].Text = DateTime.Today.AddDays(-4).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 6].BackColor = backColor;

                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 7].Text = DateTime.Today.AddDays(-5).ToShortDateString();
                                tvArchiveOSDComponent.TabPages[tvArchiveOSDComponent.TabCount - 7].BackColor = backColor;

                                tvArchiveOSDComponent.SelectedIndex = tvArchiveOSDComponent.TabCount;
                                tvArchiveOSDComponent.SelectedIndex = tvArchiveOSDComponent.TabCount - 2;

                                tvArchiveOSDComponent.Show();
                            }
                        }
                        else
                        {
                            tvArchiveOSDComponent.Hide();
                        }
                    }
                    catch { }
                break;

                case 2: // Channel name
                    if (Channels.currentPlayingChannel.Id > 0 || EPGs.currentPlayingEPGInArchive.Id > 0)
                    {
                        if (!channelNameOSDComponent.Visible)
                        {
                            channelNameOSDComponent.Text = Channels.currentPlayingChannel.Number + " " + Channels.currentPlayingChannel.Name + " | " + DateTime.Now.ToShortTimeString();
                            channelNameOSDComponent.Show();
                            osdTimerStart();
                        }
                        else
                        {
                            channelNameOSDComponent.Hide();
                        }
                    }
                break;

                case 3: // Current show & position
                    if (Channels.currentPlayingChannel.Id > 0 || EPGs.currentPlayingEPGInArchive.Id > 0)
                    {
                        if (!tvCurrentShowName.Visible)
                        {

                            if (osdEPGUpdate.Visible)
                            {
                                osdEPGUpdate.Location = new System.Drawing.Point(10, tvVolumeOSDComponent.Location.Y - osdEPGUpdate.Height - 5);
                            }
                            
                            EPG _currentShow;
                            if (!Player.playingFromArchive)
                            {
                                _currentShow = EPGs.getCurrentShow(Channels.currentPlayingChannel);
                            }
                            else
                            {
                                _currentShow = EPGs.currentPlayingEPGInArchive;
                            }

                            if (_currentShow.Id > 0)
                            {
                                tvCurrentShowName.Text = _currentShow.Name + " [" + UnixTime.UnixTimeStampToDateTime(_currentShow.Start).ToShortTimeString() +
                                    " - " + UnixTime.UnixTimeStampToDateTime(_currentShow.End).ToShortTimeString() + "]";
                            }
                            else
                            {
                                tvCurrentShowName.Text = "Нет информации о текущей ТВ-программе...";
                            }

                            tvCurrentShowName.Show();
                        }
                        else
                        {
                            tvCurrentShowName.Hide();
                        }
                    }
                break;

                case 4:
                    if (Channels.currentPlayingChannel.Id > 0 || EPGs.currentPlayingEPGInArchive.Id > 0)
                    {
                        if (!tvIndicator.Visible)
                        {
                            if (tvSwitchChannelNumber.Visible)
                            {
                                tvSwitchChannelNumber.Hide();
                                tvSwitchChannelNumber.Location = new System.Drawing.Point(tvSwitchChannelNumber.Location.X, 56);
                                tvSwitchChannelNumber.Show();
                            }
                            if (Player.playingFromArchive)
                            {
                                tvIndicator.Text = "ТВ-АРХИВ";
                            }
                            else
                            {
                                tvIndicator.Text = "Онлайн";
                            }

                            tvIndicator.Show();
                        }
                        else
                        {
                            tvIndicator.Hide();
                        }
                    }
                break;

                case 5:
                    if (EPGs.threadBusyStatus)
                    {
                        if (!tvCurrentShowName.Visible)
                        {
                            //osdEPGUpdate.Location = new System.Drawing.Point(10, 513);
                            osdEPGUpdate.Location = new System.Drawing.Point(10, tvCurrentShowName.Location.Y);
                        }
                        else
                        {
                            //osdEPGUpdate.Location = new System.Drawing.Point(10, 447);
                            osdEPGUpdate.Location = new System.Drawing.Point(10, tvVolumeOSDComponent.Location.Y - osdEPGUpdate.Height - 5);
                        }
                        osdEPGUpdate.Text = "Идёт обновление программы передач... Подождите, пожалуйста!";
                        osdEPGUpdate.Visible = true;
                    }
                    else
                    {
                        osdEPGUpdate.Visible = false;
                    }
                break;
            }
        }

        public static bool getVisibleOfOSD(int i)
        {
            switch (i)
            {
                case 1: // Archive
                    return tvArchiveOSDComponent.Visible;

                case 2: // Channel name
                    return channelNameOSDComponent.Visible;

                case 3: // Time & position
                    return tvCurrentShowName.Visible;

                case 4: // Indicator
                    return tvIndicator.Visible;

                case 5: // Volume OSD
                    return tvVolumeOSDComponent.Visible;

                case 6: // Switcher OSD
                    return tvSwitchChannelNumber.Visible;

                case 7: // Update EPG OSD
                    return osdEPGUpdate.Visible;

                default:
                    return false;
            }
        }
    }
}
