using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IPlayerCharacterBuilder
    {
        #region Public Interface

        void CreateLoadout();
        void CreateNaturalStats();

        CharacterTypes GetCharacterType();
        Id GetId();
        Loadout GetLoadout();
        Name GetName();
        Stats GetNaturalStats();
        Xp GetXp();

        #endregion
    }
}
