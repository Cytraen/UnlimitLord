using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

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

            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinTroopHealing, McmSettings.Instance.MaxTroopHealing) - result, textObject);
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

            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinHeroHealing, McmSettings.Instance.MaxHeroHealing) - result, textObject);
            return explainedNumber.ResultNumber;
        }
    }
}