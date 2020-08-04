using System;
using System.Collections.Generic;
using System.Text;

namespace ProjBobcat.MLI.Gaming
{
    public class GameExitedEventArgs : System.EventArgs
    {
        public GameExitedEventArgs(int exitCode, ICollection<dynamic> extraInfos = null)
        {
            this.ExitCode = exitCode;
            this.ExtraInfos = extraInfos;
        }
        public int ExitCode { get; }
        public ICollection<dynamic> ExtraInfos { get; }
    }
}
