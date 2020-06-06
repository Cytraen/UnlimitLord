using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace UnlimitLord
{
    // Does not show up in inventory menu, but prevents "cargo within capacity" speed de-buff.
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "GetTotalWeightOfItems")]
    internal static class WeightlessItemsOverridePt1
    {
        public static float Postfix(float result, MobileParty mobileParty)
        {
            if (mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan)
                return 0;
            return result;
        }
    }

    // Does not show in inventory menu, but prevents overburden speed de-buff.
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), "AddCargoStats")]
    internal static class WeightlessItemsOverridePt2
    {
        public static void Postfix(MobileParty mobileParty, ref int numberOfAvailableMounts, ref float totalWeightCarried, ref int herdSize)
        {
            if (mobileParty.Leader == CharacterObject.PlayerCharacter || mobileParty.LeaderHero?.Clan == Clan.PlayerClan)
                totalWeightCarried = 0;
        }
    }
}