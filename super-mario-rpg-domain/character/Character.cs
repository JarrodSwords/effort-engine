using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public abstract class Character : AggregateRoot
    {
        #region Creation

        protected Character(Guid id, string name) : base(id)
        {
            Name = Name.CreateName(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
