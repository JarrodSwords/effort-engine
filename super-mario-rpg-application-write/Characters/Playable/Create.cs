using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Application.Write.Characters.Playable
{
    public record Create(
        string Name,
        ushort HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand, IPlayableCharacterBuilder, ICombatStatsBuilder
    {
        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.Combatant | CharacterTypes.Playable;
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

        #region IPlayableCharacterBuilder Implementation

        public CombatStats GetCombatStats() => new(this);

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
                UnitOfWork.PlayableCharacters.Create(new PlayableCharacter(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
