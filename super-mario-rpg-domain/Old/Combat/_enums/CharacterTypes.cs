using System;

namespace SuperMarioRpg.Domain.Old.Combat
{
    [Flags]
    public enum CharacterTypes
    {
        None = 0,
        Combatant = 1,
        Bowser = 1 << 1,
        Geno = 1 << 2,
        Mallow = 1 << 3,
        Mario = 1 << 4,
        Toadstool = 1 << 5,
        Playable = Bowser | Geno | Mallow | Mario | Toadstool
    }
}
