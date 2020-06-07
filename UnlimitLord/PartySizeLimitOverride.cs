using System.Reflection.Emit;
using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
    internal static class PartySizeLimitOverride
    {
        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (!(party.MobileParty.IsMainParty && party.LeaderHero.IsHumanPlayerCharacter && !party.MobileParty.IsGarrison))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Clamp(GlobalSettings<McmSettings>.Instance.PartySize, McmSettings.Instance.PartySize);
#else
            explainedNumber.Clamp(100000f, 100000f);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}