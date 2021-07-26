using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class PlayerCharacter : AggregateRoot
    {
        #region Creation

        public PlayerCharacter(Id id = default) : base(id)
        {
        }

        #endregion
    }
}
