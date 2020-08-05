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
    [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
    internal static class DefaultCharacterStatsModelPatch
    {
        private static Settings Setting => Settings.Instance;
        private static bool Enabled => Setting.HeroHealthAmountEnabled;
        private static AppliesToEnum AppliesTo => Setting.HeroHealthAmountAppliesTo.SelectedValue;
        private static float Multiplier => Setting.HeroHealthAmountMultiplier;
        private static int Minimum => Setting.MinimumHeroHealthAmount;
        private static int Maximum => Setting.MaximumHeroHealthAmount;

        internal static int Postfix(int result, CharacterObject character, StatExplainer explanation)
        {
            if (!PatchAppliesTo.DoesPatchApply(AppliesTo, character))
                return result;

            return MathHelper.ClampAndExplainInt((int)(result * Multiplier), explanation, Minimum, Maximum);
        }

        internal static bool Prepare()
        {
            return Enabled;
        }
    }
}