using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BSPB_autotests.Settings
{
    public static class Settings
    {
        public static string file;

        private static string baseURL;
        private static string login;
        private static string password;
        private static string authCode;

        private static XmlDocument document;

        public static string FindSettingsFile()
        {
            file = "D:\\QA\\Практика\\BSPB_autotests\\BSPB_autotests\\Settings\\Settings.xml";

            return file;
        }

        static Settings()
        {
            file = FindSettingsFile();
            if (!System.IO.File.Exists(file))
            {
                throw new Exception("Problem: settings file not found: " + file);
            }

            document = new XmlDocument();
            document.Load(file);
        }

        public static string BaseURL
        {
            get
            {
                if (baseURL == null)
                {
                    XmlNode node =
                        document.DocumentElement.SelectSingleNode("BaseUrl");
                    baseURL = node.InnerText;
                }

                return baseURL;
            }
        }

        public static string Username
        {
            get
            {
                if (login == null)
                {
                    XmlNode node =
                        document.DocumentElement.SelectSingleNode("Login");
                    login = node.InnerText;
                }
                return login;
            }
        }

        public static string Password
        {
            get
            {
                if (password == null)
                {
                    XmlNode node =
                        document.DocumentElement.SelectSingleNode("Password");
                    password = node.InnerText;
                }
                return password;
            }
        }

        public static string AuthCode
        {
            get
            {
                if (authCode == null)
                {
                    XmlNode node =
                        document.DocumentElement.SelectSingleNode("AuthCode");
                    authCode = node.InnerText;
                }
                return authCode;
            }
        }
    }
}
