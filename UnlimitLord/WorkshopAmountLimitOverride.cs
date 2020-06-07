using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
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
            return McmSettings.Instance.NumOfWorkshops;
        }

#endif

    }
}