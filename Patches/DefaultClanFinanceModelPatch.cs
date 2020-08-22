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
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    internal static class DefaultClanFinanceModelPatch
    {
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class Party
        {
            private static bool Enabled => Setting.PartyWageEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyWageAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyWageMultiplier;
            private static int Minimum => Setting.MinimumPartyWage;
            private static int Maximum => Setting.MaximumPartyWage;

            internal static int Postfix(int result, MobileParty mobileParty)
            {
                if (mobileParty.IsThisPartyGarrison() || !PatchAppliesTo.DoesPatchApply(AppliesTo, mobileParty))
                    return result;

                return MathHelper.ClampInt((int)(result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanFinanceModel), "CalculatePartyWage")]
        internal static class Garrison
        {
            private static bool Enabled => Setting.GarrisonWageEnabled;
            private static AppliesToEnum AppliesTo => Setting.GarrisonWageAppliesTo.SelectedValue;
            private static float Multiplier => Setting.GarrisonWageMultiplier;
            private static int Minimum => Setting.MinimumGarrisonWage;
            private static int Maximum => Setting.MaximumGarrisonWage;

            internal static int Postfix(int result, MobileParty mobileParty)
            {
                if (!mobileParty.IsThisPartyGarrison() || !PatchAppliesTo.DoesPatchApply(AppliesTo, mobileParty))
                    return result;

                return MathHelper.ClampInt((int)(result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}