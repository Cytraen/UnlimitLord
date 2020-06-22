using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
    internal static class DefaultClanFinanceModelPatch
    {
        internal static int Postfix(int result, MobileParty mobileParty)
        {
            var settings = Settings.Instance;
            if (!mobileParty.IsGarrison() || !WhoToApplyTo.DoesPatchApply(settings.GarrisonWageAppliesTo.SelectedValue.GetWho(), mobileParty))
                return result;

            return (int)Math.Clamp(
                result * settings.GarrisonWageMultiplier,
                settings.MinimumGarrisonWage,
                settings.MaximumGarrisonWage
                );
        }

        internal static bool Prepare()
        {
            return Settings.Instance.GarrisonWageEnabled;
        }
    }
}