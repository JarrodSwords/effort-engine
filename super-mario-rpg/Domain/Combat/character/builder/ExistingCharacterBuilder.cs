using System;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Stats;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class ExistingCharacterBuilder : ICharacterBuilder
    {
        #region Public Interface

        public ExistingCharacterBuilder For(CharacterDto dto)
        {
            Dto = dto;
            return this;
        }

        #endregion

        #region Private Interface

        private CharacterDto Dto { get; set; }

        #endregion

        #region ICharacterBuilder Implementation

        public Equipment Accessory { get; }
        public Equipment Armor { get; }
        public CharacterTypes CharacterType => Dto.CharacterType;
        public Guid Id => Dto.Id;
        public Name Name { get; }

        public Stats NaturalStats { get; private set; }
        public Equipment Weapon { get; }
        public Xp Xp => CreateXp(Dto.Xp);

        public void CreateLoadout()
        {
        }

        public void CreateNaturalStats()
        {
            NaturalStats = CreateStats(
                Dto.Attack,
                Dto.Defense,
                Dto.Hp,
                Dto.SpecialAttack,
                Dto.SpecialDefense,
                Dto.Speed
            );
        }

        #endregion
    }
}
