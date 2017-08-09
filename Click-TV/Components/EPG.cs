using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Click_TV
{
    public class EPGs
    {
        // TV programs of channels:
        private static Dictionary<Channel, Dictionary<int, EPG>> _epg = new Dictionary<Channel, Dictionary<int, EPG>>();

        // Thread for get all TV program:
        private static BackgroundWorker _getEPGThread = new BackgroundWorker();

        // Get all programs:
        public static Dictionary<Channel, Dictionary<int, EPG>> Epgs
        {
            get
            {
                return _epg;
            }
        }

        // Thread status 
        public static bool threadBusyStatus
        {
            get
            {
                return _getEPGThread.IsBusy;
            }

        }

        // Current playing EPG(if archive is enabled)
        public static EPG currentPlayingEPGInArchive = new EPG();

        // Thread method for get all TV programs:
        private static void _getAllEPGs(object sender, DoWorkEventArgs e)
        {
            StreamWriter tmpFileWritter = new StreamWriter("tmp.epg", false);
            try
            {
                Logger.Write(Logger.LogLevel.WARNING, "[КРИТИЧЕСКАЯ СЕКЦИЯ] Начало получения EPG.");
                // If dictionary isn't empty, clear it:
                if (_epg.Count > 0)
                {
                    _epg.Clear();
                }
                tmpFileWritter.WriteLine(DateTime.Today.ToShortDateString());

                // Fill the dictionary of EPGs:
                foreach (Channel _currentChannel in Channels.AllChannels.Values)
                {
                    Dictionary<int, EPG> _channelEPGs = new Dictionary<int, EPG>();
                    foreach (EPG _currentEPG in API.getTVProgram(_currentChannel, UnixTime.getUnixTimeStamp(DateTime.Today), UnixTime.getUnixTimeStamp(DateTime.Today.AddDays(1))))
                    {
                        _channelEPGs.Add(_channelEPGs.Count, _currentEPG);
                    }
                    _epg.Add(_currentChannel, _channelEPGs);
                }
                Logger.Write(Logger.LogLevel.WARNING, "[КРИТИЧЕСКАЯ СЕКЦИЯ] Выход из критической секции 'Получение EPG'.");

                Logger.Write(Logger.LogLevel.WARNING, "[КРИТИЧЕСКАЯ СЕКЦИЯ] Начало кэширования EPG.");
                foreach (var _current in _epg)
                {
                    tmpFileWritter.WriteLine("CH:" + _current.Key.Id);
                    foreach (var __currentEPG in _current.Value)
                    {
                        tmpFileWritter.WriteLine("PG:" + __currentEPG.Key);
                        tmpFileWritter.WriteLine("ID:" + __currentEPG.Value.Id);
                        tmpFileWritter.WriteLine("NM:" + __currentEPG.Value.Name);
                        tmpFileWritter.WriteLine("ST:" + __currentEPG.Value.Start);
                        tmpFileWritter.WriteLine("EN:" + __currentEPG.Value.End);
                        tmpFileWritter.WriteLine("DW:" + __currentEPG.Value.Downloadable);
                        tmpFileWritter.WriteLine("IA:" + __currentEPG.Value.inArchive);
                    }
                }
                Logger.Write(Logger.LogLevel.WARNING, "[КРИТИЧЕСКАЯ СЕКЦИЯ] Выход из критической секции 'Кэширование EPG'.");
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "[КРИТИЧЕСКАЯ СЕКЦИЯ 'Получение EPG'] Ошибка: " + ex.Message);
            }
            finally
            {
                tmpFileWritter.Close();
                tmpFileWritter.Dispose();
            }

            try
            {
                string hash = "";
                using (MD5 md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead("tmp.epg"))
                    {
                        hash = BitConverter.ToString(md5.ComputeHash(stream)).ToLower();
                    }
                }

                Configurator.writeToGlobalSection("chksm", hash);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "[КРИТИЧЕСКАЯ СЕКЦИЯ 'Кэширование EPG'] Ошибка: " + ex.Message);
            }
        }

        private static bool __loadAllEPGs()
        {
            if (File.Exists("tmp.epg"))
            {
                /* Get MD5 checksum of existing file */
                string hash = "";
                using (MD5 md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead("tmp.epg"))
                    {
                        hash = BitConverter.ToString(md5.ComputeHash(stream)).ToLower();
                    }
                }

                /* Read checksum */
                string checksum = Configurator.getKeyFromGlobalSection("chksm");

                /* Compare it */
                if (hash == checksum)
                {
                    /* Compare date */
                    StreamReader tmpFileReader = new StreamReader("tmp.epg");
                    try
                    {
                        /* First, load date */
                        string tmpDate = tmpFileReader.ReadLine();

                        if (tmpDate != DateTime.Today.ToShortDateString())
                        {
                            tmpFileReader.Close();
                            tmpFileReader.Dispose();
                            return false;
                        }

                        Channel currentChannel = new Channel();
                        Dictionary<int, EPG> currentEPGDictionary = new Dictionary<int, EPG>();
                        EPG currentEPG = new EPG();
                        int currentEPGCounter = -1;

                        /* Fill the dictionary */
                        while (!tmpFileReader.EndOfStream)
                        {
                            string line = tmpFileReader.ReadLine();
                            string[] cmds = line.Split(':');

                            if (cmds[0] == "CH")
                            {
                                if (currentChannel.Id > 0)
                                {
                                    Dictionary<int, EPG> copy = new Dictionary<int, EPG>(currentEPGDictionary);
                                    _epg.Add(currentChannel, copy);
                                    currentEPGDictionary.Clear();
                                }

                                /* Search channel id in channels */
                                string id = cmds[1];
                                for (int i = 0; i < Channels.AllChannels.Count; i++)
                                {
                                    if (Channels.AllChannels[i].Id == int.Parse(id))
                                    {
                                        currentChannel = Channels.AllChannels[i];
                                        break;
                                    }
                                }
                            }

                            if (cmds[0] == "PG")
                            {
                                string id = cmds[1];
                                currentEPGCounter = int.Parse(id);
                            }

                            if (cmds[0] == "ID")
                            {
                                currentEPG.Id = int.Parse(cmds[1]);
                            }

                            if (cmds[0] == "NM")
                            {
                                currentEPG.Name = cmds[1];
                            }

                            if (cmds[0] == "ST")
                            {
                                currentEPG.Start = int.Parse(cmds[1]);
                            }

                            if (cmds[0] == "EN")
                            {
                                currentEPG.End = int.Parse(cmds[1]);
                            }

                            if (cmds[0] == "DW")
                            {
                                currentEPG.Downloadable = int.Parse(cmds[1]);
                            }

                            if (cmds[0] == "IA")
                            {
                                currentEPG.inArchive = int.Parse(cmds[1]);

                                /* Save previous EPG */
                                currentEPGDictionary.Add(currentEPGCounter, currentEPG);
                            }
                        }

                        /* Add last EPG */
                        Dictionary<int, EPG> lastcopy = new Dictionary<int, EPG>(currentEPGDictionary);
                        _epg.Add(currentChannel, lastcopy);
                    }
                    catch
                    {

                    }
                    finally
                    {
                        tmpFileReader.Close();
                        tmpFileReader.Dispose();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void updateEPGFromServer()
        {
            if (API.isAuth)
            {
                // If thread isn't working, start it:
                if (!_getEPGThread.IsBusy)
                {
                    Logger.Write(Logger.LogLevel.INFO, "Инициализация получения EPG.");
                    _getEPGThread.RunWorkerAsync();
                }
            }
        }

        public static void Init()
        {
            if (API.isAuth)
            {
                _getEPGThread.WorkerSupportsCancellation = true;
                _getEPGThread.DoWork += new DoWorkEventHandler(_getAllEPGs);

                // Check tmp
                if (!__loadAllEPGs())
                {
                    updateEPGFromServer();
                }
            }
        }

        public static EPG getCurrentShow(Channel channel)
        {
            EPG _currentEPG = new EPG();
            try
            {
                if (_epg.Count > 0)
                {
                    Dictionary<int, EPG> __epg = _epg[channel];
                    int currentUNIXTime = UnixTime.getUnixTimeStamp(DateTime.UtcNow);

                    for (int i = 0; i < __epg.Count; i++)
                    {
                        if (currentUNIXTime >= __epg[i].Start && currentUNIXTime <= __epg[i].End)
                        {
                            _currentEPG = __epg[i];
                        }
                    }
                }
            }
            catch
            { }
            return _currentEPG;
        }

        public static int getCurrentShowPosition(Channel channel)
        {
            try
            {
                EPG _currentChannel = getCurrentShow(channel);
                int _length = _currentChannel.End - _currentChannel.Start;
                int _position = 0;
                if (_length > 0)
                {
                    int _currentPos = UnixTime.getUnixTimeStamp(DateTime.UtcNow) - _currentChannel.Start;
                    _position = (_currentPos * 10000 / _length);

                    if (_position > 10000) _position = 10000;
                    if (_position < 0) _position = 0;
                }
                return _position;
            }
            catch
            {
                return 1000;
            }
        }
    }
}
