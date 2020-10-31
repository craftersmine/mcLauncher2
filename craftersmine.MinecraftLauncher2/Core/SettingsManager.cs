using craftersmine.MinecraftLauncher2.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class SettingsManager
    {
        public static string Username { get { return Settings.Default.Username; } set { Settings.Default.Username = value; Settings.Default.Save(); } }
        public static int MaxAllocatedMemory { get { return Settings.Default.MaxAllocatedMemory; } set { Settings.Default.MaxAllocatedMemory = value; Settings.Default.Save(); } }
        public static bool FirstStart { get { return Settings.Default.FirstStart; } set { Settings.Default.FirstStart = value; Settings.Default.Save(); } }
        public static string LastBuildId { get { return Settings.Default.LastBuildId; } set { Settings.Default.LastBuildId = value; Settings.Default.Save(); } }
        public static bool EnableLogging { get { return Settings.Default.EnableLogging; } set { Settings.Default.EnableLogging = value; Settings.Default.Save(); } }
        public static string DownloadedContentStorage { get { return Settings.Default.DownloadedContentStorage; } set { Settings.Default.DownloadedContentStorage = value; Settings.Default.Save(); } }
        public static bool IsJreInstalled { get { return Settings.Default.IsJreInstalled; } set { Settings.Default.IsJreInstalled = value; Settings.Default.Save(); } }
        public static bool UseInternalJre { get { return Settings.Default.UseInternalJre; } set { Settings.Default.UseInternalJre = value; Settings.Default.Save(); } }
    }
}
