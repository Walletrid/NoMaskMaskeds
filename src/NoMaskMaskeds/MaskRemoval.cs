using HarmonyLib;
using UnityEngine;

namespace NoMaskMaskeds;

public class MaskRemoval
{
    [HarmonyPatch(typeof(MaskedPlayerEnemy), "Awake")]
    internal static class MaskedPlayerEnemyAwakePatch
    {
        [HarmonyPostfix]
        private static void Postfix(MaskedPlayerEnemy __instance)
        {
            if (!Plugin.MasksSounds.Value)
            {
                //Disable Audio
                __instance.maskTypes[0].GetComponent<RandomPeriodicAudioPlayer>().enabled = false;
                __instance.maskTypes[1].GetComponent<RandomPeriodicAudioPlayer>().enabled = false;

            }

            if (!Plugin.MaskPresence.Value)
            {
                //Disable LOD
                __instance.maskTypes[0].transform.Find("ComedyMaskLOD1").gameObject.SetActive(false);
                __instance.maskTypes[1].transform.Find("ComedyMaskLOD1").gameObject.SetActive(false);
                //Disable full model mesh
                __instance.maskTypes[0].transform.Find("Mesh").GetComponent<Renderer>().enabled = false;
                __instance.maskTypes[1].transform.Find("Mesh").GetComponent<Renderer>().enabled = false;
            }
        }
    }

    [HarmonyPatch(typeof(MaskedPlayerEnemy), "SetMaskType")]
    internal static class MaskedPlayerEnemySetMaskTypePatch
    {
        [HarmonyPostfix]
        private static void Postfix(MaskedPlayerEnemy __instance)
        {
            if (!Plugin.MasksSounds.Value)
            {
                //Disable Audio
                __instance.maskTypes[0].GetComponent<RandomPeriodicAudioPlayer>().enabled = false;
                __instance.maskTypes[1].GetComponent<RandomPeriodicAudioPlayer>().enabled = false;

            }

            if (!Plugin.MaskPresence.Value)
            {
                //Disable LOD
                __instance.maskTypes[0].transform.Find("ComedyMaskLOD1").gameObject.SetActive(false);
                __instance.maskTypes[1].transform.Find("ComedyMaskLOD1").gameObject.SetActive(false);
                //Disable full model mesh
                __instance.maskTypes[0].transform.Find("Mesh").GetComponent<Renderer>().enabled = false;
                __instance.maskTypes[1].transform.Find("Mesh").GetComponent<Renderer>().enabled = false;
            }
        }
    }

    [HarmonyPatch(typeof(MaskedPlayerEnemy), "SetMaskGlow")]
    internal static class MaskedPlayerEnemySetMaskGlowPatch
    {
        [HarmonyPostfix]
        private static void Postfix(MaskedPlayerEnemy __instance)
        {
            if (!Plugin.RedEyes.Value)
            {
                //Disable Red eyes
                __instance.maskEyesGlow[__instance.maskTypeIndex].enabled = false;
            }

            if (!Plugin.RedGlow.Value)
            {
                //Disable the red glow
                __instance.maskEyesGlowLight.enabled = false;
            }
        }
    }
}
