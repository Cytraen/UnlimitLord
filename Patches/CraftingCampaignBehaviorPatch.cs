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
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;

namespace UnlimitLord.Patches
{
    internal static class CraftingCampaignBehaviorPatch
    {
        public static Settings Setting => Settings.Instance;
        public static AppliesToEnum AppliesTo => Setting.CraftingStaminaAppliesTo.SelectedValue.GetWho();

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
        internal static class MaximumStamina
        {
            public static bool Enabled => Setting.CraftingStaminaAmountEnabled;
            public static float Multiplier => Setting.CraftingStaminaMultiplier;
            public static int Minimum => Setting.MinimumCraftingStamina;
            public static int Maximum => Setting.MaximumCraftingStamina;

            internal static int Postfix(int result, Hero hero)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, hero))
                    return result;

                return Math.ClampInt((int)(result * Multiplier), Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
        internal static class InfiniteStamina
        {
            public static bool Enabled => Setting.InfiniteCraftingStaminaEnabled;

            internal static int Postfix(int result, Hero hero)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, hero))
                    return result;

                return CampaignBehaviorBase
                    .GetCampaignBehavior<CraftingCampaignBehavior>()
                    .GetMaxHeroCraftingStamina(hero);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}