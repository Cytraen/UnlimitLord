using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultArmyManagementCalculationModel), "CalculateCohesionChange")]
    internal static class ArmyCohesionOverride
    {
        public static float Postfix(float result, Army army, StatExplainer explanation)
        {
            if (army.LeaderParty?.Leader != CharacterObject.PlayerCharacter)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

#if mcmMode
            explainedNumber.Add(Helpers.ClampFloat(result + army.Cohesion, McmSettings.Instance.MinCohesion, McmSettings.Instance.MaxCohesion) - (result + army.Cohesion), textObject);
#else
            explainedNumber.LimitMin(100f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}