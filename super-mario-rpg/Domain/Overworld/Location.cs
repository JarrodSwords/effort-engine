﻿using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public class Location : ValueObject<Location>
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

        protected override bool EqualsExplicit(Location other) => Name == other.Name;
        protected override int GetHashCodeExplicit() => Name.GetHashCode();

        #endregion
    }
}
