using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrpConfigManager.Utils
{
    public class CmdHelper
    {
        /// <summary>
        /// 定义委托接口处理函数，用于实时处理cmd输出信息
        /// </summary>
        public delegate void Method(string cmd);
        /// <summary>
        /// 定义委托接口处理函数，用于实时处理cmd输出信息
        /// </summary>
        public delegate void CallBack(string line);

        /// <summary>
        /// 在新的线程中执行method逻辑
        /// </summary>
        public static void ThreadRun(Method method, string cmd, Form form = null, Button button = null, String Text = "执行中")
        {
            Thread thread = new Thread(delegate ()
            {
                // 允许不同线程间的调用
                Control.CheckForIllegalCrossThreadCalls = false;

                // 设置按钮和界面按钮不可用
                String text = "";
                if (form != null) form.ControlBox = false;

                if (button != null)
                {
                    text = button.Text;
                    button.Text = Text;
                    button.Enabled = false;
                }

                // 执行method逻辑
                method?.Invoke(cmd);

                if (button != null)
                {
                    button.Text = text;
                    button.Enabled = true;
                }
                if (form != null) form.ControlBox = true;
            });

            thread.Priority = ThreadPriority.Highest;               // 设置子线程优先级
            Thread.CurrentThread.Priority = ThreadPriority.Highest; // 设置当前线程为最高优先级
            thread.Start();
        }

        /// <summary>
        /// 以后台进程的形式执行应用程序（d:\*.exe）
        /// </summary>
        public static Process newProcess(String exe)
        {
            Process P = new Process();
            P.StartInfo.CreateNoWindow = true;
            P.StartInfo.FileName = exe;
            P.StartInfo.UseShellExecute = false;
            P.StartInfo.RedirectStandardError = true;
            P.StartInfo.RedirectStandardInput = true;
            P.StartInfo.RedirectStandardOutput = true;
            //P.StartInfo.WorkingDirectory = @"C:\windows\system32";
            P.Start();
            return P;
        }

        /// <summary>
        /// 以进程的形式打开应用程序（d:\*.exe）,并执行命令
        /// </summary>
        public static void RunProgram(string programName, string cmd)
        {
            Process P = newProcess(programName);
            if (cmd.Length != 0)
            {
                P.StandardInput.WriteLine(cmd);
            }
            P.Close();
        }

        /// <summary>
        /// 正常启动window应用程序（d:\*.exe）
        /// </summary>
        public static void Open(String exe)
        {
            System.Diagnostics.Process.Start(exe);
        }

        /// <summary>
        /// 正常启动window应用程序（d:\*.exe）,并传递初始命令参数
        /// </summary>
        public static void Open(String exe, String args)
        {
            System.Diagnostics.Process.Start(exe, args);
        }

        /// <summary>
        /// 执行CMD语句,实时获取cmd输出结果，输出到call函数中
        /// </summary>
        /// <param name="cmd">要执行的CMD命令</param>
        public static string Run(string cmd, CallBack callBack)
        {
            //string cmd_exe = DependentFiles.curDir() + "tools\\cmd.exe";
            Process P = newProcess("cmd.exe");
            P.StandardInput.WriteLine(cmd);
            P.StandardInput.WriteLine("exit");

            string outStr = "";
            string line = "", error = "";
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');

            try
            {
                for (int i = 0; i < 3; i++) P.StandardOutput.ReadLine();

                while ((line = P.StandardOutput.ReadLine()) != null || ((line = P.StandardError.ReadToEnd()) != null && !line.Trim().Equals("")))
                {
                    // cmd运行输出信息
                    if (!line.EndsWith(">exit") && !line.Equals(""))
                    {
                        if (line.StartsWith(baseDir + ">")) line = line.Replace(baseDir + ">", "cmd>\r\n"); // 识别的cmd命令行信息
                        line = ((line.Contains("[Fatal Error]") || line.Contains("ERROR:") || line.Contains("Exception")) ? "【E】 " : "") + line;
                        callBack?.Invoke(line);
                        outStr += line + "\r\n";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // MessageBox.Show(ex.Message);
            }

            P.WaitForExit();
            P.Close();
            return outStr;
        }

        public static string ProcessCMD(string cmd)
        {
            string strOuput = string.Empty;
            try
            {
                var strInput = cmd;
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();
                //向cmd窗口发送输入信息
                //  p.StandardInput.WriteLine(strInput);
                p.StandardInput.WriteLine(strInput + "&exit");
                p.StandardInput.AutoFlush = true;

                //获取输出信息
                strOuput = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();

                return strOuput;
            }
            catch (Exception ex)
            {
                throw new Exception($"执行自定义命令发生错误,原因:{ex.Message},堆栈:{ex.StackTrace}");
            }

        }
    }
}
