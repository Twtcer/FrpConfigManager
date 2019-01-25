using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FrpConfigManager.Utils;

namespace FrpConfigManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static readonly string _BasePath = AppDomain.CurrentDomain.BaseDirectory;

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //open file 
            openFileDialog1.InitialDirectory = _BasePath;
            openFileDialog1.Filter = "配置文件|*.ini";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName;
                rtxtConfig.Text = File.ReadAllText(path);
                rtxtConfig.AppendText("");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadDefaultConfig();
        }

        private void LoadDefaultConfig()
        {
            var path = $"{_BasePath}{txtPath.Text}";
            if (!System.IO.File.Exists(path))
            {
                return;
            }
            rtxtConfig.Text = File.ReadAllText(path);
            rtxtConfig.AppendText("");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                CmdHelper.Run($"frpc.exe -c {txtPath.Text}", Logger); 
            }));
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true; 
        }

        public void Logger(string info)
        {
            this.Invoke(new Action(() => {
                rtxtRunInfo.Text += $"{info}" + Environment.NewLine;
            }));
        }

    }
}
