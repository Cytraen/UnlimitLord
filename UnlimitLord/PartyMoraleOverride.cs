using System.Reflection.Emit;
using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultPartyMoraleModel), "GetEffectivePartyMorale")]
    internal static class PartyMoraleOverride
    {
        public static float Postfix(float result, MobileParty mobileParty, StatExplainer explanation = null)
        {
            if (!(mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan))
                return result;

            var explainedNumber = new ExplainedNumber(0.0f, explanation);

            var textObject = new TextObject("UnlimitLord");
#if mcmMode
            explainedNumber.Clamp(GlobalSettings<McmSettings>.Instance.PartyMorale, McmSettings.Instance.PartyMorale);
#else
            explainedNumber.Clamp(100f, 100f);
#endif
            return explainedNumber.ResultNumber;
        }
    }
}