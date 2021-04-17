using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultBarterModel), "get_BarterCooldownWithHeroInDays")]
    internal static class DefaultBarterModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.BarterCooldownEnabled;
        private static int Cooldown => Setting.BarterCooldownDays;

        internal static void Postfix(ref int __result)
        {
            __result = Cooldown;
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}