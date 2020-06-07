using System;
using System.ComponentModel;
using System.Reflection;
using HarmonyLib;
using MCM.Abstractions.Settings.Base;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
#if !mcmMode
            new Harmony("com.unlimitLord.patch").PatchAll();
            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
#else
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

            if (mcmSettings.NumOfCompanions != -1)
            {
                harmony.Patch(typeof(DefaultClanTierModel).GetMethod("GetCompanionLimitForTier"),
                    postfix: new HarmonyMethod(typeof(CompanionAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.NumOfParties != -1)
            {
                harmony.Patch(typeof(DefaultClanTierModel).GetMethod("GetPartyLimitForTier"),
                    postfix: new HarmonyMethod(typeof(PartyAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.PartySize != -1)
            {
                harmony.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyMemberSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PartySizeLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.NumOfPrisoners != -1)
            {
                harmony.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyPrisonerSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PrisonerAmountLimitOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.NumOfWorkshops != -1)
            {
                harmony.Patch(typeof(DefaultWorkshopModel).GetMethod("GetMaxWorkshopCountForPlayer"),
                    postfix: new HarmonyMethod(typeof(WorkshopAmountLimitOverride).GetMethod("Postfix")));
            }

            if (Math.Abs(mcmSettings.PartyMorale - -1.0f) > 0.005)
            {
                harmony.Patch(typeof(DefaultPartyMoraleModel).GetMethod("GetEffectivePartyMorale"),
                    postfix: new HarmonyMethod(typeof(PartyMoraleOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.DisableClanPartiesEating)
            {
                harmony.Patch(typeof(DefaultMobilePartyFoodConsumptionModel).GetMethod("DoesPartyConsumeFood"),
                    postfix: new HarmonyMethod(typeof(PartyDoesNotEatOverride).GetMethod("Postfix")));
            }

            if (mcmSettings.DisableItemWeight)
            {
                harmony.Patch(typeof(DefaultPartySpeedCalculatingModel).GetMethod("GetTotalWeightOfItems", BindingFlags.NonPublic | BindingFlags.Static),
                    postfix: new HarmonyMethod(typeof(WeightlessItemsOverridePt1).GetMethod("Postfix")));

                harmony.Patch(typeof(DefaultPartySpeedCalculatingModel).GetMethod("AddCargoStats", BindingFlags.NonPublic | BindingFlags.Static),
                    postfix: new HarmonyMethod(typeof(WeightlessItemsOverridePt2).GetMethod("Postfix")));
            }
#endif
        }
    }
}