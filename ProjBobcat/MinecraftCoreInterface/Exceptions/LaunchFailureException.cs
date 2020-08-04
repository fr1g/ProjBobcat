using System;
using System.Runtime.Serialization;

namespace ProjBobcat.MCI.Exceptions
{
    public class LaunchFailureException : Exception
    {
        [Flags]
        public enum LaunchFailureTypes
        {
            NoJava = 0b000001,
            DecompressFailed = 0b000010,
            AuthFailed = 0b000100,
            OperationFailed = 0b001000,
            IncompleteArguments = 0b010000,
            Others = 0b100000
        }

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
