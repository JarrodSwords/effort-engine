using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        #region Core

        public CharacterValidator()
        {
            RuleFor(x => x.Accessory).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Armor).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.Weapon).NotNull().MustBeCompatibleWithCharacter();
            RuleFor(x => x.NaturalStats).NotNull();
            RuleFor(x => x.EffectiveStats)
                .NotNull()
                .Must((x, y) => y == x.NaturalStats + x.Accessory.Stats + x.Armor.Stats + x.Weapon.Stats);
        }

        #endregion
    }
}
