using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;

namespace UnlimitLord.Settings.Mcm
{
    internal partial class McmSettings
    {
        [SettingPropertyGroup("Party/Morale", IsMainToggle = true)]
        [SettingPropertyBool("Party Morale Enabled", RequireRestart = false)]
        public bool PartyMoraleEnabled { get; set; } = false;

        [SettingPropertyGroup("Party/Morale")]
        [SettingPropertyFloatingInteger("Min. Party Morale", 0f, 100f, Order = 1, RequireRestart = false)]
        public float MinPartyMorale { get; set; } = 0f;

        [SettingPropertyGroup("Party/Morale")]
        [SettingPropertyFloatingInteger("Max. Party Morale", 0f, 100f, Order = 2, RequireRestart = false)]
        public float MaxPartyMorale { get; set; } = 100f;
    }
}