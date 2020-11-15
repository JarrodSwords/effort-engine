using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Character : Entity
    {
        #region Core

        public Character(Guid id = new Guid()) : base(id)
        {
        }

        #endregion
    }
}
