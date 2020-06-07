using HarmonyLib;
using TaleWorlds.CampaignSystem;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    internal static class CompanionAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfCompanions, McmSettings.Instance.MinNumOfCompanions);
#else
            return 100000;
#endif
        }
    }
}