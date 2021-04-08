using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public record Stat : TinyType<short>
    {
        public const short Max = 255;
        public const short Min = -255;

        #region Creation

        public Stat(short value = default) : base(value)
        {
            new StatValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Equality, Operators

        public static Stat operator +(Stat left, Stat right)
        {
            var sum = (short) (left.Value + right.Value);

            // clamp
            sum = sum < Min ? Min : sum > Max ? Max : sum;

            return new(sum);
        }

        #endregion
    }
}
