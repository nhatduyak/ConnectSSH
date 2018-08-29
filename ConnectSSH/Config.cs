namespace ConnectSSH
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
using System.Collections.Generic;

    internal class Config
    {
        public static string _Name;
        public static List<string> _ListName;
        public static List<string> _ListFolDerCommand;
        
        public static void GetConfig()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(Application.StartupPath + @"\Config.xml");
                _Name = document.SelectSingleNode("//Name").Attributes["Value"].Value;
                string folder= document.SelectSingleNode("//FolderCommand").Attributes["Value"].Value;
                try
                {
                    _ListFolDerCommand = new List<string>();
                    string[] listfolder=folder.Split(';');
                    foreach (string s in listfolder)
                    {
                        _ListFolDerCommand.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    CTLError.WriteError("Loi get List Forlder command ", ex.Message);
                }
                try
                {
                    _ListName = new List<string>();
                    foreach (string s in _Name.Split(';'))
                    {
                        string[] str=s.Split('.');
                        string s1 = str[str.Length - 1];
                        _ListName.Add(s1);
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("loi Config GetDateUpdate ", exception.Message);
            }
        }

        public static void Setvalue(string KeyConfig, string value)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(Environment.CurrentDirectory + @"\Config.xml");
                document.SelectSingleNode("//" + KeyConfig).Attributes["Value"].Value = value;
                document.Save(Path.Combine(Application.StartupPath, "Config.xml"));
            }
            catch (Exception exception)
            {
                CTLError.WriteError("Loi Setvalue Config.....", exception.Message);
            }
        }
    }
}

