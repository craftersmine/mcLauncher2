using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.MinecraftLauncher2.Core;
using craftersmine.MinecraftLauncher2.Extensions;

namespace craftersmine.MinecraftLauncher2
{
    public partial class FirstStartForm : Form
    {
        public FirstStartForm()
        {
            InitializeComponent();
            enableLogging.Checked = SettingsManager.EnableLogging;
            memAlloc.Value = SettingsManager.MaxAllocatedMemory;
            downloadedContentStorage.Text = SettingsManager.DownloadedContentStorage;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.Description = "Выберите папку лаунчера";
            folderBrowserDialog.ShowDialog();
            downloadedContentStorage.Text = folderBrowserDialog.SelectedPath;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (!downloadedContentStorage.Text.IsNullEmptyOrWhitespace())
            {
                if (Path.IsPathRooted(downloadedContentStorage.Text) && !downloadedContentStorage.Text.Contains(" "))
                {
                    if (!Directory.Exists(downloadedContentStorage.Text))
                        Directory.CreateDirectory(downloadedContentStorage.Text);
                    SettingsManager.EnableLogging = enableLogging.Checked;
                    SettingsManager.MaxAllocatedMemory = (int)memAlloc.Value;
                    SettingsManager.DownloadedContentStorage = downloadedContentStorage.Text;
                    SettingsManager.FirstStart = false;
                    MessageBox.Show("Сейчас лаунчер будет перезапущен. Выбранные настройки можно будет изменить позднее", "Настройка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
            MessageBox.Show("Указанный путь не корректный, если путь содержит пробелы, удалите их, так как это вызывает проблемы с клиентом! Выберите корректный путь для продолжения!", "Неверный путь!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Настройка лаунчера не была завершена! Продолжение невозможно! Вы действительно хотите выйти?", "Отмена настройки.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
            }
        }
    }
}
