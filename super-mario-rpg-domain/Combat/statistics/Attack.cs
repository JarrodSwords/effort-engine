namespace SuperMarioRpg.Domain.Combat
{
    public class Attack : Statistic
    {
        #region Creation

        public Attack(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Attack(short value) => new(value);

        #endregion
    }
}
