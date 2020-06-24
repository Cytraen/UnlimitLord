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
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord.Patches
{
    internal static class DefaultPartySizeLimitModelPatch
    {
        public static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Castle
        {
            public static bool Enabled => Setting.CastleGarrisonSizeEnabled;
            public static AppliesToEnum AppliesTo => Setting.CastleGarrisonSizeAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.CastleGarrisonSizeMultiplier;
            public static int Minimum => Setting.MinimumCastleGarrisonSize;
            public static int Maximum => Setting.MaximumCastleGarrisonSize;

            internal static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                if (!party.IsThisPartyGarrison() || !party.DoesPartyBelongToCastle())
                    return result;

                return Math.ClampAndExplainInt((int)(result * Multiplier), explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Town
        {
            public static bool Enabled => Setting.TownGarrisonSizeEnabled;
            public static AppliesToEnum AppliesTo => Setting.TownGarrisonSizeAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.TownGarrisonSizeMultiplier;
            public static int Minimum => Setting.MinimumTownGarrisonSize;
            public static int Maximum => Setting.MaximumTownGarrisonSize;

            internal static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                if (!party.IsThisPartyGarrison() || !party.DoesPartyBelongToTown())
                    return result;

                return Math.ClampAndExplainInt((int)(result * Multiplier), explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Troops
        {
            public static bool Enabled => Setting.PartyTroopAmountEnabled;
            public static AppliesToEnum AppliesTo => Setting.PartyTroopAmountAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.PartyTroopAmountMultiplier;
            public static int Minimum => Setting.MinimumPartyTroopAmount;
            public static int Maximum => Setting.MaximumPartyTroopAmount;

            internal static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainInt((int)(result * Multiplier), explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
        internal static class Prisoners
        {
            public static bool Enabled => Setting.PartyPrisonerAmountEnabled;
            public static AppliesToEnum AppliesTo => Setting.PartyPrisonerAmountAppliesTo.SelectedValue.GetWho();
            public static float Multiplier => Setting.PartyPrisonerAmountMultiplier;
            public static int Minimum => Setting.MinimumPartyPrisonerAmount;
            public static int Maximum => Setting.MaximumPartyPrisonerAmount;

            internal static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return result;

                return Math.ClampAndExplainInt((int)(result * Multiplier), explanation, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}