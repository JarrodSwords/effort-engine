using System;

namespace SuperMarioRpg.Domain.Old.Combat
{
    /// <remarks>Highest number is highest priority</remarks>
    [Flags]
    public enum Ailments
    {
        None = 0,
        Silence = 1,
        Sleep = 1 << 1,
        Poison = 1 << 2,
        Fear = 1 << 3,
        Mushroom = 1 << 4,
        Scarecrow = 1 << 5,
        Ko = 1 << 6
    }
}
