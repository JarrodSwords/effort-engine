using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class CharacterViewModel : ViewModel
    {
        private readonly Character _character;

        #region Creation

        public CharacterViewModel(Character character)
        {
            _character = character;
        }

        #endregion

        #region Public Interface

        public short Hp => _character.EffectiveStats.Hp.Value;
        public byte Level => _character.Progression.CurrentLevel.Value;
        public string Name => _character.Name.Value;

        #endregion
    }
}
