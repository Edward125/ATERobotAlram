using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Edward;
using System.Diagnostics;

namespace ATERobotAlram
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region TabSetting

        private void txtAS2IP_KeyDown(object sender, KeyEventArgs e)
        {
            InputIP(txtAS2IP, e);
        }

        private void txtAS4IP_KeyDown(object sender, KeyEventArgs e)
        {
            InputIP(txtAS4IP, e);
        }

        private void txtAS6IP_KeyDown(object sender, KeyEventArgs e)
        {
            InputIP(txtAS6IP, e);
        }

        private void txtAS9IP_KeyDown(object sender, KeyEventArgs e)
        {
            InputIP(txtAS6IP, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="e"></param>
        private void InputIP(MaskedTextBox txt, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                int pos = txt.SelectionStart;
                int max = (txt.MaskedTextProvider.Length - txt.MaskedTextProvider.EditPositionCount);
                int nextField = 0;

                for (int i = 0; i < txt.MaskedTextProvider.Length; i++)
                {
                    if (!txt.MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                        nextField = i;
                }
                nextField += 1;
                // We're done, enable the TabStop property again 
                txt.SelectionStart = nextField;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check ip;   
            if (!checkIP(txtAS2IP))
                return;
            if (!checkIP(txtAS4IP))
                return;
            if (!checkIP(txtAS6IP))
                return;
            if (!checkIP(txtAS9IP))
                return;

            p.AS2RobotIP = txtAS2IP.Text.Trim().Replace(" ", "");  txtAS2IPInfo.Text = p.AS2RobotIP;
            p.AS4RobotIP = txtAS4IP.Text.Trim().Replace(" ", "");
            p.AS6RobotIP = txtAS6IP.Text.Trim().Replace(" ", "");
            p.AS9RobotIP = txtAS9IP.Text.Trim().Replace(" ", "");
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AS2RobotIP", p.AS2RobotIP, p.iniFilePath);
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AS4RobotIP", p.AS4RobotIP, p.iniFilePath);
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AS6RobotIP", p.AS6RobotIP, p.iniFilePath);
            IniFile.IniWriteValue(p.IniSection.SysConfig.ToString(), "AS9RobotIP", p.AS9RobotIP, p.iniFilePath);

            MessageBox.Show("Save IP Address complete...", "Save Config", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private bool checkIP(MaskedTextBox txt)
        {

            string ip = txt.Text.Trim();
            ip = ip.Replace(" ", "");
            System.Net.IPAddress _IP;
            if (System.Net.IPAddress.TryParse(ip, out _IP))
                return true;
            else
            {
                MessageBox.Show("Input:" + ip + " is not a valid IP address", "Check IP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                return false;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private string getMaskedIPAddress(string ip)
        {
            string newIP = string.Empty;
            if (ip.Contains("."))
            {
                foreach (string  item in ip.Split ('.'))
                {
                    string part = item;

                    while (part.Length <3)
                    {
                        part  =  part + " ";
                    }

                    newIP = newIP + part + ".";
                }
            }
            return newIP.Remove(newIP.LastIndexOf('.'), 1);
        }

        #endregion


        //FICT
        string PLC_ReadValue = string.Empty; //從FICT寄存器中讀到的值
        string PLC_Last_ReadValue = string.Empty; //上一次從FICT寄存器中讀到的值


        private void frmMain_Load(object sender, EventArgs e)
        {
            Init();
           
        }

        private void Init()
        {
            if (!p.checkFolder())
            {
                MessageBox.Show("Create app folder fail,program will exit.", "Create Folder Fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Threading.Thread.Sleep(1000);
                // SplashForm.CloseSplash();
                Environment.Exit(0);
            }

            if (!File.Exists(p.iniFilePath))
                p.createIniFile(p.iniFilePath);
            p.readIniValue(p.iniFilePath);
            {
                System.Threading.Thread.Sleep(1000);
                // Environment.Exit(0);
            }
            //load data in ui           
            txtAS2IP.Text = getMaskedIPAddress(p.AS2RobotIP);
            txtAS4IP.Text = getMaskedIPAddress(p.AS4RobotIP);
            txtAS6IP.Text =getMaskedIPAddress( p.AS6RobotIP);
            txtAS9IP.Text =getMaskedIPAddress(p.AS9RobotIP);

            //
            txtAS2IPInfo.Text = p.AS2RobotIP;

            //
            SetPLC();

        }



        #region PLCSetting


        private void SetPLC()
        {
            //as2
           axActProgTypeAS2.ActUnitType = 0x004A;
            axActProgTypeAS2.ActCpuType = 0x0208;
            //axActPLC.ActUnitType = 0x000F;
            axActProgTypeAS2.ActHostAddress = p.AS2RobotIP;
           // axActProgTypeAS2.ActThroughNetworkType = 1;
           // axActProgTypeAS2.ActDidPropertyBit = 0x0001;
           // axActProgTypeAS2.ActIONumber = 0x03FF;
            axActProgTypeAS2.ActProtocolType = 5;
            axActProgTypeAS2.ActCpuTimeOut = 10000;

        }



        #endregion



        #region AS2
        private void btnAS2Run_Click(object sender, EventArgs e)
        {
            if (openPLC(axActProgTypeAS2))
            {
                timerRead_PLC_AS2.Start();
                btnAS2Run.Enabled = false;
                btnAS2Stop.Enabled = true;
            }
        }

        
        #endregion

        #region MX操作PLC

        /// <summary>
        /// 連接Robot PLC
        /// </summary>
        /// <param name="portname">Robot PLC IP</param>
        /// <returns></returns>
        private bool openPLC( AxActProgTypeLib.AxActProgType axActPLC)
        {
            int iReturnCode = -1;//定義返回值
            int iMaxRetry = 3;
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();


            for (int i = 1; i <= iMaxRetry; i++)
            {
                sw.Start();
                updateMessage(lstAS2Info , "第" + i + "次連接PLC");
                //saveLog(Param.logType.SYSLOG.ToString(), "第" + i + "次連接PLC");
                Application.DoEvents();
                try
                {
                    iReturnCode = axActPLC.Open();
                }
                catch (Exception ex)
                {
                    updateMessage(lstAS2Info , "第" + i + "次連接PLC NG,Message:" + ex.Message);
                   //saveLog(Param.logType.SYSLOG.ToString(), "第" + i + "次連接PLC NG,Message:" + ex.Message);
                }
                sw.Stop();
                ts = sw.Elapsed;
                if (iReturnCode == 0)
                {
                    updateMessage(lstAS2Info , "第" + i + "次連接Robot PLC OK,Used time(s):" + ts.Seconds);
                     //saveLog(Param.logType.SYSLOG.ToString(), "第" + i + "次連接PLC OK,Used time(s):" + ts.Seconds);
                    return true;
                }

                string sMessage = string.Empty;
                axActSupportMsg1.GetErrorMessage(iReturnCode, out sMessage);
            }
            // sw.Stop();
            string sMess = string.Empty;
            axActSupportMsg1.GetErrorMessage(iReturnCode, out sMess);
            string[] stemp = sMess.Split('\r');
            updateMessage(lstAS2Info , "第" + iMaxRetry + "次連接PLC NG,,已達到最大retry數，Errorcode=" + iReturnCode + ",Used time(s):" + ts.Seconds);
            foreach (string s in stemp)
            {
                if (!string.IsNullOrEmpty(s.Trim()))
                    updateMessage(lstAS2Info , s);
            }
            //saveLog(Param.logType.SYSLOG.ToString(), "第" + iMaxRetry + "次連接PLC NG,已達到最大retry數，Errorcode=" + iReturnCode + ",Used time(s):" + ts.Seconds);
           // saveLog(Param.logType.SYSLOG.ToString(), sMess);
            return false;
        }

        /// <summary>
        /// 斷開Robot PLC
        /// </summary>   
        /// <returns></returns>
        private bool closePLC( AxActProgTypeLib.AxActProgType axActPLC)
        {
            try
            {
                axActPLC.Close();
                updateMessage(lstAS2Info , "Close PLC");
               // saveLog(Param.logType.SYSLOG.ToString(), "close PLC");

            }
            catch (Exception e)
            {
                updateMessage(lstAS2Info , "Close PLC error," + e.Message);
                //saveLog(Param.logType.SYSLOG.ToString(), "close PLC," + e.Message);
                return false;
            }
            return true;
        }




        #endregion



        /// <summary>
        /// 更新信息到listbox中
        /// </summary>
        /// <param name="listbox">listbox name</param>
        /// <param name="message">message</param>
        private   void updateMessage(ListBox listbox, string message)
        {
            if (listbox.Items.Count > 1000)
                listbox.Items.RemoveAt(0);
            string item = string.Empty;
            item = DateTime.Now.ToString("HH:mm:ss") + " " + @message;
            listbox.Items.Add(item);

            // Display a horizontal scroll bar.
            listbox.HorizontalScrollbar = true;
            Graphics g = listbox.CreateGraphics();
            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(listbox.Items[listbox.Items.Count - 1].ToString(), listbox.Font).Width;
            // Set the HorizontalExtent property.
            listbox.HorizontalExtent = hzSize;

            if (listbox.Items.Count > 1)
            {
                listbox.TopIndex = listbox.Items.Count - 1;
                listbox.SetSelected(listbox.Items.Count - 1, true);
            }
        }


        /// <summary>
        /// 進制轉換
        /// </summary>
        /// <param name="value">需要轉換的值</param>
        /// <param name="fromBase">原進制</param>
        /// <param name="toBase">需要轉換的進制</param>
        /// <returns>返回的結果</returns>
        public static string ConverString(string value, int fromBase, int toBase)
        {
            Int32 n = Convert.ToInt32(value, fromBase);
            return Convert.ToString(n, toBase);
        }



        ///// <summary>
        ///// 保存log
        ///// </summary>
        ///// <param name="logtype">log類型</param>
        ///// <param name="logcontents">log內容</param>
        //private  void saveLog(string logtype, string logcontents)
        //{
        //    //根據logtype獲取對應的文件路徑以及文件名
        //    string logpath = string.Empty;
        //    if (logtype.ToUpper() == Param.logType.COMLOG.ToString())
        //        logpath = Param.comLogFolder + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        //    if (logtype.ToUpper() == Param.logType.SYSLOG.ToString())
        //        logpath = Param.sysLogFolder + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";

        //    //判斷文件是否存在，不存在就創建文件，存在就寫入文件
        //    if (!File.Exists(@logpath))
        //    {
        //        FileStream fs = File.Create(@logpath);
        //        fs.Close();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            File.AppendAllText(@logpath, DateTime.Now.ToString("yyyyMMddHHmmss") + " " + @logcontents + "\r\n");
        //        }
        //        catch (Exception)
        //        {
        //            //wait

        //        }
        //    }

        //}



        private bool getStatus(AxActProgTypeLib.AxActProgType axActPLC, string szDevice,out string result)
        {
            int[] istatus = new int[14];
            int iReturn = -1;
            result = string.Empty;
            iReturn = axActPLC.ReadDeviceBlock(szDevice, 13, out istatus[0]);
            if (iReturn == 0)
            {    
                if (szDevice.ToUpper().StartsWith("M"))
                {
                    try
                    {
                        Int64 it32 = 0;
                        for (int i = 0; i < 13; i++)
                        {
                            it32 = Convert.ToInt64(ConverString(istatus[i].ToString(), 10, 2));
                            updateMessage(lstAS2Info, string.Format("{0:0000000000000000}", it32));
                            result = result + string.Format("{0:0000000000000000}", it32);
                        }                   


                       // it32 = Convert.ToInt64(ConverString(istatus[0].ToString(), 10, 2));
                       // updateMessage(lstAS2Info, "Read " + szDevice + ":");
                       // updateMessage(lstAS2Info, string.Format("{0:0000000000000000}", it32));
                       //// Param.M_Status_1 = string.Format("{0:0000000000000000}", it32);
                       // it32 = Convert.ToInt64(ConverString(istatus[1].ToString(), 10, 2));
                       // //Param.M_Status_2 = string.Format("{0:0000000000000000}", it32);
                       // updateMessage(lstAS2Info, string.Format("{0:0000000000000000}", it32));
                       // it32 = Convert.ToInt64(ConverString(istatus[2].ToString(), 10, 2));
                       // updateMessage(lstAS2Info, string.Format("{0:0000000000000000}", it32));
                       // it32 = Convert.ToInt64(ConverString(istatus[3].ToString(), 10, 2));
                       // updateMessage(lstAS2Info, string.Format("{0:0000000000000000}", it32));

                    }
                    catch (Exception ex)
                    {

                        updateMessage(lstAS2Info , szDevice + "," + ex.Message);
                        //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), szDevice + "," + ex.Message);
                    }
                }
                return true;
            }
            else
            {
                string sResult = string.Format("0x{0:x8}", iReturn);
                string sMessge = string.Empty;
                //  getErrorMessage(sResult,ref sMessge);
                axActSupportMsg1.GetErrorMessage(iReturn, out sMessge);
                updateMessage(lstAS2Info , "Read Device:" + szDevice + " fail,Message:" + sResult + "," + sMessge);
                //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "Read Device:" + szDevice + " fail,Message:" + sResult + "," + sMessge);
                return false;
            }

        }

        private void btnAS2Stop_Click(object sender, EventArgs e)
        {
            closePLC(axActProgTypeAS2);
            timerRead_PLC_AS2.Stop();
            btnAS2Run.Enabled = true;
            btnAS2Stop.Enabled = false;
        }

        private void timerRead_PLC_AS2_Tick(object sender, EventArgs e)
        {
            
          //  getStatus(axActProgTypeAS2, "M2992");

            //
           // timerRead_PLC_AS2.Stop();
            string PLC_Read_Value = string.Empty;
            //

            getStatus(axActProgTypeAS2, "M2992", out PLC_ReadValue);

            if (PLC_Last_ReadValue == PLC_ReadValue) //已經讀到了
            {         
                timerRead_PLC_AS2.Start();
                return;
            }
            //還沒讀到，賦值給上一次的值
            //SubFunction.updateMessage(lstStatusCommand, "FICT->PC:" + FICT_ReadValue);
            //SubFunction.saveLog(Param.logType.SYSLOG.ToString(), "FICT->PC:" + FICT_ReadValue);
            //SubFunction.saveLog(Param.logType.COMLOG.ToString(), "FICT->PC:" + FICT_ReadValue);
            PLC_Last_ReadValue = PLC_ReadValue;


            for (int i = 0; i < PLC_ReadValue .Length ; i++)
            {
                
            }




//             Dim PLC_Alarm_Code() As String = {
//"",
//"",
//"",
//"",
//"",
//"",
//"",
//"",
//"",
//"A000-急停Alarm",
//"A001-左安全門打開Alarm",
//"A002-右安全門打開Alarm",
//"A003-CC-Link主站模塊故障",
//"A004-CC-Link-Robostar模塊故障",
//"A005-RS232通訊模塊故障",
//"A006-1PG-Alarm",
//"A007-查詢條碼SFCS電腦未準備好",
//"A008-查詢條碼SFCS電腦網絡中斷",
//"A009-PC查詢SFCS反饋超時",
//"A010-ATE機台PC未完成準備好",
//"A011-ATE-A站台PC未完成準備",
//"A012-ATE-B站台PC未完成準備",
//"A013-ATE-C站台PC未完成準備",
//"A014-ATE-D站台PC未完成準備",
//"A015-",
//"A016-",
//"A017-Robostar程序未選擇Alarm",
//"A018-Robostar故障Alarm",
//"A019-Robostar TP急停",
//"A020-Robostar 未運行故障",
//"A021-NG軌道Robostar放片有板超時Alarm",
//"A022-OK軌道Robostar放片有板超時Alarm",
//"A023-ARM1吸真空異常Alarm",
//"A024-ARM2吸真空異常Alarm",
//"A025-ARM1破真空異常Alarm",
//"A026-ARM2破真空異常Alarm",
//"A027-條碼槍擋料氣缸上升故障",
//"A028-條碼槍擋料氣缸下降故障",
//"A029-",
//"A030-載板治具氣缸上升故障",
//"A031-載板治具氣缸下降故障",
//"A032-載板治具PCB檢測異常故障",
//"A033-載板治具PCB定位故障",
//"A034-",
//"A035-測試OK Robostar放片OK軌道有板",
//"A036-載板治具有板故障Alarm",
//"A037-ATE治具A站有板故障",
//"A038-ATE治具B站有板故障",
//"A039-ATE治具C站有板故障",
//"A040-ATE治具D站有板故障",
//"A041-機械手臂ARM1有板故障",
//"A042-機械手臂ARM2有板故障",
//"A043-NG皮帶線rRobostar放板時未準備",
//"A044-ARM1取板真空異常",
//"A045-ARM2取板真空異常",
//"A046-ARM2上点Sensor故障",
//"A047-ARM2下点Sensor故障",
//"A048-",
//"A049-",
//"A050-ATE刷條碼連續NG達到設定值報警",
//"A051-A站ATE測試連續NG達到設定值Alarm",
//"A052-B站ATE測試連續NG達到設定值Alarm",
//"A053-C站ATE測試連續NG達到設定值Alarm",
//"A054-D站ATE測試連續NG達到設定值Alarm",
//"A055-AB站ATE连续测试NG锁屏报警",
//"A056-CD站ATE连续测试NG锁屏报警",
//"A057-",
//"A058-",
//"A059-",
//"A060-A站ATE回原點超時Alarm",
//"A061-Robostar運行中A站省力裝置不在開啟點",
//"A062-Robostar往A站ATE放片超時Alarm",
//"A063-Robostar往A站ATE放片真空異常Alarm",
//"A064-Robostar往A站ATE取片超時Alarm",
//"A065-Robostar往A站ATE取片真空異常Alarm",
//"A066-Robostar往A站PCB板OK放片超時Alarm",
//"A067-Robostar往A站PCB板NG放片超時Alarm",
//"A068-",
//"A069-",
//"A070-B站ATE回原點超時Alarm",
//"A071-Robostar運行中B站省力裝置不在開啟點",
//"A072-Robostar往B站ATE放片超時Alarm",
//"A073-Robostar往B站ATE放片真空異常Alarm",
//"A074-Robostar往B站ATE取片超時Alarm",
//"A075-Robostar往B站ATE取片真空異常Alarm",
//"A076-Robostar往B站PCB板OK放片超時Alarm",
//"A077-Robostar往B站PCB板NG放片超時Alarm",
//"A078-",
//"A079-",
//"A080-C站ATE回原點超時Alarm",
//"A081-Robostar運行中C站省力裝置不在開啟點",
//"A082-Robostar往C站ATE放片超時Alarm",
//"A083-Robostar往C站ATE放片真空異常Alarm",
//"A084-Robostar往C站ATE取片超時Alarm",
//"A085-Robostar往C站ATE取片真空異常Alarm",
//"A086-Robostar往C站PCB板OK放片超時Alarm",
//"A087-Robostar往C站PCB板NG放片超時Alarm",
//"A088-",
//"A089-",
//"A090-D站ATE回原點超時Alarm",
//"A091-Robostar運行中D站省力裝置不在開啟點",
//"A092-Robostar往D站ATE放片超時Alarm",
//"A093-Robostar往D站ATE放片真空異常Alarm",
//"A094-Robostar往D站ATE取片超時Alarm",
//"A095-Robostar往D站ATE取片真空異常Alarm",
//"A096-Robostar往D站PCB板OK放片超時Alarm",
//"A097-Robostar往D站PCB板NG放片超時Alarm",
//"A098-",
//"A099-",
//"A100-軌道CV01進片超時Alarm",
//"A101-軌道CV01出片超時Alarm",
//"A102-軌道CV02進片超時Alarm",
//"A103-軌道CV02出片超時Alarm",
//"A104-軌道CV03進片超時Alarm",
//"A105-軌道CV03出片超時Alarm",
//"A106-軌道CV04進片超時Alarm",
//"A107-軌道CV04出片超時Alarm",
//"A108-軌道CV05進片超時Alarm",
//"A109-軌道CV05出片超時Alarm",
//"A110-A站ATE Robostar離開干涉區超時Alarm",
//"A111-A站ATE PCB定位Alarm",
//"A112-A站ATE PCB有板檢測Alarm",
//"A113-A站ATE 條碼丟失Alarm",
//"A114-A站ATE 省力裝置關閉超時Alarm",
//"A115-A站ATE 反饋K11超時Alarm",
//"A116-A站ATE PCB測試超時Alarm",
//"A117-A站ATE 省力裝置開啟超時Alarm",
//"A118-A站ATE 省力裝置回原點超時Alarm",
//"A119-A站ATE 省力裝置斷帶故障",
//"A120-A站ATE 微動開關損壞",
//"A121-A站ATE 異常匯總",
//"A122-A站ATE省力装置不开起点位置",
//"A123-",
//"A124-",
//"A125-",
//"A126-",
//"A127-",
//"A128-",
//"A129-",
//"A130-B站ATE Robostar離開干涉區超時Alarm",
//"A131-B站ATE PCB定位Alarm",
//"A132-B站ATE PCB有板檢測Alarm",
//"A133-B站ATE 條碼丟失Alarm",
//"A134-B站ATE 省力裝置關閉超時Alarm",
//"A135-B站ATE 條碼反饋超時Alarm",
//"A136-B站ATE PCB測試超時Alarm",
//"A137-B站ATE 省力裝置開啟超時Alarm",
//"A138-B站ATE 省力裝置回原點超時Alarm",
//"A139-B站ATE 省力裝置斷帶故障",
//"A140-B站ATE 微動開關損壞",
//"A141-B站ATE 異常匯總",
//"A142-B站ATE省力装置不开起点位置",
//"A143-",
//"A144-",
//"A145-",
//"A146-",
//"A147-",
//"A148-",
//"A149-",
//"A150-C站ATE Robostar離開干涉區超時Alarm",
//"A151-C站ATE PCB定位Alarm",
//"A152-C站ATE PCB有板檢測Alarm",
//"A153-C站ATE 條碼丟失Alarm",
//"A154-C站ATE 省力裝置關閉超時Alarm",
//"A155-C站ATE 條碼反饋超時Alarm",
//"A156-C站ATE PCB測試超時Alarm",
//"A157-C站ATE 省力裝置開啟超時Alarm",
//"A158-C站ATE 省力裝置回原點超時Alarm",
//"A159-C站ATE 省力裝置斷帶故障",
//"A160-C站ATE 微動開關損壞",
//"A161-C站ATE 異常匯總",
//"A162-C站ATE省力装置不开起点位置",
//"A163-",
//"A164-",
//"A165-",
//"A166-",
//"A167-",
//"A168-",
//"A169-",
//"A170-D站ATE Robostar離開干涉區超時Alarm",
//"A171-D站ATE PCB定位Alarm",
//"A172-D站ATE PCB有板檢測Alarm",
//"A173-D站ATE 條碼丟失Alarm",
//"A174-D站ATE 省力裝置關閉超時Alarm",
//"A175-D站ATE 條碼反饋超時Alarm",
//"A176-D站ATE PCB測試超時Alarm",
//"A177-D站ATE 省力裝置開啟超時Alarm",
//"A178-D站ATE 省力裝置回原點超時Alarm",
//"A179-D站ATE 省力裝置斷帶故障",
//"A180-D站ATE 微動開關損壞",
//"A181-D站ATE 異常匯總",
//"A182-D站ATE省力装置不开起点位置",
//"A183-",
//"A184-",
//"A185-",
//"A186-",
//"A187-",
//"A188-",
//"A189-",
//"A190-",
//"A191-",
//"A192-",
//"A193-",
//"A194-",
//"A195-",
//"A196-",
//"A197-",
//"A198-",
//"A199-"}



        }

    }
}
