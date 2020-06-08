using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal sealed partial class McmSettings
    {
        [SettingPropertyGroup("Clan", GroupOrder = 2)]
        public bool ClanCategory { get; set; }

        //

        [SettingPropertyGroup("Clan/Number of Parties", IsMainToggle = true)]
        [SettingPropertyBool("Party Amount Enabled", RequireRestart = false)]
        public bool PartyAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Clan/Number of Parties")]
        [SettingPropertyFloatingInteger("Number of Parties Multiplier", 0f, 100f, "00.00x", Order = 0, RequireRestart = false)]
        public float NumOfPartiesMult { get; set; } = 1f;

        [SettingPropertyGroup("Clan/Number of Parties")]
        [SettingPropertyInteger("Min. Number of Parties", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfParties { get; set; } = 0;

        [SettingPropertyGroup("Clan/Number of Parties")]
        [SettingPropertyInteger("Max. Number of Parties", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfParties { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Clan/Garrison Size", IsMainToggle = true)]
        [SettingPropertyBool("Garrison Size Enabled", RequireRestart = false)]
        public bool GarrisonSizesEnabled { get; set; } = false;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyFloatingInteger("Castle Garrison Size Multiplier", 0f, 100f, "00.00x", Order = 0, RequireRestart = false)]
        public float CastleGarrisonSizeMult { get; set; } = 1f;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyInteger("Min. Castle Garrison Size", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinCastleGarrisonSize { get; set; } = 0;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyInteger("Max. Castle Garrison Size", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxCastleGarrisonSize { get; set; } = 1000000;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyFloatingInteger("Castle Garrison Size Multiplier", 0f, 100f, "00.00x", Order = 3, RequireRestart = false)]
        public float TownGarrisonSizeMult { get; set; } = 1f;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyInteger("Min. Town Garrison Size", 0, 1000000, Order = 4, RequireRestart = false)]
        public int MinTownGarrisonSize { get; set; } = 0;

        [SettingPropertyGroup("Clan/Garrison Size")]
        [SettingPropertyInteger("Max. Town Garrison Size", 0, 1000000, Order = 5, RequireRestart = false)]
        public int MaxTownGarrisonSize { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Clan/Garrison Wages", IsMainToggle = true)]
        [SettingPropertyBool("Garrison Wages Enabled", RequireRestart = false)]
        public bool GarrisonWageEnabled { get; set; } = false;

        [SettingPropertyGroup("Clan/Garrison Wages")]
        [SettingPropertyFloatingInteger("Garrison Wage Multiplier", 0f, 25f, "00.00x", Order = 0, RequireRestart = false)]
        public float GarrisonWageMultiplier { get; set; } = 1f;

        [SettingPropertyGroup("Clan/Garrison Wages")]
        [SettingPropertyInteger("Min. Wage per Garrison", 0, 100000, Order = 1, RequireRestart = false)]
        public int MinGarrisonWage { get; set; } = 0;

        [SettingPropertyGroup("Clan/Garrison Wages")]
        [SettingPropertyInteger("Min. Wage per Garrison", 0, 100000, Order = 2, RequireRestart = false)]
        public int MaxGarrisonWage { get; set; } = 100000;
    }
}