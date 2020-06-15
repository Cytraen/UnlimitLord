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

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal sealed partial class McmSettings
    {
        [SettingPropertyGroup("Party", GroupOrder = 1)]
        public bool PartyCategory { get; set; }

        //

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool("Main Party Weightless Items", HintText = "Does not appear in inventory menu but prevents inventory-related speed debuffs.", Order = 0, RequireRestart = false)]
        public bool WeightlessItemsEnabled { get; set; } = false;

        //

        [SettingPropertyGroup("Party/Food")]
        [SettingPropertyBool("Player's Party Doesn't Eat Food", Order = 0, RequireRestart = false)]
        public bool FoodlessPartyEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Food")]
        [SettingPropertyBool("Player's Clan's Parties Don't Eat Food", Order = 1, RequireRestart = false)]
        public bool FoodlessClanEnabled { get; set; } = false;

        //

        [SettingPropertyGroup("Party/Healing", IsMainToggle = true)]
        [SettingPropertyBool("Party Healing Enabled", RequireRestart = false)]
        public bool PartyHealingEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Troop Healing Rate Multiplier", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float TroopHealingMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Min. Troop Healing Rate", 0f, 1000000f, Order = 1, RequireRestart = false)]
        public float MinTroopHealing { get; set; } = 0f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Max. Troop Healing Rate", 0f, 1000000f, Order = 2, RequireRestart = false)]
        public float MaxTroopHealing { get; set; } = 1000000f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Hero Healing Rate Multiplier", 0f, 1000f, "##00.00x", Order = 3, RequireRestart = false)]
        public float HeroHealingMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Min. Hero Healing Rate", 0f, 1000000f, Order = 4, RequireRestart = false)]
        public float MinHeroHealing { get; set; } = 0f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Max. Hero Healing Rate", 0f, 1000000f, Order = 5, RequireRestart = false)]
        public float MaxHeroHealing { get; set; } = 1000000f;

        //

        [SettingPropertyGroup("Party/Morale", IsMainToggle = true)]
        [SettingPropertyBool("Party Morale Enabled", RequireRestart = false)]
        public bool PartyMoraleEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Morale")]
        [SettingPropertyFloatingInteger("Party Morale Mult", 0f, 25f, "##00.00x", Order = 0, RequireRestart = false)]
        public float PartyMoraleMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Morale")]
        [SettingPropertyFloatingInteger("Min. Party Morale", 0f, 100f, Order = 1, RequireRestart = false)]
        public float MinPartyMorale { get; set; } = 0f;

        [SettingPropertyGroup("Party/Morale")]
        [SettingPropertyFloatingInteger("Max. Party Morale", 0f, 100f, Order = 2, RequireRestart = false)]
        public float MaxPartyMorale { get; set; } = 100f;

        //

        [SettingPropertyGroup("Party/Size", IsMainToggle = true)]
        [SettingPropertyBool("Party Size Enabled", RequireRestart = false)]
        public bool PartySizeEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Size")]
        [SettingPropertyFloatingInteger("Party Size Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float PartySizeMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Size")]
        [SettingPropertyInteger("Min. Party Size", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinPartySize { get; set; } = 0;

        [SettingPropertyGroup("Party/Size")]
        [SettingPropertyInteger("Max. Party Size", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxPartySize { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Party/Movement Speed", IsMainToggle = true)]
        [SettingPropertyBool("Party Speed Enabled", RequireRestart = false)]
        public bool PartySpeedEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Movement Speed")]
        [SettingPropertyFloatingInteger("Party Speed Mult", 0f, 25f, "##00.00x", Order = 0, RequireRestart = false)]
        public float PartySpeedMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Movement Speed")]
        [SettingPropertyFloatingInteger("Min. Speed", 0f, 250f, Order = 1, RequireRestart = false)]
        public float MinPartySpeed { get; set; } = 0f;

        [SettingPropertyGroup("Party/Movement Speed")]
        [SettingPropertyFloatingInteger("Max. Speed", 0f, 250f, Order = 2, RequireRestart = false)]
        public float MaxPartySpeed { get; set; } = 50f;

        //

        [SettingPropertyGroup("Party/Prisoners", IsMainToggle = true)]
        [SettingPropertyBool("Prisoner Amount Enabled", RequireRestart = false)]
        public bool PrisonerAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Prisoners")]
        [SettingPropertyFloatingInteger("Number of Prisoners Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float NumOfPrisonersMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/Prisoners")]
        [SettingPropertyInteger("Min. Number of Prisoners", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfPrisoners { get; set; } = 0;

        [SettingPropertyGroup("Party/Prisoners")]
        [SettingPropertyInteger("Max. Number of Prisoners", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfPrisoners { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Party/View Distance", IsMainToggle = true)]
        [SettingPropertyBool("View Distance Enabled", RequireRestart = false)]
        public bool ViewDistEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/View Distance")]
        [SettingPropertyFloatingInteger("View Distance Mult", 0f, 100f, "##00.00x", Order = 0, RequireRestart = false)]
        public float ViewDistMult { get; set; } = 1f;

        [SettingPropertyGroup("Party/View Distance")]
        [SettingPropertyFloatingInteger("Min. View Distance", 0f, 1000f, Order = 1, RequireRestart = false)]
        public float MinViewDist { get; set; } = 0f;

        [SettingPropertyGroup("Party/View Distance")]
        [SettingPropertyFloatingInteger("Max. View Distance", 0f, 1000f, Order = 2, RequireRestart = false)]
        public float MaxViewDist { get; set; } = 75f;

        //

        [SettingPropertyGroup("Party/Party Wages", IsMainToggle = true)]
        [SettingPropertyBool("Party Wages Enabled", RequireRestart = false)]
        public bool TroopWageEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Party Wages")]
        [SettingPropertyBool("Applies to All Parties in Player's Clan", Order = 0, RequireRestart = false)]
        public bool TroopWageAllParties { get; set; } = false;

        [SettingPropertyGroup("Party/Party Wages")]
        [SettingPropertyFloatingInteger("Party Wage Multiplier", 0f, 25f, "##00.00x", Order = 1, RequireRestart = false)]
        public float TroopWageMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Party/Party Wages")]
        [SettingPropertyInteger("Min. Wage per Party", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MinTroopWage { get; set; } = 0;

        [SettingPropertyGroup("Party/Party Wages")]
        [SettingPropertyInteger("Max. Wage per Party", 0, 1000000, Order = 3, RequireRestart = false)]
        public int MaxTroopWage { get; set; } = 1000000;
    }
}