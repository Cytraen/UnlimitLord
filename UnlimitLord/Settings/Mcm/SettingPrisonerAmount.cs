#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Party/Prisoners", IsMainToggle = true)]
        [SettingPropertyBool("Prisoner Amount Enabled", RequireRestart = false)]
        public bool PrisonerAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Prisoners")]
        [SettingPropertyInteger("Min. Number of Prisoners", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfPrisoners { get; set; } = 0;

        [SettingPropertyGroup("Party/Prisoners")]
        [SettingPropertyInteger("Max. Number of Prisoners", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfPrisoners { get; set; } = 1000000;
    }
}

#endif