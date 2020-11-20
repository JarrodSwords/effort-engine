using FluentValidation;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        #region Creation

        public CharacterValidator()
        {
            RuleFor(x => x.Accessory).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Armor).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Weapon).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.NaturalStats).NotNull();
            RuleFor(x => x.EffectiveStats)
                .NotNull()
                .Must((x, y) => y == Aggregate(x.NaturalStats, x.Accessory.Stats, x.Armor.Stats, x.Weapon.Stats));
        }

        #endregion
    }
}
