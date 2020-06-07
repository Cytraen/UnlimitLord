using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
    internal static class PartySpeedOverride
    {
        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation)
        {
            if (!(mobileParty.IsMainParty && mobileParty.LeaderHero.IsHumanPlayerCharacter) || (mobileParty.Army != null && mobileParty.Army.LeaderParty.Leader != CharacterObject.PlayerCharacter))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Clamp(GlobalSettings<McmSettings>.Instance.PartySpeed, McmSettings.Instance.PartySpeed);
#else
            explainedNumber.LimitMin(6f);
            // explainedNumber.Clamp(7f, 7f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}