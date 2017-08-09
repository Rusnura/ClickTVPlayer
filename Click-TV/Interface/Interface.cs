using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MetroFramework.Controls;
using System.ComponentModel;

namespace Click_TV
{
    public class Interface
    {
        private static Panel _displayPanel;
        private static int _selectedChannelItemID = -1;
        private static Timer _pingTimer = new Timer();

        // This is worker shows the channels position in seconds thread
        private static BackgroundWorker _positionViewer = new BackgroundWorker();

        public static void Init(Panel control)
        {
            // Logger subsystem init...
            Logger.Init();

            // Autorizate in API server...
            API.Auth();

            // Init player...
            Logger.Write(Logger.LogLevel.INFO, "API::Auth выполнен успешно.");

            Player.Init(control);
            Logger.Write(Logger.LogLevel.INFO, "Player::Init выполнен успешно.");

            // Init a channels...
            Channels.Init();
            Logger.Write(Logger.LogLevel.INFO, "Channels::Init выполнен успешно.");

            // Init an EPGs (warning: Thread)...
            EPGs.Init();
            Logger.Write(Logger.LogLevel.INFO, "EPGs::Init выполнен успешно.");

            // Init the ping
            Logger.Write(Logger.LogLevel.INFO, "Timer::Ping::Init.");
            _pingTimer.Tick += new EventHandler(_pingTimer_Tick);
            _pingTimer.Interval = 70000;
            _pingTimer.Enabled = true;

            // Send first ping
            API.sendPing();

            // Write message to log
            Logger.Write(Logger.LogLevel.INFO, "Timer::Ping::Init выполнен успшено.");

            // Init background thread
            _positionViewer.WorkerSupportsCancellation = true;
            _positionViewer.DoWork += new DoWorkEventHandler(_positionViewer_DoWork);
        }

        static void _positionViewer_DoWork(object sender, DoWorkEventArgs e)
        {
            Panel control = e.Argument as Panel;

            if (EPGs.Epgs.Count > 0)
            {
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    int id = int.Parse(control.Controls[i].Name.Split('_')[1]);
                    if ( EPGs.Epgs.ContainsKey(Channels.AllChannels[id]) )
                    {
                        if (control.Controls[i].Name.StartsWith("pbChannelShowPosition_"))
                        {
                            MetroProgressBar bar = (MetroProgressBar)control.Controls[i];
                            bar.Invoke(new Action<int>((iV) => { bar.Value = iV; }), EPGs.getCurrentShowPosition(Channels.AllChannels[id]));
                        }
                        else if (control.Controls[i].Name.StartsWith("pbChannelProgram_"))
                        {
                            Label lProgrammName = (Label)control.Controls[i];
                            lProgrammName.Invoke(new Action<string>((s) => { lProgrammName.Text = s; }), EPGs.getCurrentShow(Channels.AllChannels[id]).Name);
                        }
                        else if (control.Controls[i].Name.StartsWith("pbChannelStartProgramTime_"))
                        {
                            Label lProgrammTime = (Label)control.Controls[i];
                            lProgrammTime.Invoke(new Action<string>((s) => { lProgrammTime.Text = s; }), UnixTime.UnixTimeStampToDateTime(EPGs.getCurrentShow(Channels.AllChannels[id]).Start).ToShortTimeString());
                        }
                        else if (control.Controls[i].Name.StartsWith("pbChannelEndProgramTime_"))
                        {
                            Label lProgrammTime = (Label)control.Controls[i];
                            lProgrammTime.Invoke(new Action<string>((s) => { lProgrammTime.Text = s; }), UnixTime.UnixTimeStampToDateTime(EPGs.getCurrentShow(Channels.AllChannels[id]).End).ToShortTimeString());
                        }
                    }
                }
            }
        }

