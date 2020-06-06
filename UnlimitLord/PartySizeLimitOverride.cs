using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
    internal static class PartySizeLimitOverride
    {
        public static int Postfix(int result, PartyBase party)
        {
            return party.MobileParty.IsMainParty && party.LeaderHero.IsHumanPlayerCharacter && !party.MobileParty.IsGarrison ? 100000 : result;
        }
    }
}