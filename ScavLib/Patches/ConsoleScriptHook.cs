using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;

namespace ScavLib.Hooks
{
    internal class ConsoleScriptHook
    {
        public delegate string orig_ConsoleScript_CheckInput(ConsoleScript self);
        public static string ConsoleScript_CheckInput(orig_ConsoleScript_CheckInput orig, ConsoleScript self)
        {
            string text = self.input.text;
            string command = text.Split(' ')[0];
            if (command.IsNullOrWhiteSpace())
            {
                return "Command does not exist";
            }
            for (int i = 0; i < Objects.ConsoleStuff.builtInCommands.Length; i++)
            {
                if (command == Objects.ConsoleStuff.builtInCommands[i])
                {
                    return orig(self);
                }
            }
            for (int i = 0; Objects.ConsoleStuff.addedCommands.Count > i; i++)
            {
                if (Objects.ConsoleStuff.addedCommands.ContainsKey(command))
                {
                    Objects.ConsoleStuff.addedCommands.TryGetValue(command, out Func<string[], string> Function);
                    string[] args = text.Split(' ').Skip(1).ToArray();
                    return Function(args);
                }
            }
            return "Fuck.";
        }
    }
}
