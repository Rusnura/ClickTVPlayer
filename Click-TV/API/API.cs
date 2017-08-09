using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Click_TV
{
    public class API
    {
        // service private props
        private static string authAPIHost = "http://212.77.128.205/stalker_portal/auth/token.php";
        private static string APIHost = "http://v2.api.ark.rikt.ru";
        
        public static string imagesHost = "http://tv.rikt.ru";

        // is auth private param
        private static bool _isAuth = false;

        // API host getter
        public static string host
        {
            get
            {
                return APIHost;
            }
        }
        
        // is auth public getter
        public static bool isAuth
        {
            get
            {
                return _isAuth;
            }

            set
            {
                _isAuth = true;
            }
        }

        // Auth private params
        private static string _tokenType = null;
        private static string _accessToken = null;
        private static string _refreshToken = null;
        private static string _userID = null;

        // Auth public getter
        public static string tokenType
        {
            get
            {
                return _tokenType;
            }
        }

        public static string accessToken
        {
            get
            {
                return _accessToken;
            }
        }

        public static string refreshToken
        {
            get
            {
                return _refreshToken;
            }
        }

        public static string userID
        {
            get
            {
                return _userID;
            }
        }

        public static void Auth()
        {
            string username = "";
            string password = "";

            if (!Configurator.isKeyExists("login", "Global") || !Configurator.isKeyExists("password", "Global"))
            {
                Logger.Write(Logger.LogLevel.INFO, "Авторизация: Запрос нового пользователя.");
                // Get user MAC address
                string macAddresses = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddresses += nic.GetPhysicalAddress();
                        break;
                    }
                }
                Logger.Write(Logger.LogLevel.INFO, "Авторизация: Запрос MAC адреса выполнен. [" + macAddresses + "]");
                // Get new data
                string userData = WebRequests.GET("http://212.77.128.205/stalker_portal/custom/user_create.php", "mac=" + macAddresses + "&device=pc");
                Dictionary<string, string> userDataParams = new Dictionary<string, string>();
                userDataParams = Json.JSONStringToDictionary(userData);
                username = userDataParams["login"];
                password = userDataParams["password"];
                Logger.Write(Logger.LogLevel.INFO, "Авторизация: Запрос нового пользователя: Логин: " + username + " получен! Попытка записать логин в базу.");

                // Write to INI
                Configurator.writeToGlobalSection("login", username);
                Configurator.writeToGlobalSection("password", password);
                Logger.Write(Logger.LogLevel.INFO, "Авторизация: Логин записан в базу данных.");
            }
            else
            {
                Logger.Write(Logger.LogLevel.INFO, "Авторизация: Получение имени пользователя из базы данных.");
                // Get data from INI file
                username = Configurator.getKeyFromGlobalSection("login");
                password = Configurator.getKeyFromGlobalSection("password");
            }
            Logger.Write(Logger.LogLevel.INFO, "Авторизация: Отправка запроса авторизации на сервер.");
            string accessParams = WebRequests.POST(authAPIHost, "grant_type=password&username=" + username + "&password=" + password);
            Dictionary<string, string> dataParams = new Dictionary<string, string>();
            dataParams = Json.JSONStringToDictionary(accessParams);
            if (dataParams.ContainsKey("error"))
            {
                Logger.Write(Logger.LogLevel.ERROR, "Авторизация не прошла. Аккаунт отключён или заблокирован!");
                _isAuth = false;
            }
            else
            {
                _accessToken = dataParams["access_token"];
                _tokenType = dataParams["token_type"];
                _refreshToken = dataParams["refresh_token"];
                _userID = dataParams["user_id"];
                _isAuth = true;
                Logger.Write(Logger.LogLevel.INFO, "Авторизация прошла успешно.");
            }
        }

        public static Channel[] getTVChannels(bool favorite)
        {
            if (API.isAuth)
            {
                string retValue = WebRequests.GET(APIHost + "/users/" + API._userID + "/tv-channels", "mark=" + (favorite ? "favorite" : "default"));

                Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(retValue);
                return JsonConvert.DeserializeObject<Channel[]>(result["results"].ToString());
            }
            else
            {
                return null;
            }
        }

        public static string getVideoLink(Channel channel)
        {
            if (API.isAuth)
            {
                try
                {
                    return Json.JSONStringToDictionary(WebRequests.GET(APIHost + "/users/" + API._userID + "/tv-channels/" + channel.Id + "/link", ""))["results"];
                }
                catch
                {
                    Logger.Write(Logger.LogLevel.ERROR, "Ошибка API::getVideoLink. Возвращаем пустую строку.");
                    return "";
                }
            }
            else
            {
                return null;
            }
        }

        public static EPG[] getTVProgram(Channel channel, long startUnixTime, long endUnixTime)
        {
            try
            {
                string retValue = WebRequests.GET(APIHost + "/tv-channels/" + channel.Id + "/epg", "from=" + startUnixTime + "&to=" + endUnixTime);
                Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(retValue);
                return JsonConvert.DeserializeObject<EPG[]>(result["results"].ToString());
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "getTVProgram: Не удалось получить распознать данные от сервера: '" + ex.Message + "'!");
                return null;
            }
        }

        public static string getTVArchiveLink(EPG tv)
        {
            if (API.isAuth)
            {
                string retValue = WebRequests.GET(APIHost + "/epg/" + tv.Id + "/link", "");
                Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(retValue);
                return Json.JSONStringToDictionary(retValue)["results"];
            }
            else
            {
                return null;
            }
        }

        public static void sendPing()
        {
            if (API.isAuth)
            {
                try
                {
                    WebRequests.GET(APIHost + "/users/" + API._userID + "/ping", "");
                }
                catch
                {
                    Logger.Write(Logger.LogLevel.ERROR, "PING: Не удалось сделать пинг до сервера");
                }
            }
            else
            {
                
            }
        }

        public enum MediaINFOTypes
        {
            TVChannel, TVArchive, Karaoke, Video
        }

        public static void sendMediaInfo(MediaINFOTypes type, string mediaID)
        {
            try
            {
                if (type == MediaINFOTypes.TVChannel)
                {
                    WebRequests.POST(APIHost + "/users/" + _userID + "/media-info", "type=tv-channel&media_id=" + mediaID);
                }

                if (type == MediaINFOTypes.TVArchive)
                {
                    WebRequests.POST(APIHost + "/users/" + _userID + "/media-info", "type=tv-archive&media_id=" + mediaID);
                }

                if (type == MediaINFOTypes.Karaoke)
                {
                    WebRequests.POST(APIHost + "/users/" + _userID + "/media-info", "type=karaoke&media_id=" + mediaID);
                }

                if (type == MediaINFOTypes.Video)
                {
                    WebRequests.POST(APIHost + "/users/" + _userID + "/media-info", "type=video&media_id=" + mediaID);
                }
                Logger.Write(Logger.LogLevel.INFO, "MEDIA Sent successfully...");
            }
            catch
            {
                Logger.Write(Logger.LogLevel.ERROR, "MEDIA INFO: Не удалось отправить mediaInfo.");
            }
        }

        public static void deleteMediaInfo()
        {
            if (API.isAuth)
            {
                try
                {
                    WebRequests.DELETE(APIHost + "/users/" + _userID + "/media-info", "");
                    Logger.Write(Logger.LogLevel.INFO, "MEDIA INFO: DELETE ok...");
                }
                catch
                {
                    Logger.Write(Logger.LogLevel.ERROR, "MEDIA INFO: Не удалось удалить информацию о mediaInfo.");
                }
            }
        }

        public static string getParentPassword()
        {
            if (API.isAuth)
            {
                try
                {
                    string retValue = WebRequests.GET(APIHost + "/users/" + _userID + "/settings", "");
                    Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(retValue);

                    /* Results */
                    Newtonsoft.Json.Linq.JObject code = Newtonsoft.Json.Linq.JObject.Parse(result["results"].ToString());
                    return JsonConvert.DeserializeObject<string>(code["parent_password"].ToString());
                }
                catch
                {
                    
                }
            }

            return null;
        }

        public static ServiceMessage getMessage()
        {
            try
            {
                string retValue = WebRequests.GET(APIHost + "/users/" + _userID + "/message", "");
                Newtonsoft.Json.Linq.JObject result = Newtonsoft.Json.Linq.JObject.Parse(retValue);
                Logger.Write(Logger.LogLevel.INFO, "Получено сообщение: " + retValue);
                return JsonConvert.DeserializeObject<ServiceMessage>(result["results"].ToString());
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "MESSAGES: Не удалось получить message." + ex.Message);
                return new ServiceMessage();
            }
        }
    }
}
