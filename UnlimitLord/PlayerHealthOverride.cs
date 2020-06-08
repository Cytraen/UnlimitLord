using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;

#if mcmMode
using UnlimitLord.Settings.Mcm;
#endif

namespace UnlimitLord
{
    [HarmonyPatch(typeof(DefaultCharacterStatsModel), "MaxHitpoints")]
    internal static class PlayerHealthOverride
    {
        public static int Postfix(int result, CharacterObject character, StatExplainer explanation)
        {
            if (character != CharacterObject.PlayerCharacter)
                return result;

            var explainedNumber = new ExplainedNumber(result, explanation);
            var textObject = new TextObject("UnlimitLord");

#if mcmMode
            explainedNumber.Add(Helpers.ClampInt(result, McmSettings.Instance.MinPlayerHealth, McmSettings.Instance.MaxPlayerHealth) - result, textObject);
#else
            explainedNumber.Clamp(250, 250);
#endif
            return (int)explainedNumber.ResultNumber;
        }
    }
}