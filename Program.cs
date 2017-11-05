using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TYSJ
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            byte[] temp = Properties.Resources.CSkin;
            System.IO.FileStream fileStream = new System.IO.FileStream(Application.StartupPath + @"\CSkin.dll", System.IO.FileMode.OpenOrCreate);
            fileStream.Write(temp, 0, (int)(temp.Length));
            fileStream.Close();
            temp = Properties.Resources.Clean;
            fileStream = new System.IO.FileStream(Application.StartupPath + @"\Clean.exe", System.IO.FileMode.OpenOrCreate);
            fileStream.Write(temp, 0, (int)(temp.Length));
            fileStream.Close();
            temp = Properties.Resources.WinAPI32;
            fileStream = new System.IO.FileStream(Application.StartupPath + @"\WinAPI32.dll", System.IO.FileMode.OpenOrCreate);
            fileStream.Write(temp, 0, (int)(temp.Length));
            fileStream.Close();
            int a = 0;
            if (args.Contains("-online"))
            {
                Form1 form1 = new Form1(args);
                form1.ShowDialog();
            }
            else if (args.Contains("-guid"))
            {
                    foreach (string b in args)
                    {
                        if (b == "-guid")
                        {
                            string guid = args[a + 1];
                            Form1 form1 = new Form1(args);
                            form1.guid = guid;
                            form1.ShowDialog();
                            break;
                        }
                        else
                        {
                            a = a + 1;
                        }
                    }
                    a = 0;
            }
            else
            {
                MessageForm.Show("程序无启动引导,请检查问题!");
                Process.Start(Directory.GetCurrentDirectory() + @"\Clean.exe", "-id" + Process.GetCurrentProcess().Id.ToString() + " -filename" + Process.GetCurrentProcess().ProcessName);
                return;
            }
        }
    }
}
