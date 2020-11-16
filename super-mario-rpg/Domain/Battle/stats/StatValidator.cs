using FluentValidation;

namespace SuperMarioRpg.Domain.Battle
{
    public class StatValidator : AbstractValidator<Stat>
    {
        #region Core

        public StatValidator()
        {
            RuleFor(x => x.Value).InclusiveBetween(Stat.Min, Stat.Max);
        }

        #endregion
    }
}
