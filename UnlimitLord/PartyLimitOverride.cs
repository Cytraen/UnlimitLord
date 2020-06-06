using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal class PartyLimitOverrideOld
    {
        [HarmonyPostfix]
        public static int Postfix(int result, Clan clan)
        {
            return clan.Leader.IsHumanPlayerCharacter ? 100000 : result;
        }
    }

    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "CalculateMobilePartyMemberSizeLimit")]
    internal class PartyLimitOverride
    {
        [HarmonyPostfix]
        public static int Postfix(int result, MobileParty party, StatExplainer explanation)
        {
            if (party.IsMainParty && party.Leader.HeroObject.IsHumanPlayerCharacter)
            {
                return 100000;
            }

            return result;
        }
    }
}
