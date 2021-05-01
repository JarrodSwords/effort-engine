using FluentValidation;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public class StatValidator : AbstractValidator<Stat>
    {
        #region Creation

        public StatValidator()
        {
            RuleFor(x => (short) x).InclusiveBetween(Stat.Min, Stat.Max);
        }

        #endregion
    }
}
