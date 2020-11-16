using System;

namespace SuperMarioRpg.Domain.Combat
{
    public class StatFactory
    {
        #region Public Interface

        public static Stats Create(Characters key)
        {
            var stats = key switch
            {
                Characters.Bowser => new Stats(20, 0, 20, 10, 2, 20),
                Characters.Geno => new Stats(),
                Characters.Mallow => new Stats(22, 3, 20, 15, 10, 18),
                Characters.Mario => new Stats(),
                Characters.Toadstool => new Stats(),
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        public static Stats Create(EquipmentType key)
        {
            var stats = key switch
            {
                EquipmentType.None => new Stats(),
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
