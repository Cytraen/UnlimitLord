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
        public DefaultDropdown<WhoToApplyTo> MovementSpeedAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerParty),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerArmy),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Movement Speed Multiplier", 0f, 25f, "###0.00x", Order = 1,
            RequireRestart = false)]
        public float MovementSpeedMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Minimum Speed", 0f, 250f, "###0.00", Order = 2, RequireRestart = false)]
        public float MinimumMovementSpeed { get; set; } = 0f;

        [SettingPropertyGroup("Movement Speed")]
        [SettingPropertyFloatingInteger("Maximum Speed", 0f, 250f, "###0.00", Order = 3, RequireRestart = false)]
        public float MaximumMovementSpeed { get; set; } = 50f;
    }

    // Troop healing settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Troop Healing", IsMainToggle = true)]
        [SettingPropertyBool("Healing Rate Enabled", RequireRestart = false)]
        public bool TroopHealingRateEnabled { get; set; } = false;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<WhoToApplyTo> TroopHealingRateAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerParty),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerArmy),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Troop Healing Rate Multiplier", 0f, 1000f, "###0.00x", Order = 1, RequireRestart = false)]
        public float TroopHealingRateMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Min. Troop Healing Rate", 0f, 1000000f, "###0.00", Order = 2, RequireRestart = false)]
        public float MinimumTroopHealingRate { get; set; } = 0f;

        [SettingPropertyGroup("Troop Healing")]
        [SettingPropertyFloatingInteger("Max. Troop Healing Rate", 0f, 1000000f, "###0.00", Order = 3, RequireRestart = false)]
        public float MaximumTroopHealingRate { get; set; } = 1000000f;
    }

    // Hero healing settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Hero Healing", IsMainToggle = true)]
        [SettingPropertyBool("Healing Rate Enabled", RequireRestart = false)]
        public bool HeroHealingRateEnabled { get; set; } = false;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<WhoToApplyTo> HeroHealingRateAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerParty),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerArmy),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Hero Healing Rate Multiplier", 0f, 1000f, "###0.00x", Order = 1, RequireRestart = false)]
        public float HeroHealingRateMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Min. Hero Healing Rate", 0f, 1000000f, "###0.00", Order = 2, RequireRestart = false)]
        public float MinimumHeroHealingRate { get; set; } = 0f;

        [SettingPropertyGroup("Hero Healing")]
        [SettingPropertyFloatingInteger("Max. Hero Healing Rate", 0f, 1000000f, "###0.00", Order = 3, RequireRestart = false)]
        public float MaximumHeroHealingRate { get; set; } = 1000000f;
    }

    // Morale settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Morale", IsMainToggle = true)]
        [SettingPropertyBool("Morale Enabled", RequireRestart = false)]
        public bool MoraleEnabled { get; set; } = false;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<WhoToApplyTo> MoraleAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerParty),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerArmy),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Morale Multiplier", 0f, 10f, "#0.00x", Order = 1, RequireRestart = false)]
        public float MoraleMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Minimum Morale", 0f, 100f, "##0.00", Order = 2, RequireRestart = false)]
        public float MinimumMorale { get; set; } = 0f;

        [SettingPropertyGroup("Morale")]
        [SettingPropertyFloatingInteger("Maximum Morale", 0f, 100f, "##0.00", Order = 3, RequireRestart = false)]
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
        public DefaultDropdown<WhoToApplyTo> CastleGarrisonSizeAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyFloatingInteger("Castle Garrison Size Multiplier", 0f, 1000f, "###0.00x", Order = 1, RequireRestart = false)]
        public float CastleGarrisonSizeMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyInteger("Minimum Castle Garrison Size", 0, 1000000, "#####00", Order = 2, RequireRestart = false)]
        public int MinimumCastleGarrisonSize { get; set; } = 0;

        [SettingPropertyGroup("Castle Garrison Size")]
        [SettingPropertyInteger("Maximum Castle Garrison Size", 0, 1000000, "#####00", Order = 3, RequireRestart = false)]
        public int MaximumCastleGarrisonSize { get; set; } = 1000000;
    }

    // Town garrison size settings
    internal sealed partial class Settings
    {
        [SettingPropertyGroup("Town Garrison Size", IsMainToggle = true)]
        [SettingPropertyBool("Town Garrison Size Enabled", RequireRestart = false)]
        public bool TownGarrisonSizeEnabled { get; set; } = false;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyDropdown("Who is affected", Order = 0, RequireRestart = false)]
        public DefaultDropdown<WhoToApplyTo> TownGarrisonSizeAppliesTo { get; set; } = new DefaultDropdown<WhoToApplyTo>(new[]
        {
            new WhoToApplyTo(WhoToApplyToEnum.PlayerClan),
            new WhoToApplyTo(WhoToApplyToEnum.PlayerKingdom),
            new WhoToApplyTo(WhoToApplyToEnum.Everyone)
        }, 0);

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyFloatingInteger("Town Garrison Size Multiplier", 0f, 1000f, "###0.00x", Order = 1, RequireRestart = false)]
        public float TownGarrisonSizeMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyInteger("Minimum Town Garrison Size", 0, 1000000, "#####00", Order = 2, RequireRestart = false)]
        public int MinimumTownGarrisonSize { get; set; } = 0;

        [SettingPropertyGroup("Town Garrison Size")]
        [SettingPropertyInteger("Maximum Town Garrison Size", 0, 1000000, "#####00", Order = 3, RequireRestart = false)]
        public int MaximumTownGarrisonSize { get; set; } = 1000000;
    }
}