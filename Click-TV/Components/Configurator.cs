using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace Click_TV
{
    class Configurator
    {
        private static INI iniFile = new INI("settings.ini");

        public static string getKeyFromGlobalSection(string key)
        {
            return iniFile.Read(key, "Global");
        }

        public static string getKeyFromSection(string key, string sections)
        {
            return iniFile.Read(key, sections);
        }

        public static bool isKeyExists(string key, string section)
        {
            return iniFile.KeyExists(key, section);
        }

        public static void writeToSection(string key, string value, string section)
        {
            iniFile.Write(key, value, section);
        }

        public static void writeToGlobalSection(string key, string value)
        {
            iniFile.Write(key, value, "Global");
        }
    }
}
