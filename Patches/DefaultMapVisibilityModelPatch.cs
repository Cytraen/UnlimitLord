using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
    internal static class DefaultMapVisibilityModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.ViewDistanceEnabled;
        private static float Multiplier => Setting.ViewDistanceMultiplier;
        private static float Minimum => Setting.MinimumViewDistance;
        private static float Maximum => Setting.MaximumViewDistance;

        internal static void Postfix(ref ExplainedNumber __result, MobileParty party, bool includeDescriptions = false)
        {
            if (!PatchAppliesTo.DoesPatchApply(AppliesToEnum.PlayerParty, party))
                return;

            MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}