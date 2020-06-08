using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Army/Movement Speed", IsMainToggle = true)]
        [SettingPropertyBool("Party Speed Enabled", RequireRestart = false)]
        public bool PartySpeedEnabled { get; set; } = false;

        [SettingPropertyGroup("Army/Movement Speed")]
        [SettingPropertyFloatingInteger("Min. Speed", 0f, 250f, Order = 1, RequireRestart = false)]
        public float MinPartySpeed { get; set; } = 0f;

        [SettingPropertyGroup("Army/Movement Speed")]
        [SettingPropertyFloatingInteger("Max. Speed", 0f, 250f, Order = 2, RequireRestart = false)]
        public float MaxPartySpeed { get; set; } = 250f;
    }
}