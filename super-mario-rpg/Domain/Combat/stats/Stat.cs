using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Combat
{
    public class Stat : TinyType<short>
    {
        #region Core

        public const short Max = 255;
        public const short Min = -255;

        public Stat(short value) : base(value)
        {
            new StatValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Equality, Operators

        public static Stat operator +(Stat addend1, Stat addend2)
        {
            var sum = (short) (addend1.Value + addend2.Value);

            // clamp
            sum = sum < Min ? Min : sum > Max ? Max : sum;

            return new Stat(sum);
        }

        #endregion
    }
}
