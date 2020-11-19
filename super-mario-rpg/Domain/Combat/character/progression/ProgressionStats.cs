using System;
using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionStats : ValueObject<ProgressionStats>
    {
        #region Core

        private readonly LinkedList<Level> _levels;

        public ProgressionStats(Xp currentXp, IEnumerable<Level> levels)
        {
            var temp = levels.ToList();
            var index = temp.FindLastIndex(x => x.Required.Value <= currentXp.Value);

            _levels = new LinkedList<Level>(temp.Skip(index));
            CurrentXp = currentXp;
        }

        private ProgressionStats(Xp currentXp, LinkedList<Level> levels)
        {
            _levels = levels;
            CurrentXp = currentXp;
        }

        #endregion

        #region Public Interface

        public Xp CurrentXp { get; }
        public event EventHandler<Stats> LeveledUp;
        public Level CurrentLevel => _levels.First.Value;
        public Level NextLevel => _levels.First.Next.Value;
        public Xp ToNext => NextLevel.Required - CurrentXp;

        public ProgressionStats Add(Xp xp)
        {
            var newXp = CurrentXp + xp;

            if (newXp.Value > CurrentXp.Value && newXp == NextLevel.Required)
                LevelUp();

            return new ProgressionStats(newXp, _levels);
        }

        public void LevelUp()
        {
            _levels.RemoveFirst();
            LeveledUp?.Invoke(this, NextLevel.CombatStatReward);
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionStats other) => throw new NotImplementedException();
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
