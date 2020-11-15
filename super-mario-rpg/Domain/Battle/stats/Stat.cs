using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Stat : TinyType<short>
    {
        #region Core

        public const short Max = 255;
        public const short Min = -255;

        public Stat(short value) : base(value)
        {
            if (value > Max)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"\"{nameof(Stat)}\" cannot be greater than {Max}."
                );

            if (value < Min)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    $"\"{nameof(Stat)}\" cannot be less than {Min}."
                );
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
