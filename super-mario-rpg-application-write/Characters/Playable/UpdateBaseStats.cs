using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write.Characters.Playable
{
    public record UpdateBaseStats(
        string Name,
        ushort HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand, ICombatStatsBuilder
    {
        #region ICombatStatsBuilder Implementation

        public short GetAttack() => Attack;
        public short GetDefense() => Defense;
        public ushort GetHitPoints() => HitPoints;
        public short GetMagicAttack() => MagicAttack;
        public short GetMagicDefense() => MagicDefense;
        public short GetSpeed() => Speed;

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

                playableCharacter.BaseStats = new CombatStats(command);

                UnitOfWork.PlayableCharacterRepository.Update(playableCharacter);
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
