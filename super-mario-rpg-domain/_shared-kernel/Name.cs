using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public class Name : TinyType<string>
    {
        #region Creation

        public Name(string value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Name(string name) => new(name);
        public static implicit operator string(Name name) => name.Value;

        #endregion
    }
}
