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
                CharacterTypes.Mallow => new Stats(22, 3, 20, 15, 10, 18),
                CharacterTypes.Mario => new Stats(20, 0, 20, 10, 2, 20),
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
                EquipmentType.Hammer => new Stats(10),
                EquipmentType.JumpShoes => new Stats(0, 1, 0, 5, 1, 2),
                EquipmentType.Shirt => new Stats(0, 6, 0, 0, 6),
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        #endregion
    }
}
