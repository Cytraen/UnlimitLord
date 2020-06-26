using HarmonyLib;
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultPersuasionModel), "GetChances")]
    internal static class DefaultPersuasionModelPatch
    {
        public static Settings Setting => Settings.Instance;
        public static bool Enabled => Setting.PersuasionChanceEnabled;
        public static float Multiplier => Setting.PersuasionSuccessMultiplier;
        public static float Minimum => Setting.MinimumSuccessChance;
        public static float Maximum => Setting.MaximumSuccessChance;
        public static float SuccessRatio => Setting.CriticalSuccessChance;
        public static float FailureRatio => Setting.CriticalFailureChance;

        internal static void Postfix(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
        {
            var totalSuccessChance = Math.ClampFloat(successChance + critSuccessChance, Minimum, Maximum);
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