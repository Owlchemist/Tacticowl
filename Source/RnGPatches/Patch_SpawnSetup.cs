using System;
using Verse;
using HarmonyLib;
using RimWorld;
using Verse.AI;
using Settings = RunGunAndDestroy.ModSettings_RunAndDestroy;

namespace RunGunAndDestroy
{
    [HarmonyPatch(typeof(Pawn), nameof(Pawn.SpawnSetup))]
    static class Patch_SpawnSetup
    {
        static void Postfix(Pawn __instance)
        {
            if (!__instance.IsColonist && Settings.enableForAI && 
				(__instance.RaceProps.intelligence != Intelligence.Animal || Settings.enableForAnimals )) 
			{
				__instance.SetRunsAndGuns(true);
			}
        }
    }
}