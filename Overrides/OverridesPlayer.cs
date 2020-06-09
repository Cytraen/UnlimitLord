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
                var settings = McmSettings.Instance;
                return (int)Helpers.Clamp(result * settings.NumOfCompanionsMult, settings.MinNumOfCompanions, settings.MinNumOfCompanions);
            }
        }

        [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
        internal static class PlayerHealthOverride
        {
            public static int Postfix(int result, CharacterObject character, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!character.IsPlayer())
                    return result;

                return (int)Helpers.ClampAndExplain(result * settings.PlayerHealthMult, explanation, settings.MinPlayerHealth, settings.MaxPlayerHealth);
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
        internal static class SmithingStaminaAmountOverride
        {
            public static int Postfix(int result, Hero hero)
            {
                return hero.IsPlayer() ? result : CampaignBehaviorBase.GetCampaignBehavior<CraftingCampaignBehavior>().GetMaxHeroCraftingStamina(hero);
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
        internal static class SmithingStaminaMaxOverride
        {
            public static int Postfix(int result, Hero hero)
            {
                var settings = McmSettings.Instance;
                if (!hero.IsPlayer())
                    return result;

                return (int)Helpers.Clamp(result * settings.SmithStaminaMult, 0, settings.MaxSmithStaminaAmount);
            }
        }

        [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
        internal static class WorkshopAmountLimitOverride
        {
            public static int Postfix(int result)
            {
                var settings = McmSettings.Instance;
                return (int)Helpers.Clamp(result * settings.NumOfWorkshopsMult, settings.MinNumOfWorkshops, settings.MaxNumOfWorkshops);
            }
        }
    }
}