using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using Vlc;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace Click_TV
{
    public partial class mainForm : Form
    {
        private bool buffering = false;
        private bool firstInitialization = true;
        private bool progressBarInFocus = false;
        private PropertiesWindow wProperties = new PropertiesWindow();
        private GlobalPropertiesWindow glWProperties = new GlobalPropertiesWindow();
        private About wAbout = new About();
        private Timer interfaceUpdateTimer = new Timer();
        private Timer postLoadingTimer = new Timer();

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Logger.Write(Logger.LogLevel.INFO, "===== Запуск приложения =====");
            Interface.Init(tvPlayer);

            Interface.DisplayChannels(tvChannels);
            Player.onFullScreen += new Player.OnFullScreenDelegate(FullScreenMode);
            Player.onPlayerKeyDown += new Player.OnPlayerKeyDown(Player_onPlayerKeyDown);
            tvChannels.PreviewKeyDown += new PreviewKeyDownEventHandler((s, args) => { Player_onPlayerKeyDown(args.KeyCode.ToString()); });
            Player.onMouseMoveOnVideoPanel += new Player.OnMouseMoveOnVideoPanel(Player_onFullScreen);
            Player.onPlayerError += new Player.OnPlayerError(Player_onPlayerError);
            Player.onPlayerBuffering += new Player.OnPlayerBuffering(Buffering);

            // Init OSD
            OSD.Init(osdTVProgram, osd_name, videoOSDVolume, osd_currentShow, osd_indicator, osd_channelNumber, osd_EPGUpdate, new Button[] { osd_load_1, osd_load_2, osd_load_3, osd_load_4 });

            // Events
            controlVolume.MouseWheel += new MouseEventHandler(controlVolume_MouseWheel);

            // Reading dock style
            if (Configurator.getKeyFromGlobalSection("left") == "1")
            {
                tvChannels.Dock = DockStyle.Left;
            }

            // Start lastchannel
            int lastChannel = -1;
            if (int.TryParse(Configurator.getKeyFromGlobalSection("lastchannel"), out lastChannel))
            {
                if (lastChannel >= 0)
                {
                    // Search channel
                    Interface.switchChannel(null, lastChannel);
                }
            }

            // Set scroll on last channel
            int lastChannelScroll = -1;
            if (int.TryParse(Configurator.getKeyFromGlobalSection("lastchannelid"), out lastChannelScroll))
            {
                if (lastChannelScroll >= 0)
                {
                    // Set scroll on last channel
                    tvChannels.AutoScrollPosition = new Point(tvChannels.AutoScrollPosition.X, lastChannelScroll * 60);
                }
            }
            // Initialization of interface update timer
            interfaceUpdateTimer.Interval = 500;
            interfaceUpdateTimer.Tick += new EventHandler(interfaceUpdateTimer_Tick);
            interfaceUpdateTimer.Enabled = true;
            postLoadingTimer.Interval = 4000;
            postLoadingTimer.Tick += new EventHandler(postLoadingTimer_Tick);
        }

        void postLoadingTimer_Tick(object sender, EventArgs e)
        {
            OSD.ShowLoadOSD(false);
            postLoadingTimer.Stop();
        }

        void Buffering()
        {
            buffering = true;
            OSD.ShowLoadOSD(true);
        }

        void Player_onPlayerError()
        {
            /* Not implemented */
        }

        void Player_onFullScreen(MouseEventArgs e)
        {
            if (Player.isFullScreen)
            {
                if (e.Y >= (tvPlayer.Height - (controlPanel.Height)))
                {
                    controlPanel.Show();
                }
                else
                {
                    controlPanel.Hide();
                }
            }
        }

        void controlVolume_MouseWheel(object sender, MouseEventArgs e)
        {
            int volume = 0;
            int val = e.Delta / 10;
            volume = controlVolume.Value + val;
            if (val > 0)
            {
                if (volume > controlVolume.Maximum) volume = controlVolume.Maximum;
            }
            else
            {
                if (volume < controlVolume.Minimum) volume = controlVolume.Minimum;
            }
            controlVolume.Value = volume;
            Player.Volume = controlVolume.Value;
        }

        void Player_onPlayerKeyDown(string key)
        {
            if (key == "R")
            {
                if (tvChannels.Dock == DockStyle.Left)
                {
                    tvChannels.Dock = DockStyle.Right;
                }
                else
                {
                    tvChannels.Dock = DockStyle.Left;
                }
            }

            if (key == "L")
            {
                tvChannels.Visible = !tvChannels.Visible;
            }

            if (key == "C")
            {
                controlPanel.Visible = !controlPanel.Visible;
            }

            if (key == "G") // Show TV archive
            {
                OSD.ShowOSD(1);
            }

            if (key == "F") // OnFullScreen
            {
                Player.playerOnFullScreen();
            }

            if (key == "Escape") // Esc in full screen
            {
                if (Player.isFullScreen)
                {
                    Player.playerOnFullScreen();
                }
            }

            if ((key.StartsWith("NumPad") || key.StartsWith("D")) && key != "D") // Nums
            {
                int number = 0;
                if (key.StartsWith("NumPad"))
                {
                    string num = key.Substring(6, 1);
                    int.TryParse(num, out number);
                }

                if (key.StartsWith("D"))
                {
                    string num = key.Substring(1, 1);
                    int.TryParse(num, out number);
                }
                OSD.setSwitcherOSD(number);
            }

            if (key == "Back")
            {
                if (OSD.getVisibleOfOSD(6))
                {
                    OSD.setSwitcherOSD(-1);
                }
            }
        }

        private void FullScreenMode()
        {
            if (!Player.isFullScreen)
            {
                tvChannels.Hide();
                controlPanel.Hide();
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                tvChannels.Show();
                controlPanel.Show();
            }
        }

        void interfaceUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (firstInitialization)
            {
                try
                {
                    Player.Contrast = 100;
                    Player.Brightness = 100;
                    Player.Saturation = 100;
                    // VOLUME
                    int iVolume = 100;
                    if (int.TryParse(Configurator.getKeyFromGlobalSection("volume"), out iVolume))
                    {
                        if (iVolume == -2)
                        {
                            controlVolume.Value = 100;
                            Player.Mute();
                        }
                        if (iVolume >= 0)
                        {
                            // Set scroll on last channel
                            controlVolume.Value = iVolume;
                        }
                    }
                }
                catch
                {

                }
                firstInitialization = false;
            }

            try
            {

                if (!firstInitialization && !EPGs.threadBusyStatus && EPGs.Epgs[Channels.AllChannels[0]].Count <= 0)
                {
                    EPGs.updateEPGFromServer();
                }
            }
            catch
            {
                EPGs.updateEPGFromServer();
            }

            try
            {
                controlVolume.Value = Player.Volume;
            }
            catch
            {
                controlVolume.Value = 0;
            }

            if (Player.isPlaying)
            {
                pbPlayPauseBtn.ImageLocation = "images/1478525425_PAUSE24x24.png";
                паузаToolStripMenuItem.Checked = false;
            }
            else
            {
                pbPlayPauseBtn.ImageLocation = "images/1478525327_PLAY24x24.png";
                паузаToolStripMenuItem.Checked = true;
            }

            if (Player.isMute)
            {
                pbMuteBtn.ImageLocation = "images/1478526188_MUTE24x24.png";
                отключитьЗвукToolStripMenuItem.Checked = true;
            }
            else
            {
                pbMuteBtn.ImageLocation = "images/1478529204_MUTE_OFF.png";
                отключитьЗвукToolStripMenuItem.Checked = false;
            }

            if (Player.isFullScreen)
            {
                pbFullScreen.ImageLocation = "images/1479457519_fullscreen_exit.png";
            }
            else
            {
                pbFullScreen.ImageLocation = "images/1479457549_fullscreen.png";
            }

            if (tvChannels.Visible)
            {
                показатьСписокКаналовToolStripMenuItem.Checked = true;
            }
            else
            {
                показатьСписокКаналовToolStripMenuItem.Checked = false;
            }

            if (tvChannels.Dock == DockStyle.Left)
            {
                списокКаналовСлеваToolStripMenuItem.Checked = true;
            }
            else
            {
                списокКаналовСлеваToolStripMenuItem.Checked = false;
            }

            if (buffering)
            {
                TVStateLabel.Text = "Загрузка...";
                if (Player.isPlaying) 
                {
                    buffering = false;
                    postLoadingTimer.Start();
                }
            }
            else
            {
                if ((Channels.currentPlayingChannel.Id > 0 || EPGs.currentPlayingEPGInArchive.Id > 0) && Player.isPlaying)
                {
                    TVStateLabel.Text = Channels.currentPlayingChannel.Number + ". " + Channels.currentPlayingChannel.Name;
                    if (Player.playingFromArchive)
                    {
                        TVStateLabel.Text += ": ТВ-архив";
                        if (!pb_ToOnline.Visible)
                        {
                            //videoPositionTime.Location = new Point(pb_ToOnline.Location.X - 5, videoPositionTime.Location.Y);
                            pb_ToOnline.Show();
                        }
                    }
                    else
                    {
                        TVStateLabel.Text += ": Онлайн";
                        if (pb_ToOnline.Visible)
                        {
                            pb_ToOnline.Hide();
                            //videoPositionTime.Location = new Point(pbFullScreen.Location.X - 5, videoPositionTime.Location.Y);
                        }
                    }

                    videoPositionTime.Text = Player.Time;

                    try
                    {
                        if (Player.playingFromArchive)
                        {
                            if (!progressBarInFocus)
                            {
                                videoPosition.Value = Player.Position;
                            }
                        }
                        else
                        {
                            videoPosition.Value = Player.Position;
                        }
                    }
                    catch
                    {
                        videoPosition.Value = 0;
                    }
                }
                else
                {
                    TVStateLabel.Text = "";
                }
            }
            if (Player.isFullScreen)
            {
                toolStripMenuItem2.Checked = true;
            }
            else
            {
                toolStripMenuItem2.Checked = false;
            }

            if (API.isAuth)
            {
                Interface.setProgressPercent(tvChannels);
            }
            
            OSD.ShowOSD(5); // Update EPG OSD
        }

        private void tvPlayer_Resize(object sender, EventArgs e)
        {
            Player.Resize(tvPlayer.Width, tvPlayer.Height);
        }

        private void controlVolume_MouseMove(object sender, MouseEventArgs e)
        {
            controlVolume.Focus();
        }

        private void pbOpenSettings_Click(object sender, EventArgs e)
        {
            wProperties.getConfigureWindow(Channels.currentPlayingChannel);
        }

        private void pbOpenTVProgramm_Click(object sender, EventArgs e)
        {
            OSD.ShowOSD(1);
        }

        private void pbPlayPauseBtn_Click(object sender, EventArgs e)
        {
            Player.Pause();
        }

        private void videoPosition_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseF();
        }

        private void pbStopBtn_Click(object sender, EventArgs e)
        {
            Player.Stop();
        }

        private void pbMuteBtn_Click(object sender, EventArgs e)
        {
            Player.Mute();
        }

        private void controlVolume_Change(object sender, EventArgs e)
        {
            Player.Volume = controlVolume.Value;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Player.playerOnFullScreen();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OSD.ShowOSD(1);
        }

        private void настройкиКаналаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wProperties.getConfigureWindow(Channels.currentPlayingChannel);
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Pause();
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Stop();
        }

        private void отключитьЗвукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.Mute();
        }

        private void pbFullScreen_Click(object sender, EventArgs e)
        {
            Player.playerOnFullScreen();
        }

        private void обновитьТелепрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EPGs.updateEPGFromServer();
        }

        private void настройкиПроигрывателяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            glWProperties.getGlobalConfigureWindow();
        }

        private void показатьСписокКаналовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvChannels.Visible = !tvChannels.Visible;
        }

        private void списокКаналовСлеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvChannels.Dock == DockStyle.Right)
            {
                tvChannels.Dock = DockStyle.Left;
            }
            else
            {
                tvChannels.Dock = DockStyle.Right;
            }
        }

        private void pb_ToOnline_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вернуться в режим онлайн просмотра?", "ТВ-архив", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Interface.switchChannel(null, Channels.currentPlayingChannel.Number);
            }
        }

        private void CloseF()
        {
            if (Player.isPlaying)
            {
                Player.Pause();
            }

            if (Player.Volume > 0)
            {
                if (Player.isMute)
                {
                    Configurator.writeToGlobalSection("volume", "-2");
                }
                else
                {
                    Configurator.writeToGlobalSection("volume", Player.Volume.ToString());
                }
            }
            else
            {
                Configurator.writeToGlobalSection("volume", "0");
            }

            if (tvChannels.Dock == DockStyle.Left)
            {
                Configurator.writeToGlobalSection("left", "1");
            }
            else
            {
                Configurator.writeToGlobalSection("left", "0");
            }

            if (Channels.currentPlayingChannel.Number >= 0)
            {
                if (Channels.currentPlayingChannel.Censored == 1)
                {
                    Configurator.writeToGlobalSection("lastchannel", "0");
                }
                else
                {
                    Configurator.writeToGlobalSection("lastchannel", Channels.currentPlayingChannel.Number.ToString());
                }
            }
            else
            {
                Configurator.writeToGlobalSection("lastchannel", "-1");
            }

            if (Channels.currentPlayingChannel.Id > 0)
            {
                for (int i = 0; i < Channels.AllChannels.Count; i++)
                {
                    if (Channels.currentPlayingChannel.Id == Channels.AllChannels[i].Id)
                    {
                        Configurator.writeToGlobalSection("lastchannelid", i.ToString());
                        break;
                    }
                }
            }
            API.deleteMediaInfo();
            Logger.Write(Logger.LogLevel.INFO, "===== Закрытие приложения =====");
            LoadingWindow.loadWindow.Dispose();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.CloseF();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wAbout.ShowDialog();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            LoadingWindow.loadWindow.Hide();
        }

        private void videoPosition_MouseUp(object sender, MouseEventArgs e)
        {
            Player.SetPosition(videoPosition.Value);
        }

        private void videoPosition_MouseEnter(object sender, EventArgs e)
        {
            progressBarInFocus = true;
        }

        private void videoPosition_MouseLeave(object sender, EventArgs e)
        {
            progressBarInFocus = false;
        }
    }
}
