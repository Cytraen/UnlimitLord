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
        [SettingPropertyBool("Weightless Items", Order = 1, RequireRestart = false)]
        public bool WeightlessItemsEnabled { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool("Party Doesn't Need Food", Order = 2, RequireRestart = false)]
        public bool FoodlessPartyEnabled { get; set; } = false;

        //

        [SettingPropertyGroup("Party/Healing", IsMainToggle = true)]
        [SettingPropertyBool("Party Healing Enabled", RequireRestart = false)]
        public bool PartyHealingEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Min. Troop Healing Rate", 0f, 1000000f, Order = 1, RequireRestart = false)]
        public float MinTroopHealing { get; set; } = 0f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Max. Troop Healing Rate", 0f, 1000000f, Order = 2, RequireRestart = false)]
        public float MaxTroopHealing { get; set; } = 1000000f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Min. Hero Healing Rate", 0f, 1000000f, Order = 3, RequireRestart = false)]
        public float MinHeroHealing { get; set; } = 0f;

        [SettingPropertyGroup("Party/Healing")]
        [SettingPropertyFloatingInteger("Max. Hero Healing Rate", 0f, 1000000f, Order = 4, RequireRestart = false)]
        public float MaxHeroHealing { get; set; } = 1000000f;

        //

        [SettingPropertyGroup("Party/Morale", IsMainToggle = true)]
        [SettingPropertyBool("Party Morale Enabled", RequireRestart = false)]
        public bool PartyMoraleEnabled { get; set; } = false;

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
        [SettingPropertyFloatingInteger("Min. View Distance", 0f, 1000f, Order = 1, RequireRestart = false)]
        public float MinViewDist { get; set; } = 0f;

        [SettingPropertyGroup("Party/View Distance")]
        [SettingPropertyFloatingInteger("Max. View Distance", 0f, 1000f, Order = 2, RequireRestart = false)]
        public float MaxViewDist { get; set; } = 75f;
    }
}