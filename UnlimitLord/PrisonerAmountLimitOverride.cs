using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal class PrisonerAmountLimitOverride
    {
        [HarmonyPostfix]
        public static int Postfix(int result, PartyBase party)
        {
            return party.MobileParty.IsMainParty && party.LeaderHero.IsHumanPlayerCharacter ? 100000 : result;
        }
    }
}