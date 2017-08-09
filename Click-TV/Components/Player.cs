using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Vlc;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;
using System.Threading;

namespace Click_TV
{
    class Player
    {
        private static VlcControl _player = new VlcControl();
        private static DoubleBufferedPanel _fullScreenPanel = new DoubleBufferedPanel();

        public delegate void OnFullScreenDelegate();
        public static event OnFullScreenDelegate onFullScreen;

        public delegate void OnPlayerKeyDown(string e);
        public static event OnPlayerKeyDown onPlayerKeyDown;

        public delegate void OnMouseMoveOnVideoPanel(MouseEventArgs e);
        public static event OnMouseMoveOnVideoPanel onMouseMoveOnVideoPanel;

        public delegate void OnPlayerError();
        public static event OnPlayerError onPlayerError;

        public delegate void OnPlayerBuffering();
        public static event OnPlayerBuffering onPlayerBuffering;

        public static bool isFullScreen = false;
        private static bool isPlayingFromArchive = false;

        public static bool playingFromArchive
        {
            get
            {
                return isPlayingFromArchive;
            }
        }

        public static int Position
        {
            get
            {
                if (Channels.currentPlayingChannel.Id > 0)
                {
                    if (isPlayingFromArchive)
                    {
                        return (int)(_player.Position * 10000);
                    }
                    else
                    {
                        return EPGs.getCurrentShowPosition(Channels.currentPlayingChannel);
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public static float Length
        {
            get
            {
                return _player.Position;
            }
        }

        public static int Volume
        {
            get
            {
                try
                {
                    return _player.Audio.Volume;
                }
                catch
                {
                    return 0;
                }
            }

            set
            {
                try
                {
                    _player.Audio.Volume = value;
                }
                catch
                {}
            }
        }

        public static string Time
        {
            get
            {
                try
                {
                    if (!Player.playingFromArchive)
                    {
                        // get length
                        long length = EPGs.getCurrentShow(Channels.currentPlayingChannel).End - EPGs.getCurrentShow(Channels.currentPlayingChannel).Start;
                        long current = UnixTime.getUnixTimeStamp(DateTime.UtcNow) - EPGs.getCurrentShow(Channels.currentPlayingChannel).Start;

                        float percent = (current * 100.0f) / length;

                        // get start in normal time format
                        DateTime startTime = UnixTime.UnixTimeStampToDateTime(EPGs.getCurrentShow(Channels.currentPlayingChannel).Start);
                        DateTime endTime = UnixTime.UnixTimeStampToDateTime(EPGs.getCurrentShow(Channels.currentPlayingChannel).End);
                        TimeSpan span = endTime - startTime;

                        // get current position
                        double value = (span.TotalSeconds * (percent * 100) / 10000);
                        return string.Format("{0:00}:{1:00}:{2:00}", (int)TimeSpan.FromSeconds(value).TotalHours, TimeSpan.FromSeconds(value).Minutes, TimeSpan.FromSeconds(value).Seconds) + " / " + string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
                    }
                    else
                    {
                        // get start & end time of archive TV
                        DateTime startTime = UnixTime.UnixTimeStampToDateTime(EPGs.currentPlayingEPGInArchive.Start);
                        DateTime endTime = UnixTime.UnixTimeStampToDateTime(EPGs.currentPlayingEPGInArchive.End);
                        TimeSpan span = endTime - startTime;

                        // get current position
                        double value = span.TotalSeconds * _player.Position;
                        return string.Format("{0:00}:{1:00}:{2:00}", (int)TimeSpan.FromSeconds(value).TotalHours, TimeSpan.FromSeconds(value).Minutes, TimeSpan.FromSeconds(value).Seconds) + " / " + string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);
                    }
                }
                catch
                {
                    return "00:00:00 / 00:00:00";
                }
            }
        }

        /// Image parameters
        public static float Contrast
        {
            set
            {
                _player.Video.Adjustments.Contrast = value;
            }
        }

        public static float Brightness
        {
            set
            {
                _player.Video.Adjustments.Brightness = value;
            }
        }

        public static float Saturation
        {
            set
            {
                _player.Video.Adjustments.Saturation = value;
            }
        }

        public static bool isPlaying
        {
            get
            {
                return _player.IsPlaying;
            }
        }

        public static bool isMute
        {
            get
            {
                try
                {
                    return _player.Audio.IsMute;
                }
                catch { return false; }
            }
        }

        private static void OnVlcControlNeedsLibDirectory(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            Assembly currentAssembly = Assembly.GetEntryAssembly();
            string currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
            {
                return;
            }
            e.VlcLibDirectory = new DirectoryInfo(System.IO.Path.Combine(currentDirectory, @"lib\"));
        }

        public static void Init(Panel control)
        {
            _player.VlcMediaplayerOptions = new[] { "--network-caching=3000" };
            Logger.Write(Logger.LogLevel.INFO, "Инициализация плеера.");
            _player.VlcLibDirectoryNeeded += OnVlcControlNeedsLibDirectory;
            _player.Size = new Size(control.Size.Width, control.Size.Height);
            _player.EndInit();

            Logger.Write(Logger.LogLevel.INFO, "Инициализация плеера завершена успешно.");

            control.Controls.Add(_player);

            _player.Buffering += new EventHandler<VlcMediaPlayerBufferingEventArgs>(Buffering);
            _player.EncounteredError += new EventHandler<VlcMediaPlayerEncounteredErrorEventArgs>(PlayerError);

            _fullScreenPanel.BackColor = Color.Black;
            _fullScreenPanel.BackgroundImage = Image.FromFile("images/image.jpg");
            _fullScreenPanel.BackgroundImageLayout = ImageLayout.Zoom;
            _fullScreenPanel.Size = new Size(control.Size.Width, control.Size.Height);
            _fullScreenPanel.MouseDoubleClick += new MouseEventHandler((s, e) => { playerOnFullScreen(); });
            _fullScreenPanel.PreviewKeyDown += new PreviewKeyDownEventHandler(_fullScreenPanel_PreviewKeyDown);
            _fullScreenPanel.MouseMove += new MouseEventHandler(_fullScreenPanel_MouseMove);
            _fullScreenPanel.MouseWheel += new MouseEventHandler(_fullScreenPanel_MouseWheel);
            _fullScreenPanel.MouseClick += new MouseEventHandler(_fullScreenPanel_MouseClick);
            _player.Controls.Add(_fullScreenPanel);
            _fullScreenPanel.BringToFront();
        }

        static void EndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            //MessageBox.Show("End Reached!");
        }

        static void Buffering(object sender, VlcMediaPlayerBufferingEventArgs e)
        {
            onPlayerBuffering();
        }

        static void PlayerError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            onPlayerError();
        }

        static void _fullScreenPanel_MouseClick(object sender, MouseEventArgs e)
        {
            // if osd tv archive active ...
            // get osd visiable status 
            if (OSD.getVisibleOfOSD(1))
            {
                OSD.ShowOSD(1); // hide it
            }

            OSD.ShowOSD(2);
            OSD.ShowOSD(3);
            OSD.ShowOSD(4);
        }

        private static void initializeBeforePlay(Channel content)
        {
            /* Initialize BEFORE play */
            string deinterlace = Configurator.getKeyFromSection("deinterlace", content.Id.ToString());
            string aspectRatio = Configurator.getKeyFromSection("aspectRatio", content.Id.ToString());

            if (String.IsNullOrEmpty(deinterlace) || String.IsNullOrEmpty(aspectRatio))
            {
                deinterlace = Configurator.getKeyFromGlobalSection("deinterlace");
                aspectRatio = Configurator.getKeyFromGlobalSection("aspectRatio");
            }
            int iDeinterlace = 0, iAspectRatio = 0;
            int.TryParse(deinterlace, out iDeinterlace);
            int.TryParse(aspectRatio, out iAspectRatio);


            Player.SetDeinterlace(iDeinterlace);
            Player.SetAspectRatio(iAspectRatio);
        }

        private static void initializeAfterPlay(Channel content)
        {
            if (OSD.getVisibleOfOSD(1)) { OSD.ShowOSD(1); OSD.ShowOSD(1); }
            string audiotrack = Configurator.getKeyFromSection("audiotrack", content.Id.ToString());
            if (String.IsNullOrEmpty(audiotrack))
            {
                audiotrack = Configurator.getKeyFromGlobalSection("audiotrack");
            }
            int iTrackNumber = 1;
            int.TryParse(audiotrack, out iTrackNumber);
            Player.setAudioChannel((iTrackNumber + 1));

            string contrast = Configurator.getKeyFromSection("contrast", content.Id.ToString());
            string brightness = Configurator.getKeyFromSection("brightness", content.Id.ToString());
            string saturation = Configurator.getKeyFromSection("saturation", content.Id.ToString());

            if (String.IsNullOrEmpty(contrast) || String.IsNullOrEmpty(brightness) || String.IsNullOrEmpty(saturation))
            {
                contrast = Configurator.getKeyFromGlobalSection("contrast");
                brightness = Configurator.getKeyFromGlobalSection("brightness");
                saturation = Configurator.getKeyFromGlobalSection("saturation");
            }

            /* Set it */
            int iContrast = 100, iBrightness = 100, iSaturation = 100;


            int.TryParse(contrast, out iContrast);
            int.TryParse(brightness, out iBrightness);
            int.TryParse(saturation, out iSaturation);

            Player.Contrast = iContrast;
            Player.Brightness = iBrightness;
            Player.Saturation = iSaturation;

            OSD.ShowLoadOSD(false);
        }

        public static void Play(Channel content)
        {
            if ( _player.IsPlaying ) _player.Stop();
            OSD.ShowLoadOSD(true);
            string url = content.Url;
            if (String.IsNullOrEmpty(url))
            {
                url = API.getVideoLink(content);
            }

            if (!String.IsNullOrEmpty(url))
            {
                _fullScreenPanel.BackColor = Color.Transparent;
                _fullScreenPanel.BackgroundImage = null;

                isPlayingFromArchive = false;
                Channels.currentPlayingChannel = content;
                initializeBeforePlay(content);
                _player.SetMedia(url);
                _player.Play();
                OSD.ShowOSD(2);
                OSD.ShowOSD(3);
                OSD.ShowOSD(4);
                API.sendMediaInfo(API.MediaINFOTypes.TVChannel, content.Id.ToString());
                initializeAfterPlay(content);
            }
        }

        public static void Play(EPG content)
        {
            string url = API.getTVArchiveLink(content);
            if (!String.IsNullOrEmpty(url))
            {
                _fullScreenPanel.BackColor = Color.Transparent;
                _fullScreenPanel.BackgroundImage = null;

                isPlayingFromArchive = true;
                EPGs.currentPlayingEPGInArchive = content;
                _player.SetMedia(url);
                _player.Play();
                OSD.ShowOSD(2);
                OSD.ShowOSD(3);
                OSD.ShowOSD(4);
                API.sendMediaInfo(API.MediaINFOTypes.TVArchive, content.Id.ToString());
            }
        }

        public static void SetPosition(int position)
        {
            if (isPlayingFromArchive)
            {
                _player.Position = position / 10000.0f;
            }
        }

        public static void SetDeinterlace(int id)
        {
            switch (id)
            {
                case 0: // None
                    _player.Video.Deinterlace = null;
                    break;

                case 1: // Blend
                    _player.Video.Deinterlace = "blend";
                    break;

                case 2: // Mean
                    _player.Video.Deinterlace = "mean";
                    break;

                case 3: // Bob
                    _player.Video.Deinterlace = "bob";
                    break;

                case 4: // Linear
                    _player.Video.Deinterlace = "linear";
                    break;

                case 5: // X
                    _player.Video.Deinterlace = "x";
                    break;

                case 6: // Discard
                    _player.Video.Deinterlace = "discard";
                    break;

                case 7: // Yadif
                    _player.Video.Deinterlace = "yadif";
                    break;

                case 8: // Yadif2x
                    _player.Video.Deinterlace = "yadif2x";
                    break;
            }

        }

        public static void SetAspectRatio(int id)
        {
            switch (id)
            {
                case 0: // None
                    _player.Video.AspectRatio = null;
                    break;

                case 1: // 1:1
                    _player.Video.AspectRatio = "1:1";
                    break;

                case 2: // 4:3
                    _player.Video.AspectRatio = "4:3";
                    break;

                case 3: // 16:9
                    _player.Video.AspectRatio = "16:9";
                    break;

                case 4: // 16:10
                    _player.Video.AspectRatio = "16:10";
                    break;

                case 5: // 14:9
                    _player.Video.AspectRatio = "14:9";
                    break;

                case 6: // 221:100
                    _player.Video.AspectRatio = "221:100";
                    break;

                case 7: // 5:4
                    _player.Video.AspectRatio = "5:4";
                    break;
            }
        }

        public static void Resize(int x, int y)
        {
            _player.Size = new Size(x, y);
            _fullScreenPanel.Size = new Size(x, y);
        }

        public static void ChangeAudioTrack(int id)
        {
            _player.Audio.Tracks.Current = _player.Audio.Tracks.All.ElementAt(id);
        }

        public static void playerOnFullScreen()
        {
            try
            {
                onFullScreen();
                isFullScreen = !isFullScreen;
            }
            catch
            {

            }
        }

        public static void Pause()
        {
            if (Player.isPlaying)
            {
                _player.Pause();
            }
            else
            {
                if (!playingFromArchive)
                {
                    Play(Channels.currentPlayingChannel);
                }
                else
                {
                    _player.Play();
                }
            }
        }

        private static void _fullScreenPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            onPlayerKeyDown(e.KeyCode.ToString());
        }

        static void _fullScreenPanel_MouseMove(object sender, MouseEventArgs e)
        {
            onMouseMoveOnVideoPanel(e);
            if ( !_fullScreenPanel.Focused ) _fullScreenPanel.Focus();
        }

        static void _fullScreenPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int val = e.Delta / 10 + Volume;
            if (val > 200) val = 200;
            if (val < 0) val = 0;
            Volume = val;

            // Show current volume on OSD
            OSD.setVolumeOSD(val);
        }

        public static void Stop()
        {
            _fullScreenPanel.BackgroundImage = Image.FromFile("images/image.jpg");
            if (_player.IsPlaying)
            {
                _player.Stop();
            }
        }

        public static void Mute()
        {
            try
            {
                _player.Audio.ToggleMute();
            }
            catch
            {

            }
        }

        public static void setAudioChannel(int i)
        {
            if ( i < _player.Audio.Tracks.Count )
                _player.Audio.Tracks.Current = _player.Audio.Tracks.All.ElementAt(i);
        }
    }
}