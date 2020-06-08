#if mcmMode

using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyBool("Change Maximum Smithing Stamina", Order = 1, RequireRestart = false)]
        public bool MaxSmithStaminaEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyInteger("Maximum Smithing Stamina", 0, 10000, Order = 2, RequireRestart = false)]
        public int MaxSmithStaminaAmount { get; set; } = 100;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyBool("Infinite Smithing Stamina", Order = 3, RequireRestart = false)]
        public bool InfiniteSmithStamina { get; set; } = false;
    }
}

#endif