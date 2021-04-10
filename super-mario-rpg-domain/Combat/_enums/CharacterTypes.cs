using System;

namespace SuperMarioRpg.Domain.Combat
{
    [Flags]
    public enum CharacterTypes
    {
        Enemy = 1,
        NonPlayerCharacter = 1 << 1,
        PlayerCharacter = Bowser | Geno | Mallow | Mario | Toadstool,
        Bowser = 1 << 2,
        Geno = 1 << 3,
        Mallow = 1 << 4,
        Mario = 1 << 5,
        Toadstool = 1 << 6
    }
}
