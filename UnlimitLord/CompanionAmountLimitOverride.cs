using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
    internal static class CompanionAmountLimitOverride
    {
        public static int Postfix(int result)
        {
            return 100000;
        }
    }
}