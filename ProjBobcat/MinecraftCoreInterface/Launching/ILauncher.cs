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

        /// <summary>
        /// 启动游戏。
        /// 若启动成功，其返回值会包含消耗的时间；失败则包含异常信息。
        /// </summary>
        /// <param name="settings">启动设置。</param>
        /// <returns>启动结果。若启动成功，会包含消耗的时间；失败则包含异常信息。</returns>
        /// <exception cref="Exceptions.LaunchFailureException">启动失败。</exception>
        IGame Launch(ILaunchSettings settings);
        
        /// <summary>
        /// 启动日志输出事件
        /// </summary>
        event EventHandler<LoggingEventArgs> LaunchLog;
    }
}