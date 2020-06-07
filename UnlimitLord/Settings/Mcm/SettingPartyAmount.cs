#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Clan/Number of Parties", IsMainToggle = true)]
        [SettingPropertyBool("Party Amount Enabled", RequireRestart = false)]
        public bool PartyAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Clan/Number of Parties")]
        [SettingPropertyInteger("Min. Number of Parties", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfParties { get; set; } = 0;

        [SettingPropertyGroup("Clan/Number of Parties")]
        [SettingPropertyInteger("Max. Number of Parties", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfParties { get; set; } = 1000000;
    }
}

#endif