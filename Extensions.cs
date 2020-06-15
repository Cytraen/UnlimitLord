/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using TaleWorlds.CampaignSystem;

namespace UnlimitLord
{
    public static class Extensions
    {
        public static bool IsPlayer(this CharacterObject character)
        {
            return character.IsPlayerCharacter;
        }

        public static bool IsPlayer(this Hero hero)
        {
            return hero.IsHumanPlayerCharacter;
        }

        public static bool IsPlayerOwnedParty(this PartyBase party)
        {
            return party.Owner?.IsPlayer() == true;
        }

        public static bool IsPlayerOwnedParty(this MobileParty party)
        {
            return party.Party?.IsPlayerOwnedParty() == true;
        }

        public static bool IsPlayersMainParty(this MobileParty party)
        {
            return party.IsMainParty;
        }

        public static bool IsPlayersMainParty(this PartyBase party)
        {
            return party.MobileParty?.IsPlayersMainParty() == true;
        }

        public static bool IsPlayerClan(this Clan clan)
        {
            return clan == Clan.PlayerClan;
        }

        public static bool IsPlayerClanOwnedParty(this PartyBase party)
        {
            return party.Owner?.Clan?.IsPlayerClan() == true;
        }

        public static bool IsPlayerClanOwnedParty(this MobileParty party)
        {
            return party.Party?.IsPlayerClanOwnedParty() == true;
        }

        public static bool IsPlayerInArmy(this Army army)
        {
            return army.Parties?.Contains(MobileParty.MainParty) == true;
        }

        public static bool IsPlayerLedArmy(this Army army)
        {
            return army.ArmyOwner?.IsHumanPlayerCharacter == true;
        }

        public static bool IsPlayerInKingdom(this Kingdom kingdom)
        {
            return kingdom.Clans?.Contains(Clan.PlayerClan) == true;
        }

        public static bool IsPlayerRuledKingdom(this Kingdom kingdom)
        {
            return kingdom.Leader?.IsPlayer() == true;
        }

        public static bool IsGarrison(this MobileParty party)
        {
            return party.IsGarrison;
        }

        public static bool IsGarrison(this PartyBase party)
        {
            return party.MobileParty?.IsGarrison() == true;
        }

        public static bool PartyBelongsToCastle(this PartyBase party)
        {
            return party.MobileParty?.HomeSettlement?.IsCastle == true;
        }

        public static bool PartyBelongsToTown(this PartyBase party)
        {
            return party.MobileParty?.HomeSettlement?.IsTown == true;
        }
    }
}
