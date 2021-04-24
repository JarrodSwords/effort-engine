using System;
using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

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
    ) : ICommand, Character.IBuilder
    {
        #region Public Interface

        public PlayableCharacter Build()
        {
            return new(this);
        }

        public static PlayableCharacter Build(Create builder)
        {
            return builder.Build();
        }

        #endregion

        #region IBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.Combatant | CharacterTypes.Playable;
        }

        public Enemy.CombatStats GetEnemyCombatStats()
        {
            throw new NotSupportedException();
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
            return new(HitPoints, Speed, Attack, MagicAttack, Defense, MagicDefense);
        }

        #endregion

        #region Nested Types

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
                UnitOfWork.PlayableCharacters.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
