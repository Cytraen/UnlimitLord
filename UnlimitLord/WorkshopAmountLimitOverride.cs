using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class WorkshopAmountLimitOverride
    {
        [HarmonyPostfix]
        public static int Postfix(int result)
        {
            return 100000;
        }
    }
}