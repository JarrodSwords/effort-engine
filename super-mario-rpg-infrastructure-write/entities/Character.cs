using System;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character : Entity, Domain.Character.IBuilder
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

        public PlayableCharacter BuildPlayableCharacter()
        {
            return new(this);
        }

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

        public Guid GetId()
        {
            return Id;
        }

        public string GetName()
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
    }
}
