using HarmonyLib;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultPersuasionModel), "GetChances")]
    internal static class DefaultPersuasionModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.PersuasionChanceEnabled;
        private static float Multiplier => Setting.PersuasionSuccessMultiplier;
        private static float Minimum => Setting.MinimumSuccessChance;
        private static float Maximum => Setting.MaximumSuccessChance;
        private static float SuccessRatio => Setting.CriticalSuccessChance;
        private static float FailureRatio => Setting.CriticalFailureChance;

        internal static void Postfix(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
        {
            var totalSuccessChance = MathHelper.ClampFloat((successChance + critSuccessChance) * Multiplier, Minimum, Maximum);
            critSuccessChance = totalSuccessChance * SuccessRatio;
            successChance = totalSuccessChance * (1.0f - SuccessRatio);

            var totalFailChance = 1.0f - totalSuccessChance;
            critFailChance = totalFailChance * FailureRatio;
            failChance = totalFailChance * (1.0f - FailureRatio);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}