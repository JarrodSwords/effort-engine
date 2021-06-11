using System;
using Effort.Domain;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;
using SuperMarioRpg.Domain.Overworld;
using ICharacterBuilder = SuperMarioRpg.Domain.Combat.ICharacterBuilder;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character : Entity, ICharacterBuilder, IPlayableCharacterBuilder
    {
        #region Creation

        public Character()
        {
        }

        private Character(Domain.Combat.Character character)
        {
            Name = character.Name;
            Update(character.CharacterTypes);
        }

        private Character(Enemy enemy) : this(enemy as Domain.Combat.Character)
        {
            Statistics = enemy.Statistics;
        }

        private Character(PlayableCharacter playableCharacter) : this(
            playableCharacter as Domain.Combat.Character
        )
        {
            Statistics = playableCharacter.Statistics;
        }

        private Character(NonPlayableCharacter nonPlayableCharacter)
        {
            Name = nonPlayableCharacter.Name;
            Update(nonPlayableCharacter.CharacterTypes);
        }

        #endregion

        #region Public Interface

        public bool IsCombatant { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }
        public Statistics Statistics { get; set; }
        public Guid? StatisticsId { get; set; }

        #endregion

        #region Private Interface

        private Character Update(PlayableCharacter playableCharacter)
        {
            Statistics.Update(playableCharacter.Statistics);
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

        public Id GetId() => new(Id);
        public Name GetName() => Name;

        #endregion

        #region IPlayableCharacterBuilder Implementation

        public Domain.Statistics GetStatistics() => Statistics;

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
