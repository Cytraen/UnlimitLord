using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings
{
    internal sealed partial class McmSettings
    {
        [SettingPropertyGroup("Player", GroupOrder = 0)]
        public bool PlayerCategory { get; set; }

        //

        [SettingPropertyGroup("Player/Companions", IsMainToggle = true)]
        [SettingPropertyBool("Companion Amount Enabled", RequireRestart = false)]
        public bool CompanionAmountEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Min. Number of Companions", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinNumOfCompanions { get; set; } = 0;

        [SettingPropertyGroup("Player/Companions")]
        [SettingPropertyInteger("Max. Number of Companions", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxNumOfCompanions { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Player/Health", IsMainToggle = true)]
        [SettingPropertyBool("Health Enabled", RequireRestart = false)]
        public bool PlayerHealthEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Min. Health", 0, 1000000, Order = 1, RequireRestart = false)]
        public int MinPlayerHealth { get; set; } = 100;

        [SettingPropertyGroup("Player/Health")]
        [SettingPropertyInteger("Max. Health", 0, 1000000, Order = 2, RequireRestart = false)]
        public int MaxPlayerHealth { get; set; } = 1000000;

        //

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyBool("Change Maximum Smithing Stamina", Order = 1, RequireRestart = false)]
        public bool MaxSmithStaminaEnabled { get; set; } = false;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyInteger("Maximum Smithing Stamina", 0, 10000, Order = 2, RequireRestart = false)]
        public int MaxSmithStaminaAmount { get; set; } = 100;

        [SettingPropertyGroup("Player/Smithing")]
        [SettingPropertyBool("Infinite Smithing Stamina", Order = 3, RequireRestart = false)]
        public bool InfiniteSmithStamina { get; set; } = false;

        //

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