using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Old.Combat;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Application.Write.Characters.NonPlayable
{
    public record Create(string Name) : ICommand, ICharacterBuilder
    {
        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes() => CharacterTypes.None;
        public Id GetId() => default;
        public Name GetName() => Name;

        #endregion

        [Log]
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
                UnitOfWork.NonPlayerCharacterRepository.Create(new NonPlayableCharacter(command));
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
