using FluentValidation;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        #region Creation

        public CharacterValidator()
        {
            RuleFor(x => x.Loadout.Accessory).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Loadout.Armor).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Loadout.Weapon).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.NaturalStats).NotNull();
            RuleFor(x => x.EffectiveStats)
                .NotNull()
                .Must((x, y) => y == Aggregate(x.NaturalStats, x.Loadout.GetStats()));
        }

        #endregion
    }
}
