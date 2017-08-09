using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Click_TV
{
    class WebRequests
    {
        public static string GET(string url, string data)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    if (API.isAuth) client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + API.accessToken);
                    client.Headers.Add("UA-resolution", "160");
                    return client.DownloadString(url + (String.IsNullOrEmpty(data) ? "" : "?" + data));
                }
                catch ( Exception ex )
                {
                    Logger.Write(Logger.LogLevel.ERROR, "WebRequest::GET: Не удалось отправить данные на сервер: '" + ex.Message + "!' Строка запроса: '" + data + "'");
                    return null;
                }
            }
        }

        public static string POST(string url, string data)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    if (API.isAuth) client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + API.accessToken);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    var values = new NameValueCollection();

                    // Parse string & add parameters to collection
                    string[] parameters = data.Split('&');
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        values[parameters[i].Split('=')[0]] = parameters[i].Split('=')[1];
                    }

                    byte[] response;
                    string retResponse = null;
                    response = client.UploadValues(url, values);
                    retResponse = Encoding.Default.GetString(response);
                    return retResponse;
                }
                catch (Exception ex)
                {
                    Logger.Write(Logger.LogLevel.ERROR, "WebRequest::POST: Не удалось отправить данные на сервер: '" + ex.Message + "!' Строка запроса: '" + data + "'");
                    return null;
                }
            }
        }

        public static void DELETE(string url, string data)
        {
            try
            {
                HttpWebRequest client = (HttpWebRequest)WebRequest.Create(url + (String.IsNullOrEmpty(data) ? "" : "?" + data));
                client.Method = "DELETE";
                client.Accept = "application/json";
                client.ContentType = "application/x-www-form-urlencoded";
                if (API.isAuth) client.Headers.Add("Authorization: Bearer " + API.accessToken);
                HttpWebResponse response = (HttpWebResponse)client.GetResponse();
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "WebRequest::DELETE: Не удалось отправить данные на сервер: '" + ex.Message + "!' Строка запроса: '" + data + "'");
            }
        }
    }
}

