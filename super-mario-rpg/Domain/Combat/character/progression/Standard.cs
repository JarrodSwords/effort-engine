using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class Standard : Progression
    {
        #region Creation

        public Standard(Character character, Xp xp) : base(character, xp)
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp)
        {
            var newXp = Xp + xp;
            LevelUp(newXp);

            if (newXp.Value >= Max.Value)
                return new Maxed(Character, Max, CreateXp());

            return new Standard(Character, newXp);
        }

        #endregion
    }
}
