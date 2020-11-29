using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class StatsViewModel : ViewModel
    {
        private readonly Character _character;

        #region Creation

        public StatsViewModel(Character character)
        {
            _character = character;
        }

        #endregion

        #region Public Interface

        public short EffectiveAttack => _character.EffectiveStats.Attack.Value;
        public short EffectiveDefense => _character.EffectiveStats.Defense.Value;
        public short EffectiveMagicAttack => _character.EffectiveStats.SpecialAttack.Value;
        public short EffectiveMagicDefense => _character.EffectiveStats.SpecialDefense.Value;
        public short EffectiveSpeed => _character.EffectiveStats.Speed.Value;
        public short NaturalAttack => _character.NaturalStats.Attack.Value;
        public short NaturalDefense => _character.NaturalStats.Defense.Value;
        public short NaturalMagicAttack => _character.NaturalStats.SpecialAttack.Value;
        public short NaturalMagicDefense => _character.NaturalStats.SpecialDefense.Value;
        public short NaturalSpeed => _character.NaturalStats.Speed.Value;
        public ushort NextLevelAt => _character.Progression.ToNext.Value;
        public ushort Xp => _character.Progression.Xp.Value;

        #endregion
    }
}
