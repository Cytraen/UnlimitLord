using HarmonyLib;
using TaleWorlds.CampaignSystem;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
    internal static class CompanionAmountLimitOverride
    {
        public static int Postfix(int result)
        {
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfCompanions, McmSettings.Instance.MinNumOfCompanions);
        }
    }
}