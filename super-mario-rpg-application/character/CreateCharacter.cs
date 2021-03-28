using Effort.Domain;

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
        public class CreateCharacterHandler : ICommandHandler<CreateCharacter>
        {
            #region ICommandHandler<CreateCharacter> Implementation

            public void Handle(CreateCharacter command)
            {
            }

            #endregion
        }

        #endregion
    }
}
