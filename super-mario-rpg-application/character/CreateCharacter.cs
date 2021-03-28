using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public record CreateCharacter(string Name) : ICommand
    {
        #region Nested Types

        [Logged]
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
