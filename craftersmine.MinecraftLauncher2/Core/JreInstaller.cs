using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.MinecraftLauncher2.Exceptions;
using Ionic.Zip;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class JreInstaller
    {
        private Downloader downloader;

        public event EventHandler<JREDownloadProgressChangedEventArgs> JREDownloadProgressChanged;
        public event EventHandler JREDownloadCompleted;
        public event EventHandler JREInstallationCompleted;
        public event EventHandler JREInstallCancelled;

        public string JreTempArchivePath { get; set; }
        public bool IsInstallAllowed { get; private set; } = true;
        public bool IsInstallCompleted { get; private set; }
        
        public JreInstaller()
        {
            downloader = new Downloader();
            downloader.DownloadCompleted += downloadComplete;
            downloader.DownloadProgressChanged += downloadProgressChanged;
        }

        public async Task Install(string destinationDir)
        {
            if (IsInstallAllowed)
                await Task.Run(new Action(() => { install(destinationDir); }));
        }

        public void Cancel()
        {
            IsInstallCompleted = false;
            IsInstallAllowed = false;
            Logger.Instance.Log(LogEntryType.Info, "Cancelling JRE installation...");
            downloader.CancelDownload();
            JREInstallCancelled?.Invoke(this, EventArgs.Empty);
        }

        private void install(string destDir)
        {
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Installing JRE...");
                string arc = Path.Combine(StaticData.TempPath, "jre.zip");
                ZipFile archive = new ZipFile(arc);
                archive.ExtractAll(destDir, ExtractExistingFileAction.OverwriteSilently);
                archive.Dispose();
                Logger.Instance.Log(LogEntryType.Done, "JRE Installed!");
                JREInstallationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to install JRE!", LauncherExceptionErrorCode.JreInstallationFailed, ex);
            }
        }

        private void downloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            JREDownloadProgressChanged?.Invoke(this, new JREDownloadProgressChangedEventArgs() { Received = e.BytesReceived, Total = e.TotalBytesToReceive, Percentage = ((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100.0f });
        }

        private void downloadComplete(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            JREDownloadCompleted?.Invoke(this, EventArgs.Empty);
        }

        public async Task DownloadJre(string uri)
        {
            Logger.Instance.Log(LogEntryType.Info, "Downloading JRE...");
            await downloadJre(uri);
        }

        private async Task downloadJre(string uri)
        {
            JreTempArchivePath = Path.Combine(StaticData.TempPath, "jre.zip");

            await downloader.DownloadFile(uri, JreTempArchivePath);
        }
    }

    public sealed class JREDownloadProgressChangedEventArgs : EventArgs
    {
        public long Received { get; set; }
        public long Total { get; set; }
        public float Percentage { get; set; }
    }
}
