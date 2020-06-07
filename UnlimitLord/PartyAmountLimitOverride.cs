using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    internal static class PartyAmountLimitOverride
    {
        public static int Postfix(int result, Clan clan)
        {
#if mcmMode
            if (clan.Leader?.IsHumanPlayerCharacter == false) return result;
            if (result > McmSettings.Instance.MaxNumOfParties) return McmSettings.Instance.MaxNumOfParties;
            if (result < McmSettings.Instance.MinNumOfParties) return McmSettings.Instance.MinNumOfParties;
            return result;
#else
            return clan.Leader.IsHumanPlayerCharacter ? 100000 : result;
#endif
        }
    }
}