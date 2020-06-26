using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(Barterable), "GetValueForFaction")]
    internal static class BarterablePatch
    {
        public static Settings Setting => Settings.Instance;
        public static bool Enabled => Setting.BarterSuccessMultiplierEnabled;
        public static float Multiplier => Setting.BarterSuccessMultiplier;

        internal static int Postfix(int result, IFaction faction)
        {
            if (result >= 0)
                return (int)(result * Multiplier);

            return result;
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}