using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Player/Health", IsMainToggle = true)]
        [SettingPropertyBool("Health Enabled", RequireRestart = false)]
        public bool PlayerHealthEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Min. Health", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinPlayerHealth { get; set; } = 100;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Max. Health", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxPlayerHealth { get; set; } = 1000000;
    }
}