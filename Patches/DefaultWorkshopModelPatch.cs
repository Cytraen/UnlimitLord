using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class DefaultWorkshopModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.WorkshopAmountEnabled;
        private static float Multiplier => Setting.WorkshopAmountMultiplier;
        private static int Minimum => Setting.MinimumWorkshopAmount;
        private static int Maximum => Setting.MaximumWorkshopAmount;

        internal static void Postfix(ref int __result)
        {
            __result = MathHelper.ClampInt((int)(__result * Multiplier), Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}