using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public static class CleanupManager
    {
        public static async Task ClearClientDirectory(string clientId, bool retainUserData)
        {
            Logger.Instance.Log(LogEntryType.Info, "Clearing client directory...");
            await Task.Run(new Action(() => { clearClientDirectory(clientId, retainUserData); }));
        }

        private static void clearClientDirectory(string clientId, bool retainUserData)
        {
            DirectoryInfo clientDir = new DirectoryInfo(Path.Combine(StaticData.ClientsRootPath, clientId));
            foreach (var file in clientDir.EnumerateFiles())
            {
                if (!file.Name.Contains("options") && retainUserData)
                    file.Delete();
                else file.Delete();
            }
            foreach (var dir in clientDir.EnumerateDirectories())
            {
                if ((!dir.Name.Contains("screenshot") || !dir.Name.Contains("saves") || !dir.Name.Contains("resource") || !dir.Name.Contains("shader")) && retainUserData)
                    dir.Delete(true);
                else dir.Delete(true);
            }
        }

        public static async Task ClearTemp()
        {
            Logger.Instance.Log(LogEntryType.Info, "Clearing temporary data directory...");
            await Task.Run(new Action(() => { clearTemp(); }));
        }

        private static void clearTemp()
        {
            DirectoryInfo tempDir = new DirectoryInfo(StaticData.TempPath);
            foreach (var file in tempDir.EnumerateFiles())
                file.Delete();
            foreach (var dir in tempDir.EnumerateDirectories())
                dir.Delete(true);
        }
    }
}
