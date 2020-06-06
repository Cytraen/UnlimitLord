using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal static class PrisonerAmountLimitOverride
    {
        [HarmonyPostfix]
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (party.LeaderHero == null || party.LeaderHero != Hero.MainHero)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(100000f, textObject);

            return (int)explainedNumber.ResultNumber;
        }
    }
}