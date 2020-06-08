using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
    internal static class PrisonerAmountLimitOverride
    {
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (!party.IsMobile || party.Leader == null || party.Leader != CharacterObject.PlayerCharacter)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(Helpers.ClampInt(result, McmSettings.Instance.MinNumOfPrisoners, McmSettings.Instance.MaxNumOfPrisoners) - result, textObject);
            return (int)explainedNumber.ResultNumber;
        }
    }
}