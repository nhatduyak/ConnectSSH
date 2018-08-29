namespace ConnectSSH
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using Renci.SshNet;
    //using WindowsFormsApplication2.Model;
    using System.Net.NetworkInformation;
    using System.Net;
    using System.Net.Sockets;
    using System.Data;
    
    public partial class FormMain : Form
    {
        private int _CountLookup = 1;
        private List<string> _ipClient = new List<string>();
        private bool _isstart = true;
        private const int BN_CLICKED = 0xf5;
        
        private bool respring12h = false;
        private bool respring17h = false;
        private bool respring23h = false;
        private bool respring7h = false;
        private Thread threadMain;
        private System.Windows.Forms.Timer timer1;
        private const int WM_CLOSE = 0x10;
        private const int WM_GETTEXT = 13;
        public const uint WM_SETTEXT = 12;

        public FormMain()
        {
            this.InitializeComponent();

            LoadListInstallDeb();
            

            FileInfo file = new FileInfo(Path.Combine(Application.StartupPath, "commanddefault.txt"));
            if (file.Exists)
            {
                StreamReader read = new StreamReader(file.FullName);
                while (!read.EndOfStream)
                {
                    string str = read.ReadLine();
                    if (str.Trim() != string.Empty)
                        listcommand.Items.Add(str);
                }
            }
            //CtlScanbarcode barcode = new CtlScanbarcode();
            //Ctlbarcode x = barcode.GetInfoFromInputBarcode("ENOTAUBYRAAGE");
            
            //DirectoryInfo info =new DirectoryInfo(@"D:\WinDSS");
            //DirectoryInfo i1=new DirectoryInfo(Path.Combine(info.Parent.FullName,"A"+info.Name));
        }

        public void AccetpButtonSave()
        {
            IntPtr zero = IntPtr.Zero;
            for (int i = 0; (zero == IntPtr.Zero) && (i < 10); i++)
            {
                Thread.Sleep(0x3e8);
                zero = (IntPtr) FindWindow("#32770", "PuTTY Security Alert");
            }
            SendMessage(FindWindowEx(zero, IntPtr.Zero, "Button", "&Yes"), 0xf5, IntPtr.Zero, IntPtr.Zero);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._isstart)
            {
                this.threadMain.Abort();
                this.button1.Text = "Start";
                this._isstart = false;
            }
            else
            {
                this.threadMain.Start();
                this.button1.Text = "Stop";
                this._isstart = true;
            }
        }

        public void connect(object cmd)
        {
            CIp ip = (CIp) cmd;
            string str = ip.Ip;
            string str2 = ip.Count.ToString();
            this.CreateComman(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe") {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }

        public void connectAffterRespring(object cmd)
        {
            CIp ip = (CIp) cmd;
            string str = ip.Ip;
            string str2 = ip.Count.ToString();
            this.CreateCommanOpenAffreboot(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe") {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }

        public void connectReset(object cmd)
        {
            CIp ip = (CIp) cmd;
            string str = ip.Ip;
            string str2 = ip.Count.ToString();
            this.CreateCommanAndReset(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe") {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }

        public void connectRespring(object cmd)
        {
            CIp ip = (CIp) cmd;
            string str = ip.Ip;
            string str2 = ip.Count.ToString();
            this.CreateCommanRespring(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe") {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }

        public void CopyFileConfigSSH(object cmd)
        {
            CIp ip = (CIp) cmd;
            string str = ip.Ip;
            string str2 = ip.Count.ToString();
            this.CreateCommanOpenAffreboot(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe") {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }

        public void CreateComman(int x)
        {
            string fileName = Path.Combine(Application.StartupPath, "command" + x.ToString() + ".txt");
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string str2 = "killall -c ";
                string str3 = "open ";
                string str4 = "logout";
                string[] strArray = Config._Name.Split(new char[] { ';' });
                foreach (string str5 in strArray)
                {
                    string[] strArray2 = str5.Split(new char[] { '.' });
                    writer.WriteLine(str2 + strArray2[strArray2.Length - 1]);
                }
                Random random = new Random();
                writer.WriteLine(str3 + strArray[random.Next(strArray.Length)]);
                writer.WriteLine(str4);
                writer.Close();
            }
        }

        public void CreateCommanAndReset(int x)
        {
            try
            {
                string fileName = Path.Combine(Application.StartupPath, "command" + x.ToString() + ".txt");
                FileInfo info = new FileInfo(fileName);
                if (info.Exists)
                {
                    info.Delete();
                }
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    string str2 = "killall -c ";
                    string str3 = "open ";
                    string str4 = "rm /var/db/lsd/com.apple.lsdidentifiers.plist";
                    string str5 = "logout";
                    string[] strArray = Config._Name.Split(new char[] { ';' });
                    foreach (string str6 in strArray)
                    {
                        string[] strArray2 = str6.Split(new char[] { '.' });
                        writer.WriteLine(str2 + strArray2[strArray2.Length - 1]);
                    }
                    writer.WriteLine(str4);
                    Random random = new Random();
                    writer.WriteLine(str3 + strArray[random.Next(strArray.Length)]);
                    writer.WriteLine(str5);
                    writer.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public void CreateCommanOpenAffreboot(int x)
        {
            string fileName = Path.Combine(Application.StartupPath, "command" + x.ToString() + ".txt");
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string str3 = "open ";
                string str4 = "activator send libactivator.system.homebutton && sleep 1 && stouch swipe 200 300 700 300 0.2 1 && Sleep 3";
                string str5 = "logout";
                writer.WriteLine(str4);
                writer.WriteLine(str4);
                string[] strArray = Config._Name.Split(new char[] { ';' });
                Random random = new Random();
                writer.WriteLine(str3 + strArray[random.Next(strArray.Length)]);
                writer.WriteLine(str5);
                writer.Close();
            }
        }

        public void CreateCommanreboot(int x)
        {
            string fileName = Path.Combine(Application.StartupPath, "command" + x.ToString() + ".txt");
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string str2 = "Activator send libactivator.system.reboot";
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        public void CreateCommanRespring(int x)
        {
            string fileName = Path.Combine(Application.StartupPath, "command" + x.ToString() + ".txt");
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string str2 = "killall SpringBoard";
                writer.WriteLine(str2);
                writer.Close();
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (this.components != null))
        //    {
        //        this.components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        [DllImport("User32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        private void Form1_Load(object sender, EventArgs e)
        {
            string str = Path.Combine(Application.StartupPath, "putty.exe");
            this.LoadList();
            //this.threadMain = new Thread(new ThreadStart(this.StartTask));
            //this.threadMain.Start();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
        [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        
        private void InteropSetText(IntPtr iptrHWndDialog, int iControlID, string strTextToSet)
        {
            IntPtr dlgItem = GetDlgItem(iptrHWndDialog, iControlID);
            HandleRef hWnd = new HandleRef(null, dlgItem);
            SendMessage(hWnd, 12, IntPtr.Zero, strTextToSet);
        }

        public void LoadList()
        {
            try
            {
                this._ipClient.Clear();
                StreamReader reader = new StreamReader(Path.Combine(Application.StartupPath, "list.txt"));
                while (!reader.EndOfStream)
                {
                    string item = reader.ReadLine();
                    this.listipaddress.Items.Add(item.Trim());
                    this._ipClient.Add(item);
                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("loi LoadList ", exception.Message);
            }
        }

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, string lParam);
        public void SendMessageCommand(string cm, string ip)
        {
            IntPtr handle = (IntPtr) FindWindow("PuTTY", string.Format("{0} - PuTTY", ip));
            if (!handle.Equals(IntPtr.Zero))
            {
                HandleRef hWnd = new HandleRef(null, handle);
                SendMessage(hWnd, 12, IntPtr.Zero, cm);
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public void StartTask()
        {
            CIp ip;
            Thread thread;
            int num = 0;
            int hour = DateTime.Now.Hour;
            if (((((hour == 7) && this.respring7h) || ((hour == 12) && this.respring12h)) || ((hour == 0x11) && this.respring17h)) || ((hour == 0x17) && this.respring23h))
            {
                num = 0;
                foreach (string str in this._ipClient)
                {
                    if (str != string.Empty)
                    {
                        ip = new CIp {
                            Ip = str,
                            Count = num
                        };
                        thread = new Thread(new ParameterizedThreadStart(this.connectRespring));
                        thread.Start(ip);
                        num++;
                    }
                    Thread.Sleep(0x1388);
                }
                num = 0;
                foreach (string str in this._ipClient)
                {
                    if (str != string.Empty)
                    {
                        ip = new CIp {
                            Ip = str,
                            Count = num
                        };
                        thread = new Thread(new ParameterizedThreadStart(this.connectAffterRespring));
                        thread.Start(ip);
                        num++;
                    }
                    Thread.Sleep(0x1388);
                }
                if (hour == 7)
                {
                    this.respring7h = false;
                }
                if (hour == 12)
                {
                    this.respring12h = false;
                }
                if (hour == 0x11)
                {
                    this.respring17h = false;
                }
                if (hour == 0x17)
                {
                    this.respring23h = false;
                }
            }
            else
            {
                num = 0;
                foreach (string str in this._ipClient)
                {
                    if (str != string.Empty)
                    {
                        ip = new CIp {
                            Ip = str,
                            Count = num
                        };
                        thread = new Thread(new ParameterizedThreadStart(this.connect));
                        thread.Start(ip);
                        num++;
                    }
                    Thread.Sleep(0x2710);
                }
                if ((this._CountLookup % 5) == 0)
                {
                    int num3 = 0;
                    foreach (string str in this._ipClient)
                    {
                        if (str != string.Empty)
                        {
                            ip = new CIp {
                                Ip = str,
                                Count = num
                            };
                            new Thread(new ParameterizedThreadStart(this.connectReset)).Start(ip);
                        }
                        num3++;
                    }
                    Thread.Sleep(0x1388);
                }
                if (this._CountLookup == 0x1389)
                {
                    this._CountLookup = 1;
                }
                this._CountLookup++;
            }
            Thread.Sleep(0x1388);
            Closelass.ColoseMethodNew();
            Thread.Sleep(0x9c40);
            this.StartTask();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now.Hour == 0) || (DateTime.Now.Hour == 0x18))
            {
                this.respring7h = false;
                this.respring12h = false;
                this.respring17h = false;
                this.respring23h = false;
            }
            if ((((DateTime.Now.Hour == 7) || (DateTime.Now.Hour == 12)) || (DateTime.Now.Hour == 0x11)) || (DateTime.Now.Hour == 0x17))
            {
            }
        }

        public class Closelass
        {
            public static void AccetpButtonOKTimeOut()
            {
                IntPtr zero = IntPtr.Zero;
                int num = 0;
                while (num < 20)
                {
                    Thread.Sleep(0x3e8);
                    zero = (IntPtr) FormMain.FindWindow("#32770", "PuTTY Fatal Error");
                    num++;
                    if (!(zero == IntPtr.Zero))
                    {
                        FormMain.SendMessage(FormMain.FindWindowEx(zero, IntPtr.Zero, "Button", "OK"), 0xf5, IntPtr.Zero, IntPtr.Zero);
                    }
                }
            }

            public static void ColoseMethodNew()
            {
                try
                {
                    string processName = "putty";
                    AccetpButtonOKTimeOut();
                    Process[] processesByName = Process.GetProcessesByName(processName);
                    foreach (Process process in processesByName)
                    {
                        process.Kill();
                    }
                }
                catch (Exception exception)
                {
                    CTLError.WriteError("Loi CloseMethodNew", exception.Message);
                }
            }

            [DllImport("user32.dll")]
            private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

            public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
        }


        //new funtion


        public void connect_ExcuteFile(object cmd)
        {
            CIp ip = (CIp)cmd;
            string str = ip.Ip;
            string str2 = "amz";
            this.CreateComman(ip.Count);
            string str3 = Path.Combine(Application.StartupPath, "command" + str2 + ".txt");
            string str4 = Path.Combine(Application.StartupPath, "putty.exe");
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe")
            {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = false,
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };
            Process process = new Process
            {
                StartInfo = info
            };
            process.Start();
            StreamWriter standardInput = process.StandardInput;
            standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, str, str3));
            new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
            if (!process.HasExited)
            {
                standardInput.Close();
            }
        }


        public void Replace_Command_File(string PathFile_Replace,string str_Replace)
        {
            try
            {
                List<string> list_ID = new List<string>();
                StreamReader readfile = new StreamReader(PathFile_Replace);
                while (!readfile.EndOfStream)
                {
                    string strid = readfile.ReadLine();
                    list_ID.Add(strid);

                }
                Random ran = new Random();
                int index= ran.Next(0, list_ID.Count - 1);
                StreamReader read_Command_file=new StreamReader(Path.Combine(Application.StartupPath,"commandamz.txt"));
                string strcommand=read_Command_file.ReadToEnd();
                strcommand= strcommand.Replace("{"+str_Replace+"}",list_ID[index]);
                read_Command_file.Dispose();
                read_Command_file.Close();
                StreamWriter write=new StreamWriter(Path.Combine(Application.StartupPath,"commandamz.txt"),false);
                write.Write(strcommand);
                write.Dispose();
                write.Close();
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi Replace_Command_File ", ex.Message);
            }
        }

        public void StartTask_NEW()
        {
            CIp ip;
            Thread thread;
            int num = 0;
            int hour = DateTime.Now.Hour;
            
            //chep command tu file source --> commandamz.txt
            StreamReader read_Command_file = new StreamReader(Path.Combine(Application.StartupPath, "commandsource.txt"));
            string strcommand = read_Command_file.ReadToEnd();            
            read_Command_file.Dispose();
            read_Command_file.Close();
            StreamWriter write = new StreamWriter(Path.Combine(Application.StartupPath, "commandamz.txt"), false);
            write.Write(strcommand);
            write.Dispose();
            write.Close();

            foreach(string str in Config._ListName)
            {
                string[] filename=str.Split('.');
                Replace_Command_File(Path.Combine(Application.StartupPath, filename[filename.Length - 1] + ".txt"), filename[filename.Length - 1]);
            }
            //else
            //{
                num = 0;
                foreach (string str in this._ipClient)
                {
                    if (str != string.Empty)
                    {
                        ip = new CIp
                        {
                            Ip = str,
                            Count = num
                        };
                        thread = new Thread(new ParameterizedThreadStart(this.connect_ExcuteFile));
                        thread.Start(ip);
                        num++;
                    }
                    Thread.Sleep(0x2710);
                }
                
            Thread.Sleep(0x1388);
            Closelass.ColoseMethodNew();
            Thread.Sleep(0x9c40);
            
        }

        private void timer_SetIDtoIP_Tick(object sender, EventArgs e)
        {
            StartTask_NEW();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread;
                //run Comman From Forderl
                foreach (string ipdevice in _ipClient)
                {
                    bool x = PingHost(ipdevice);
                    if (!x)
                        continue;
                    foreach (string command in Config._ListFolDerCommand)
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(command);
                        if (dinfo.Exists)
                        {
                            FileInfo[] listfile = dinfo.GetFiles("*.txt");
                            if (listfile.Length > 0)
                            {
                                foreach (FileInfo f in listfile)
                                {
                                    CIp ip = new CIp
                                    {
                                        Ip = ipdevice,
                                        file = f
                                    };
                                    thread = new Thread(new ParameterizedThreadStart(this.ExcCommandFile));
                                    thread.Start(ip);
                                }
                            }
                        }
                        Thread.Sleep(1000);
                    }
                }
                Thread.Sleep(25000);
                KillPuty();
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi Start click ", ex.Message);
            }
        }



        //backup code cu 
        /*

        public void ExcCommandFile(object cmd)
        {
            try
            {
                CIp ip = (CIp)cmd;

                string str4 = Path.Combine(Application.StartupPath, "putty.exe");
                //ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe")
                ProcessStartInfo info = new ProcessStartInfo(Environment.ExpandEnvironmentVariables("%windir%\\sysnative\\cmd.exe"))
                {
                    UseShellExecute = false,
                    ErrorDialog = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };
                Process process = new Process
                {
                    StartInfo = info
                };
                process.Start();
                StreamWriter standardInput = process.StandardInput;
                standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, ip.Ip, ip.file.FullName));
                new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
                if (!process.HasExited)
                {
                    standardInput.Close();
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi ExcCommandFile ", ex.Message);
            }
        }
         * 
         */
        
           public void ExcCommandFileRenci(object cmd)
        {
            try
            {
                CIp ip = (CIp)cmd;
                using (Renci.SshNet.SshClient client = new SshClient(ip.Ip, "root", "alpine"))// new SftpClient(ipdevice, 22, "root", "alpine"))
                        {
                            client.Connect();
                            foreach (string str in listcommand.Items)
                            {
                                client.RunCommand(str);
                                Thread.Sleep(5000);
                            }
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi ExcCommandFile ", ex.Message);
            }
        }            

        public void ExcCommandFile(object cmd)
        {
            try
            {
                CIp ip = (CIp)cmd;

                string str4 = Path.Combine(Application.StartupPath, "putty.exe");
                //ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe")
                //ProcessStartInfo info = new ProcessStartInfo(Environment.ExpandEnvironmentVariables("%windir%\\sysnative\\cmd.exe"))
                ProcessStartInfo info = new ProcessStartInfo()
                {
                    FileName=str4,
                    UseShellExecute = false,
                    ErrorDialog = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    Arguments =string.Format("-ssh -4 root@{1} 22 -pw alpine -m {2}", str4, ip.Ip, ip.file.FullName)
                };
                Process process = new Process
                {
                    StartInfo = info
                };
                process.Start();
                //StreamWriter standardInput = process.StandardInput;
                //standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, ip.Ip, ip.file.FullName));
                new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
                //if (!process.HasExited)
                //{
                //    standardInput.Close();
                //}
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi ExcCommandFile ", ex.Message);
            }
        }

        public void UploadSFTPFile(string host, string username,
string password, string sourcefile, string destinationpath, int port)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(sourcefile);
                if (d.Exists)
                {
                    foreach (FileInfo f in d.GetFiles())
                    {
                        using (SftpClient client = new SftpClient(host, port, username, password))
                        {
                            client.Connect();
                            client.ChangeDirectory(destinationpath);
                            if(client.Exists(Path.Combine(destinationpath,f.Name)))
                            {
                                CTLError.WriteError("File exists "+f.Name, host);
                                continue;
                            }
                            using (FileStream fs = new FileStream(f.FullName, FileMode.Open))
                            {
                                client.BufferSize = 4 * 1024;
                                client.UploadFile(fs, f.Name);
                            }
                            using (SshClient ssh = new SshClient(host, username, password))
                            {
                                ssh.Connect();
                                ssh.RunCommand("chmod 777 " + Path.Combine(txtdest.Text, f.Name));
                            }
                            CTLError.WriteError("OK Tranferfile "+f.Name+" voi ip " + host + " ", " TranferFile !!!");
                        }
                    }
                }
                else
                    MessageBox.Show("Vui long kiem tra lai Path Source");
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi tranfer file "+sourcefile+"IP "+host, ex.Message);
            }
        }

        public void Copyfile()
        {
            try
            {
                if (checkUploadfile.Checked)
                {

                    foreach (string ip in _ipClient)
                    {
                        bool x = PingHost(ip);

                        if (!x)
                        {
                            CTLError.WriteError("Ping False " + ip + " ", " Ping !!!");
                            continue;
                            
                        }
                        else
                        {
                            CTLError.WriteError("Ping OK " + ip + " ", " Ping !!!");
                        }
                        UploadSFTPFile(ip, "root", "alpine", txtsource.Text, txtdest.Text, 22);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkUploadfile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUploadfile.Checked)
            {
                txtdest.Enabled = true;
                txtsource.Enabled = true;
                btbrowSourcefolder.Enabled = true;
            }
            else
            {
                txtdest.Enabled = false;
                txtsource.Enabled = false;
                btbrowSourcefolder.Enabled = false;
            }
        }

        private void btbrowSourcefolder_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtsource.Text = folder.SelectedPath;
            }
        }

        private void bttranfer_Click(object sender, EventArgs e)
        {
            Copyfile();
        }


        
        

        private void btRunRenci_Click(object sender, EventArgs e)
        {
            try
            {
                if (listcommand.Items.Count <= 0)
                {
                    MessageBox.Show("Vui long Add Command");
                    return;
                }
                Thread thread;
                //run Comman From Forderl
                foreach (string ipdevice in _ipClient)
                {

                    try
                    {
                        bool x = PingHost(ipdevice);

                        if (!x)
                        {
                            CTLError.WriteError("Ping Failse " + ipdevice + " ", " Ping !!!");
                            continue;
                            
                        }                       

                        foreach (string  str in listcommand.Items)
                        {
                            if (str == string.Empty)
                                continue;
                            CIp ip = new CIp
                            {
                                Ip = ipdevice
                                
                            };
                            thread = new Thread(new ParameterizedThreadStart(this.ExcCommandFileRenci));
                            thread.Start(ip);
                            
                        }
                        //using (Renci.SshNet.SshClient client = new SshClient(ipdevice, "root", "alpine"))// new SftpClient(ipdevice, 22, "root", "alpine"))
                        //{
                        //    client.Connect();
                        //    foreach (string str in listcommand.Items)
                        //    {
                        //        client.RunCommand(str);
                        //    }
                        //}
                    }
                    catch (Exception ex)
                    {
                        CTLError.WriteError("Loi connect ssh " + ipdevice, ex.Message);
                    }
                               
                       
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi RunRenci click ", ex.Message);
            }




            
        }

        private void btAddCommand_Click(object sender, EventArgs e)
        {
            if (txtCommandadd.Text != string.Empty)
            {
                if (txtCommandadd.Lines.Length > 1)
                {
                    string[] listadd= txtCommandadd.Text.Split(new string[] {"\n"},StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in listadd)
                    {
                        if(s.Trim()!=string.Empty)
                            listcommand.Items.Add(s.Trim());
                    }
                }
                else
                listcommand.Items.Add(txtCommandadd.Text);
            }
        }

        private void listcommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if(listcommand.SelectedIndex>=0)
                    listcommand.Items.RemoveAt(listcommand.SelectedIndex);
            }
        }

        private void btloadList_Click(object sender, EventArgs e)
        {
            try
            {
                listipaddress.Items.Clear();
                //for (int i = 11; i < 200; i++)
                //{
                //    System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                //    System.Net.NetworkInformation.PingReply rep = p.Send(txtipaddress.Text+i);
                //    if (rep.Status == System.Net.NetworkInformation.IPStatus.Success)
                //    {
                //        //host is active
                //        listipaddress.Items.Add(txtipaddress.Text + i);
                //    }

                //}

                List<string> x = IPList2();
                foreach (string s in x)
                {
                    listipaddress.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi bt load list ", ex.Message);
            }
        }


         CountdownEvent countdown;
         int upCount = 0;
         object lockObj = new object();
        const bool resolveNames = true;

        //public void p_PingCompleted(object sender, PingCompletedEventArgs e)
        //{
        //    string ip = (string)e.UserState;
        //    if (e.Reply != null && e.Reply.Status == IPStatus.Success)
        //    {
        //        if (resolveNames)
        //        {
        //            string name;
        //            try
        //            {
        //                IPHostEntry hostEntry = Dns.GetHostEntry(ip);
        //                name = hostEntry.HostName;
        //            }
        //            catch (SocketException ex)
        //            {
        //                name = "?";
        //            }
        //            //add vao list box
        //            listipaddress.Items.Add(ip);
        //            //Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
        //        }
        //        else
        //        {
        //            Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
        //        }
        //        lock (lockObj)
        //        {
        //            upCount++;
        //        }
        //    }
        //    else if (e.Reply == null)
        //    {
        //        Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
        //    }
        //    countdown.Signal();
        //}


        private delegate void MyPing(int id);
        public List<string> IPList2()
        {

            string myipsplit = string.Empty;
            string localhostname = Dns.GetHostName();
            IPAddress[] paddresses = Dns.GetHostAddresses(localhostname);
            //string myip = paddresses.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault().ToString();
            //string[] myiparray = myip.Split(new[] { '.' });
            //for (int j = 1; j < myiparray.Length; j++)
            //    myipsplit += myiparray[j - 1] + ".";
            myipsplit = txtipaddress.Text;
            //Trace.WriteLine(DateTime.Now);
            var results = new string[0x100];
            MyPing ping =
             id =>
             {
                 string ls = myipsplit + id;
                 var pingSender = new Ping();
                 PingReply reply = pingSender.Send(ls, 100);
                 if (reply != null)
                     if (reply.Status == IPStatus.Success)
                         results[id] = reply.Address.ToString();
             };
            var asyncResults = new IAsyncResult[0x100];
            for (int i = 1; i < 0x100; i++)
            {
                asyncResults[i] = ping.BeginInvoke(i, null, null);
            }
            for (int i = 1; i < 0x100; i++)
            {
                ping.EndInvoke(asyncResults[i]);
            }
            Trace.WriteLine(DateTime.Now);
            //var sb = new StringBuilder();
            List<string> listip = new System.Collections.Generic.List<string>();
            for (int i = 11; i < 200; i++)
            {
                if (results[i] != null)
                    //sb.AppendFormat("{0} ", results[i]);
                    listip.Add(results[i]);
            }
            //return sb.ToString();
            return listip;
        }

        private void btexport_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter write = new StreamWriter(Path.Combine(Application.StartupPath, DateTime.Now.ToString("ddMMyyyy") + "list.txt"), false);
                foreach (string ip in listipaddress.Items)
                {
                    write.WriteLine(ip);
                }
                write.Dispose();
                write.Close();
                MessageBox.Show("Export file thanh cong !!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export ko thanh cong .....");
                CTLError.WriteError("Loi Export ip list ", ex.Message);
            }
        }
        public void KillPuty()
        {
            try
            {
                Process[] pr = Process.GetProcessesByName("putty");
                foreach (Process p in pr)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi KillPuty ", ex.Message);

            }
        }

        private void btload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open=new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(open.FileName);
                while (!read.EndOfStream)
                {
                    string str = read.ReadLine();
                    if(str.Trim()!=string.Empty)
                        listcommand.Items.Add(str);
                }

            }
        }
        public bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private void btcheckip_Click(object sender, EventArgs e)
        {
            //load list
            DataTable dt = new DataTable();
            dt.Columns.Add("IP");
            dt.Columns.Add("Status");
            StreamReader reader = new StreamReader(Path.Combine(Application.StartupPath, "list.txt"));
            while (!reader.EndOfStream)
            {
                string item = reader.ReadLine();
                //this.listipaddress.Items.Add(item.Trim());
                //this._ipClient.Add(item);
                DataRow r = dt.NewRow();
                r["IP"] = item.Trim();
                r["Status"] = "0";
                dt.Rows.Add(r);
            }
            gridviewIP.DataSource = dt;

            foreach (DataRow row in dt.Rows)
            {
                bool check=PingHost(row["IP"].ToString());
                if(check)
                    row["Status"]="1";
                else
                    row["Status"]="2";
            }
            gridviewIP.DataSource=dt;
        }

        private void btexportListOK_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter write = new StreamWriter(Path.Combine(Application.StartupPath, DateTime.Now.ToString("ddMMyyyy") + "list.txt"), false);
                DataTable dt =(DataTable) gridviewIP.DataSource;
                foreach (DataRow r in dt.Rows)
                {
                    if(r["Status"].ToString().Trim()=="1")
                        write.WriteLine(r["IP"].ToString().Trim());
                }
                write.Dispose();
                write.Close();
                MessageBox.Show("Export file thanh cong !!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export ko thanh cong .....");
                CTLError.WriteError("Loi Export ip list gridview ", ex.Message);
            }
        }

        private void btbrow1deb_Click(object sender, EventArgs e)
        {
            if (checkinstAll1deb.Checked)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtpath1deb.Text = folder.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtpath1deb.Text = open.FileName;
                }
            }
        }

        private void btinstall1ded_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(txtpath1deb.Text);
            if (!d.Exists)
            {
                MessageBox.Show("Khong co thu muc ! vui long xem lai");
                return;
            }
            if (checkinstAll1deb.Checked)
            {
                DirectoryInfo direc = new DirectoryInfo(txtpath1deb.Text);
                foreach (FileInfo file in direc.GetFiles("*.deb"))
                {
                    TranferFileDebInstall(file.FullName, txtipdebfile.Text);
                }
            }
            else
            {
                FileInfo file = new FileInfo(txtpath1deb.Text);
                TranferFileDebInstall(file.FullName, txtipdebfile.Text);
            }
            RespringDevice(txtipdebfile.Text);

        }

        public void TranferFileDebInstall(string pathfiledeb, string ipdevice)
        {
            try
            {
                bool x = PingHost(ipdevice);

                if (!x)
                {
                    MessageBox.Show("Khong ket noi den thiet bi");
                    return;
                }

                FileInfo f=new FileInfo(pathfiledeb);
                using (SftpClient client = new SftpClient(ipdevice, 22, "root", "alpine"))
                {
                    client.Connect();
                    client.ChangeDirectory("/private/var/mobile/");
                    using (FileStream fs = new FileStream(f.FullName, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fs, f.Name);
                    }
                    using (SshClient ssh = new SshClient(ipdevice, "root", "alpine"))
                    {
                        ssh.Connect();
                        ssh.RunCommand("chmod 777 " + Path.Combine("/private/var/mobile", f.Name));
                    }
                }

                using(SshClient rencommand=new SshClient(ipdevice,"root","alpine"))
                {
                    rencommand.Connect();
                    rencommand.RunCommand("dpkg - i " + Path.Combine("/private/var/mobile", f.Name));

                }

                
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi TranferFileDeb and install ssh " + ipdevice, ex.Message);
            }
        }

        public void RespringDevice(string ip)
        {
            try
            {
                using (SshClient rencommand = new SshClient(ip, "root", "alpine"))
                {
                    rencommand.Connect();
                    rencommand.RunCommand("respring");

                }
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi RespringDevice " + ip + " ", ex.Message);
            }
        }

        private void btinstallfull_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(txtpahtinstfull.Text);
            if (checkinstAllfull.Checked)
                if (!d.Exists)
                {
                    MessageBox.Show("Khong co thu muc ! vui long xem lai");
                    return;
                }
            if (checkinstAllfull.Checked)
            {
                DirectoryInfo direc = new DirectoryInfo(txtpahtinstfull.Text);
                foreach (FileInfo file in direc.GetFiles("*.deb"))
                {
                    foreach (string strip in listBoxInstalldeb.Items)
                    {
                        bool x = PingHost(strip);

                        if (!x)
                        {
                            CTLError.WriteError("Ping Failse InstallDeb " + strip + " ", "");
                            continue;
                        }

                        TranferFileDebInstall(file.FullName, strip);

                        RespringDevice(strip);
                    }
                    
                }
            }
            else
            {
                FileInfo file = new FileInfo(txtpahtinstfull.Text);
                foreach (string strip in listBoxInstalldeb.Items)
                {
                    bool x = PingHost(strip);

                    if (!x)
                    {
                        CTLError.WriteError("Ping Failse InstallDeb " + strip + " ", "");
                        continue;
                    }

                    TranferFileDebInstall(file.FullName, strip);

                    RespringDevice(strip);
                }
                
            }
            
        }

        private void btbrowfull_Click(object sender, EventArgs e)
        {
            if (checkinstAllfull.Checked)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtpahtinstfull.Text = folder.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtpahtinstfull.Text = open.FileName;
                }
            }
        }
        public void LoadListInstallDeb()
        {
            try
            {
                
                StreamReader reader = new StreamReader(Path.Combine(Application.StartupPath, "list.txt"));
                while (!reader.EndOfStream)
                {
                    string item = reader.ReadLine();
                    this.listBoxInstalldeb.Items.Add(item.Trim());
                    
                }
            }
            catch (Exception exception)
            {
                CTLError.WriteError("loi LoadList ip install deb ", exception.Message);
            }
        }

        public void ExcCommandTranferFilePSCP(object cmd)
        {
            try
            {
                CIp ip = (CIp)cmd;

                string str4 = Path.Combine(Application.StartupPath, "Pscp.exe");
                //ProcessStartInfo info = new ProcessStartInfo(@"C:\Windows\System32\cmd.exe")
                //ProcessStartInfo info = new ProcessStartInfo(Environment.ExpandEnvironmentVariables("%windir%\\sysnative\\cmd.exe"))
                ProcessStartInfo info = new ProcessStartInfo()
                {
                    FileName = str4,
                    UseShellExecute = false,
                    ErrorDialog = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    Arguments = string.Format("-l root -pw alpine -p 22 root@{1} {0} {2}", ip.pathSource, ip.Ip, ip.pathTo)
                };
                Process process = new Process
                {
                    StartInfo = info
                };
                process.Start();
                //StreamWriter standardInput = process.StandardInput;
                //standardInput.WriteLine(string.Format("{0} -ssh -4 root@{1} 22 -pw alpine -m {2}", str4, ip.Ip, ip.file.FullName));
                new Thread(new ThreadStart(this.AccetpButtonSave)).Start();
                //if (!process.HasExited)
                //{
                //    standardInput.Close();
                //}
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi ExcCommandFile ", ex.Message);
            }
        }

        private void bttranferputty_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread;
                //run Comman From Forderl
                foreach (string ipdevice in _ipClient)
                {
                    bool x = PingHost(ipdevice);
                    if (!x)
                        continue;                    
                        
                               
                                    CIp ip = new CIp
                                    {
                                        Ip = ipdevice,
                                        pathSource = txtsource.Text,
                                        pathTo=txtdest.Text
                                    };
                                    thread = new Thread(new ParameterizedThreadStart(this.ExcCommandTranferFilePSCP));
                                    thread.Start(ip);
                                
                           
                       
                        Thread.Sleep(2000);
                    }
               
                //Thread.Sleep(25000);
                //KillPuty();
            }
            catch (Exception ex)
            {
                CTLError.WriteError("Loi Start click ", ex.Message);
            }
        }
    }
}

