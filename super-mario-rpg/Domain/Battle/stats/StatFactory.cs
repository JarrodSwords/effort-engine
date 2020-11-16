using System;

namespace SuperMarioRpg.Domain.Battle
{
    public class StatFactory
    {
        #region Singleton

        public static StatFactory Instance => new StatFactory();

        #endregion

        #region Core

        private StatFactory()
        {
        }

        #endregion

        #region Public Interface

        public Stats Create(Characters key)
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

        public Stats Create(EquipmentType key)
        {
            var stats = key switch
            {
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
