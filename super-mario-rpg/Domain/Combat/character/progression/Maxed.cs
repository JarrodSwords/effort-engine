using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public record Maxed : Progression
    {
        #region Creation

        public Maxed(Character character) : base(character, Max, CreateXp())
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp) => this;

        #endregion
    }
}
