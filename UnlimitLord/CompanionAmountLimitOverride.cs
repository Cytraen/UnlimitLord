using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
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