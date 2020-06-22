using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    internal static class DefaultClanTierModelPatch
    {
        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class Party
        {
            internal static int Postfix(int result, Clan clan)
            {
                var settings = Settings.Instance;
                if (!WhoToApplyTo.DoesPatchApply(settings.PartyAmountAppliesTo.SelectedValue.GetWho(), clan))
                    return result;

                return (int)Math.Clamp(
                    result * settings.PartyAmountMultiplier,
                    settings.MinimumPartyAmount,
                    settings.MaximumPartyAmount
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.PartyAmountEnabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
        internal static class Companion
        {
            internal static int Postfix(int result, Clan clan)
            {
                var settings = Settings.Instance;

                return (int)Math.Clamp(
                    result * settings.CompanionAmountMultiplier,
                    settings.MinimumCompanionAmount,
                    settings.MaximumCompanionAmount
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.CompanionAmountEnabled;
            }
        }
    }
}