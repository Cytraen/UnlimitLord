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