using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        #region Public Interface

        CharacterTypes GetCharacterType();
        Id GetId();
        Name GetName();
        Loadout GetLoadout();
        Stats GetNaturalStats();
        Xp GetXp();

        void CreateLoadout();
        void CreateNaturalStats();

        #endregion
    }
}
