using System.Collections.Generic;
using static SuperMarioRpg.Domain.Combat.Stats;

namespace SuperMarioRpg.Domain.Combat
{
    public record Level
    {
        public static LinkedList<Level> Levels =
            new(
                new[]
                {
                    new Level(1, 0, Default),
                    new Level(2, 16, CreateStats(3, 2, 5, 2, 2)),
                    new Level(3, 48, CreateStats(3, 2, 5, 2, 2)),
                    new Level(4, 84, CreateStats(3, 2, 5, 2, 2)),
                    new Level(5, 130, CreateStats(3, 2, 5, 2, 2)),
                    new Level(6, 200, CreateStats(3, 2, 5, 2, 2)),
                    new Level(7, 290, CreateStats(3, 2, 5, 2, 2)),
                    new Level(8, 402, CreateStats(3, 2, 5, 2, 2)),
                    new Level(9, 538, CreateStats(3, 2, 5, 2, 2)),
                    new Level(10, 700, CreateStats(3, 2, 5, 2, 2)),
                    new Level(11, 890, CreateStats(3, 2, 5, 2, 2)),
                    new Level(12, 1110, CreateStats(3, 2, 5, 2, 2)),
                    new Level(13, 1360, CreateStats(3, 2, 5, 2, 2)),
                    new Level(14, 1640, CreateStats(3, 2, 5, 2, 2)),
                    new Level(15, 1950, CreateStats(3, 2, 5, 2, 2)),
                    new Level(16, 2290, CreateStats(3, 2, 5, 2, 2)),
                    new Level(17, 2660, CreateStats(3, 2, 5, 2, 2)),
                    new Level(18, 3060, CreateStats(3, 2, 5, 2, 2)),
                    new Level(19, 3490, CreateStats(3, 2, 5, 2, 2)),
                    new Level(20, 3950, CreateStats(3, 2, 5, 2, 2)),
                    new Level(21, 4440, CreateStats(3, 2, 5, 2, 2)),
                    new Level(22, 4960, CreateStats(3, 2, 5, 2, 2)),
                    new Level(23, 5510, CreateStats(3, 2, 5, 2, 2)),
                    new Level(24, 6088, CreateStats(3, 2, 5, 2, 2)),
                    new Level(25, 6692, CreateStats(3, 2, 5, 2, 2)),
                    new Level(26, 7320, CreateStats(3, 2, 5, 2, 2)),
                    new Level(27, 7968, CreateStats(3, 2, 5, 2, 2)),
                    new Level(28, 8634, CreateStats(3, 2, 5, 2, 2)),
                    new Level(29, 9315, CreateStats(3, 2, 5, 2, 2)),
                    new Level(30, 9999, CreateStats(3, 2, 5, 2, 2))
                }
            );

        #region Creation

        public Level(byte value, ushort required, Stats combatStatReward)
        {
            Value = value;
            Required = new(required);
            CombatStatReward = combatStatReward;
        }

        #endregion

        #region Public Interface

        public Stats CombatStatReward { get; }
        public Xp Required { get; }
        public byte Value { get; }

        #endregion
    }
}
