using MCM.Abstractions.Settings.Base.Global;

namespace UnlimitLord.Settings
{
    internal sealed partial class McmSettings : AttributeGlobalSettings<McmSettings>
    {
        public override string Id => "Cytraen.UnlimitLordSettings_v1";
        public override string DisplayName => $"UnlimitLord {typeof(McmSettings).Assembly.GetName().Version.ToString(3)}";
        public override string FolderName => "UnlimitLord";
        public override string Format => "json";
    }
}