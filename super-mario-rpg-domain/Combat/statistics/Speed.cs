namespace SuperMarioRpg.Domain.Combat
{
    public class Speed : Statistic
    {
        #region Creation

        public Speed(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Speed(short value) => new(value);

        #endregion
    }
}
