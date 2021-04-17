using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), "CalculateDisguiseDetectionProbability")]
    internal class DefaultDisguiseDetectionModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.DisguiseChanceEnabled;
        private static float Multiplier => Setting.DisguiseChanceMultiplier;
        private static float Minimum => Setting.MinimumDisguiseChance;
        private static float Maximum => Setting.MaximumDisguiseChance;

        internal static void Postfix(ref float __result, Settlement settlement)
        {
            __result = MathHelper.ClampFloat(__result * Multiplier, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}