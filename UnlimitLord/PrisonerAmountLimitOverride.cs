using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal static class PrisonerAmountLimitOverride
    {
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (!party.IsMobile || party.Leader == null || party.Leader != CharacterObject.PlayerCharacter)
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
            explainedNumber.Add(result, textObject);
#if mcmMode
            explainedNumber.Clamp(McmSettings.Instance.MinNumOfPrisoners, McmSettings.Instance.MaxNumOfPrisoners);
#else
            explainedNumber.Clamp(100000f, 100000f);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}