using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
    internal static class PartySpeedOverride
    {
        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation)
        {
            if (!mobileParty.IsMainParty || mobileParty.LeaderHero?.IsHumanPlayerCharacter == false || (mobileParty.Army != null && mobileParty.Army.LeaderParty.Leader != CharacterObject.PlayerCharacter))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
            explainedNumber.Add(result, textObject);
#if mcmMode
            explainedNumber.Clamp(McmSettings.Instance.MinPartySpeed, McmSettings.Instance.MaxPartySpeed);
#else
            explainedNumber.LimitMin(4f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}