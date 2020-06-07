using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

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

#if mcmMode
            explainedNumber.Add(Helpers.ClampInt(result, McmSettings.Instance.MinPartySize, McmSettings.Instance.MaxPartySize) - result, textObject);
#else
            explainedNumber.Clamp(100000f, 100000f);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}