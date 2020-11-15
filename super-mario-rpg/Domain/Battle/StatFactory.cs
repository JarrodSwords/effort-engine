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

        public Stats Create(CharacterType key)
        {
            var stats = key switch
            {
                CharacterType.Mario => new Stats(20, 0, 20, 10, 2, 20),
                _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
            };

            return stats;
        }

        #endregion
    }
}
