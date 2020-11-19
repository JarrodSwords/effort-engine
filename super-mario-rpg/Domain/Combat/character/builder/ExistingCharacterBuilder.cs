using System;
using System.Collections.Generic;
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

        #region ICharacterBuilder

        public Equipment Accessory { get; }
        public Equipment Armor { get; }
        public CharacterTypes CharacterType => Dto.CharacterType;
        public Guid Id => Dto.Id;

        public ICollection<Level> Levels =>
            new List<Level>
            {
                new Level(1, 0, Default),
                new Level(2, 16, CreateStats(3, 2, 5, 2, 2)),
                new Level(3, 48, CreateStats(3, 2, 5, 2, 2)),
                new Level(4, 84, CreateStats(3, 2, 5, 2, 2))
            };

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
