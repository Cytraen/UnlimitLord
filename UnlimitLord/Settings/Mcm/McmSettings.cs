using MCM.Abstractions.Attributes;
using MCM.Abstractions.Settings.Base.Global;

namespace UnlimitLord.Settings.Mcm
{
    internal sealed partial class McmSettings : AttributeGlobalSettings<McmSettings>
    {
        public override string Id => "Cytraen.UnlimitLordSettings_v1";
        public override string DisplayName => $"UnlimitLord {typeof(McmSettings).Assembly.GetName().Version.ToString(3)}";
        public override string FolderName => "UnlimitLord";
        public override string Format => "json";

        [SettingPropertyGroup("Player", GroupOrder = 0)]
        public bool PlayerCategory { get; set; }

        [SettingPropertyGroup("Party", GroupOrder = 1)]
        public bool PartyCategory { get; set; }

        [SettingPropertyGroup("Clan", GroupOrder = 2)]
        public bool ClanCategory { get; set; }

        [SettingPropertyGroup("Army", GroupOrder = 3)]
        public bool ArmyCategory { get; set; }
    }
}