using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

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