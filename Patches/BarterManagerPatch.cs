using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(BarterManager), "IsOfferAcceptable")]
    internal static class BarterManagerPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.BarterAlwaysAccepted;

        internal static void Postfix(ref bool __result, BarterData args, Hero hero, PartyBase party)
        {
            __result = true;
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}