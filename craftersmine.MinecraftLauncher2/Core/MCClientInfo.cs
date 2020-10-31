using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class MCClientInfo
    {
        public bool IsInstalled { get; set; }
        public string[] InstalledPatches { get; set; }
    }
}
