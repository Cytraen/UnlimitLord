using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Localization;
using UnlimitLord.Settings.Mcm;

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

            explainedNumber.Add(Helpers.ClampInt(result, McmSettings.Instance.MinPlayerHealth, McmSettings.Instance.MaxPlayerHealth) - result, textObject);
            return (int)explainedNumber.ResultNumber;
        }
    }
}