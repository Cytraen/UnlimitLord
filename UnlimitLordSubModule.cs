using HarmonyLib;
using MCM.Abstractions.Settings.Base;
using System.ComponentModel;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (McmSettings.Instance != null)
                McmSettings.Instance.PropertyChanged += MCMSettings_PropertyChanged;

            ApplyPatches(McmSettings.Instance);

            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
        }

        private static void MCMSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is McmSettings settings && e.PropertyName == BaseSettings.SaveTriggered)
            {
                ApplyPatches(settings);
            }
        }

        private static void ApplyPatches(McmSettings mcmSettings)
        {
            var harmony = new Harmony("com.unlimitLord.patch");
            if (Harmony.HasAnyPatches("com.unlimitLord.patch"))
            {
                harmony.UnpatchAll("com.unlimitLord.patch");
            }

            if (mcmSettings.CompanionAmountEnabled)
            {
                harmony.Patch(typeof(Clan).GetMethod("get_CompanionLimit"),
                    postfix: new HarmonyMethod(typeof(CompanionAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartyAmountEnabled)
            {
                harmony.Patch(typeof(DefaultClanTierModel).GetMethod("GetPartyLimitForTier"),
                    postfix: new HarmonyMethod(typeof(PartyAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartySizeEnabled)
            {
                harmony.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyMemberSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PartySizeLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PrisonerAmountEnabled)
            {
                harmony.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyPrisonerSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PrisonerAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.WorkshopAmountEnabled)
            {
                harmony.Patch(typeof(DefaultWorkshopModel).GetMethod("GetMaxWorkshopCountForPlayer"),
                    postfix: new HarmonyMethod(typeof(WorkshopAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartyMoraleEnabled)
            {
                harmony.Patch(typeof(DefaultPartyMoraleModel).GetMethod("GetEffectivePartyMorale"),
                    postfix: new HarmonyMethod(typeof(PartyMoraleOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartySpeedEnabled)
            {
                harmony.Patch(typeof(DefaultPartySpeedCalculatingModel).GetMethod("CalculateFinalSpeed"),
                    postfix: new HarmonyMethod(typeof(PartySpeedOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.FoodlessPartyEnabled)
            {
                harmony.Patch(typeof(DefaultMobilePartyFoodConsumptionModel).GetMethod("DoesPartyConsumeFood"),
                    postfix: new HarmonyMethod(typeof(PartyDoesNotEatOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.WeightlessItemsEnabled)
            {
                harmony.Patch(typeof(DefaultPartySpeedCalculatingModel).GetMethod("GetTotalWeightOfItems", BindingFlags.NonPublic | BindingFlags.Static),
                    postfix: new HarmonyMethod(typeof(WeightlessItemsOverridePt1).GetMethod("Postfix")));

                harmony.Patch(typeof(DefaultPartySpeedCalculatingModel).GetMethod("AddCargoStats", BindingFlags.NonPublic | BindingFlags.Static),
                    postfix: new HarmonyMethod(typeof(WeightlessItemsOverridePt2).GetMethod("Postfix")));
            }

            if (mcmSettings.InfiniteSmithStamina)
            {
                harmony.Patch(typeof(CraftingCampaignBehavior).GetMethod("GetHeroCraftingStamina"),
                    postfix: new HarmonyMethod(typeof(SmithingStaminaAmountOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.MaxSmithStaminaEnabled)
            {
                harmony.Patch(typeof(CraftingCampaignBehavior).GetMethod("GetMaxHeroCraftingStamina"),
                    postfix: new HarmonyMethod(typeof(SmithingStaminaMaxOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.ArmyCohesionEnabled)
            {
                harmony.Patch(typeof(DefaultArmyManagementCalculationModel).GetMethod("CalculateCohesionChange"),
                    postfix: new HarmonyMethod(typeof(ArmyCohesionOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.ViewDistEnabled)
            {
                harmony.Patch(typeof(DefaultMapVisibilityModel).GetMethod("GetPartySpottingRange"),
                    postfix: new HarmonyMethod(typeof(PartyViewDistanceOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PlayerHealthEnabled)
            {
                harmony.Patch(typeof(DefaultCharacterStatsModel).GetMethod("MaxHitpoints"),
                    postfix: new HarmonyMethod(typeof(PlayerHealthOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartyHealingEnabled)
            {
                harmony.Patch(typeof(DefaultPartyHealingModel).GetMethod("GetDailyHealingForRegulars"),
                    postfix: new HarmonyMethod(typeof(PartyHealingRateOverrideTroops).GetMethod("Postfix")));

                harmony.Patch(typeof(DefaultPartyHealingModel).GetMethod("GetDailyHealingHpForHeroes"),
                    postfix: new HarmonyMethod(typeof(PartyHealingRateOverrideHeroes).GetMethod("Postfix")));
            }
        }
    }
}