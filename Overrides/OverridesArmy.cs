using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(DefaultArmyManagementCalculationModel), "CalculateCohesionChange")]
        internal static class ArmyCohesionOverride
        {
            public static float Postfix(float result, Army army, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (army.LeaderParty?.Leader != CharacterObject.PlayerCharacter)
                    return result;

                return Helpers.ClampAndExplainFloat((result * settings.ArmyCohesionMultiplier) + army.Cohesion, explanation, settings.MinCohesion, settings.MaxCohesion);
            }
        }
    }
}