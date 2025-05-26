using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx.Configuration;

namespace TweakAutoCombat;

public static class Settings
{
    public static ConfigEntry<string> ignoreActIds;

    public static List<string> IgnoreActIds
    {
        get { return ignoreActIds.Value.Split(',').ToList(); }
        set { ignoreActIds.Value = string.Join(",", value); }
    }
}
