using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        public static int Postfix(int result)
        {
            return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfWorkshops, McmSettings.Instance.MaxNumOfWorkshops);
        }
    }
}