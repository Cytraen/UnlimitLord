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
        internal static class PartyDoesNotEatOverridePt1
        {
            public static bool Postfix(bool result, MobileParty mobileParty)
            {
                var settings = McmSettings.Instance;
                return !(!result || mobileParty.IsPlayersMainParty()
                    || (mobileParty.IsPlayerClanOwnedParty() && settings.FoodlessClanEnabled)
                    || (mobileParty.IsGarrison() && settings.FoodlessGarrisonsEnabled)
                    );
            }
        }

        [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "CalculateDailyFoodConsumptionf")]
        internal static class PartyDoesNotEatOverridePt2
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explainer)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty()
                    && (!party.IsPlayerClanOwnedParty() || !settings.FoodlessClanEnabled)
                    && (!party.IsGarrison() || !settings.FoodlessGarrisonsEnabled)
                    )
                    return result;


                return Helpers.ClampAndExplain(-result, explainer, 0, 0);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        internal static class PartyHealingRateOverrideTroops
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty())
                    return result;

                return Helpers.ClampAndExplain(result * settings.TroopHealingMult, explanation, settings.MinTroopHealing, settings.MaxTroopHealing);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        internal static class PartyHealingRateOverrideHeroes
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty())
                    return result;

                return Helpers.ClampAndExplain(result * settings.HeroHealingMult, explanation, settings.MinHeroHealing, settings.MaxHeroHealing);
            }
        }

        [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
        internal static class PartyMoraleOverride
        {
            public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
            {
                var settings = McmSettings.Instance;
                if (!mobileParty.IsPlayersMainParty())
                    return result;

                return Helpers.ClampAndExplain(result * settings.PartyMoraleMult, explanation, settings.MinPartyMorale, settings.MaxPartyMorale);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class PartySizeLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty())
                    return result;

                return (int)Helpers.ClampAndExplain(result * settings.PartySizeMult, explanation, settings.MinPartySize, settings.MaxPartySize);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "CalculateFinalSpeed")]
        internal static class PartySpeedOverride
        {
            public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!mobileParty.IsPlayersMainParty())
                    return result;

                return Helpers.ClampAndExplain(result * settings.PartySpeedMult, explanation, settings.MinPartySpeed, settings.MaxPartySpeed);
            }
        }

        [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
        internal static class PartyViewDistanceOverride
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explainer)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty())
                    return result;

                return Helpers.ClampAndExplain(result * settings.ViewDistMult, explainer, settings.MinViewDist, settings.MaxViewDist);
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
        internal static class PrisonerAmountLimitOverride
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!party.IsPlayersMainParty())
                    return result;

                return (int)Helpers.ClampAndExplain(result * settings.NumOfPrisonersMult, explanation, settings.MinNumOfPrisoners, settings.MaxNumOfPrisoners);
            }
        }

        // Does not show up in inventory menu, but prevents "cargo within capacity" speed de-buff.
        [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "GetTotalWeightOfItems")]
        internal static class WeightlessItemsOverridePt1
        {
            public static float Postfix(float result, MobileParty mobileParty)
            {
                if (!mobileParty.IsPlayersMainParty())
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
                if (mobileParty.IsPlayersMainParty())
                    totalWeightCarried = 0;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class PartyWageOverride
        {
            public static int Postfix(int result, MobileParty mobileParty)
            {
                var settings = McmSettings.Instance;
                if (!mobileParty.IsPlayersMainParty() && (!mobileParty.IsPlayerClanOwnedParty() || !settings.TroopWageAllParties))
                    return result;

                return (int)Helpers.Clamp(result * settings.TroopWageMultiplier, settings.MinTroopWage, settings.MaxTroopWage);
            }
        }
    }
}