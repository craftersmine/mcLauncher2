using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    /// <summary>
    /// Contains launcher system settings such as downloading sources, metadata, updates etc.
    /// </summary>
    public static class LauncherSystemSettings
    {
        /// <summary>
        /// Link where get MC builds infos
        /// </summary>
        public const string BuildsInfosJsonLink = "https://raw.githubusercontent.com/craftersmine/mclauncher2-data/main/builds/builds.json";
        /// <summary>
        /// Link where get MC client list
        /// </summary>
        public const string ClientListJsonLink = "https://raw.githubusercontent.com/craftersmine/mclauncher2-data/main/builds/mcVersions.json";
        public const string LauncherDataJsonLink = "https://raw.githubusercontent.com/craftersmine/mclauncher2-data/main/launcherData.json";
        public const string LauncherInternalVersion = "1.0.0";
        public const string LauncherBuildRevision = "debug";
    }
}
