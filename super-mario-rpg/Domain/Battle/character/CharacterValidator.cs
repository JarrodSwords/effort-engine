using FluentValidation;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterValidator : AbstractValidator<Character>
    {
        #region Core

        public CharacterValidator()
        {
            RuleFor(x => x.NaturalStats).NotNull();

            RuleFor(x => x.Loadout)
                .NotNull()
                .Must((character, loadout) => loadout.IsCompatible(character.CharacterType));

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
