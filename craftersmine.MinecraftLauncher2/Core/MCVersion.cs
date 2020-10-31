using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    [Serializable]
    public class MCVersion
    {
        public string Version { get; set; }
        public string Assets { get; set; }
        public string Core { get; set; }
    }
}
