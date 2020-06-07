using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        public static int Postfix(int result)
        {
#if mcmMode
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfWorkshops, McmSettings.Instance.MaxNumOfWorkshops);
#else
            return 100000;
#endif
        }
    }
}