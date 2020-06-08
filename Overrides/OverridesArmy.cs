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
                if (army.LeaderParty?.Leader != CharacterObject.PlayerCharacter)
                    return result;

                return Helpers.ClampAndExplainFloat(result + army.Cohesion, explanation, McmSettings.Instance.MinCohesion, McmSettings.Instance.MaxCohesion);
            }
        }
    }
}