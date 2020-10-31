using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    [Serializable]
    public sealed class LauncherData
    {
        public string JRE { get; set; }
        public string LauncherVersion { get; set; }
    }
}
