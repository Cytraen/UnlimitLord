using MCM.Abstractions.Settings.Base;
using System.ComponentModel;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (McmSettings.Instance != null)
                McmSettings.Instance.PropertyChanged += MCMSettings_PropertyChanged;

            Patch.ApplyPatches(McmSettings.Instance);
        }

        private static void MCMSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is McmSettings settings && e.PropertyName == BaseSettings.SaveTriggered)
            {
                Patch.ApplyPatches(settings);
            }
        }
    }
}