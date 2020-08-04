using System;
using System.Runtime.Serialization;

namespace ProjBobcat.MLI.Launching
{
    public class LaunchFailureException : Exception
    {
        public LaunchFailureTypes FailureType { get; }
        public LaunchFailureException(LaunchFailureTypes failureType)
            : base()
        {
            this.FailureType = failureType;
        }
        public LaunchFailureException(LaunchFailureTypes failureType, string message) : base(message)
        {
            this.FailureType = failureType;
        }
        public LaunchFailureException(LaunchFailureTypes failureType,
            string message, Exception innerException) : base(message, innerException)
        {
            this.FailureType = failureType;
        }
        public LaunchFailureException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
