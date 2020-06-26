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

using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord.Patches
{
    internal static class BarterManagerPatch
    {
        public static Settings Setting => Settings.Instance;
        public static bool Enabled => Setting.BarterAlwaysAccepted;

        [HarmonyPatch(typeof(BarterManager), "IsOfferAcceptable", typeof(IEnumerable<Barterable>), typeof(Hero), typeof(PartyBase))]
        internal static class BarterGuaranteedPt1
        {
            internal static bool Postfix(bool result)
            {
                return true;
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(BarterManager), "IsOfferAcceptable", typeof(BarterData), typeof(Hero), typeof(PartyBase))]
        internal static class BarterGuaranteedPt2
        {
            internal static bool Postfix(bool result)
            {
                return true;
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}