using System;
using Effort.Domain;
using FluentValidation;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public class Stat : TinyType<short>
    {
        public const short Max = 255;
        public const short Min = -255;

        #region Creation

        public Stat(short value = default) : base(value)
        {
            new StatValidator().ValidateAndThrow(this);
        }

        #endregion

        #region Static Interface

        public static Stat operator +(Stat left, Stat right)
        {
            var sum = (short) Math.Clamp(left.Value + right.Value, Min, Max);

            return new(sum);
        }

        #endregion
    }
}
