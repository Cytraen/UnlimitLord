using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
    internal static class SmithingStaminaAmountOverride
    {
        public static int Postfix(int result, Hero hero)
        {
            return hero != CharacterObject.PlayerCharacter.HeroObject ? result : CampaignBehaviorBase.GetCampaignBehavior<CraftingCampaignBehavior>().GetMaxHeroCraftingStamina(hero);
        }
    }

    [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
    internal static class SmithingStaminaMaxOverride
    {
        public static int Postfix(int result, Hero hero)
        {
#if mcmMode
            return McmSettings.Instance.MaxSmithStaminaAmount;
#else
            return 500;
#endif
        }
    }
}