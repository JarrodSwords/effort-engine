using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Application.Write.Characters.Playable
{
    public record Create(
        string Name,
        short HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand, IPlayableCharacterBuilder, IStatisticsBuilder
    {
        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.Combatant | CharacterTypes.Playable;
        public Id GetId() => default;
        public Name GetName() => Name;

        #endregion

        #region IPlayableCharacterBuilder Implementation

        public Statistics GetStatistics() => new(this);

        #endregion

        #region IStatisticsBuilder Implementation

        public Attack GetAttack() => Attack;
        public Defense GetDefense() => Defense;
        public HitPoints GetHitPoints() => HitPoints;
        public MagicAttack GetMagicAttack() => MagicAttack;
        public MagicDefense GetMagicDefense() => MagicDefense;
        public Speed GetSpeed() => Speed;

        #endregion

        internal class Handler : Handler<Create>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(Create command)
            {
                UnitOfWork.PlayableCharacterRepository.Create(new PlayableCharacter(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
