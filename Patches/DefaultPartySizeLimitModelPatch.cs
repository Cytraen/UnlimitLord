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
        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Castle
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = Settings.Instance;
                if (!party.IsThisPartyGarrison() || !WhoToApplyTo.DoesPatchApply(settings.CastleGarrisonSizeAppliesTo.SelectedValue.GetWho(), party))
                    return result;

                if (party.DoesPartyBelongToCastle())
                    return (int)Math.ClampAndExplain(
                        result * settings.CastleGarrisonSizeMultiplier, explanation,
                        settings.MinimumCastleGarrisonSize,
                        settings.MaximumCastleGarrisonSize
                        );

                return result;
            }

            internal static bool Prepare()
            {
                return Settings.Instance.CastleGarrisonSizeEnabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Town
        {
            public static int Postfix(int result, PartyBase party, StatExplainer explanation)
            {
                var settings = Settings.Instance;
                if (!party.IsThisPartyGarrison() || !WhoToApplyTo.DoesPatchApply(settings.TownGarrisonSizeAppliesTo.SelectedValue.GetWho(), party))
                    return result;

                if (party.DoesPartyBelongToCastle())
                    return (int)Math.ClampAndExplain(
                        result * settings.TownGarrisonSizeMultiplier, explanation,
                        settings.MinimumTownGarrisonSize,
                        settings.MaximumTownGarrisonSize
                        );

                return result;
            }

            internal static bool Prepare()
            {
                return Settings.Instance.TownGarrisonSizeEnabled;
            }
        }
    }
}