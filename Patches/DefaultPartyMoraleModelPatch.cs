using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
    internal static class DefaultPartyMoraleModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.MoraleEnabled;
        private static AppliesToEnum AppliesTo => Setting.MoraleAppliesTo.SelectedValue;
        private static float Multiplier => Setting.MoraleMultiplier;
        private static float Minimum => Setting.MinimumMorale;
        private static float Maximum => Setting.MaximumMorale;

        internal static void Postfix(ref ExplainedNumber __result, MobileParty mobileParty, bool includeDescription = false)
        {
            if (!PatchAppliesTo.DoesPatchApply(AppliesTo, mobileParty))
                return;

            MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}