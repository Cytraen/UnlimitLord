using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal static class PartyAmountLimitOverride
    {
        public static int Postfix(int result, Clan clan)
        {
            if (clan.Leader?.IsHumanPlayerCharacter == false) return result;
#if mcmMode
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfParties, McmSettings.Instance.MaxNumOfParties);
#else
            return 100000;
#endif
        }
    }
}