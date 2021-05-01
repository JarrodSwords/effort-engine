using System;

namespace SuperMarioRpg.Domain.Old.Combat
{
    [Flags]
    public enum Buffs
    {
        None = 0,
        AttackUp = 1,
        DefenseUp = 1 << 1,
        DoubleCoins = 1 << 2,
        DoubleXp = 1 << 3,
        HalveFpCost = 1 << 4,
        Invincible = 1 << 5,
        Lucky = 1 << 6,
        OnceAgain = 1 << 7,
        RevealHiddenChests = 1 << 8
    }
}
