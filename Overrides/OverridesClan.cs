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
                if (clan != Clan.PlayerClan)
                    return result;

                return Helpers.ClampInt((int)(result * settings.NumOfPartiesMult), settings.MinNumOfParties, settings.MaxNumOfParties);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class GarrisonSizeLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (party.MobileParty?.IsGarrison != true || party.Owner != CharacterObject.PlayerCharacter.HeroObject)
                    return result;

                else if (party.MobileParty?.HomeSettlement?.IsCastle == true)
                    return Helpers.ClampAndExplainInt((int)(result * settings.CastleGarrisonSizeMult), explanation, settings.MinCastleGarrisonSize, settings.MaxCastleGarrisonSize);

                else if (party.MobileParty?.HomeSettlement?.IsTown == true)
                    return Helpers.ClampAndExplainInt((int)(result * settings.TownGarrisonSizeMult), explanation, settings.MinTownGarrisonSize, settings.MaxTownGarrisonSize);

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
                if (!mobileParty.IsGarrison || mobileParty.Party?.Owner?.Clan != Clan.PlayerClan)
                    return result;

                return Helpers.ClampInt((int)(result * settings.GarrisonWageMultiplier), settings.MinGarrisonWage, settings.MaxGarrisonWage);
            }
        }
    }
}