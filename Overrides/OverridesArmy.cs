/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord.Overrides
{
    internal static partial class Overrides
    {
        [HarmonyPatch(typeof(DefaultArmyManagementCalculationModel), "CalculateCohesionChange")]
        internal static class ArmyCohesionOverride
        {
            public static float Postfix(float result, Army army, StatExplainer explanation)
            {
                var settings = McmSettings.Instance;
                if (!army.IsPlayerLedArmy())
                    return result;

                return Helpers.ClampAndExplain((result * settings.ArmyCohesionMultiplier) + army.Cohesion, explanation, settings.MinCohesion, settings.MaxCohesion);
            }
        }
    }
}