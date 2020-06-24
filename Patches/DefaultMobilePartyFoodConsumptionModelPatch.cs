using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    internal static class DefaultMobilePartyFoodConsumptionModelPatch
    {
        [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "CalculateDailyFoodConsumptionf")]
        internal static class Party
        {
            public static Settings Setting => Settings.Instance;
            public static bool Enabled => Setting.PartyFoodConsumptionEnabled;
            public static AppliesToEnum AppliesTo => Setting.PartyFoodConsumptionAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.PartyFoodConsumptionMultiplier;
            public static float Minimum => Setting.MinimumPartyFoodConsumption;
            public static float Maximum => Setting.MaximumPartyFoodConsumption;

            internal static float Postfix(float result, MobileParty party, StatExplainer explainer)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainFloat(result * Multiplier, explainer, -Minimum, -Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}