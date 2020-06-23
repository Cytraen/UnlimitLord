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
        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetMaxHeroCraftingStamina")]
        internal static class MaximumStamina
        {
            internal static int Postfix(int result, Hero hero)
            {
                var settings = Settings.Instance;
                if (!WhoToApplyTo.DoesPatchApply(settings.CraftingStaminaAppliesTo.SelectedValue.GetWho(), hero))
                    return result;

                return (int)Math.Clamp(
                    result * settings.CraftingStaminaMultiplier,
                    settings.MinimumCraftingStamina,
                    settings.MaximumCraftingStamina
                    );
            }

            internal static bool Prepare()
            {
                return Settings.Instance.CraftingStaminaAmountEnabled;
            }
        }

        [HarmonyPatch(typeof(CraftingCampaignBehavior), "GetHeroCraftingStamina")]
        internal static class InfiniteStamina
        {
            internal static int Postfix(int result, Hero hero)
            {
                if (!WhoToApplyTo.DoesPatchApply(Settings.Instance.CraftingStaminaAppliesTo.SelectedValue.GetWho(), hero))
                    return result;

                return CampaignBehaviorBase
                    .GetCampaignBehavior<CraftingCampaignBehavior>()
                    .GetMaxHeroCraftingStamina(hero)
                    ;
            }

            internal static bool Prepare()
            {
                return Settings.Instance.InfiniteCraftingStaminaEnabled;
            }
        }
    }
}