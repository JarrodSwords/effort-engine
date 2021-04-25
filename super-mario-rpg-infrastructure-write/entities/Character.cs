﻿using System;
using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Configuration;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character : Entity, Domain.Configuration.Character.IBuilder
    {
        #region Creation

        public Character()
        {
        }

        private Character(Domain.Configuration.Character character)
        {
            Name = character.Name;
            Update(character.CharacterTypes);
        }

        private Character(Enemy enemy) : this(enemy as Domain.Configuration.Character)
        {
            CombatStats = enemy.BaseStats;
        }

        private Character(PlayableCharacter playableCharacter) : this(
            playableCharacter as Domain.Configuration.Character
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

        #region IBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            var characterTypes = CharacterTypes.None;

            if (IsCombatant)
                characterTypes |= CharacterTypes.Combatant;

            if (IsPlayable)
                characterTypes |= CharacterTypes.Playable;

            return characterTypes;
        }

        public Enemy.CombatStats GetEnemyCombatStats()
        {
            return new(
                CombatStats.HitPoints,
                CombatStats.FlowerPoints.Value,
                CombatStats.Speed,
                CombatStats.Attack,
                CombatStats.MagicAttack,
                CombatStats.Defense,
                CombatStats.MagicDefense,
                CombatStats.Evade.Value,
                CombatStats.MagicEvade.Value
            );
        }

        public Id GetId()
        {
            return new(Id);
        }

        public Name GetName()
        {
            return Name;
        }

        public PlayableCharacter.CombatStats GetPlayableCharacterCombatStats()
        {
            return new(
                CombatStats.HitPoints,
                CombatStats.Speed,
                CombatStats.Attack,
                CombatStats.MagicAttack,
                CombatStats.Defense,
                CombatStats.MagicDefense
            );
        }

        #endregion

        #region Static Interface

        private static Character AsCharacter(Enemy enemy)
        {
            return enemy;
        }

        private static Character AsCharacter(NonPlayableCharacter nonPlayableCharacter)
        {
            return nonPlayableCharacter;
        }

        private static Character AsCharacter(PlayableCharacter playableCharacter)
        {
            return playableCharacter;
        }

        public static implicit operator Character(Enemy enemy)
        {
            return new(enemy);
        }

        public static implicit operator Character(NonPlayableCharacter nonPlayableCharacter)
        {
            return new(nonPlayableCharacter);
        }

        public static implicit operator Character(PlayableCharacter playableCharacter)
        {
            return new(playableCharacter);
        }

        public static implicit operator PlayableCharacter(Character character)
        {
            return new(character);
        }

        #endregion
    }
}
