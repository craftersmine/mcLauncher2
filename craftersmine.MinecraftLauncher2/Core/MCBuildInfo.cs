using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    [Serializable]
    public class MCBuildInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MCVersion { get; set; }
        public string Core { get; set; }
        public string AssetIndex { get; set; }
        public string Arguments { get; set; }
        public MCPatch[] Patches { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
