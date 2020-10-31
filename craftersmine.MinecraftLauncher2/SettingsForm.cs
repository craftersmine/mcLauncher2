using craftersmine.MinecraftLauncher2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.MinecraftLauncher2
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            enableLogging.Checked = SettingsManager.EnableLogging;
            memAlloc.Value = SettingsManager.MaxAllocatedMemory;
            firstStart.Checked = SettingsManager.FirstStart;
            jreInstalled.Checked = SettingsManager.IsJreInstalled;
            if (SettingsManager.EnableLogging)
                logPath.Text = Logger.Instance.LogFile;
            else logPath.Text = "Журналирование отключено";
            downloadedContentStorage.Text = SettingsManager.DownloadedContentStorage;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            SettingsManager.EnableLogging = enableLogging.Checked;
            SettingsManager.MaxAllocatedMemory = (int)memAlloc.Value;
            SettingsManager.FirstStart = firstStart.Checked;
            SettingsManager.IsJreInstalled = jreInstalled.Checked;
            if (SettingsManager.FirstStart)
            {
                switch (MessageBox.Show("Для переустановки лаунчера требуется перезапуск! Выполнить перезапуск?", "Требуется перезапуск.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        Application.Restart();
                        break;
                    case DialogResult.No:
                        Close();
                        break;
                }
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Logger.Instance.LogFile);
        }
    }
}
