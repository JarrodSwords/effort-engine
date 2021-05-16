namespace SuperMarioRpg.Domain.Combat
{
    public class HitPoints : Statistic
    {
        #region Creation

        public HitPoints(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator HitPoints(short value) => new(value);

        #endregion
    }
}
