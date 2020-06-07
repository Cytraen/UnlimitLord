#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Party/Size", IsMainToggle = true)]
        [SettingPropertyBool("Party Size Enabled", RequireRestart = false)]
        public bool PartySizeEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Size")]
        [SettingPropertyInteger("Min. Party Size", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinPartySize { get; set; } = 0;

        [SettingPropertyGroup("Party/Size")]
        [SettingPropertyInteger("Max. Party Size", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxPartySize { get; set; } = 1000000;
    }
}

#endif