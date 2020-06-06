using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
#if !mcmMode
            new Harmony("com.unlimitLord.patch").PatchAll();
#endif
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));

#if mcmMode
            ApplyPatches(McmSettings.Instance);
        }

        private static void ApplyPatches(McmSettings mcmSettings)
        {
            var patcher = new Harmony("com.unlimitLord.patch");

            if (mcmSettings.DisableCompanionAmount)
                patcher.Patch(typeof(DefaultClanTierModel).GetMethod("GetCompanionLimitForTier"),
                    postfix: new HarmonyMethod(typeof(CompanionAmountLimitOverride).GetMethod("Postfix")));

            if (mcmSettings.DisablePartyAmount)
                patcher.Patch(typeof(DefaultClanTierModel).GetMethod("GetPartyLimitForTier"),
                    postfix: new HarmonyMethod(typeof(PartyAmountLimitOverride).GetMethod("Postfix")));

            if (mcmSettings.DisablePartySize)
                patcher.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyMemberSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PartySizeLimitOverride).GetMethod("Postfix")));

            if (mcmSettings.DisablePrisonerAmount)
                patcher.Patch(typeof(DefaultPartySizeLimitModel).GetMethod("GetPartyPrisonerSizeLimit"),
                    postfix: new HarmonyMethod(typeof(PrisonerAmountLimitOverride).GetMethod("Postfix")));

            if (mcmSettings.DisableWorkshopAmount)
                patcher.Patch(typeof(DefaultWorkshopModel).GetMethod("GetMaxWorkshopCountForPlayer"),
                    postfix: new HarmonyMethod(typeof(WorkshopAmountLimitOverride).GetMethod("Postfix")));
        }

#endif

        }
    }
}