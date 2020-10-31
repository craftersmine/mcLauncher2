using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Exceptions
{
    public enum LauncherExceptionErrorCode
    {
        GenericLauncherError = 0xdead,

        UnableToCreateLauncherDirectoryStructure = 0x101,

        GenericDownloadError = 0x400,
        UnableToDownloadBuildList = 0x401,
        UnableToDownloadClientList = 0x402,
        UnableToDownloadFile = 0x403,
        UnableToDownloadClientCore = 0x404,
        UnableToDownloadLauncherData = 0x405,

        ArchiveInstallFailed = 0xc0ffee,
        ClientLaunchFailed = 0xd00d,

        AssetIndexExtractionFailed = 0x301,
        ClientInstallationCorrupted = 0x302,
        JreInstallationFailed = 0x303
    }
}
