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
            if (result > McmSettings.Instance.MaxNumOfCompanions) return McmSettings.Instance.MaxNumOfCompanions;
            if (result < McmSettings.Instance.MinNumOfCompanions) return McmSettings.Instance.MinNumOfCompanions;
            return result;
#else
            return 100000;
#endif
        }
    }
}