using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        #region Core

        public CharacterValidator()
        {
            RuleFor(x => x.NaturalStats).NotNull();

            RuleFor(x => x.Loadout)
                .NotNull()
                .Must((c, l) => l.IsCompatible(c.CharacterType))
                .WithMessage(
                    (c, l) =>
                    {
                        var equipment = string.Join(", ", l.GetIncompatible(c.CharacterType));
                        return $"{c.CharacterType} cannot equip: {equipment}";
                    }
                );

            RuleFor(x => x.EffectiveStats)
                .NotNull()
                .Must(
                    (x, y) => y
                           == x.NaturalStats
                            + x.Loadout.Accessory.Stats
                            + x.Loadout.Armor.Stats
                            + x.Loadout.Weapon.Stats
                );
        }

        #endregion
    }
}
