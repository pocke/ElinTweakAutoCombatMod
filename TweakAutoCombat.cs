using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace TweakAutoCombat;

internal static class ModInfo
{
    internal const string Guid = "me.pocke.tweak-auto-combat";
    internal const string Name = "Tewak Auto Combat";
    internal const string Version = "1.0.0";
}

[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
internal class TweakAutoCombat : BaseUnityPlugin
{
    internal static TweakAutoCombat Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
        Settings.ignoreActIds = Config.Bind("Settings", "IgnoreActIds", "", "List of Act IDs to ignore in auto combat. Acts with these IDs will not be used in the auto combat.");
        new Harmony("TweakAutoCombat").PatchAll();
    }

    public static void Log(object message)
    {
        Instance.Logger.LogInfo(message);
    }
}
