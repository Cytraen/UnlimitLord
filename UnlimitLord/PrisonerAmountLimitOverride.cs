using System.Reflection.Emit;
using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal static class PrisonerAmountLimitOverride
    {
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (party.LeaderHero == null || party.LeaderHero != Hero.MainHero)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Clamp(GlobalSettings<McmSettings>.Instance.NumOfPrisoners, McmSettings.Instance.NumOfPrisoners);
#else
            explainedNumber.Clamp(100000f, 100000f);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}