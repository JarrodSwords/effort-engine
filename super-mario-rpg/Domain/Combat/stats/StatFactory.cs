using System;

namespace SuperMarioRpg.Domain.Combat
{
    public class StatFactory
    {
        #region Public Interface

        public static Stats CreateStats(CharacterTypes key)
        {
            var stats = key switch
            {
                CharacterTypes.Bowser => Stats.Default,
                CharacterTypes.Geno => Stats.Default,
                CharacterTypes.Mallow => Stats.Create(22, 3, 20, 15, 10, 18),
                CharacterTypes.Mario => Stats.Create(20, 0, 20, 10, 2, 20),
                CharacterTypes.Toadstool => Stats.Default,
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        public static Stats CreateStats(EquipmentType key)
        {
            var stats = key switch
            {
                EquipmentType.None => Stats.Default,
                EquipmentType.Hammer => Stats.Create(10),
                EquipmentType.JumpShoes => Stats.Create(0, 1, 0, 5, 1, 2),
                EquipmentType.Shirt => Stats.Create(0, 6, 0, 0, 6),
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        #endregion
    }
}
