/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using MCM.Abstractions.Settings.Base;
using System.ComponentModel;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    internal class UnlimitLordSubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (McmSettings.Instance != null)
                McmSettings.Instance.PropertyChanged += MCMSettings_PropertyChanged;

            Patch.ApplyPatches(McmSettings.Instance);

            InformationManager.DisplayMessage(new InformationMessage("UnlimitLord loaded!"));
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