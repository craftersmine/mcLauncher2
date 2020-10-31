using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Exceptions
{

    [Serializable]
    public class MinecraftLaunchException : Exception
    {
        public int ProcessExitCode { get; private set; }
        public LauncherExceptionErrorCode ErrorCode { get; private set; }

        public MinecraftLaunchException() { }
        public MinecraftLaunchException(string message) : base(message) { }
        public MinecraftLaunchException(string message, int processExitCode, LauncherExceptionErrorCode errorCode) : base(message) { ProcessExitCode = processExitCode; ErrorCode = errorCode; }
        public MinecraftLaunchException(string message, Exception inner) : base(message, inner) { }
        protected MinecraftLaunchException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
