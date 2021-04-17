using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    internal static class DefaultClanTierModelPatch
    {
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class Party
        {
            private static bool Enabled => Setting.PartyAmountEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyAmountAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyAmountMultiplier;
            private static int Minimum => Setting.MinimumPartyAmount;
            private static int Maximum => Setting.MaximumPartyAmount;

            internal static void Postfix(ref int __result, Clan clan)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, clan))
                    return;

                __result = MathHelper.ClampInt((int)(__result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimit")]
        internal static class Companion
        {
            private static bool Enabled => Setting.CompanionAmountEnabled;
            private static float Multiplier => Setting.CompanionAmountMultiplier;
            private static int Minimum => Setting.MinimumCompanionAmount;
            private static int Maximum => Setting.MaximumCompanionAmount;

            internal static void Postfix(ref int __result, Clan clan)
            {
                // if (!PatchAppliesTo.DoesPatchApply(AppliesTo, clan))
                //     return;

                __result = MathHelper.ClampInt((int)(__result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}