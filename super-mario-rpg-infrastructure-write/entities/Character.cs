using System;
using Effort.Domain;
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
            Name = character.Name;
            SetCharacterTypes(character.CharacterTypes);
        }

        #endregion

        #region Public Interface

        public CombatStats CombatStats { get; set; }
        public Guid? CombatStatsId { get; set; }
        public bool IsCombatant { get; set; }
        public bool IsPlayable { get; set; }
        public string Name { get; set; }

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

        public Name GetName()
        {
            return (Name) Name;
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
