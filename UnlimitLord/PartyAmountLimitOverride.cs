using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal static class PartyAmountLimitOverride
    {
        public static int Postfix(int result, Clan clan)
        {
#if mcmMode
            return clan.Leader.IsHumanPlayerCharacter ? GlobalSettings<McmSettings>.Instance.NumOfParties : result;
#else
            return clan.Leader.IsHumanPlayerCharacter ? 100000 : result;
#endif
        }
    }
}