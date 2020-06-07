using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
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

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Add(result);
            explainedNumber.Clamp(McmSettings.Instance.MinPartySpeed, McmSettings.Instance.MaxPartySpeed);
#else
            explainedNumber.LimitMin(6f);
            // explainedNumber.Clamp(7f, 7f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}