using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Click_TV
{
    public class Channels
    {
        private static Dictionary<int, Channel> _channels = new Dictionary<int, Channel>();
        public static Channel currentPlayingChannel = new Channel();

        // Get channels dictionary:
        public static Dictionary<int, Channel> AllChannels
        {
            get
            {
                return _channels;
            }
        }


        public static void Init()
        {
            if (API.isAuth)
            {
                Logger.Write(Logger.LogLevel.INFO, "Каналы. Получение списка каналов.");
                // If channels isn't empty, clear it before...
                if (_channels.Count > 0) _channels.Clear();

                // Fill the dictionary...
                foreach (Channel _current in API.getTVChannels(false))
                {
                    _channels.Add(_channels.Count, _current);
                }
            }
        }
    }
}
