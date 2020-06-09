using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class PartyAmountLimitOverride
        {
            public static int Postfix(int result, Clan clan)
            {
                var settings = McmSettings.Instance;
                if (!clan.IsPlayerClan())
                    return result;

                return (int)Helpers.Clamp(result * settings.NumOfPartiesMult, settings.MinNumOfParties, settings.MaxNumOfParties);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class GarrisonSizeLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!party.IsGarrison() || !party.Owner.IsPlayer())
                    return result;

                else if (party.PartyBelongsToCastle())
                    return (int)Helpers.ClampAndExplain((int)(result * settings.CastleGarrisonSizeMult), explanation, settings.MinCastleGarrisonSize, settings.MaxCastleGarrisonSize);

                else if (party.PartyBelongsToTown())
                    return (int)Helpers.ClampAndExplain((int)(result * settings.TownGarrisonSizeMult), explanation, settings.MinTownGarrisonSize, settings.MaxTownGarrisonSize);

                else
                    return result;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class GarrisonWageOverride
        {
            public static int Postfix(int result, MobileParty mobileParty)
            {
                var settings = McmSettings.Instance;
                if (!mobileParty.IsGarrison() || !mobileParty.IsPlayerOwnedParty())
                    return result;

                return (int)Helpers.Clamp(result * settings.GarrisonWageMultiplier, settings.MinGarrisonWage, settings.MaxGarrisonWage);
            }
        }
    }
}