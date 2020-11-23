using System;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Combat
{
    public class StatFactory
    {
        #region Creation

        public static Stats CreateStats(CharacterTypes key)
        {
            var stats = key switch
            {
                CharacterTypes.Bowser => Default,
                CharacterTypes.Geno => Default,
                CharacterTypes.Mallow => Stats.CreateStats(22, 3, 20, 15, 10, 18),
                CharacterTypes.Mario => Stats.CreateStats(20, 0, 20, 10, 2, 20),
                CharacterTypes.Toadstool => Default,
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        public static Stats CreateStats(EquipmentType key)
        {
            var stats = key switch
            {
                EquipmentType.None => Default,
                EquipmentType.Hammer => Stats.CreateStats(10),
                EquipmentType.JumpShoes => Stats.CreateStats(0, 1, 0, 5, 1, 2),
                EquipmentType.PolkaDress => Stats.CreateStats(defense: 24, specialDefense: 12),
                EquipmentType.Shirt => Stats.CreateStats(0, 6, 0, 0, 6),
                EquipmentType.SlapGlove => Stats.CreateStats(40),
                _ => Default
            };

            return stats;
        }

        #endregion
    }
}
