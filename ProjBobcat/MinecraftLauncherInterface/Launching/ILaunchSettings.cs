using ProjBobcat.MLI.Authorizing;
using ProjBobcat.MLI.VersionLocating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjBobcat.MLI.Launching
{
    public interface ILaunchSettings
    {
        // TODO: Change this!
        string GameName { get; }
        string LauncherName { get; }
        string WindowTitle { get; }

        DirectoryInfo GamePath { get; }
        DirectoryInfo GameResourcePath { get; }

        IGameVersion Version { get; }
        IPlayer SelectedProfile { get; }
        IGameArguments GameArguments { get; }
    }
}