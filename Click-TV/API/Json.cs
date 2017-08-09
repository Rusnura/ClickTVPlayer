using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Click_TV
{
    class Json
    {
        public static Dictionary<string, string> JSONStringToDictionary(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
            }
            catch (Exception ex)
            {
                Logger.Write(Logger.LogLevel.ERROR, "Json::DeserializeObject: Не удалось распознать данные.");
                return null;
            }
        }
    }
}
