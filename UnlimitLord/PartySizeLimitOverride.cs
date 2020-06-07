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
            if (!party.MobileParty.IsMainParty || party.LeaderHero?.IsHumanPlayerCharacter == false || party.MobileParty.IsGarrison)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
            explainedNumber.Add(result);
#if mcmMode
            explainedNumber.Clamp(McmSettings.Instance.MinPartySize, McmSettings.Instance.MaxPartySize);
#else
            explainedNumber.Clamp(100000f, 100000f);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}