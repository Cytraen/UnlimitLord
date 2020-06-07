using System.Reflection.Emit;
using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            return GlobalSettings<McmSettings>.Instance.NumOfWorkshops;
#else
            return 100000;
#endif
        }
    }
}