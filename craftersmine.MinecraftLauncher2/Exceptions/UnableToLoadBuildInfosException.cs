using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.MinecraftLauncher2.Exceptions
{

    [Serializable]
    public class UnableToLoadBuildInfosException : Exception
    {
        public UnableToLoadBuildInfosException() { }
        public UnableToLoadBuildInfosException(string message) : base(message) { }
        public UnableToLoadBuildInfosException(string message, Exception inner) : base(message, inner) { }
        protected UnableToLoadBuildInfosException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
