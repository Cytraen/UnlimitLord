/*
 Copyright (C) 2020 ashakoor

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License,
 or any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
        Harmony HarmonyPatcher = new Harmony(HarmonyId);

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
                HarmonyPatcher.UnpatchAll(HarmonyId);

            HarmonyPatcher.PatchAll();
        }
    }
}