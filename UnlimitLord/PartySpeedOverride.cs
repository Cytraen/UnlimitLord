using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
    internal static class PartySpeedOverride
    {
        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation)
        {
            if (!mobileParty.IsMainParty || mobileParty.LeaderHero?.IsHumanPlayerCharacter == false || (mobileParty.Army != null && mobileParty.Army.LeaderParty.Leader != CharacterObject.PlayerCharacter))
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinPartySpeed, McmSettings.Instance.MaxPartySpeed) - result, textObject);
            return explainedNumber.ResultNumber;
        }
    }
}