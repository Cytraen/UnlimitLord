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
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Castle
        {
            private static bool Enabled => Setting.CastleGarrisonSizeEnabled;
            private static AppliesToEnum AppliesTo => Setting.CastleGarrisonSizeAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.CastleGarrisonSizeMultiplier;
            private static int Minimum => Setting.MinimumCastleGarrisonSize;
            private static int Maximum => Setting.MaximumCastleGarrisonSize;

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
            private static bool Enabled => Setting.TownGarrisonSizeEnabled;
            private static AppliesToEnum AppliesTo => Setting.TownGarrisonSizeAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.TownGarrisonSizeMultiplier;
            private static int Minimum => Setting.MinimumTownGarrisonSize;
            private static int Maximum => Setting.MaximumTownGarrisonSize;

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
            private static bool Enabled => Setting.PartyTroopAmountEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyTroopAmountAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.PartyTroopAmountMultiplier;
            private static int Minimum => Setting.MinimumPartyTroopAmount;
            private static int Maximum => Setting.MaximumPartyTroopAmount;

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
            private static bool Enabled => Setting.PartyPrisonerAmountEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyPrisonerAmountAppliesTo.SelectedValue.GetWho();
            private static float Multiplier => Setting.PartyPrisonerAmountMultiplier;
            private static int Minimum => Setting.MinimumPartyPrisonerAmount;
            private static int Maximum => Setting.MaximumPartyPrisonerAmount;

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