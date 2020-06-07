#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Party")]
        [SettingPropertyBool("Weightless Items", Order = 1, RequireRestart = false)]
        public bool WeightlessItemsEnabled { get; set; } = false;

        [SettingPropertyGroup("Party")]
        [SettingPropertyBool("Party Doesn't Need Food", Order = 2, RequireRestart = false)]
        public bool FoodlessPartyEnabled { get; set; } = false;
    }
}

#endif