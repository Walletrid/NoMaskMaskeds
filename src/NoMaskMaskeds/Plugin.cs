using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace NoMaskMaskeds;

[BepInPlugin(MyPluginInfo.Id, MyPluginInfo.Name, MyPluginInfo.Version)]
[BepInProcess("Lethal Company.exe")]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    internal static ConfigEntry<bool> Enabled { get; private set; } = null!;
    internal static ConfigEntry<bool> MaskPresence { get; private set; } = null!;
    internal static ConfigEntry<bool> MasksSounds { get; private set; } = null!;
    internal static ConfigEntry<bool> RedEyes { get; private set; } = null!;
    internal static ConfigEntry<bool> RedGlow { get; private set; } = null!;

    private void Awake()
    {
        Log = Logger;

        Enabled = Config.Bind("General", "Enabled", true, "Turns the mod ON or OFF.");
        MaskPresence = Config.Bind("General", "Mask Presence", false, "Turns the masked's mask visibility ON or OFF. I don't really know why you might want to use this, but if you really want to, at least you have the option.");
        MasksSounds = Config.Bind("General", "Mask Sounds", false, "The haunted mask items can randomly play sounds such as a laugh or a cry. You can choose if the Masked enemy will also keep that functionality (In vanilla they do) or have it removed.");
        RedEyes = Config.Bind("General", "Red eyes", false, "When a masked infects you, they get red eyes and a red glow. Here you can toggle the eyes ON or OFF. (I DO NOT RECOMMEND THIS AT ALL. THE EYES ONLY GLOW AT THE MASKS EYES, SO IT LOOKS REALLY BAD)");
        RedGlow = Config.Bind("General", "Red glow", false, "When a masked infects you, they get red eyes and a red glow. Here you can toggle the glow ON or OFF.");

        if (!Enabled.Value)
        {
            Log.LogInfo($"{MyPluginInfo.Name} is turned off in its config.");
            return;
        }

        var harm = new Harmony(MyPluginInfo.Id);
        harm.PatchAll();
        Log.LogInfo($"{MyPluginInfo.Name} {MyPluginInfo.Version} loaded");
    }
}
