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

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Data;
using MCM.Abstractions.Settings.Base.Global;

namespace UnlimitLord
{
    internal sealed partial class Settings : AttributeGlobalSettings<Settings>
    {
        public override string Id => "UnlimitLord.Settings_v2";
        public override string DisplayName => "UnlimitLord " + typeof(Settings).Assembly.GetName().Version.ToString(3);
        public override string FolderName => "UnlimitLord";
        public override string Format => "json";
    }

    // Movement speed settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Movement Speed", IsMainToggle = true)]
        [SettingPropertyBool("Movement Speed Enabled", RequireRestart = false)]
        public bool MovementSpeedEnabled { get; set; } = false;

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> MovementSpeedAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Movement Speed Multiplier", 0.01f, 10000f, Order = 1,
            RequireRestart = false)]
        public float MovementSpeedMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Minimum Speed", 0.01f, 100000f, Order = 2, RequireRestart = false)]
        public float MinimumMovementSpeed { get; set; } = 1f;

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Maximum Speed", 0.01f, 100000f, Order = 3, RequireRestart = false)]
        public float MaximumMovementSpeed { get; set; } = 100000f;
    }

    // Troop healing settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Troop Healing", IsMainToggle = true)]
        [SettingPropertyBool("Troop Healing Rate Enabled", RequireRestart = false)]
        public bool TroopHealingRateEnabled { get; set; } = false;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> TroopHealingRateAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Troop Healing Rate Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float TroopHealingRateMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Minimum Troop Healing Rate", 0f, 100000f, Order = 2, RequireRestart = false)]
        public float MinimumTroopHealingRate { get; set; } = 0f;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Maximum Troop Healing Rate", 0f, 100000f, Order = 3, RequireRestart = false)]
        public float MaximumTroopHealingRate { get; set; } = 100000f;
    }

    // Hero healing settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Hero Healing", IsMainToggle = true)]
        [SettingPropertyBool("Hero Healing Rate Enabled", RequireRestart = false)]
        public bool HeroHealingRateEnabled { get; set; } = false;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> HeroHealingRateAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Hero Healing Rate Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float HeroHealingRateMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Minimum Hero Healing Rate", 0f, 100000f, Order = 2, RequireRestart = false)]
        public float MinimumHeroHealingRate { get; set; } = 0f;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Maximum Hero Healing Rate", 0f, 100000f, Order = 3, RequireRestart = false)]
        public float MaximumHeroHealingRate { get; set; } = 100000f;
    }

    // Morale settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Morale", IsMainToggle = true)]
        [SettingPropertyBool("Morale Enabled", RequireRestart = false)]
        public bool MoraleEnabled { get; set; } = false;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> MoraleAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Morale Multiplier", 0.01f, 20f, Order = 1, RequireRestart = false)]
        public float MoraleMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Minimum Morale", 0f, 100f, Order = 2, RequireRestart = false)]
        public float MinimumMorale { get; set; } = 5f;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Maximum Morale", 0f, 100f, Order = 3, RequireRestart = false)]
        public float MaximumMorale { get; set; } = 100f;
    }

    // Castle garrison size settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Castle Garrison Size", IsMainToggle = true)]
        [SettingPropertyBool("Castle Garrison Size Enabled", RequireRestart = false)]
        public bool CastleGarrisonSizeEnabled { get; set; } = false;

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> CastleGarrisonSizeAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyFloatingInteger("Castle Garrison Size Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float CastleGarrisonSizeMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyInteger("Minimum Castle Garrison Size", 0, 100000, Order = 2, RequireRestart = false)]
        public int MinimumCastleGarrisonSize { get; set; } = 25;

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyInteger("Maximum Castle Garrison Size", 0, 100000, Order = 3, RequireRestart = false)]
        public int MaximumCastleGarrisonSize { get; set; } = 1000000000;
    }

    // Town garrison size settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Town Garrison Size", IsMainToggle = true)]
        [SettingPropertyBool("Town Garrison Size Enabled", RequireRestart = false)]
        public bool TownGarrisonSizeEnabled { get; set; } = false;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> TownGarrisonSizeAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyFloatingInteger("Town Garrison Size Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float TownGarrisonSizeMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyInteger("Minimum Town Garrison Size", 0, 100000, Order = 2, RequireRestart = false)]
        public int MinimumTownGarrisonSize { get; set; } = 25;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyInteger("Maximum Town Garrison Size", 0, 100000, Order = 3, RequireRestart = false)]
        public int MaximumTownGarrisonSize { get; set; } = 10000;
    }

    // Garrison wage settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Garrison Wage", IsMainToggle = true)]
        [SettingPropertyBool("Garrison Wage Enabled", RequireRestart = false)]
        public bool GarrisonWageEnabled { get; set; } = false;

        [SettingPropertyGroup("Garrison Wage")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> GarrisonWageAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Garrison Wage")]
        [SettingPropertyFloatingInteger("Garrison Wage Multiplier", 0.01f, 5000f, Order = 1, RequireRestart = false)]
        public float GarrisonWageMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Garrison Wage")]
        [SettingPropertyInteger("Minimum Garrison Wage", 0, 500000, Order = 2, RequireRestart = false)]
        public int MinimumGarrisonWage { get; set; } = 0;

        [SettingPropertyGroup("Garrison Wage")]
        [SettingPropertyInteger("Maximum Garrison Wage", 0, 500000, Order = 3, RequireRestart = false)]
        public int MaximumGarrisonWage { get; set; } = 500000;
    }

    // Party amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Party Amount", IsMainToggle = true)]
        [SettingPropertyBool("Party Amount Enabled", RequireRestart = false)]
        public bool PartyAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Party Amount")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> PartyAmountAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Party Amount")]
        [SettingPropertyFloatingInteger("Party Amount Multiplier", 0.01f, 500f, Order = 1, RequireRestart = false)]
        public float PartyAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Party Amount")]
        [SettingPropertyInteger("Minimum Party Amount", 0, 2500, Order = 2, RequireRestart = false)]
        public int MinimumPartyAmount { get; set; } = 1;

        [SettingPropertyGroup("Party Amount")]
        [SettingPropertyInteger("Maximum Party Amount", 0, 2500, Order = 3, RequireRestart = false)]
        public int MaximumPartyAmount { get; set; } = 2500;
    }

    // Companion amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Companion Amount", IsMainToggle = true)]
        [SettingPropertyBool("Companion Amount Enabled", RequireRestart = false)]
        public bool CompanionAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Companion Amount")]
        [SettingPropertyFloatingInteger("Companion Amount Multiplier", 0.01f, 500f, Order = 1, RequireRestart = false)]
        public float CompanionAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Companion Amount")]
        [SettingPropertyInteger("Minimum Companion Amount", 0, 2500, Order = 2, RequireRestart = false)]
        public int MinimumCompanionAmount { get; set; } = 1;

        [SettingPropertyGroup("Companion Amount")]
        [SettingPropertyInteger("Maximum Companion Amount", 0, 2500, Order = 3, RequireRestart = false)]
        public int MaximumCompanionAmount { get; set; } = 2500;
    }

    // Crafting stamina settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> CraftingStaminaAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerOnly),
            new PatchAppliesTo(AppliesToEnum.PlayerCompanions)
        }, 0);

        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyBool("Infinite Crafting Stamina Enabled", Order = 1, RequireRestart = false)]
        public bool InfiniteCraftingStaminaEnabled { get; set; } = false;

        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyBool("Crafting Stamina Amount Enabled", Order = 2, RequireRestart = false)]
        public bool CraftingStaminaAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyFloatingInteger("Crafting Stamina Multiplier", 0.01f, 100f, Order = 3, RequireRestart = false)]
        public float CraftingStaminaMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyInteger("Minimum Crafting Stamina", 0, 10000, Order = 4, RequireRestart = false)]
        public int MinimumCraftingStamina { get; set; } = 50;

        [SettingPropertyGroup("Crafting Stamina")]
        [SettingPropertyInteger("Maximum Crafting Stamina", 0, 10000, Order = 5, RequireRestart = false)]
        public int MaximumCraftingStamina { get; set; } = 10000;
    }

    // Workshop amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Workshop Amount", IsMainToggle = true)]
        [SettingPropertyBool("Workshop Amount Enabled", RequireRestart = false)]
        public bool WorkshopAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Workshop Amount")]
        [SettingPropertyFloatingInteger("Workshop Amount Multiplier", 0.01f, 100f, Order = 1, RequireRestart = false)]
        public float WorkshopAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Workshop Amount")]
        [SettingPropertyInteger("Minimum Workshop Amount", 0, 500, Order = 2, RequireRestart = false)]
        public int MinimumWorkshopAmount { get; set; } = 1;

        [SettingPropertyGroup("Workshop Amount")]
        [SettingPropertyInteger("Maximum Workshop Amount", 0, 500, Order = 3, RequireRestart = false)]
        public int MaximumWorkshopAmount { get; set; } = 500;
    }

    // Hero health amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Hero Health Amount", IsMainToggle = true)]
        [SettingPropertyBool("Hero Health Amount Enabled", RequireRestart = false)]
        public bool HeroHealthAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Hero Health Amount")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> HeroHealthAmountAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerOnly),
            new PatchAppliesTo(AppliesToEnum.PlayerCompanions),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Hero Health Amount")]
        [SettingPropertyFloatingInteger("Hero Health Amount Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float HeroHealthAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Hero Health Amount")]
        [SettingPropertyInteger("Minimum Hero Health Amount", 0, 100000, Order = 2, RequireRestart = false)]
        public int MinimumHeroHealthAmount { get; set; } = 50;

        [SettingPropertyGroup("Hero Health Amount")]
        [SettingPropertyInteger("Maximum Hero Health Amount", 0, 100000, Order = 3, RequireRestart = false)]
        public int MaximumHeroHealthAmount { get; set; } = 100000;
    }

    // Party food consumption settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Party Food Consumption", IsMainToggle = true)]
        [SettingPropertyBool("Party Food Consumption Enabled", RequireRestart = false)]
        public bool PartyFoodConsumptionEnabled { get; set; } = false;

        [SettingPropertyGroup("Party Food Consumption")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> PartyFoodConsumptionAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Party Food Consumption")]
        [SettingPropertyFloatingInteger("Party Food Consumption Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float PartyFoodConsumptionMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Party Food Consumption")]
        [SettingPropertyFloatingInteger("Minimum Party Food Consumption", 0f, 100000f, Order = 2, RequireRestart = false)]
        public float MinimumPartyFoodConsumption { get; set; } = 0f;

        [SettingPropertyGroup("Party Food Consumption")]
        [SettingPropertyFloatingInteger("Maximum Party Food Consumption", 0f, 100000f, Order = 3, RequireRestart = false)]
        public float MaximumPartyFoodConsumption { get; set; } = 100000f;
    }

    // Party troop amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Party Troops", IsMainToggle = true)]
        [SettingPropertyBool("Party Troop Amount Enabled", RequireRestart = false)]
        public bool PartyTroopAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Party Troops")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> PartyTroopAmountAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Party Troops")]
        [SettingPropertyFloatingInteger("Party Troop Amount Multiplier", 0.01f, 1000f, Order = 1, RequireRestart = false)]
        public float PartyTroopAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Party Troops")]
        [SettingPropertyInteger("Minimum Party Troop Amount", 0, 100000, Order = 2, RequireRestart = false)]
        public int MinimumPartyTroopAmount { get; set; } = 10;

        [SettingPropertyGroup("Party Troops")]
        [SettingPropertyInteger("Maximum Party Troop Amount", 0, 100000, Order = 3, RequireRestart = false)]
        public int MaximumPartyTroopAmount { get; set; } = 100000;
    }

    // Party prisoner amount settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Party Prisoners", IsMainToggle = true)]
        [SettingPropertyBool("Party Prisoner Amount Enabled", RequireRestart = false)]
        public bool PartyPrisonerAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Party Prisoners")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<PatchAppliesTo> PartyPrisonerAmountAppliesTo { get; set; } = new DefaultDropdown<PatchAppliesTo>(new[]
        {
            new PatchAppliesTo(AppliesToEnum.PlayerParty),
            new PatchAppliesTo(AppliesToEnum.PlayerClan),
            new PatchAppliesTo(AppliesToEnum.PlayerArmy),
            new PatchAppliesTo(AppliesToEnum.PlayerKingdom),
            new PatchAppliesTo(AppliesToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Party Prisoners")]
        [SettingPropertyFloatingInteger("Party Prisoner Amount Multiplier", 0.01f, 500f, Order = 1, RequireRestart = false)]
        public float PartyPrisonerAmountMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Party Prisoners")]
        [SettingPropertyInteger("Minimum Party Prisoner Amount", 0, 500000, Order = 2, RequireRestart = false)]
        public int MinimumPartyPrisonerAmount { get; set; } = 5;

        [SettingPropertyGroup("Party Prisoners")]
        [SettingPropertyInteger("Maximum Party Prisoner Amount", 0, 500000, Order = 3, RequireRestart = false)]
        public int MaximumPartyPrisonerAmount { get; set; } = 100000;
    }

    // Persuasion chance settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Persuasion", IsMainToggle = true)]
        [SettingPropertyBool("Persuasion Chance Enabled", RequireRestart = false)]
        public bool PersuasionChanceEnabled { get; set; } = false;

        [SettingPropertyGroup("Persuasion")]
        [SettingPropertyFloatingInteger("Success Chance Multiplier", 0.01f, 10f, Order = 0, RequireRestart = false)]
        public float PersuasionSuccessMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Persuasion")]
        [SettingPropertyFloatingInteger("Minimum Success Chance", 0f, 1f, "P", Order = 1, RequireRestart = false)]
        public float MinimumSuccessChance { get; set; } = 0f;

        [SettingPropertyGroup("Persuasion")]
        [SettingPropertyFloatingInteger("Maximum Success Chance", 0f, 1f, "P", Order = 2, RequireRestart = false)]
        public float MaximumSuccessChance { get; set; } = 1f;

        [SettingPropertyGroup("Persuasion")]
        [SettingPropertyFloatingInteger("Critical Success Ratio", 0f, 1f, "P", Order = 3, RequireRestart = false)]
        public float CriticalSuccessChance { get; set; } = 0.33f;

        [SettingPropertyGroup("Persuasion")]
        [SettingPropertyFloatingInteger("Critical Failure Ratio", 0f, 1f, "P", Order = 4, RequireRestart = false)]
        public float CriticalFailureChance { get; set; } = 0.33f;
    }

    // Bartering settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Bartering")]
        [SettingPropertyBool("Barter Always Accepted", Order = 0, RequireRestart = false)]
        public bool BarterAlwaysAccepted { get; set; } = false;

        [SettingPropertyGroup("Bartering")]
        [SettingPropertyBool("Barter Acceptance Enabled", Order = 1, RequireRestart = false)]
        public bool BarterSuccessMultiplierEnabled { get; set; } = false;

        [SettingPropertyGroup("Bartering")]
        [SettingPropertyFloatingInteger("Barter Success Multiplier", 0.01f, 1000f, Order = 2, RequireRestart = false)]
        public float BarterSuccessMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Bartering")]
        [SettingPropertyBool("Barter Cooldown Enabled", Order = 3, RequireRestart = false)]
        public bool BarterCooldownEnabled { get; set; } = false;

        [SettingPropertyGroup("Bartering")]
        [SettingPropertyInteger("Number of Days Between Barters", 0, 120, Order = 4, RequireRestart = false)]
        public int BarterCooldownDays { get; set; } = 3;
    }
}