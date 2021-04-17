using HarmonyLib;
using MCM.Abstractions.Settings.Base;
using System.ComponentModel;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace UnlimitLord
{
    internal class SubModule : MBSubModuleBase
    {
        private const string HarmonyId = "com.unlimitlord.patch";
        private readonly Harmony _harmonyPatcher = new Harmony(HarmonyId);

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (Settings.Instance != null)
                Settings.Instance.PropertyChanged += Settings_PropertyChanged;

            Patch();

            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is Settings && e.PropertyName == BaseSettings.SaveTriggered)
            {
                Patch(true);
            }
        }

        private void Patch(bool unPatch = false)
        {
            if (unPatch)
                _harmonyPatcher.UnpatchAll(HarmonyId);

            _harmonyPatcher.PatchAll();
        }
    }
}