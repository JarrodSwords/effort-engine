using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Stat : TinyType<short>
    {
        #region Core

        public const short Max = 255;
        public const short Min = -255;

        private Stat(short value) : base(value)
        {
            new StatValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Public Interface

        public static Stat Create(short value = default) => new Stat(value);

        #endregion

        #region Equality, Operators

        public static Stat operator +(Stat left, Stat right)
        {
            var sum = (short) (left.Value + right.Value);

            // clamp
            sum = sum < Min ? Min : sum > Max ? Max : sum;

            return Create(sum);
        }

        #endregion
    }
}
