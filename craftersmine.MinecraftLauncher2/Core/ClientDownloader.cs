using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class ClientDownloader
    {
        private Downloader downloader;
        private Queue<ClientFile> downloadQueue = new Queue<ClientFile>();
        private bool dontRaiseCompletedEvent = false;

        public event EventHandler<ClientArchiveDownloadProgressEventArgs> ClientArchiveDownloadProgress;
        public event EventHandler<ClientArchiveDownloadedEventArgs> ClientArchiveDownloaded;
        public event EventHandler ClientArchiveDownloadQueueCancelled;
        public event EventHandler ClientArchivesDownloaded;

        public ClientFile DownloadingFile { get; private set; }
        public int TotalQueueSize { get; private set; }
        public int Downloaded { get; private set; }

        public ClientDownloader()
        {
            downloader = new Downloader();
            downloader.DownloadCompleted += downloadCompleted;
            downloader.DownloadProgressChanged += downloadProgressChanged;
        }

        private void downloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            ClientArchiveDownloadProgress?.Invoke(this, new ClientArchiveDownloadProgressEventArgs() { DownloadedSize = e.BytesReceived, TotalSize = e.TotalBytesToReceive, Percentage = ((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100.0f });
        }

        private void downloadCompleted(object sender, System.Net.DownloadDataCompletedEventArgs e)
        {
            if (!dontRaiseCompletedEvent)
                ClientArchiveDownloaded?.Invoke(this, new ClientArchiveDownloadedEventArgs() { FileName = DownloadingFile.FileName });
        }

        public void AddToQueue(string url, string filepath)
        {
            downloadQueue.Enqueue(new ClientFile(url, filepath));
            TotalQueueSize = downloadQueue.Count;
        }

        public async void DownloadNext()
        {
            if (downloadQueue.Count < 1)
            {
                ClientArchivesDownloaded?.Invoke(this, EventArgs.Empty);
                return;
            }

            DownloadingFile = downloadQueue.Dequeue();
            await downloader.DownloadFile(DownloadingFile.DownloadUrl, DownloadingFile.FileName);
            Downloaded++;
        }

        public void Cancel()
        {
            dontRaiseCompletedEvent = true;
            Logger.Instance.Log(LogEntryType.Info, "Cancelling client download...");
            DownloadingFile = null;
            TotalQueueSize = 0;
            Downloaded = 0;
            downloader.CancelDownload();
            downloadQueue.Clear();

            ClientArchiveDownloadQueueCancelled?.Invoke(this, EventArgs.Empty);
        }
    }

    public sealed class ClientArchiveDownloadProgressEventArgs : EventArgs
    {
        public float Percentage { get; set; }
        public long TotalSize { get; set; }
        public long DownloadedSize { get; set; }
    }

    public sealed class ClientArchiveDownloadedEventArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
