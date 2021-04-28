﻿using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character : Entity, ICharacterBuilder
    {
        #region Creation

        public Character()
        {
        }

        private Character(Domain.Characters.Character character)
        {
            Name = character.Name;
            Update(character.CharacterTypes);
        }

        private Character(Enemy enemy) : this(enemy as Domain.Characters.Character)
        {
            CombatStats = enemy.BaseStats;
        }

        private Character(PlayableCharacter playableCharacter) : this(
            playableCharacter as Domain.Characters.Character
        )
        {
            CombatStats = playableCharacter.BaseStats;
        }

        #endregion

        #region Public Interface

        public CombatStats CombatStats { get; set; }
        public Guid? CombatStatsId { get; set; }
        public bool IsCombatant { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }

        #endregion

        #region Private Interface

        private Character Update(PlayableCharacter playableCharacter)
        {
            CombatStats.Update(playableCharacter.BaseStats);
            return this;
        }

        private Character Update(CharacterTypes characterTypes)
        {
            IsCombatant = characterTypes.Contains(CharacterTypes.Combatant);
            IsPlayable = characterTypes.Contains(CharacterTypes.Playable);

            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            var characterTypes = CharacterTypes.None;

            if (IsCombatant)
                characterTypes |= CharacterTypes.Combatant;

            if (IsPlayable)
                characterTypes |= CharacterTypes.Playable;

            return characterTypes;
        }

        public Domain.Stats.CombatStats GetCombatStats() => CombatStats;
        public EnemyCombatStats GetEnemyCombatStats() => CombatStats;
        public Id GetId() => new(Id);
        public Name GetName() => Name;

        #endregion

        #region Static Interface

        private static Character AsCharacter(Enemy enemy) => enemy;
        private static Character AsCharacter(NonPlayableCharacter nonPlayableCharacter) => nonPlayableCharacter;
        private static Character AsCharacter(PlayableCharacter playableCharacter) => playableCharacter;
        public static implicit operator Character(Enemy enemy) => new(enemy);

        public static implicit operator Character(NonPlayableCharacter nonPlayableCharacter) =>
            new(nonPlayableCharacter);

        public static implicit operator Character(PlayableCharacter playableCharacter) => new(playableCharacter);
        public static implicit operator PlayableCharacter(Character character) => new(character);

        #endregion
    }
}
