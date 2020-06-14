using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
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
                if (!party.IsGarrison() || !party.IsPlayerOwnedParty())
                    return result;

                if (party.PartyBelongsToCastle())
                    return (int)Helpers.ClampAndExplain((int)(result * settings.CastleGarrisonSizeMult), explanation, settings.MinCastleGarrisonSize, settings.MaxCastleGarrisonSize);

                if (party.PartyBelongsToTown())
                    return (int)Helpers.ClampAndExplain((int)(result * settings.TownGarrisonSizeMult), explanation, settings.MinTownGarrisonSize, settings.MaxTownGarrisonSize);

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

        [HarmonyPatch(typeof(DefaultSettlementFoodModel), "CalculateTownFoodStocksChange")]
        internal static class GarrisonFoodConsumptionOverride
        {
            public static float Postfix(float result, Town town, StatExplainer explanation)
            {
                MobileParty garrisonParty = town?.GarrisonParty;

                if (garrisonParty?.IsGarrison() == false || garrisonParty?.IsPlayerOwnedParty() == false)
                    return result;

                return Helpers.ClampAndExplain(((garrisonParty?.Party?.NumberOfAllMembers) ?? 0) / 20, explanation, 0, 1000000);
            }
        }
    }
}