using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(Barterable), "GetValueForFaction")]
    internal static class BarterablePatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.BarterSuccessMultiplierEnabled;
        private static float Multiplier => Setting.BarterSuccessMultiplier;

        internal static void Postfix(ref int __result, IFaction faction)
        {
            if (__result >= 0)
                __result = (int)(__result * Multiplier);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}