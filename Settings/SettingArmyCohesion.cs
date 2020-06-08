using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Army/Cohesion", IsMainToggle = true)]
        [SettingPropertyBool("Army Cohesion Enabled", RequireRestart = false)]
        public bool ArmyCohesionEnabled { get; set; } = false;

        [SettingPropertyGroup("Army/Cohesion")]
        [SettingPropertyFloatingInteger("Min. Cohesion", 0f, 100f, Order = 1, RequireRestart = false)]
        public float MinCohesion { get; set; } = 0f;

        [SettingPropertyGroup("Army/Cohesion")]
        [SettingPropertyFloatingInteger("Max. Cohesion", 0f, 100f, Order = 2, RequireRestart = false)]
        public float MaxCohesion { get; set; } = 100f;
    }
}