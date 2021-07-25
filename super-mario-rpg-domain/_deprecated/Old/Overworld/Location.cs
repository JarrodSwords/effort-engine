﻿namespace SuperMarioRpg.Domain.Old.Overworld
{
    public record Location
    {
        #region Creation

        public Location(string name)
        {
            Name = new(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
