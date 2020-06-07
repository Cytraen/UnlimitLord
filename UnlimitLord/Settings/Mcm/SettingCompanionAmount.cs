#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Player/Companions", IsMainToggle = true)]
        [SettingPropertyBool("Companion Amount Enabled", RequireRestart = false)]
        public bool CompanionAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Min. Number of Companions", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfCompanions { get; set; } = 0;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Max. Number of Companions", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfCompanions { get; set; } = 1000000;
    }
}

#endif