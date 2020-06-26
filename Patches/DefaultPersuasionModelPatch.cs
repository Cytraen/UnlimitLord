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
using TaleWorlds.CampaignSystem.Conversation.Persuasion;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultPersuasionModel), "GetChances")]
    internal static class DefaultPersuasionModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.PersuasionChanceEnabled;
        private static float Multiplier => Setting.PersuasionSuccessMultiplier;
        private static float Minimum => Setting.MinimumSuccessChance;
        private static float Maximum => Setting.MaximumSuccessChance;
        private static float SuccessRatio => Setting.CriticalSuccessChance;
        private static float FailureRatio => Setting.CriticalFailureChance;

        internal static void Postfix(PersuasionOptionArgs optionArgs, ref float successChance, ref float critSuccessChance, ref float critFailChance, ref float failChance, float difficultyMultiplier)
        {
            var totalSuccessChance = Math.ClampFloat((successChance + critSuccessChance) * Multiplier, Minimum, Maximum);
            critSuccessChance = totalSuccessChance * SuccessRatio;
            successChance = totalSuccessChance * (1.0f - SuccessRatio);

            var totalFailChance = 1.0f - totalSuccessChance;
            critFailChance = totalFailChance * FailureRatio;
            failChance = totalFailChance * (1.0f - FailureRatio);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}