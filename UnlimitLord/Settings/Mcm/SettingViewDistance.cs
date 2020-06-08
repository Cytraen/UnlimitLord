using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
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