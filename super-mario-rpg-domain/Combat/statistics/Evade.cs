namespace SuperMarioRpg.Domain.Combat
{
    public class Evade : Statistic
    {
        #region Creation

        public Evade(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Evade(short value) => new(value);

        #endregion
    }
}
