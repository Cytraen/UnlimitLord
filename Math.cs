/*
 Copyright (C) 2020 ashakoor

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License,
 or any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

namespace UnlimitLord
{
    internal static class Math
    {
        internal static float ClampFloat(float value, float minimum, float maximum)
        {
            return value < minimum ? minimum : value > maximum ? maximum : value;
        }

        internal static int ClampInt(int value, int minimum, int maximum)
        {
            return value < minimum ? minimum : value > maximum ? maximum : value;
        }

        internal static float ClampAndExplainFloat(float toClamp, StatExplainer explain, float minimum, float maximum)
        {
            var baseTextObject = new TextObject("{=2bAElQ6l7ita}Total after UL multiplier");
            var unLimitTextObject = new TextObject("{=yLa9PdHUZB6l}UnlimitLord clamp");
            var explainedNumber = new ExplainedNumber(toClamp, explain, baseTextObject);

            explainedNumber.Add(ClampFloat(toClamp, minimum, maximum) - toClamp, unLimitTextObject);
            return explainedNumber.ResultNumber;
        }

        internal static int ClampAndExplainInt(int toClamp, StatExplainer explain, int minimum, int maximum)
        {
            var baseTextObject = new TextObject("{=2bAElQ6l7ita}Total after UL multiplier");
            var unLimitTextObject = new TextObject("{=yLa9PdHUZB6l}UnlimitLord clamp");
            var explainedNumber = new ExplainedNumber(toClamp, explain, baseTextObject);

            explainedNumber.Add(ClampInt(toClamp, minimum, maximum) - toClamp, unLimitTextObject);
            return (int)explainedNumber.ResultNumber;
        }
    }
}