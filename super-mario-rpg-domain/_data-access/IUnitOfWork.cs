using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Players;

namespace SuperMarioRpg.Domain
{
    public interface IUnitOfWork
    {
        IEnemyRepository EnemyRepository { get; }
        INonPlayableCharacterRepository NonPlayerCharacterRepository { get; }
        IPlayableCharacterRepository PlayableCharacterRepository { get; }
        IPlayerRepository PlayerRepository { get; }

        void Commit();
    }
}
