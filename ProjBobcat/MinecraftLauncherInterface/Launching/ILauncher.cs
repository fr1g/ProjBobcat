using System;
using ProjBobcat.MLI.Gaming;
using ProjBobcat.MLI.Logging;

namespace ProjBobcat.MLI.Launching
{
    /// <summary>
    /// 表示一个启动器核心。
    /// </summary>
    public interface ILauncher : IDisposable
    {
        ILaunchSettings Settings { get; }

        /// <exception cref="LaunchFailureException">启动失败。</exception>
        IGame Launch(ILaunchSettings settings);
        
        /// <summary>
        /// 启动日志输出事件
        /// </summary>
        event EventHandler<LoggingEventArgs> LaunchLog;
    }
}