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
            if (mobileParty.Leader == null || mobileParty.Leader != CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan != Clan.PlayerClan)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinPartyMorale, McmSettings.Instance.MaxPartyMorale) - result, textObject);
            return explainedNumber.ResultNumber;
        }
    }
}