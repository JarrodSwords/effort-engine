using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public abstract class Character : AggregateRoot
    {
        #region Creation

        protected Character(ICharacterBuilder builder) : base(builder.GetId())
        {
            Name = new Name(builder.GetName());
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
