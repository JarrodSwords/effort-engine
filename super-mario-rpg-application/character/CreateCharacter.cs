using Effort.Domain;
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
        internal class Handler : ICommandHandler<CreateCharacter>
        {
            private readonly ICharacterRepository _repository;

            #region Creation

            public Handler(ICharacterRepository repository)
            {
                _repository = repository;
            }

            #endregion

            #region ICommandHandler<CreateCharacter> Implementation

            public void Handle(CreateCharacter command)
            {
                var director = new Director();
                var builder = new NewCharacterBuilder().For(CharacterTypes.Mario);
                director.Configure(builder);

                var character = builder.Build();

                _repository.Create(character);
            }

            #endregion
        }

        #endregion
    }
}
