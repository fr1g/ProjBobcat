using System;
using System.Collections.Generic;
using System.Text;

namespace ProjBobcat.MLI.Logging
{
    public class LoggingEventArgs : System.EventArgs
    {
        public enum LogTypes
        {
            Debug,
            Info,
            Warning,
            Error,
            Critical
        }
        public LogTypes LogType { get; }
        public string Content { get; }
        public DateTime? AbsoluteTime { get; }
        public TimeSpan? RelativeTime { get; }
        public ICollection<dynamic> ExtraInfos { get; }
        public LoggingEventArgs(LogTypes logType, string content,
            DateTime? absoluteTime = null, TimeSpan? relativeTime = null)
        {
            this.LogType = logType;
            this.Content = content;
            this.AbsoluteTime = absoluteTime;
            this.RelativeTime = relativeTime;
        }
        public LoggingEventArgs(LogTypes logType, string content, ICollection<dynamic> extraInfos,
            DateTime? absoluteTime = null, TimeSpan? relativeTime = null)
            : this(logType, content, absoluteTime,relativeTime)
        {
            this.ExtraInfos = extraInfos;
        }
    }
}