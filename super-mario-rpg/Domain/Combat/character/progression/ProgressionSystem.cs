using System;
using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionSystem : ValueObject<ProgressionSystem>, IProgressionSystem
    {
        private readonly LinkedListNode<Level> _currentNode;
        private readonly IGrowth _growth;

        #region Creation

        public ProgressionSystem(Xp xp)
        {
            _growth = new Standard(this);

            Xp = xp;

            _currentNode = Level.Levels.First;

            while (CanIncrementLevel())
                _currentNode = _currentNode.Next;

            ToNext = NextLevel.Required - Xp;
        }

        private ProgressionSystem(
            Xp xp,
            LinkedListNode<Level> currentNode,
            EventHandler<Stats> leveledUp,
            IGrowth growth
        )
        {
            Xp = xp;
            _currentNode = currentNode;
            _growth = growth;
            LeveledUp = leveledUp;

            while (CanIncrementLevel())
            {
                _currentNode = _currentNode.Next;
                LeveledUp?.Invoke(this, _currentNode.Value.CombatStatReward);
            }

            ToNext = NextLevel.Required - Xp;
        }

        #endregion

        #region Public Interface

        public event EventHandler<Stats> LeveledUp;

        #endregion

        #region Private Interface

        private bool CanIncrementLevel() => _currentNode.Next.Value.Required.Value <= Xp.Value;

        #endregion

        #region IProgressionSystem Implementation

        public Level CurrentLevel => _currentNode.Value;
        public Level NextLevel => _currentNode.Next.Value;
        public Xp ToNext { get; }
        public Xp Xp { get; }

        public IProgressionSystem Add(Xp xp) => _growth.Add(xp);

        public IProgressionSystem Create(Xp xp) => new ProgressionSystem(xp, _currentNode, LeveledUp, _growth);

        public IProgressionSystem Set(IGrowth growth) => new ProgressionSystem(Xp, _currentNode, LeveledUp, growth);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) => throw new NotImplementedException();

        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
