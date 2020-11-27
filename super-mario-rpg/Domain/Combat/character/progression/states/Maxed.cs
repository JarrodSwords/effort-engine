namespace SuperMarioRpg.Domain.Combat
{
    public record Maxed : Progression
    {
        #region Creation

        public Maxed() : base(Max)
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp) => this;

        #endregion
    }
}
