using System;
using System.Threading.Tasks;
using System.IO;
using ProjBobcat.MCI.EventArgs;

namespace ProjBobcat.MCI
{
    /// <summary>
    /// 表示一个启动器核心。
    /// </summary>
    public interface ILauncherCore : IDisposable
    {
        /// <summary>
        /// 获取游戏根目录。
        /// </summary>
        DirectoryInfo RootDirectory { get; }
        /// <summary>
        /// 获取客户端令牌。
        /// </summary>
        Guid ClientToken { get; }
        /// <summary>
        /// 获取或设置版本定位器。
        /// </summary>
        IVersionLocator VersionLocator { get; }
        /// <summary>
        /// 启动游戏。
        /// 若启动成功，其返回值会包含消耗的时间；失败则包含异常信息。
        /// </summary>
        /// <param name="settings">启动设置。</param>
        /// <returns>启动结果。若启动成功，会包含消耗的时间；失败则包含异常信息。</returns>
        /// <exception cref="Exceptions.LaunchFailureException">启动失败。</exception>
        IGame Launch(LaunchSettings settings);
        
        /// <summary>
        /// 启动日志输出事件
        /// </summary>
        event EventHandler<LoggingEventArgs> LaunchLog;
    }
}