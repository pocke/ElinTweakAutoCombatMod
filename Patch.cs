using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

namespace TweakAutoCombat;

[HarmonyPatch]
public class Patch
{
    [HarmonyPrefix, HarmonyPatch(typeof(GoalCombat), "AddAbility")]
    public static bool GoalAutoCombat_AddAbility_Prefix(GoalCombat __instance, Act a, int mod = 0, int chance = 100, bool aiPt = false)
    {
        if (!__instance.owner.IsPC)
        {
            return true;
        }

        if (Settings.IgnoreActIds.Contains(a.ID))
        {
            TweakAutoCombat.Log($"GoalAutoCombat_AddAbility_Prefix: Ignoring Act ID {a.ID} for auto combat.");
            return false;
        }
        return true;
    }
}
