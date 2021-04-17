using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    internal static class DefaultClanFinanceModelPatch
    {
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class Party
        {
            private static bool Enabled => Setting.PartyWageEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyWageAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyWageMultiplier;
            private static int Minimum => Setting.MinimumPartyWage;
            private static int Maximum => Setting.MaximumPartyWage;

            internal static void Postfix(ref int __result, MobileParty mobileParty)
            {
                if (mobileParty.IsThisPartyGarrison() || !PatchAppliesTo.DoesPatchApply(AppliesTo, mobileParty))
                    return;

                __result = MathHelper.ClampInt((int)(__result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class Garrison
        {
            private static bool Enabled => Setting.GarrisonWageEnabled;
            private static AppliesToEnum AppliesTo => Setting.GarrisonWageAppliesTo.SelectedValue;
            private static float Multiplier => Setting.GarrisonWageMultiplier;
            private static int Minimum => Setting.MinimumGarrisonWage;
            private static int Maximum => Setting.MaximumGarrisonWage;

            internal static void Postfix(ref int __result, MobileParty mobileParty)
            {
                if (!mobileParty.IsThisPartyGarrison() || !PatchAppliesTo.DoesPatchApply(AppliesTo, mobileParty))
                    return;

                __result = MathHelper.ClampInt((int)(__result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}