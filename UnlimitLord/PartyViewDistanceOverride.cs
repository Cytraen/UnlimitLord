using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Localization;
using UnlimitLord.Settings.Mcm;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), "GetPartySpottingRange")]
    internal static class PartyViewDistanceOverride
    {
        public static float Postfix(float result, MobileParty party, StatExplainer explainer)
        {
            if (!party.IsMainParty || party.LeaderHero?.IsHumanPlayerCharacter == false || (party.Army != null && party.Army.LeaderParty.Leader != CharacterObject.PlayerCharacter))
                return result;

            var explainedNumber = new ExplainedNumber(result, explainer);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(Helpers.ClampFloat(result, McmSettings.Instance.MinViewDist, McmSettings.Instance.MaxViewDist) - result, textObject);
            return explainedNumber.ResultNumber;
        }
    }
}