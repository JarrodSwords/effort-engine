namespace SuperMarioRpg.Domain.Combat
{
    public class FlowerPoints : Statistic
    {
        #region Creation

        public FlowerPoints(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator FlowerPoints(short value) => new(value);

        #endregion
    }
}
