using craftersmine.MinecraftLauncher2.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Core
{
    public sealed class ClientLauncher
    {
        Process launchedProcess;

        public event EventHandler<MinecraftExitedEventArgs> MinecraftExited;

        public void Launch(string clientId, string launchString, string username, int allocatedMem, string assetIndex)
        {
            string clientDir = Path.Combine(StaticData.ClientsRootPath, clientId);
            Logger.Instance.Log(LogEntryType.Info, "Client directory: " + clientDir);

            var libs = DiscoverLibraries(clientId);

            string lStr = GenerateLaunchString(clientId, username, allocatedMem, libs, "core", assetIndex, launchString);

            string javaWPath = Path.Combine(StaticData.JrePath, "win64", "bin", "javaw.exe");

            Logger.Instance.Log(LogEntryType.Info, "Using internal launcher JRE: " + javaWPath);

            launchedProcess = new Process();
            launchedProcess.StartInfo = new ProcessStartInfo(javaWPath, lStr);
            Logger.Instance.Log(LogEntryType.Info, "Launching Minecraft with specified parameters: " + lStr);
            launchedProcess.EnableRaisingEvents = true;
            launchedProcess.Exited += processExited;
            launchedProcess.OutputDataReceived += processOutDataReceived;
            launchedProcess.StartInfo.UseShellExecute = true;
            launchedProcess.StartInfo.RedirectStandardOutput = false;
            launchedProcess.Start();
            //launchedProcess.WaitForExit();
        }

        public void Exit()
        {
            launchedProcess.Kill();
        }

        public string GenerateLaunchString(string clientId, string username, int allocatedMem, string[] libraries, string mcVersion, string assetIndex, string launchArgs)
        {
            string clientRoot = Path.Combine(StaticData.ClientsRootPath, clientId);
            string classpath = string.Join(";", libraries);
            string nativesPath = Path.Combine(clientRoot, "versions\\core\\natives");
            string assetsPath = Path.Combine(clientRoot, "assets");
            string corejarPath = Path.Combine(clientRoot, "versions\\core\\core.jar");

            string launchString = launchArgs;

            launchString = launchString.Replace("{%CLIENTROOT%}", clientRoot);
            launchString = launchString.Replace("{%MAXALLOCATEDMEM%}", allocatedMem.ToString());
            launchString = launchString.Replace("{%NATIVESDIR%}", nativesPath);
            launchString = launchString.Replace("{%COREJAR%}", corejarPath);
            launchString = launchString.Replace("{%CLASSPATH%}", classpath);
            launchString = launchString.Replace("{%USERNAME%}", username);
            launchString = launchString.Replace("{%CLIENTID%}", "core");
            launchString = launchString.Replace("{%ASSETSROOT%}", assetsPath);
            launchString = launchString.Replace("{%ASSETINDEX%}", assetIndex);
            launchString = launchString.Replace("{%ACCESSTOK%}", username.GetHashCode().ToString());

            /*
             * {0} - Max allocated mem
             * {1} - Natives root
             * {2} - Classpath
             * {3} - Username
             * {4} - Version
             * {5} - Gamedir
             * {6} - Asset dir
             * {7} - Asset index
             * {8} - Core jar
             * 
             *  -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode  - old GC
             */
            string generatedLaunchString = string.Format("-Xms{0}M -Xmx{0}M -XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M -XX:-UseAdaptiveSizePolicy -XX:+DisableExplicitGC -XX:ConcGCThreads=1 -XX:ParallelGCThreads=2 -Dfile.encoding=UTF-8 -Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true -Djava.net.useSystemProxies=true -XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump -Djava.library.path=\"{1}\" -Dminecraft.launcher.brand=java-minecraft-launcher -Dminecraft.client.jar=\"{8}\" -cp \"{2}\" net.minecraft.launchwrapper.Launch --username {3} --version {4} --gameDir {5} --assetsDir {6} --assetIndex {7} --uuid 2536abce90e8476a871679918164abc5 --accessToken 99abe417230342cb8e9e2168ab46297a --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker --userType legacy --versionType release --nativeLauncherVersion 307",
                allocatedMem,
                nativesPath,
                classpath,
                username,
                mcVersion,
                clientRoot,
                assetsPath,
                assetIndex,
                corejarPath
                );

            return launchString;
        }

        public string[] DiscoverLibraries(string clientId)
        {
            string clientRoot = Path.Combine(StaticData.ClientsRootPath, clientId);
            string libsPath = Path.Combine(clientRoot, "libraries");
            DirectoryInfo librariesDir = new DirectoryInfo(libsPath);
            FileInfo[] jars = librariesDir.GetFiles("*.jar", SearchOption.AllDirectories);
            List<string> libs = new List<string>();
            foreach (var jar in jars)
            {
                //string libPath = jar.FullName.Replace(clientRoot, "");
                libs.Add(jar.FullName);
            }
            libs.Add(Path.Combine(clientRoot, "versions\\core\\core.jar"));
            return libs.ToArray();
        }

        private void processOutDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Instance.Log(LogEntryType.Debug, e.Data);
        }

        private void processExited(object sender, EventArgs e)
        {
            MinecraftExited?.Invoke(this, new MinecraftExitedEventArgs() { ExitCode = launchedProcess.ExitCode });
        }

        public bool CheckInstalledPatches(MCPatch[] availablePatches, string[] installedPatches)
        {
            if (availablePatches.Length != installedPatches.Length)
                return false;
            else return true;
        }
    }

    public sealed class MinecraftExitedEventArgs : EventArgs
    {
        public int ExitCode { get; set; }
    }
}
