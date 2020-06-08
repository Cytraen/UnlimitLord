using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
    internal static class PartySizeLimitOverride
    {
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (party.MobileParty?.IsMainParty == false || party.LeaderHero?.IsHumanPlayerCharacter == false || party.MobileParty?.IsGarrison == true)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(Helpers.ClampInt(result, McmSettings.Instance.MinPartySize, McmSettings.Instance.MaxPartySize) - result, textObject);
            return (int)explainedNumber.ResultNumber;
        }
    }
}