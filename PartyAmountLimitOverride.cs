using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal static class PartyAmountLimitOverride
    {
        public static int Postfix(int result, Clan clan)
        {
            if (clan.Leader?.IsHumanPlayerCharacter == false) return result;
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfParties, McmSettings.Instance.MaxNumOfParties);
        }
    }
}