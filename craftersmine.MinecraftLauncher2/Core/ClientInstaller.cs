using craftersmine.MinecraftLauncher2.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class ClientInstaller
    {
        private Queue<string> archives = new Queue<string>();
        private int totalArchivesCount = 0;

        public string InstallationDirectory { get; set; }
        public bool IsInstallAllowed { get; set; }
        public event EventHandler<InstallingArchiveEventArgs> InstallingArchive;
        public event EventHandler InstallationCompleted;

        public ClientInstaller(string[] filesToInstall, string installationDir)
        {
            InstallationDirectory = installationDir;

            totalArchivesCount = filesToInstall.Length;

            foreach (var file in filesToInstall)
            {
                archives.Enqueue(file);
            }
        }

        public async Task Install()
        {
            if (IsInstallAllowed)
                await Task.Run(new Action(() => { install(); }));
        }

        private void install()
        {
            if (!Directory.Exists(InstallationDirectory))
                Directory.CreateDirectory(InstallationDirectory);

            string arcName = "";
            try
            {
                int arcCount = 0;
                while (archives.Count > 0)
                {
                    arcCount++;
                    var arc = archives.Dequeue();
                    arcName = Path.GetFileNameWithoutExtension(arc);

                    Logger.Instance.Log(LogEntryType.Info, "Installing archive \"" + arcName + "\" into \"" + InstallationDirectory + "\"");

                    InstallingArchive?.Invoke(this, new InstallingArchiveEventArgs() { InstallingArchiveName = arcName, InstallingArchiveIndex = arcCount, TotalArchivesCount = totalArchivesCount });

                    ZipFile archive = new ZipFile(arc);
                    archive.ExtractAll(InstallationDirectory, ExtractExistingFileAction.OverwriteSilently);
                    archive.Dispose();
                    Logger.Instance.Log(LogEntryType.Done, "Archive \"" + arcName + "\" installed!");
                }
                InstallationCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw new LauncherException("Unable to install archive " + arcName, LauncherExceptionErrorCode.ArchiveInstallFailed, ex);
            }
        }
    }

    public sealed class InstallingArchiveEventArgs : EventArgs
    {
        public string InstallingArchiveName { get; set; }
        public int InstallingArchiveIndex { get; set; }
        public int TotalArchivesCount { get; set; }
    }
}
