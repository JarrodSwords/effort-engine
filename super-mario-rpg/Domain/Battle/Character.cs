using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(Guid id = new Guid(), Stats stats = null) : base(id)
        {
            Stats = stats;
        }

        #endregion

        #region Public Interface

        public Stats Stats { get; }

        #endregion
    }
}
