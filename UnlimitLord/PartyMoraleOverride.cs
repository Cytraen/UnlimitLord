using System.Reflection.Emit;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
    internal static class PartyMoraleOverride
    {

#if !mcmMode

        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
        {
            if (!(mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(100f, 100f);

            return explainedNumber.ResultNumber;
        }

#endif

#if mcmMode

        public static DynamicMethod Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
        {
            return new DynamicMethod("Patch", typeof(float), new[] { typeof(float), typeof(MobileParty), typeof(StatExplainer) });
        }

        public static float Patch(float result, MobileParty mobileParty, StatExplainer explanation = null)
        {
            if (!(mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Clamp(McmSettings.Instance.PartyMorale, McmSettings.Instance.PartyMorale);

            return explainedNumber.ResultNumber;
        }

#endif

    }
}