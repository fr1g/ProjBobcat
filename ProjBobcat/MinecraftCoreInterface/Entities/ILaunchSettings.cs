using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjBobcat.MCI.Entities
{
    public interface ILaunchSettings
    {

        string GameName { get; }

        DirectoryInfo GamePath { get; }

        DirectoryInfo GameResourcePath { get; }

        GameVersion Version { get; }

        string WindowTitle { get; }

        IVersionLocator VersionLocator { get; }

        IAuthenticator Authenticator { get; }
        ProfileInfoModel SelectedProfile { get; }

        bool VersionInsulation { get; }
        string LauncherName { get; }
        GameArguments FallBackGameArguments { get; }
        GameArguments GameArguments { get; }
    }
}