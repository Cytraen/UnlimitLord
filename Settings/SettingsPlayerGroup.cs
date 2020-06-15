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
        [SettingPropertyGroup("Player", GroupOrder = 0)]
        public bool PlayerCategory { get; set; }

        //

        [SettingPropertyGroup("Player/Companions", GroupOrder = 0, IsMainToggle = true)]
        [SettingPropertyBool("Companion Amount Enabled", RequireRestart = false)]
        public bool CompanionAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyFloatingInteger("Number of Companions Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float NumOfCompanionsMult { get; set; } = 1f;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Min. Number of Companions", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfCompanions { get; set; } = 0;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Max. Number of Companions", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfCompanions { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Player/Health", GroupOrder = 1, IsMainToggle = true)]
        [SettingPropertyBool("Health Enabled", RequireRestart = false)]
        public bool PlayerHealthEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyFloatingInteger("Health Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float PlayerHealthMult { get; set; } = 1f;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Min. Health", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinPlayerHealth { get; set; } = 100;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Max. Health", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxPlayerHealth { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Player/Smithing", GroupOrder = 2)]
        [SettingPropertyBool("Change Maximum Smithing Stamina", Order = 0, RequireRestart = false)]
        public bool MaxSmithStaminaEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyFloatingInteger("Maximum Smithing Stamina Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float SmithStaminaMult { get; set; } = 1f;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyInteger("Maximum Smithing Stamina", 0, 10000, Order = 1, RequireRestart = false)]
        public int MaxSmithStaminaAmount { get; set; } = 100;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyBool("Infinite Smithing Stamina", Order = 2, RequireRestart = false)]
        public bool InfiniteSmithStamina { get; set; } = false;

        //

        [SettingPropertyGroup("Player/Workshop Amount", GroupOrder = 3, IsMainToggle = true)]
        [SettingPropertyBool("Workshop Amount Enabled", RequireRestart = false)]
        public bool WorkshopAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Workshop Amount")]
        [SettingPropertyFloatingInteger("Number of Workshops Mult", 0f, 1000f, "##00.00x", Order = 0, RequireRestart = false)]
        public float NumOfWorkshopsMult { get; set; } = 1f;

        [SettingPropertyGroup("Player/Workshop Amount")]
        [SettingPropertyInteger("Min. Number of Workshops", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfWorkshops { get; set; } = 0;

        [SettingPropertyGroup("Player/Workshop Amount")]
        [SettingPropertyInteger("Max. Number of Workshops", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfWorkshops { get; set; } = 1000000;
    }
}