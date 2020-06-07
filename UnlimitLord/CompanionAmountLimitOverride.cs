using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    internal static class CompanionAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            return GlobalSettings<McmSettings>.Instance.NumOfCompanions;
#else
            return 100000;
#endif
        }
    }
}