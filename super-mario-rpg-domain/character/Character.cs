using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public abstract class Character : AggregateRoot
    {
        #region Creation

        protected Character(Guid id, string name) : base(id)
        {
            Name = new(name);
        }

        protected Character(ICharacterBuilder builder) : this(
            builder.GetId(),
            builder.GetName()
        )
        {
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
