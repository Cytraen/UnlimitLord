using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            if (result > McmSettings.Instance.MaxNumOfWorkshops) return McmSettings.Instance.MaxNumOfWorkshops;
            if (result < McmSettings.Instance.MinNumOfWorkshops) return McmSettings.Instance.MinNumOfWorkshops;
            return result;
#else
            return 100000;
#endif
        }
    }
}