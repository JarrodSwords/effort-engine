using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public class Location : ValueObject
    {
        #region Creation

        public Location(string name)
        {
            Name = Name.CreateName(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        #endregion
    }
}
