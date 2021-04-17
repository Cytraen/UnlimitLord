using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace UnlimitLord.Patches
{
    internal static class CraftingCampaignBehaviorPatch
    {
        private static Settings Setting => Settings.Instance;
        private static AppliesToEnum AppliesTo => Setting.CraftingStaminaAppliesTo.SelectedValue;

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
        internal static class InfiniteStamina
        {
            private static bool Enabled => Setting.InfiniteCraftingStaminaEnabled;

            internal static void Postfix(ref int __result, Hero hero)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, hero))
                    return;

                __result = CampaignBehaviorBase
                    .GetCampaignBehavior<CraftingCampaignBehavior>()
                    .GetMaxHeroCraftingStamina(hero);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}