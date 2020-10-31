using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using craftersmine.MinecraftLauncher2.Exceptions;
using Newtonsoft.Json;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class Downloader
    {
        private WebClient webClient;

        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler<DownloadDataCompletedEventArgs> DownloadCompleted;

        public Downloader()
        {
            webClient = new WebClient();
            webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            webClient.DownloadFileCompleted += downloadFileCompleted;
            webClient.DownloadProgressChanged += downloadProgressChanged;
        }

        private void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressChanged?.Invoke(this, e);
        }

        private void downloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DownloadCompleted?.Invoke(this, null);
        }

        public async Task<MCBuildInfo[]> DownloadBuildlist()
        {
            return await Task.Run(new Func<MCBuildInfo[]>(() => { return downloadBuildlist(); }));
        }

        private MCBuildInfo[] downloadBuildlist()
        {
            string cachedBuildListPath = Path.Combine(SettingsManager.DownloadedContentStorage, "metadata\\builds.json");
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Downloading build list...");
                string buildList = webClient.DownloadString(LauncherSystemSettings.BuildsInfosJsonLink);
                var mcbuildlist = JsonConvert.DeserializeObject<MCBuildInfo[]>(buildList, new JsonSerializerSettings() { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });
                Logger.Instance.Log(LogEntryType.Info, "Caching build list...");
                File.WriteAllText(cachedBuildListPath, buildList);
                return mcbuildlist;
            }
            catch (Exception ex)
            {
                if (!File.Exists(cachedBuildListPath))
                    throw new LauncherException("No cached build infos!", LauncherExceptionErrorCode.UnableToDownloadBuildList, ex);
                else
                {
                    Logger.Instance.Log(LogEntryType.Warning, "Unable to download build list! Loading from cache...");
                    string cachedList = File.ReadAllText(cachedBuildListPath);
                    var mcbuildlist = JsonConvert.DeserializeObject<MCBuildInfo[]>(cachedList);
                    return mcbuildlist;
                }
            }
        }
        public async Task<LauncherData> DownloadLauncherData()
        {
            return await Task.Run(new Func<LauncherData>(() => { return downloadLauncherData(); }));
        }

        private LauncherData downloadLauncherData()
        {
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Downloading launcher data...");
                string launcherMetadata = webClient.DownloadString(LauncherSystemSettings.LauncherDataJsonLink);
                var lData = JsonConvert.DeserializeObject<LauncherData>(launcherMetadata);
                return lData;
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to download launcher data. Download interrupted!", LauncherExceptionErrorCode.UnableToDownloadLauncherData, ex);
            }
        }

        public async Task<MCVersion[]> DownloadClientList()
        {
            return await Task.Run(new Func<MCVersion[]>(() => { return downloadClientList(); }));
        }

        private MCVersion[] downloadClientList()
        {
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Downloading client list...");
                string clientList = webClient.DownloadString(LauncherSystemSettings.ClientListJsonLink);
                var mcClientList = JsonConvert.DeserializeObject<MCVersion[]>(clientList);
                return mcClientList;
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to download client list. Download interrupted!", LauncherExceptionErrorCode.UnableToDownloadClientList, ex);
            }
        }

        public async Task<bool> DownloadFile(string uri, string filepath)
        {
            return await Task.Run(new Func<bool>(() => { return downloadFile(uri, filepath); }));
        }

        private bool downloadFile(string uri, string filepath)
        {
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Downloading file: " + uri);
                webClient.DownloadFileAsync(new Uri(uri), filepath);
                return true;
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to download file: " + uri + "\r\n" + ex.Message, LauncherExceptionErrorCode.UnableToDownloadFile, ex);
            }
        }

        public void CancelDownload()
        {
            webClient.CancelAsync();
        }
    }
}
