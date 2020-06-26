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
    [HarmonyPatch(typeof(DefaultDisguiseDetectionModel), "CalculateDisguiseDetectionProbability")]
    internal class DefaultDisguiseDetectionModelPatch
    {
        public static Settings Setting => Settings.Instance;
        public static bool Enabled => Setting.DisguiseChanceEnabled;
        public static float Multiplier => Setting.DisguiseChanceMultiplier;
        public static float Minimum => Setting.MinimumDisguiseChance;
        public static float Maximum => Setting.MaximumDisguiseChance;

        internal static float Postfix(float result, Settlement settlement)
        {
            return Math.ClampFloat(result * Multiplier, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}