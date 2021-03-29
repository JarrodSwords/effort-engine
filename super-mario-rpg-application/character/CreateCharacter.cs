using Effort.Domain;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application
{
    public record CreateCharacter(string Name) : ICommand
    {
        #region Nested Types

        /// <remarks>
        ///     May belong in its own assembly.
        /// </remarks>
        public record Args(string Name)
        {
        }

        [Log]
        internal class Handler : Handler<CreateCharacter>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(CreateCharacter command)
            {
                var director = new Director();
                var builder = new NewCharacterBuilder().For(CharacterTypes.Mario);
                director.Configure(builder);

                var character = builder.Build();

                UnitOfWork.CharacterRepository.Create(character);
            }

            #endregion
        }

        #endregion
    }
}
