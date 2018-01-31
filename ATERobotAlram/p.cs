using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Edward;

namespace ATERobotAlram
{
    class p
    {
        public static string AppFolder =Application.StartupPath + @"\" + Application.ProductName;
        public static string iniFilePath = AppFolder + @"\SysConfig.ini";
        public static string AS2RobotIP = "172.30.15.153";
        public static string AS4RobotIP = "172.30.15.155";
        public static string AS6RobotIP = "172.30.15.157";
        public static string AS9RobotIP = "172.30.15.117";



        public enum IniSection
        {
            SysConfig
        }

        /// <summary>
        /// check app folder
        /// </summary>
        /// <returns></returns>
        public static bool checkFolder()
        {
            if (!Directory.Exists(AppFolder))
            {
                try
                {
                    Directory.CreateDirectory(AppFolder);
                }
                catch (Exception)
                {

                    return false;
                }
            }          

            return true;
        }

        /// <summary>
        /// create ini file
        /// </summary>
        /// <param name="inifilepath">ini file path </param>
        public static void createIniFile(string inifilepath)
        {
            IniFile.CreateIniFile(inifilepath);
            //File.SetAttributes(inifilepath, FileAttributes.Hidden);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "AS2RobotIP", AS2RobotIP, inifilepath);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "AS4RobotIP", AS4RobotIP, inifilepath);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "AS6RobotIP", AS6RobotIP, inifilepath);
            IniFile.IniWriteValue(IniSection.SysConfig.ToString(), "AS9RobotIP", AS9RobotIP, inifilepath);
        }

        /// <summary>
        /// read ini file value 
        /// </summary>
        /// <param name="inifilepath">ini file path</param>
        public static void readIniValue(string inifilepath)
        {
            AS2RobotIP = IniFile.IniReadValue(IniSection.SysConfig.ToString(), "AS2RobotIP", inifilepath);
            AS4RobotIP = IniFile.IniReadValue(IniSection.SysConfig.ToString(), "AS4RobotIP", inifilepath);
            AS6RobotIP = IniFile.IniReadValue(IniSection.SysConfig.ToString(), "AS6RobotIP", inifilepath);
            AS9RobotIP = IniFile.IniReadValue(IniSection.SysConfig.ToString(), "AS9RobotIP", inifilepath);
        }


    }
}
