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
    internal static class DefaultMobilePartyFoodConsumptionModelPatch
    {
        [HarmonyPatch(typeof(DefaultMobilePartyFoodConsumptionModel), "CalculateDailyFoodConsumptionf")]
        internal static class Party
        {
            public static Settings Setting => Settings.Instance;
            public static bool Enabled => Setting.PartyFoodConsumptionEnabled;
            public static AppliesToEnum AppliesTo => Setting.PartyFoodConsumptionAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.PartyFoodConsumptionMultiplier;
            public static float Minimum => Setting.MinimumPartyFoodConsumption;
            public static float Maximum => Setting.MaximumPartyFoodConsumption;

            internal static float Postfix(float result, MobileParty party, StatExplainer explainer)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainFloat(result * Multiplier, explainer, -Minimum, -Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}