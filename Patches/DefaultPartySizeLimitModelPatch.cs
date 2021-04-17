using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace UnlimitLord.Patches
{
    internal static class DefaultPartySizeLimitModelPatch
    {
        private static Settings Setting => Settings.Instance;

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Castle
        {
            private static bool Enabled => Setting.CastleGarrisonSizeEnabled;
            private static AppliesToEnum AppliesTo => Setting.CastleGarrisonSizeAppliesTo.SelectedValue;
            private static float Multiplier => Setting.CastleGarrisonSizeMultiplier;
            private static int Minimum => Setting.MinimumCastleGarrisonSize;
            private static int Maximum => Setting.MaximumCastleGarrisonSize;

            internal static void Postfix(ref ExplainedNumber __result, PartyBase party, bool includeDescriptions = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                if (!party.IsThisPartyGarrison() || !party.DoesPartyBelongToCastle())
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Town
        {
            private static bool Enabled => Setting.TownGarrisonSizeEnabled;
            private static AppliesToEnum AppliesTo => Setting.TownGarrisonSizeAppliesTo.SelectedValue;
            private static float Multiplier => Setting.TownGarrisonSizeMultiplier;
            private static int Minimum => Setting.MinimumTownGarrisonSize;
            private static int Maximum => Setting.MaximumTownGarrisonSize;

            internal static void Postfix(ref ExplainedNumber __result, PartyBase party, bool includeDescriptions = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                if (!party.IsThisPartyGarrison() || !party.DoesPartyBelongToTown())
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Caravan
        {
            private static bool Enabled => Setting.CaravanSizeEnabled;
            private static AppliesToEnum AppliesTo => Setting.CaravanSizeAppliesTo.SelectedValue;
            private static float Multiplier => Setting.CaravanSizeMultiplier;
            private static int Minimum => Setting.MinimumCaravanSize;
            private static int Maximum => Setting.MaximumCaravanSize;

            internal static void Postfix(ref ExplainedNumber __result, PartyBase party, bool includeDescriptions = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                if (!party.IsThisPartyCaravan())
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyMemberSizeLimit")]
        internal static class Troops
        {
            private static bool Enabled => Setting.PartyTroopAmountEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyTroopAmountAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyTroopAmountMultiplier;
            private static int Minimum => Setting.MinimumPartyTroopAmount;
            private static int Maximum => Setting.MaximumPartyTroopAmount;

            internal static void Postfix(ref ExplainedNumber __result, PartyBase party, bool includeDescriptions = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                if (party.IsThisPartyGarrison() || party.IsThisPartyCaravan())
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }

        [HarmonyPatch(typeof(DefaultPartySizeLimitModel), "GetPartyPrisonerSizeLimit")]
        internal static class Prisoners
        {
            private static bool Enabled => Setting.PartyPrisonerAmountEnabled;
            private static AppliesToEnum AppliesTo => Setting.PartyPrisonerAmountAppliesTo.SelectedValue;
            private static float Multiplier => Setting.PartyPrisonerAmountMultiplier;
            private static int Minimum => Setting.MinimumPartyPrisonerAmount;
            private static int Maximum => Setting.MaximumPartyPrisonerAmount;

            internal static void Postfix(ref ExplainedNumber __result, PartyBase party, bool includeDescriptions = false)
            {
                if (!PatchAppliesTo.DoesPatchApply(AppliesTo, party))
                    return;

                if (party.IsThisPartyGarrison())
                    return;

                MathHelper.ClampExplain(ref __result, Multiplier, Minimum, Maximum);
            }

            internal static bool Prepare()
            {
                return Enabled;
            }
        }
    }
}