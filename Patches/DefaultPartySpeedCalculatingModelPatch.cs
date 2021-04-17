using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
    internal static class DefaultPartySpeedCalculatingModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.MovementSpeedEnabled;
        private static AppliesToEnum AppliesTo => Setting.MovementSpeedAppliesTo.SelectedValue;
        private static float Multiplier => Setting.MovementSpeedMultiplier;
        private static float Minimum => Setting.MinimumMovementSpeed;
        private static float Maximum => Setting.MaximumMovementSpeed;

        internal static void Postfix(ref ExplainedNumber __result, MobileParty mobileParty, ExplainedNumber finalSpeed)
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