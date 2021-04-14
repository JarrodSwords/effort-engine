﻿using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateEnemy(
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

        public static Enemy Build(CreateEnemy builder)
        {
            return builder.Build();
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

        public Guid GetId()
        {
            return default;
        }

        public string GetName()
        {
            return Name;
        }

        public PlayableCharacter.CombatStats GetPlayableCharacterCombatStats()
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Nested Types

        internal class Handler : Handler<CreateEnemy>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(CreateEnemy command)
            {
                UnitOfWork.Enemies.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}