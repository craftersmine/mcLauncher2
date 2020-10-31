using craftersmine.MinecraftLauncher2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.MinecraftLauncher2.Extensions;
using System.IO;
using craftersmine.MinecraftLauncher2.Exceptions;
using craftersmine.MinecraftLauncher2.Properties;

namespace craftersmine.MinecraftLauncher2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Settings.Default.Upgrade();

                new Logger(Environment.GetEnvironmentVariable("TEMP"), "MCLAUNCHER");
                if (SettingsManager.DownloadedContentStorage.IsNullEmptyOrWhitespace())
                    SettingsManager.DownloadedContentStorage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".craftersmine\\MinecraftLauncher");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Logger.Instance.Log(LogEntryType.Info, "Setting value EnableLogging: " + SettingsManager.EnableLogging);
                Logger.Instance.Log(LogEntryType.Info, "Setting value DownloadedContentStorage: " + SettingsManager.DownloadedContentStorage);
                Logger.Instance.Log(LogEntryType.Info, "Setting value FirstStart: " + SettingsManager.FirstStart);
                Logger.Instance.Log(LogEntryType.Info, "Setting value IsJreInstalled: " + SettingsManager.IsJreInstalled);
                Logger.Instance.Log(LogEntryType.Info, "Setting value LastBuildId: " + SettingsManager.LastBuildId);
                Logger.Instance.Log(LogEntryType.Info, "Setting value MaxAllocatedMemory: " + SettingsManager.MaxAllocatedMemory);
                Logger.Instance.Log(LogEntryType.Info, "Setting value Username: " + SettingsManager.Username);

                if (!SettingsManager.FirstStart)
                {
                    CheckDirectoryStructure();
                    Application.Run(new MainForm());
                }
                else Application.Run(new FirstStartForm());
                Logger.Instance.Log(LogEntryType.Info, "Exiting launcher...");
            }
            catch (LauncherException ex)
            {
                Logger.Instance.Log(LogEntryType.Crash, "Unexpected launcher exception! Launcher will be halted! Here some cookies.");
                Logger.Instance.Log(LogEntryType.Crash, "Error code: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix());
                Logger.Instance.LogException(LogEntryType.Crash, ex);
                Logger.Instance.Log(LogEntryType.Crash, "Additional exception:");
                Logger.Instance.LogException(LogEntryType.Crash, ex.InnerException);
                switch (ex.ErrorCode)
                {
                    case LauncherExceptionErrorCode.GenericLauncherError:
                        MessageBox.Show("Произошла ошибка лаунчера! Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Непредвиденная ошибка лаунчера!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        break;
                }

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                Logger.Instance.Log(LogEntryType.Crash, "Unexpected launcher exception! Launcher will be halted! Here some cookies.");
                Logger.Instance.LogException(LogEntryType.Crash, ex);
                MessageBox.Show("Произошла непредвиденная ошибка лаунчера. Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ex.HResult.ToHexademicalStringWithPrefix(), "Непредвиденная ошибка лаунчера!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static void CheckDirectoryStructure()
        {
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Checking Launcher directory structure...");
                StaticData.MetadataPath = Path.Combine(SettingsManager.DownloadedContentStorage, "metadata");
                StaticData.TempPath = Path.Combine(SettingsManager.DownloadedContentStorage, "temp");
                StaticData.JrePath = Path.Combine(SettingsManager.DownloadedContentStorage, "jre");
                StaticData.ClientsRootPath = Path.Combine(SettingsManager.DownloadedContentStorage, "clients");

                if (!Directory.Exists(SettingsManager.DownloadedContentStorage))
                    Directory.CreateDirectory(SettingsManager.DownloadedContentStorage);
                if (!Directory.Exists(StaticData.MetadataPath))
                    Directory.CreateDirectory(StaticData.MetadataPath);
                if (!Directory.Exists(StaticData.TempPath))
                    Directory.CreateDirectory(StaticData.TempPath);
                if (!Directory.Exists(StaticData.ClientsRootPath))
                    Directory.CreateDirectory(StaticData.ClientsRootPath);
                if (!Directory.Exists(StaticData.JrePath))
                    Directory.CreateDirectory(StaticData.JrePath);
                Logger.Instance.Log(LogEntryType.Done, "Launcher directory structure checked and restored if needed!");
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to restore launcher directory structure!", LauncherExceptionErrorCode.UnableToCreateLauncherDirectoryStructure, ex);
            }
        }
    }
}
