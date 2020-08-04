using ProjBobcat.MLI.Launching;
using ProjBobcat.MLI.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjBobcat.MLI.Gaming
{
    public interface IGame
    {
        event EventHandler<GameExitedEventArgs> GameExited;
        event EventHandler<LoggingEventArgs> GameLogging;

        Process Process { get; }
        DateTime StartTime { get; }
        TimeSpan ElapsedTime { get; }
        ILaunchSettings LaunchSettings { get; }

        void ExitGame(int exitCode, ICollection<dynamic> extraInfos);
    }
}