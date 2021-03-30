using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class StatValidator : AbstractValidator<Stat>
    {
        #region Creation

        public StatValidator()
        {
            RuleFor(x => x.Value).InclusiveBetween(Stat.Min, Stat.Max);
        }

        #endregion
    }
}
