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
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingForRegulars")]
        internal static class Troops
        {
            private static bool Enabled => Setting.TroopHealingRateEnabled;
            private static AppliesToEnum AppliesTo => Setting.TroopHealingRateAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.TroopHealingRateMultiplier;
            private static float Minimum => Setting.MinimumTroopHealingRate;
            private static float Maximum => Setting.MaximumTroopHealingRate;

            internal static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainFloat(result * Multiplier, explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartyHealingModel), "GetDailyHealingHpForHeroes")]
        internal static class Heroes
        {
            private static bool Enabled => Setting.HeroHealingRateEnabled;
            private static AppliesToEnum AppliesTo => Setting.HeroHealingRateAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.HeroHealingRateMultiplier;
            private static float Minimum => Setting.MinimumHeroHealingRate;
            private static float Maximum => Setting.MaximumHeroHealingRate;

            internal static float Postfix(float result, MobileParty party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainFloat(result * Multiplier, explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}