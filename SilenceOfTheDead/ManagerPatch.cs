using HarmonyLib;
using PulsarModLoader.Patches;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SilenceOfTheDead
{
    [HarmonyPatch(typeof(PLPhotonVoice), "Update")]
    class VoicePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> targetSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Ldfld),
                new CodeInstruction(OpCodes.Ldc_I4_0),
            };
            List<CodeInstruction> injectionSequence = new List<CodeInstruction>()
            {
                new CodeInstruction(OpCodes.Ldloc_0),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(VoicePatch), "PatchMethod")),
                new CodeInstruction(OpCodes.Ldc_I4_0),
            };
            return HarmonyHelpers.PatchBySequence(instructions, targetSequence, injectionSequence, HarmonyHelpers.PatchMode.REPLACE, HarmonyHelpers.CheckMode.NEVER);
        }
        static bool PatchMethod(PLPlayer PlayerForPhotonPlayer) //Is Player Muted?
        {
            if(PlayerForPhotonPlayer.GetPawn() == null || PLServer.Instance == null || PLServer.Instance.PlayerShipIsDestroyed)
            {
                return PlayerForPhotonPlayer.TS_IsMuted;
            }
            return PlayerForPhotonPlayer.TS_IsMuted || GUI.ShouldBeMuting && PlayerForPhotonPlayer.GetPawn().IsDead;
        }
    }
}
