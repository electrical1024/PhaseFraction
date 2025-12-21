using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace PhaseFraction
{
    public class ConfigClass
    {
        public static string ConfigPath = Directory.GetCurrentDirectory() + "\\db\\Configuration.ini";
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string def, StringBuilder retVal, int size, string filePath);
        public string ReadConfig(string setting, string section = "")
        {
            string config = string.Empty;
            try
            {
                if (section == string.Empty)
                {
                    config = ConfigurationManager.AppSettings[setting].ToString();
                    return config;
                }
                else
                {
                    NameValueCollection collection = (NameValueCollection) ConfigurationManager.GetSection(section);
                    foreach (String str in collection.AllKeys)
                    {
                        if (str == setting)
                        {
                            config = collection[str];
                            break;
                        }
                    }
                    return config;
                }
            }
            catch
            {
                return config;
            }
        }


        public string ReadINIConfig(string key, string section = "Communication")
        {
            ConfigClass config = new ConfigClass();
            try
            {
                return config.GetINIString(ConfigPath, section, key);

            }
            catch
            {
                return String.Empty;
            }
        }

       

        public  bool WriteINIConfig( string key, string value, string section="Move")
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    WritePrivateProfileString(section, key, value, ConfigPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        public  string GetINIString(string fileName, string section, string key, string DefaultRenamed = "")
        {
            if (File.Exists(fileName))
            {
                StringBuilder stringBuilder = new StringBuilder(1024);
                GetPrivateProfileString(section, key, "", stringBuilder, 1024, fileName);
                if (stringBuilder.ToString().Trim() == String.Empty)
                    return DefaultRenamed;
                return stringBuilder.ToString().Trim();
            }
            else
            {
                return DefaultRenamed;
            }
        }

        
    }
}
