using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Stats;

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

        public short GetAttack()
        {
            return Attack;
        }

        public short GetDefense()
        {
            return Defense;
        }

        public ushort GetHitPoints()
        {
            return HitPoints;
        }

        public short GetMagicAttack()
        {
            return MagicAttack;
        }

        public short GetMagicDefense()
        {
            return MagicDefense;
        }

        public short GetSpeed()
        {
            return Speed;
        }

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
                var playableCharacter = UnitOfWork.PlayableCharacters.Find(command.Name);

                playableCharacter.BaseStats = new CombatStats(command);

                UnitOfWork.PlayableCharacters.Update(playableCharacter);
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
