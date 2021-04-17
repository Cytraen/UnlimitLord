using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    internal static class MathHelper
    {
        internal static float ClampFloat(float value, float minimum, float maximum)
        {
            return value < minimum ? minimum : value > maximum ? maximum : value;
        }

        internal static int ClampInt(int value, int minimum, int maximum)
        {
            return value < minimum ? minimum : value > maximum ? maximum : value;
        }

        internal static void ClampExplain(ref ExplainedNumber __result, float multiplier, int minimum, int maximum)
        {
            __result.AddFactor(multiplier, new TextObject("UnlimitLord"));
            __result.Clamp(minimum, maximum);
        }

        internal static void ClampExplain(ref ExplainedNumber __result, float multiplier, float minimum, float maximum)
        {
            __result.AddFactor(multiplier, new TextObject("UnlimitLord"));
            __result.Clamp(minimum, maximum);
        }
    }
}