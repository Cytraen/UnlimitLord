using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class PartyAmountLimitOverride
        {
            public static int Postfix(int result, Clan clan)
            {
                if (clan != Clan.PlayerClan) return result;
                return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfParties, McmSettings.Instance.MaxNumOfParties);
            }
        }
    }
}