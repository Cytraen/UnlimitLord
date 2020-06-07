using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
    internal static class PartyMoraleOverride
    {
        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
        {
            if (!(mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Add(result);
            explainedNumber.Clamp(McmSettings.Instance.MinPartyMorale, McmSettings.Instance.MaxPartyMorale);
#else
            explainedNumber.Clamp(100f, 100f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}