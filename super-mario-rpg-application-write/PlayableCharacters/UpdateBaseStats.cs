using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write.PlayableCharacters
{
    public record UpdateBaseStats(
        string Name,
        ushort HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand
    {
        #region Nested Types

        internal class Handler : Handler<UpdateBaseStats>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(UpdateBaseStats command)
            {
                var (name, hitPoints, speed, attack, magicAttack, defense, magicDefense) = command;
                var baseStats = new PlayableCharacter.CombatStats(
                    hitPoints,
                    speed,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense
                );

                var playableCharacter = UnitOfWork.PlayableCharacters.Find(name);

                playableCharacter.BaseStats = baseStats;

                UnitOfWork.PlayableCharacters.Update(playableCharacter);
                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
