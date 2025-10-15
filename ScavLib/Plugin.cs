using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace ScavLib;

    [BepInPlugin("05126619z.scavlib", "ScavLib", "0.0.1")]
    public partial class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            try
            {
                // Console bind
                Hook a1 = new Hook(
                    typeof(ConsoleScript).GetMethod("CheckInput", BindingFlags.Public | BindingFlags.Instance),
                    typeof(Hooks.ConsoleScriptHook).GetMethod(nameof(Hooks.ConsoleScriptHook.ConsoleScript_CheckInput))
                    );
                Logger.LogInfo(a1);
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            //BundleLoader.LoadAllBundles(Paths.PluginPath, ".scavbundle");
            Logger.LogInfo($"Plugin ScavLib is loaded!");
        }
    }

