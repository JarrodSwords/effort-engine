using System.Collections.Generic;

namespace Effort.Domain
{
    public class Name : TinyType<string>
    {
        #region Creation

        private Name(string value) : base(value)
        {
        }

        public static Name CreateName(string value) => new Name(value);

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToUpper();
        }

        #endregion
    }
}
