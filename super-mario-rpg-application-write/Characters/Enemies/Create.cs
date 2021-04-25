using System;
using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

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
    ) : ICommand, Character.IBuilder
    {
        #region Public Interface

        public Enemy Build()
        {
            return new(this);
        }

        #endregion

        #region IBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.Combatant;
        }

        public Enemy.CombatStats GetEnemyCombatStats()
        {
            return new(
                HitPoints,
                FlowerPoints,
                Speed,
                Attack,
                MagicAttack,
                Defense,
                MagicDefense,
                Evade,
                MagicEvade
            );
        }

        public Id GetId()
        {
            return default;
        }

        public Name GetName()
        {
            return Name;
        }

        public PlayableCharacter.CombatStats GetPlayableCharacterCombatStats()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Static Interface

        public static Enemy Build(Create builder)
        {
            return builder.Build();
        }

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
                UnitOfWork.Enemies.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
