using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(Clan), "get_CompanionLimit")]
        internal static class CompanionAmountLimitOverride
        {
            public static int Postfix(int result)
            {
                return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfCompanions, McmSettings.Instance.MinNumOfCompanions);
            }
        }

        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        internal static class PlayerHealthOverride
        {
            public static int Postfix(int result, CharacterObject character, StatExplainer explanation)
            {
                if (character != CharacterObject.PlayerCharacter)
                    return result;

                return Helpers.ClampAndExplainInt(result, explanation, McmSettings.Instance.MinPlayerHealth, McmSettings.Instance.MaxPlayerHealth);
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
        internal static class SmithingStaminaAmountOverride
        {
            public static int Postfix(int result, Hero hero)
            {
                return hero.IsHumanPlayerCharacter ? result : CampaignBehaviorBase.GetCampaignBehavior<CraftingCampaignBehavior>().GetMaxHeroCraftingStamina(hero);
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
        internal static class SmithingStaminaMaxOverride
        {
            public static int Postfix(int result, Hero hero)
            {
                return McmSettings.Instance.MaxSmithStaminaAmount;
            }
        }

        [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
        internal static class WorkshopAmountLimitOverride
        {
            public static int Postfix(int result)
            {
                return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfWorkshops, McmSettings.Instance.MaxNumOfWorkshops);
            }
        }
    }
}