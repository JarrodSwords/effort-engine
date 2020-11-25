using System;

namespace SuperMarioRpg.Domain.Combat
{
    [Flags]
    public enum Elements
    {
        None = 0,
        Fire = 1,
        Ice = 1 << 1,
        Jump = 1 << 2,
        Lightning = 1 << 3,
        All = Fire | Ice | Jump | Lightning
    }
}
