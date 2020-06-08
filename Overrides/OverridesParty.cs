using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "DoesPartyConsumeFood")]
        internal static class PartyDoesNotEatOverride
        {
            public static bool Postfix(bool result, MobileParty mobileParty)
            {
                return !(!result || mobileParty.IsMainParty);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        internal static class PartyHealingRateOverrideTroops
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                if (!party.IsMainParty)
                    return result;

                return Helpers.ClampAndExplainFloat(result, explanation, McmSettings.Instance.MinTroopHealing, McmSettings.Instance.MaxTroopHealing);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        internal static class PartyHealingRateOverrideHeroes
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                if (!party.IsMainParty)
                    return result;

                return Helpers.ClampAndExplainFloat(result, explanation, McmSettings.Instance.MinHeroHealing, McmSettings.Instance.MaxHeroHealing);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
        internal static class PartyMoraleOverride
        {
            public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
            {
                if (!mobileParty.IsMainParty)
                    return result;

                return Helpers.ClampAndExplainFloat(result, explanation, McmSettings.Instance.MinPartyMorale, McmSettings.Instance.MaxPartyMorale);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class PartySizeLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (party != PartyBase.MainParty)
                    return result;

                return Helpers.ClampAndExplainInt(result, explanation, McmSettings.Instance.MinPartySize, McmSettings.Instance.MaxPartySize);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
        internal static class PartySpeedOverride
        {
            public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation)
            {
                if (!mobileParty.IsMainParty)
                    return result;

                return Helpers.ClampAndExplainFloat(result, explanation, McmSettings.Instance.MinPartySpeed, McmSettings.Instance.MaxPartySpeed);
            }
        }

        [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
        internal static class PartyViewDistanceOverride
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explainer)
            {
                if (!party.IsMainParty)
                    return result;

                return Helpers.ClampAndExplainFloat(result, explainer, McmSettings.Instance.MinViewDist, McmSettings.Instance.MaxViewDist);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
        internal static class PrisonerAmountLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (party != PartyBase.MainParty)
                    return result;

                return Helpers.ClampAndExplainInt(result, explanation, McmSettings.Instance.MinNumOfPrisoners, McmSettings.Instance.MaxNumOfPrisoners);
            }
        }

        // Does not show up in inventory menu, but prevents "cargo within capacity" speed de-buff.
        [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "GetTotalWeightOfItems")]
        internal static class WeightlessItemsOverridePt1
        {
            public static float Postfix(float result, MobileParty mobileParty)
            {
                if (!mobileParty.IsMainParty)
                    return result;

                return 0;
            }
        }

        // Does not show in inventory menu, but prevents overburden speed de-buff.
        [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "AddCargoStats")]
        internal static class WeightlessItemsOverridePt2
        {
            public static void Postfix(MobileParty mobileParty, ref float totalWeightCarried)
            {
                if (mobileParty.IsMainParty)
                    totalWeightCarried = 0;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class PartyWageOverride
        {
            public static int Postfix(int result, MobileParty mobileParty)
            {
                if (mobileParty.IsMainParty || (mobileParty?.LeaderHero?.Clan == Clan.PlayerClan && McmSettings.Instance.TroopWageAllParties))
                    return (int)(result * McmSettings.Instance.TroopWageMultiplier);

                return result;
            }
        }
    }
}