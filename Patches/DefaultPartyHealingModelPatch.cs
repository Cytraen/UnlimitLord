using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    internal static class DefaultPartyHealingModelPatch
    {
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        internal static class Troops
        {
            private static bool Enabled => Setting.TroopHealingRateEnabled;
            private static AppliesToEnum AppliesTo => Setting.TroopHealingRateAppliesTo.SelectedValue;
            private static float Multiplier => Setting.TroopHealingRateMultiplier;
            private static float Minimum => Setting.MinimumTroopHealingRate;
            private static float Maximum => Setting.MaximumTroopHealingRate;

            internal static void Postfix(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false)
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

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        internal static class Heroes
        {
            private static bool Enabled => Setting.HeroHealingRateEnabled;
            private static AppliesToEnum AppliesTo => Setting.HeroHealingRateAppliesTo.SelectedValue;
            private static float Multiplier => Setting.HeroHealingRateMultiplier;
            private static float Minimum => Setting.MinimumHeroHealingRate;
            private static float Maximum => Setting.MaximumHeroHealingRate;

            internal static void Postfix(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false)
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