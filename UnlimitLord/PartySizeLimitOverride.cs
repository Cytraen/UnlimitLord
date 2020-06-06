using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord
{

    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "CalculateMobilePartyMemberSizeLimit")]
    internal class PartySizeLimitOverride
    {
        public static int Postfix(int result, MobileParty party)
        {
            return party.IsMainParty && party.Leader.HeroObject.IsHumanPlayerCharacter ? 100000 : result;
        }
    }
}