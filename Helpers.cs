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
            var explainedNumber = new ExplainedNumber(0.0f, explainer);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(ClampInt(toClamp, min, max), textObject);
            return (int)explainedNumber.ResultNumber;
        }

        public static float ClampAndExplainFloat(float toClamp, StatExplainer explainer, float min, float max)
        {
            var explainedNumber = new ExplainedNumber(0.0f, explainer);
            var textObject = new TextObject("UnlimitLord");

            explainedNumber.Add(ClampFloat(toClamp, min, max), textObject);
            return explainedNumber.ResultNumber;
        }
    }
}