using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using UnlimitLord.Settings;

namespace UnlimitLord
{
    internal static class Helpers
    {
        public static int ClampInt(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static float ClampFloat(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static int ClampAndExplainInt(int toClamp, StatExplainer explainer, int min, int max)
        {
            var explainedNumber = new ExplainedNumber(toClamp, explainer);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(ClampInt(toClamp, min, max) - toClamp, textObject);
            return (int)explainedNumber.ResultNumber;
        }

        public static float ClampAndExplainFloat(float toClamp, StatExplainer explainer, float min, float max)
        {
            var explainedNumber = new ExplainedNumber(toClamp, explainer);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(ClampFloat(toClamp, min, max) - toClamp, textObject);
            return explainedNumber.ResultNumber;
        }

        // MobileParty.MainParty = player party
        // Hero.MainHero = player
        // hero.IsHumanPlayerCharacter = player
        // CharacterObject.PlayerCharacter = player
        // presumably also PartyBase.MainParty = player party

        // if (mobileParty.Army == null && mobileParty.IsActive && mobileParty.IsMainParty && mobileParty.Leader == CharacterObject.PlayerCharacter) { }
    }
}