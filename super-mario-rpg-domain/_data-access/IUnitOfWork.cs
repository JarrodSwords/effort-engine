using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Players;

namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        #region Public Interface

        IEnemyRepository Enemies { get; }
        INonPlayableCharacterRepository NonPlayerCharacters { get; }
        IPlayableCharacterRepository PlayableCharacters { get; }
        IPlayerRepository Players { get; }

        void Commit();

        #endregion
    }
}