        static void _pingTimer_Tick(object sender, EventArgs e)
        {
            API.sendPing();
            try
            {
                ServiceMessage message = API.getMessage();
                if (message.Type == "send_msg")
                {
                    if (message.Message == "Tariff plan is changed, please restart your STB")
                    {
                        MessageBox.Show("Ваш тарифный план изменился. Приложение будет перезапущено после нажатия на кнопку 'OK'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Restart();
                    }
                    else
                    {
                        string replaced = message.Message.Replace("<br>", "\n");
                        replaced = replaced.Replace("<br/>", "\n");
                        replaced = replaced.Replace("<br />", "\n");
                        MessageBox.Show(replaced, "Получено новое сообщение [" + UnixTime.UnixTimeStampToDateTime(int.Parse(message.Time)) + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (message.Type == "reboot") Application.Restart();
                if (message.Type == "update_channels") EPGs.updateEPGFromServer();
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "Не удалось получить message от сервера: " + ex.Message);
            }
        }

        public static void DisplayChannels(Panel control)
        {
            _displayPanel = control;
            int channelsCount = Channels.AllChannels.Count;
            int widthOfBox = control.Width;
            int heightOfBox = 60;
            control.BackColor = System.Drawing.Color.Black;
            /// Panels
            for (int i = 0; i < channelsCount; i++)
            {
                Panel bgPanel = new Panel();
                bgPanel.Name = "bgPanel_" + i;
                if (i % 2 == 0) 
                {
                    bgPanel.BackColor = Color.Black;
                }
                else 
                {
                    bgPanel.BackColor = Color.FromArgb(16, 16, 16);
                }
                bgPanel.Location = new System.Drawing.Point(0, i * heightOfBox);
                bgPanel.Size = new System.Drawing.Size(control.Size.Width - 17, heightOfBox);
                bgPanel.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                bgPanel.MouseMove += new MouseEventHandler((sender, e) => { _displayPanel.Focus(); });
                control.Controls.Add(bgPanel);
            }

            /// PictureBoxes
            for (int i = 0; i < channelsCount; i++)
            {
                PictureBox pbLogo = new PictureBox();
                pbLogo.Name = "pbLogo_" + i;
                if (i % 2 == 0)
                {
                    pbLogo.BackColor = Color.Black;
                }
                else
                {
                    pbLogo.BackColor = Color.FromArgb(16, 16, 16);
                }
                pbLogo.Location = new System.Drawing.Point(0, i * heightOfBox);
                pbLogo.Size = new System.Drawing.Size(50, heightOfBox);
                pbLogo.SizeMode = PictureBoxSizeMode.CenterImage;
                pbLogo.ErrorImage = Image.FromFile("images/errlogo.png");
                pbLogo.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                pbLogo.MouseMove += new MouseEventHandler((sender, e) => { _displayPanel.Focus(); });
                control.Controls.Add(pbLogo);
                pbLogo.BringToFront();
                pbLogo.LoadAsync(API.imagesHost + Channels.AllChannels[i].Logo);
            }

            /// Labels: ChannelName
            for (int i = 0; i < channelsCount; i++)
            {
                Label channelName = new Label();
                channelName.Name = "pbChannelNameLabel_" + i;
                if (i % 2 == 0)
                {
                    channelName.BackColor = Color.Black;
                }
                else
                {
                    channelName.BackColor = Color.FromArgb(16, 16, 16);
                }
                channelName.AutoEllipsis = true;
                channelName.Location = new System.Drawing.Point(55, i * heightOfBox + 5);
                channelName.Size = new System.Drawing.Size(240/*180*/, 20);
                channelName.Font = new Font("Tahoma", 13.0f, FontStyle.Bold);
                channelName.ForeColor = System.Drawing.Color.White;
                channelName.Text = Channels.AllChannels[i].Number + ". " + Channels.AllChannels[i].Name;
                channelName.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                channelName.MouseMove += new MouseEventHandler((sender, e) => { _displayPanel.Focus(); });
                control.Controls.Add(channelName);
                channelName.BringToFront();
            }

            /// Label: ChannelProgrammStartTime
            for (int i = 0; i < channelsCount; i++)
            {
                Label channelProgram = new Label();
                channelProgram.Name = "pbChannelStartProgramTime_" + i;
                if (i % 2 == 0)
                {
                    channelProgram.BackColor = Color.Black;
                }
                else
                {
                    channelProgram.BackColor = Color.FromArgb(16, 16, 16);
                }
                channelProgram.ForeColor = System.Drawing.Color.White;
                channelProgram.Location = new System.Drawing.Point(52, i * heightOfBox + 23);
                channelProgram.Size = new System.Drawing.Size(40, 20);
                channelProgram.Font = new Font("Tahoma", 9.0f, FontStyle.Regular);
                channelProgram.Text = "";
                channelProgram.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                channelProgram.MouseMove += new MouseEventHandler((sender, e) => { _displayPanel.Focus(); });

                control.Controls.Add(channelProgram);
                channelProgram.BringToFront();
            }

            /// Position: 
            for (int i = 0; i < channelsCount; i++)
            {
                MetroProgressBar pbPosition = new MetroProgressBar();
                pbPosition.Name = "pbChannelShowPosition_" + i;
                pbPosition.BackColor = System.Drawing.Color.Black;
                pbPosition.Style = MetroFramework.MetroColorStyle.Brown;
                pbPosition.Location = new System.Drawing.Point(89, i * heightOfBox + 28);
                pbPosition.Size = new System.Drawing.Size(180/*120*/, 5);
                pbPosition.Minimum = 0;
                pbPosition.Maximum = 10000;
                pbPosition.Value = 0;
                pbPosition.Visible = true;
                pbPosition.MouseClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                control.Controls.Add(pbPosition);
                pbPosition.BringToFront();
            }

            /// Label: ChannelProgrammEndTime
            for (int i = 0; i < channelsCount; i++)
            {
                Label channelProgram = new Label();
                channelProgram.Name = "pbChannelEndProgramTime_" + i;
                if (i % 2 == 0)
                {
                    channelProgram.BackColor = Color.Black;
                }
                else
                {
                    channelProgram.BackColor = Color.FromArgb(16, 16, 16);
                }
                channelProgram.ForeColor = System.Drawing.Color.White;
                channelProgram.Location = new System.Drawing.Point(270/*210*/, i * heightOfBox + 23);
                channelProgram.Size = new System.Drawing.Size(40, 20);
                channelProgram.Font = new Font("Tahoma", 9.0f, FontStyle.Regular);
                channelProgram.Text = "";
                channelProgram.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                control.Controls.Add(channelProgram);
                channelProgram.BringToFront();
            }

            /// Labels: ChannelProgramm
            for (int i = 0; i < channelsCount; i++)
            {
                Label channelProgram = new Label();
                channelProgram.Name = "pbChannelProgram_" + i;
                if (i % 2 == 0)
                {
                    channelProgram.BackColor = Color.Black;
                }
                else
                {
                    channelProgram.BackColor = Color.FromArgb(16, 16, 16);
                }
                channelProgram.AutoEllipsis = true;
                channelProgram.ForeColor = System.Drawing.Color.White;
                channelProgram.Location = new System.Drawing.Point(55, i * heightOfBox + 35);
                channelProgram.Size = new System.Drawing.Size(240/*180*/, 15);
                channelProgram.Font = new Font("Tahoma", 9.0f, FontStyle.Regular);
                channelProgram.Text = "";
                channelProgram.MouseDoubleClick += new MouseEventHandler((sender, e) => { switchChannel(sender); });
                control.Controls.Add(channelProgram);
                channelProgram.BringToFront();
            }
        }

        /// Switch channel method
        public static void switchChannel(object sender, int ch_id = -1)
        {
            int id = -1;
            if (ch_id < 0)
            {
                Control control = (Control)sender;
                id = int.Parse(control.Name.Split('_')[1]);
            }
            else
            {
                bool found = false;
                // Search channel with id
                for (int i = 0; i < Channels.AllChannels.Count; i++)
                {
                    if (ch_id == Channels.AllChannels[i].Number)
                    {
                        id = i;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    id = -1;
                }
            }

            if (id > -1)
            {
                if (Channels.AllChannels[id].Censored == 1)
                {
                    Player.Pause();

                    PasswordProtector passwordForm = new PasswordProtector();
                    passwordForm.ShowDialog();

                    if (passwordForm.getPassword())
                    {
                        Play(id);
                    }
                    else
                    {
                        //MessageBox.Show("Неверный пароль!", "Ошибка аутентификации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Player.Pause();
                    }
                    
                }
                else
                {
                    Player.Pause();
                    Play(id);
                }
            }
        }

        private static void Play(int id)
        {
            // Return old channel
            if (_selectedChannelItemID > -1)
            {
                _displayPanel.Controls.Find("bgPanel_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbLogo_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbChannelNameLabel_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbChannelNameLabel_" + _selectedChannelItemID, true)[0].ForeColor = System.Drawing.Color.White;
                _displayPanel.Controls.Find("pbChannelStartProgramTime_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbChannelStartProgramTime_" + _selectedChannelItemID, true)[0].ForeColor = System.Drawing.Color.White;

                ((MetroProgressBar)_displayPanel.Controls.Find("pbChannelShowPosition_" + _selectedChannelItemID, true)[0]).Style = MetroFramework.MetroColorStyle.Brown;

                _displayPanel.Controls.Find("pbChannelEndProgramTime_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbChannelEndProgramTime_" + _selectedChannelItemID, true)[0].ForeColor = System.Drawing.Color.White;
                _displayPanel.Controls.Find("pbChannelProgram_" + _selectedChannelItemID, true)[0].BackColor = (_selectedChannelItemID % 2 == 0) ? Color.Black : Color.FromArgb(16, 16, 16);
                _displayPanel.Controls.Find("pbChannelProgram_" + _selectedChannelItemID, true)[0].ForeColor = System.Drawing.Color.White;
            }
            _selectedChannelItemID = id;

            // Set channel background
            _displayPanel.Controls.Find("bgPanel_" + id, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbLogo_" + id, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbChannelNameLabel_" + _selectedChannelItemID, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbChannelNameLabel_" + _selectedChannelItemID, true)[0].ForeColor = Color.Black;
            _displayPanel.Controls.Find("pbChannelStartProgramTime_" + _selectedChannelItemID, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbChannelStartProgramTime_" + _selectedChannelItemID, true)[0].ForeColor = Color.Black;

            ((MetroProgressBar)_displayPanel.Controls.Find("pbChannelShowPosition_" + _selectedChannelItemID, true)[0]).Style = MetroFramework.MetroColorStyle.Silver;

            _displayPanel.Controls.Find("pbChannelEndProgramTime_" + _selectedChannelItemID, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbChannelEndProgramTime_" + _selectedChannelItemID, true)[0].ForeColor = Color.Black;
            _displayPanel.Controls.Find("pbChannelProgram_" + _selectedChannelItemID, true)[0].BackColor = Color.FromArgb(203, 218, 233);
            _displayPanel.Controls.Find("pbChannelProgram_" + _selectedChannelItemID, true)[0].ForeColor = Color.Black;

            Timer _startTimer = new Timer();
            _startTimer.Interval = 250;
            _startTimer.Tick += new EventHandler((sender, e) => { Player.Play(Channels.AllChannels[id]); _startTimer.Dispose(); });
            _startTimer.Start();
        }

        public static void setProgressPercent(Panel control)
        {
            if (!_positionViewer.IsBusy)
            {
                _positionViewer.RunWorkerAsync(control);
            }
        }
    }
}
