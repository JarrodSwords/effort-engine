using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Application.Write.Characters.Enemies
{
    public record Create(
        string Name,
        short HitPoints,
        byte FlowerPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade
    ) : ICommand, IEnemyBuilder, IEnemyStatisticsBuilder
    {
        #region Public Interface

        public EnemyStatistics GetStatistics() => new(this);

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.Combatant;
        public Id GetId() => default;
        public Name GetName() => Name;

        #endregion

        #region IEnemyStatisticsBuilder Implementation

        public Evade GetEvade() => Evade;
        public FlowerPoints GetFlowerPoints() => FlowerPoints;
        public MagicEvade GetMagicEvade() => MagicEvade;

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
                UnitOfWork.EnemyRepository.Create(new Enemy(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
