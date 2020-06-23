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
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord.Patches
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), "GetMaxWorkshopCountForPlayer")]
    internal static class DefaultWorkshopModelPatch
    {
        internal static int Postfix(int result)
        {
            var settings = Settings.Instance;
            return (int)Math.Clamp(
                result * settings.WorkshopAmountMultiplier,
                settings.MinimumWorkshopAmount,
                settings.MaximumWorkshopAmount
                );
        }

        internal static bool Prepare()
        {
            return Settings.Instance.WorkshopAmountEnabled;
        }
    }
}