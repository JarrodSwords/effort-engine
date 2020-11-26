namespace SuperMarioRpg.Domain.Combat
{
    public record Boosted : Progression
    {
        #region Creation

        public Boosted(Character character) : base(character)
        {
        }

        public Boosted(Character character, Xp xp) : base(character, xp)
        {
        }

        public static Progression CreateProgression(Character character)
        {
            if (character.Progression.Xp == Max)
                return new Maxed(character);

            return new Boosted(character);
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp)
        {
            var newXp = Xp + xp + xp;
            LevelUp(newXp);
            return new Boosted(Character, newXp);
        }

        #endregion
    }
}
