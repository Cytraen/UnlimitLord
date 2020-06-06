using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal class PartyAmountLimitOverride
    {
        [HarmonyPostfix]
        public static int Postfix(int result, Clan clan)
        {
            return clan.Leader.IsHumanPlayerCharacter ? 100000 : result;
        }
    }
}
