using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    internal static class Helpers
    {
        public static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static float ClampAndExplain(float toClamp, StatExplainer explainer, float min, float max)
        {
            var baseTextObject = new TextObject("Total After UL Multiplier");
            var unLimitTextObject = new TextObject("UnlimitLord Clamp");
            var explainedNumber = new ExplainedNumber(toClamp, explainer, baseTextObject);

            explainedNumber.Add(Clamp(toClamp, min, max) - toClamp, unLimitTextObject);
            return explainedNumber.ResultNumber;
        }
    }
}