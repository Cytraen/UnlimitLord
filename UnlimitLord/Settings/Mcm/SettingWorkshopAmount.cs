#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Player/Workshop Amount", IsMainToggle = true)]
        [SettingPropertyBool("Workshop Amount Enabled", RequireRestart = false)]
        public bool WorkshopAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Workshop Amount")]
        [SettingPropertyInteger("Min. Number of Workshops", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfWorkshops { get; set; } = 0;

        [SettingPropertyGroup("Player/Workshop Amount")]
        [SettingPropertyInteger("Max. Number of Workshops", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfWorkshops { get; set; } = 1000000;
    }
}

#endif