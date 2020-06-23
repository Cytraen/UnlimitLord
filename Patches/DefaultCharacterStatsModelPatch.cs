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
        internal static int Postfix(int result, CharacterObject character, StatExplainer explanation)
        {
            var settings = Settings.Instance;
            if (!WhoToApplyTo.DoesPatchApply(settings.HeroHealthAmountAppliesTo.SelectedValue.GetWho(), character.HeroObject))
                return result;

            return (int)Math.ClampAndExplain(
                result * settings.HeroHealthAmountMultiplier, explanation,
                settings.MinimumHeroHealthAmount,
                settings.MaximumHeroHealthAmount
                );
        }

        internal static bool Prepare()
        {
            return Settings.Instance.HeroHealthAmountEnabled;
        }
    }
}