using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "DoesPartyConsumeFood")]
    internal static class PartyDoesNotEatOverride
    {
        public static bool Postfix(bool result, MobileParty mobileParty)
        {
            return result && !((mobileParty.Leader != null && mobileParty.Leader == CharacterObject.PlayerCharacter) || mobileParty.LeaderHero?.Clan == Clan.PlayerClan);
        }
    }
}