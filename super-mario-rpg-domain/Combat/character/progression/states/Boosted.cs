namespace SuperMarioRpg.Domain.Combat
{
    public record Boosted : Progression
    {
        #region Creation

        public Boosted(Xp xp) : base(xp)
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp)
        {
            var newXp = Xp + xp + xp;
            LevelUp(newXp);

            if (newXp >= Max)
                return new Maxed();

            return new Boosted(newXp);
        }

        #endregion
    }
}
