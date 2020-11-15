using System;

namespace SuperMarioRpg.Domain.Battle
{
    [Flags]
    public enum Characters
    {
        Bowser = 1 << 0,
        Geno = 1 << 1,
        Mallow = 1 << 2,
        Mario = 1 << 3,
        Toadstool = 1 << 4,
        All = Bowser | Geno | Mallow | Mario | Toadstool
    }
}
