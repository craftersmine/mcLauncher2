using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    [Serializable]
    public sealed class MCPatch
    {
        public string Id { get; set; }
        public string DownloadUrl { get; set; }
    }
}
