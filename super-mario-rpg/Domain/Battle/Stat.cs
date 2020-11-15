using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Stat : TinyType<short>
    {
        #region Core

        private const short Max = 255;
        private const short Min = -255;

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

        public static Stat operator +(Stat addend1, Stat addend2) => new Stat((short) (addend1.Value + addend2.Value));

        #endregion
    }
}
