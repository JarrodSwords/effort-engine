namespace SuperMarioRpg.Domain.Combat
{
    public record Standard : Progression
    {
        #region Creation

        public Standard(Xp xp) : base(xp)
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp)
        {
            var newXp = Xp + xp;
            LevelUp(newXp);

            if (newXp.Value >= Max.Value)
                return new Maxed();

            return new Standard(newXp);
        }

        #endregion
    }
}
