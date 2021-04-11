using System;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character : Entity
    {
        #region Creation

        public Character()
        {
        }

        public Character(Domain.Character character)
        {
            Name = character.Name.Value;
            SetCharacterTypes(character.CharacterTypes);
        }

        public Character(Enemy enemy) : this(enemy as Domain.Character)
        {
            CombatStats = CombatStats.From(enemy.BaseStats);
        }

        public Character(PlayableCharacter playableCharacter) : this(playableCharacter as Domain.Character)
        {
            CombatStats = CombatStats.From(playableCharacter.BaseStats);
        }

        #endregion

        #region Public Interface

        public CombatStats CombatStats { get; set; }
        public Guid? CombatStatsId { get; set; }
        public bool IsCombatant { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }

        public static Character From(Enemy enemy)
        {
            return new(enemy);
        }

        public static Character From(NonPlayerCharacter nonPlayerCharacter)
        {
            return new(nonPlayerCharacter);
        }

        public static Character From(PlayableCharacter playableCharacter)
        {
            return new(playableCharacter);
        }

        public Character SetCharacterTypes(CharacterTypes characterTypes)
        {
            IsCombatant = characterTypes.Contains(CharacterTypes.Combatant);
            IsPlayable = characterTypes.Contains(CharacterTypes.Playable);

            return this;
        }

        #endregion
    }
}
