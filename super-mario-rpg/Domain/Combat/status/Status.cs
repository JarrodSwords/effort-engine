using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Status : ValueObject
    {
        #region Creation

        public Status(Buffs buffs = Buffs.None)
        {
            Buffs = buffs;
        }

        #endregion

        #region Public Interface

        public Buffs Buffs { get; }

        public static Status Aggregate(params Status[] statuses)
        {
            return statuses.Aggregate((x, y) => x + y);
        }

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Buffs;
        }

        public static Status operator +(Status left, Status right) => new Status(left.Buffs | right.Buffs);

        #endregion
    }
}
