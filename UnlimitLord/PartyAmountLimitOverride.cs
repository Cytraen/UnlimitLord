using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal static class PartyAmountLimitOverride
    {

#if !mcmMode

        public static int Postfix(int result, Clan clan)
        {
            return clan.Leader.IsHumanPlayerCharacter ? 100000 : result;
        }

#endif

#if mcmMode

        public static DynamicMethod Postfix(int result, Clan clan)
        {
            return new DynamicMethod("Patch", typeof(int), new [] { typeof(int), typeof(Clan) });
        }

        public static int Patch(int result, Clan clan)
        {
            return clan.Leader.IsHumanPlayerCharacter ? McmSettings.Instance.NumOfParties : result;
        }

#endif

    }
}