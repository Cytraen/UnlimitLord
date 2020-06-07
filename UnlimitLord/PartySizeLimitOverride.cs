using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
    internal static class PartySizeLimitOverride
    {

#if !mcmMode

        public static int Postfix(int result, PartyBase party, StatExplainer explanation)
        {
            if (!(party.MobileParty.IsMainParty && party.LeaderHero.IsHumanPlayerCharacter && !party.MobileParty.IsGarrison))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(100000f, 100000f);

            return (int)explainedNumber.ResultNumber;
        }

#endif

#if mcmMode

        public static DynamicMethod Postfix(int result, Clan clan)
        {
            return new DynamicMethod("Patch", typeof(int), new[] { typeof(int), typeof(PartyBase), typeof(StatExplainer) });
        }


        public static int Patch(int result, PartyBase party, StatExplainer explanation)
        {
            if (!(party.MobileParty.IsMainParty && party.LeaderHero.IsHumanPlayerCharacter && !party.MobileParty.IsGarrison))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(McmSettings.Instance.PartySize, McmSettings.Instance.PartySize);

            return (int)explainedNumber.ResultNumber;
        }

#endif

    }
}