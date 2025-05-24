using System;
using System.Collections.Generic;
using System.Text;

namespace ScavLib.Objects
{
    internal class ConsoleStuff
    {
        internal static string[] builtInCommands { get; private set; } =
        {
            "setvolume",
            "sound",
            "help",
            "talk",
            "heal",
            "spawn",
            "setbodyfield",
            "tp",
            "getlimbs",
            "setlimbfield",
            "getsounds",
            "framerate",
            "pixelate",
            "starterkit",
            "getlimbfields",
            "timescale",
            "skiplayer",
            "getbodyfields",
            "explode"
        };

        internal static Dictionary<string, Func<string[], string>> addedCommands = new Dictionary<string, Func<string[], string>>();
    }
}
