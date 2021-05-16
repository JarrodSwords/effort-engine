namespace SuperMarioRpg.Domain.Combat
{
    public class MagicEvade : Statistic
    {
        #region Creation

        public MagicEvade(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator MagicEvade(short value) => new(value);

        #endregion
    }
}
