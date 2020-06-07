using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
    internal static class CompanionAmountLimitOverride
    {

#if !mcmMode

        public static int Postfix(int result)
        {
            return 100000;
        }

#endif

#if mcmMode

        public static DynamicMethod Postfix(int result)
        {
            return new DynamicMethod("Patch", typeof(int), new[] { typeof(int) });
        }

        public static int Patch(int result)
        {
            return McmSettings.Instance.NumOfCompanions;
        }

#endif

    }
}