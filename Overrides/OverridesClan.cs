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
                if (clan != Clan.PlayerClan) return result;
                return Helpers.ClampInt(result, McmSettings.Instance.MinNumOfParties, McmSettings.Instance.MaxNumOfParties);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class GarrisonSizeLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (party.MobileParty?.IsGarrison != true || party.Owner != CharacterObject.PlayerCharacter.HeroObject)
                    return result;

                else if (party.MobileParty?.HomeSettlement?.IsCastle == true)
                    return Helpers.ClampAndExplainInt(result, explanation, McmSettings.Instance.MinCastleGarrisonSize, McmSettings.Instance.MinCastleGarrisonSize);

                else if (party.MobileParty?.HomeSettlement?.IsTown == true)
                    return Helpers.ClampAndExplainInt(result, explanation, McmSettings.Instance.MinTownGarrisonSize, McmSettings.Instance.MinTownGarrisonSize);

                else
                    return result;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class GarrisonWageOverride
        {
            public static int Postfix(int result, MobileParty mobileParty)
            {
                if (!mobileParty.IsGarrison || mobileParty.Party?.Owner?.Clan != Clan.PlayerClan)
                    return result;

                return (int)(result * McmSettings.Instance.GarrisonWageMultiplier);
            }
        }
    }
}