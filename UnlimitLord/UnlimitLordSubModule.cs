using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("com.unlimitLord.patch").PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
        }
    }
}