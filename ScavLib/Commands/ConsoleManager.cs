using System;
using System.Collections.Generic;
using System.Text;

namespace ScavLib.Commands
{
    public class ConsoleManager
    {
        public static void AddCommand(string commandName, Func<string[], string> commandFunction)
        {
            Objects.ConsoleStuff.addedCommands[commandName] = commandFunction;
        }
    }
}
