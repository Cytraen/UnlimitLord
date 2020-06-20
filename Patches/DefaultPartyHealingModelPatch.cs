/*
 Copyright (C) 2020 ashakoor

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License,
 or any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord.Patches
{
    internal static class DefaultPartyHealingModelPatch
    {
        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        internal static class Troops
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                var settings = Settings.Instance;
                if (WhoToApplyTo.DoesPatchApply(settings.TroopHealingRateAppliesTo.SelectedValue.GetWho(), party))
                    return result;

                return Math.ClampAndExplain(
                    result * settings.TroopHealingRateMultiplier, explanation,
                    settings.MinimumTroopHealingRate,
                    settings.MaximumTroopHealingRate
                );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.TroopHealingRateEnabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        internal static class Heroes
        {
            public static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                var settings = Settings.Instance;
                if (WhoToApplyTo.DoesPatchApply(settings.HeroHealingRateAppliesTo.SelectedValue.GetWho(), party))
                    return result;

                return Math.ClampAndExplain(
                    result * settings.HeroHealingRateMultiplier, explanation,
                    settings.MinimumHeroHealingRate,
                    settings.MaximumHeroHealingRate
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.HeroHealingRateEnabled;
            }
        }
    }
}