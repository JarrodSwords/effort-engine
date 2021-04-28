using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;

namespace SuperMarioRpg.Application.Write.Characters.Enemies
{
    public record Create(
        string Name,
        ushort HitPoints,
        byte FlowerPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade
    ) : ICommand, IEnemyBuilder, IEnemyCombatStatsBuilder
    {
        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.Combatant;
        public Id GetId() => default;
        public Name GetName() => Name;

        #endregion

        #region ICombatStatsBuilder Implementation

        public short GetAttack() => Attack;
        public short GetDefense() => Defense;
        public ushort GetHitPoints() => HitPoints;
        public short GetMagicAttack() => MagicAttack;
        public short GetMagicDefense() => MagicDefense;
        public short GetSpeed() => Speed;

        #endregion

        #region IEnemyBuilder Implementation

        public EnemyCombatStats GetCombatStats() => new(this);

        #endregion

        #region IEnemyCombatStatsBuilder Implementation

        public decimal GetEvade() => Evade;
        public byte GetFlowerPoints() => FlowerPoints;
        public decimal GetMagicEvade() => MagicEvade;

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
                UnitOfWork.Enemies.Create(new Enemy(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
