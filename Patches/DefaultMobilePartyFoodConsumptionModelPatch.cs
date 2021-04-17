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
            private static Settings Setting => Settings.Instance;
            private static bool Enabled => Setting.PartyFoodConsumptionEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyFoodConsumptionAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyFoodConsumptionMultiplier;
            private static float Minimum => Setting.MinimumPartyFoodConsumption;
            private static float Maximum => Setting.MaximumPartyFoodConsumption;

            internal static void Postfix(ref ExplainedNumber __result, MobileParty party, bool includeDescription = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}