using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class ClientFile
    {
        public string FileName { get; set; }
        public string DownloadUrl { get; set; }

        private ClientFile() { }
        public ClientFile(string url, string filename)
        {
            DownloadUrl = url;
            FileName = filename;
        }
    }
}
