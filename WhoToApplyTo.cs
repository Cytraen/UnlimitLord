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

using System;
using TaleWorlds.CampaignSystem;

namespace UnlimitLord
{
    public class WhoToApplyTo
    {
        private readonly WhoToApplyToEnum _applyEnum;

        public WhoToApplyTo(WhoToApplyToEnum applyEnum)
        {
            _applyEnum = applyEnum;
        }

        public WhoToApplyToEnum GetWho()
        {
            return _applyEnum;
        }

        public override string ToString()
        {
            switch (_applyEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    return "Player only";

                case WhoToApplyToEnum.PlayerCompanions:
                    return "Player and companions";

                case WhoToApplyToEnum.PlayerParty:
                    return "Player's party";

                case WhoToApplyToEnum.PlayerClan:
                    return "Player's clan";

                case WhoToApplyToEnum.PlayerArmy:
                    return "Player's army";

                case WhoToApplyToEnum.PlayerKingdom:
                    return "Player's kingdom";

                case WhoToApplyToEnum.Everyone:
                    return "Everyone";

                default:
                    throw new NotSupportedException();
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, CharacterObject character)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    return character.IsThisCharacterPlayerCharacter();

                case WhoToApplyToEnum.PlayerCompanions:
                    return character.IsThisCharacterPlayerCompanion();

                case WhoToApplyToEnum.PlayerParty:
                    goto default;

                case WhoToApplyToEnum.PlayerClan:
                    return character.IsThisCharacterInPlayerClan();

                case WhoToApplyToEnum.PlayerArmy:
                    return character.IsThisCharacterInPlayerArmy();

                case WhoToApplyToEnum.PlayerKingdom:
                    return character.IsThisCharacterInPlayerKingdom() || character.IsThisCharacterInPlayerClan();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, Hero hero)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    return hero.IsThisHeroPlayerHero();

                case WhoToApplyToEnum.PlayerCompanions:
                    return hero.IsThisHeroPlayerCompanion();

                case WhoToApplyToEnum.PlayerParty:
                    goto default;

                case WhoToApplyToEnum.PlayerClan:
                    return hero.IsThisHeroInPlayerClan();

                case WhoToApplyToEnum.PlayerArmy:
                    return hero.IsThisHeroInPlayerArmy();

                case WhoToApplyToEnum.PlayerKingdom:
                    return hero.IsThisHeroInPlayerKingdom() || hero.IsThisHeroInPlayerClan();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, MobileParty party)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    goto default;
                case WhoToApplyToEnum.PlayerCompanions:
                    goto default;
                case WhoToApplyToEnum.PlayerParty:
                    return party.IsPlayerLeadingThisParty();

                case WhoToApplyToEnum.PlayerClan:
                    return party.IsThisPartyInPlayerClan();

                case WhoToApplyToEnum.PlayerArmy:
                    return party.IsThisPartyInPlayerArmy() || party.IsPlayerLeadingThisParty();

                case WhoToApplyToEnum.PlayerKingdom:
                    return party.IsThisPartyInPlayerKingdom() || party.IsThisPartyInPlayerClan();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, PartyBase party)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    goto default;
                case WhoToApplyToEnum.PlayerCompanions:
                    goto default;
                case WhoToApplyToEnum.PlayerParty:
                    return party.IsPlayerLeadingThisParty();

                case WhoToApplyToEnum.PlayerClan:
                    return party.IsThisPartyInPlayerClan();

                case WhoToApplyToEnum.PlayerArmy:
                    return party.IsThisPartyInPlayerArmy() || party.IsPlayerLeadingThisParty();

                case WhoToApplyToEnum.PlayerKingdom:
                    return party.IsThisPartyInPlayerKingdom() || party.IsThisPartyInPlayerClan();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, Clan clan)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    goto default;
                case WhoToApplyToEnum.PlayerCompanions:
                    goto default;
                case WhoToApplyToEnum.PlayerParty:
                    goto default;
                case WhoToApplyToEnum.PlayerClan:
                    return clan.IsPlayerLeadingThisClan();

                case WhoToApplyToEnum.PlayerArmy:
                    goto default;
                case WhoToApplyToEnum.PlayerKingdom:
                    return clan.IsThisClanInPlayerKingdom() || clan.IsPlayerLeadingThisClan();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, Army army)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    goto default;
                case WhoToApplyToEnum.PlayerCompanions:
                    goto default;
                case WhoToApplyToEnum.PlayerParty:
                    goto default;
                case WhoToApplyToEnum.PlayerClan:
                    goto default;
                case WhoToApplyToEnum.PlayerArmy:
                    return army.IsPlayerInThisArmy();

                case WhoToApplyToEnum.PlayerKingdom:
                    return army.IsThisArmyInPlayerKingdom();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }

        public static bool DoesPatchApply(WhoToApplyToEnum applyToEnum, Kingdom kingdom)
        {
            switch (applyToEnum)
            {
                case WhoToApplyToEnum.PlayerOnly:
                    goto default;
                case WhoToApplyToEnum.PlayerCompanions:
                    goto default;
                case WhoToApplyToEnum.PlayerParty:
                    goto default;
                case WhoToApplyToEnum.PlayerClan:
                    goto default;
                case WhoToApplyToEnum.PlayerArmy:
                    goto default;
                case WhoToApplyToEnum.PlayerKingdom:
                    return kingdom.IsPlayerInThisKingdom();

                case WhoToApplyToEnum.Everyone:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(applyToEnum), applyToEnum, null);
            }
        }
    }

    public enum WhoToApplyToEnum : byte
    {
        PlayerOnly,
        PlayerCompanions,
        PlayerParty,
        PlayerClan,
        PlayerArmy,
        PlayerKingdom,
        Everyone
    }
}