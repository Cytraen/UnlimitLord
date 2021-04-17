using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
    internal static class DefaultCharacterStatsModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.HeroHealthAmountEnabled;
        private static AppliesToEnum AppliesTo => Setting.HeroHealthAmountAppliesTo.SelectedValue;
        private static float Multiplier => Setting.HeroHealthAmountMultiplier;
        private static int Minimum => Setting.MinimumHeroHealthAmount;
        private static int Maximum => Setting.MaximumHeroHealthAmount;

        internal static void Postfix(ref ExplainedNumber __result, CharacterObject character, bool includeDescriptions = false)
        {
            if (!PatchAppliesTo.DoesPatchApply(AppliesTo, character))
                return;

            MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}