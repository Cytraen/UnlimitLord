using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal partial class McmSettings
    {
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
    }
}