using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal static class PrisonerAmountLimitOverride
    {

#if !mcmMode

        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (party.LeaderHero == null || party.LeaderHero != Hero.MainHero)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(100000f, 100000f);

            return (int)explainedNumber.ResultNumber;
        }

#endif

#if mcmMode

        public static DynamicMethod Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            return new DynamicMethod("Patch", typeof(int), new[] { typeof(int), typeof(PartyBase), typeof(StatExplainer) });
        }

        public static int Patch(int result, PartyBase party, StatExplainer explanation)
        {
            if (party.LeaderHero == null || party.LeaderHero != Hero.MainHero)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(McmSettings.Instance.NumOfPrisoners, McmSettings.Instance.NumOfPrisoners);

            return (int)explainedNumber.ResultNumber;
        }

#endif

    }
}