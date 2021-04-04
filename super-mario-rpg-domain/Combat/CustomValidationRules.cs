using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public static class CustomValidationRules
    {
        #region Public Interface

        public static IRuleBuilderOptions<T, Equipment> MustBeCompatibleWithCharacter<T>(
            this IRuleBuilder<T, Equipment> ruleBuilder
        ) where T : PlayerCharacter
        {
            return ruleBuilder
                .Must((x, y) => y.IsCompatible(x.CharacterType))
                .WithMessage((x, y) => $"{x.CharacterType} cannot equip {y}.");
        }

        #endregion
    }
}
