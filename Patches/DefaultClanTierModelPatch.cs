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
    internal static class DefaultClanTierModelPatch
    {
        public static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class Party
        {
            public static bool Enabled => Setting.PartyAmountEnabled;
            public static AppliesToEnum AppliesTo => Setting.PartyAmountAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.PartyAmountMultiplier;
            public static int Minimum => Setting.MinimumPartyAmount;
            public static int Maximum => Setting.MaximumPartyAmount;

            internal static int Postfix(int result, Clan clan)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, clan))
                    return result;

                return Math.ClampInt((int)(result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
        internal static class Companion
        {
            public static bool Enabled => Setting.CompanionAmountEnabled;
            public static float Multiplier => Setting.CompanionAmountMultiplier;
            public static int Minimum => Setting.MinimumCompanionAmount;
            public static int Maximum => Setting.MaximumCompanionAmount;

            internal static int Postfix(int result, int clanTier)
            {
                return Math.ClampInt((int)(result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}