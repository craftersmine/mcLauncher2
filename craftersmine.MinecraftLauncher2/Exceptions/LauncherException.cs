using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Exceptions
{

    [Serializable]
    public class LauncherException : Exception
    {
        public LauncherExceptionErrorCode ErrorCode { get; private set; }
        public LauncherException() { }
        public LauncherException(string message) : base(message) { }
        public LauncherException(string message, LauncherExceptionErrorCode errorCode) : base(message) { ErrorCode = errorCode; }
        public LauncherException(string message, Exception inner) : base(message, inner) { }
        public LauncherException(string message, LauncherExceptionErrorCode errorCode, Exception inner) : base(message, inner) { ErrorCode = errorCode; }
        protected LauncherException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
