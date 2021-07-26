using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write.Characters.Playable
{
    public record UpdateBaseStats(
        string Name,
        short HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand, IStatisticsBuilder
    {
        #region IStatisticsBuilder Implementation

        public Attack GetAttack() => Attack;
        public Defense GetDefense() => Defense;
        public HitPoints GetHitPoints() => HitPoints;
        public MagicAttack GetMagicAttack() => MagicAttack;
        public MagicDefense GetMagicDefense() => MagicDefense;
        public Speed GetSpeed() => Speed;

        #endregion

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
                var playableCharacter = UnitOfWork.PlayableCharacterRepository.Find(command.Name);

                playableCharacter.Statistics = new Statistics(command);

                UnitOfWork.PlayableCharacterRepository.Update(playableCharacter);
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
