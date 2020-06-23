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
        [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
        internal static class Party
        {
            internal static int Postfix(int result, Clan clan)
            {
                var settings = Settings.Instance;
                if (!WhoToApplyTo.DoesPatchApply(settings.PartyAmountAppliesTo.SelectedValue.GetWho(), clan))
                    return result;

                return (int)Math.Clamp(
                    result * settings.PartyAmountMultiplier,
                    settings.MinimumPartyAmount,
                    settings.MaximumPartyAmount
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.PartyAmountEnabled;
            }
        }

        [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitForTier")]
        internal static class Companion
        {
            internal static int Postfix(int result, int clanTier)
            {
                var settings = Settings.Instance;

                return (int)Math.Clamp(
                    result * settings.CompanionAmountMultiplier,
                    settings.MinimumCompanionAmount,
                    settings.MaximumCompanionAmount
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.CompanionAmountEnabled;
            }
        }
    }
}