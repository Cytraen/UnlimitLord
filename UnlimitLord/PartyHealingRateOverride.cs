using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
    internal static class PartyHealingRateOverrideTroops
    {
        public static float Postfix(float result, MobileParty party, StatExplainer explanation)
        {
            if (!party.IsMainParty || party.LeaderHero?.IsHumanPlayerCharacter == false || party.IsGarrison)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

#if mcmMode
            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinTroopHealing, McmSettings.Instance.MaxTroopHealing) - result, textObject);
#else
            explainedNumber.Clamp(100000, 100000);
#endif
            return explainedNumber.ResultNumber;
        }
    }

    [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
    internal static class PartyHealingRateOverrideHeroes
    {
        public static float Postfix(float result, MobileParty party, StatExplainer explanation)
        {
            if (!party.IsMainParty || party.LeaderHero?.IsHumanPlayerCharacter == false || party.IsGarrison)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

#if mcmMode
            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinHeroHealing, McmSettings.Instance.MaxHeroHealing) - result, textObject);
#else
            explainedNumber.Clamp(100000, 100000);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}