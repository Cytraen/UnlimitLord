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
        public static int Minimum => Setting.MinimumSuccessChance;
        public static int Maximum => Setting.MaximumSuccessChance;

        internal static void Postfix(PersuasionOptionArgs optionArgs, float successChance, float critSuccessChance, float critFailChance, float failChance, float difficultyMultiplier)
        {
            return Math.ClampInt((int)(result * Multiplier), Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}
