using System;

namespace SuperMarioRpg.Domain.Combat
{
    [Flags]
    public enum CharacterTypes
    {
        Bowser = 1,
        Geno = 1 << 1,
        Mallow = 1 << 2,
        Mario = 1 << 3,
        Toadstool = 1 << 4,
        All = Bowser | Geno | Mallow | Mario | Toadstool
    }
}
