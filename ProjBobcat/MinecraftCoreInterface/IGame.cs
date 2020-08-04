using ProjBobcat.MCI.EventArgs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjBobcat.MCI
{
    public interface IGame
    {
        /// <summary>
        /// 游戏退出事件
        /// </summary>
        event EventHandler<GameExitedEventArgs> GameExited;

        /// <summary>
        /// 游戏日志输出事件
        /// </summary>
        event EventHandler<LoggingEventArgs> GameLogging;

        DateTime StartTime { get; }

        TimeSpan ElapsedTime { get; }

        Process Process { get; }
        LaunchSettings LaunchSettings { get; }
        void ExitGame(int exitCode, ICollection<dynamic> extraInfos);
    }
}