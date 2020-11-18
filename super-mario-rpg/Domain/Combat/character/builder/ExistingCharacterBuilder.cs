using System;
using static SuperMarioRpg.Domain.Combat.Level;
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

        public CharacterTypes CharacterType => Dto.CharacterType;
        public Guid Id => Dto.Id;
        public Level Level => CreateLevel(Dto.Level);
        public Loadout Loadout { get; private set; }
        public Stats NaturalStats { get; private set; }
        public Xp Xp => CreateXp(Dto.Xp);

        public void CreateLoadout()
        {
            Loadout = new Loadout();
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
