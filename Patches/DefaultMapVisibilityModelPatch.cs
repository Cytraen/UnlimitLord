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
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
    internal static class DefaultMapVisibilityModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.ViewDistanceEnabled;
        private static float Multiplier => Setting.ViewDistanceMultiplier;
        private static float Minimum => Setting.MinimumViewDistance;
        private static float Maximum => Setting.MaximumViewDistance;

        internal static float Postfix(float result, MobileParty party, StatExplainer explainer)
        {
            if (!PatchAppliesTo.DoesPatchApply(AppliesToEnum.PlayerParty, party))
                return result;

            return MathHelper.ClampAndExplainFloat(result * Multiplier, explainer, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}