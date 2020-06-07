using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            return McmSettings.Instance.NumOfWorkshops;
#else
            return 100000;
#endif
        }
    }
}