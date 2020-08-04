using System;

namespace ProjBobcat.MLI.Launching
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
}
