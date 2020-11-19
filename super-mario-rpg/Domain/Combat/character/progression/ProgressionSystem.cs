using System;
using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionSystem : ValueObject<ProgressionSystem>, IProgressionSystem
    {
        #region Core

        private readonly LinkedListNode<Level> _currentNode;

        public ProgressionSystem(Xp xp)
        {
            Xp = xp;

            _currentNode = Level.Levels.First;

            while (_currentNode.Next.Value.Required.Value <= xp.Value)
                _currentNode = _currentNode.Next;

            ToNext = NextLevel.Required - Xp;
        }

        private ProgressionSystem(Xp xp, LinkedListNode<Level> currentNode)
        {
            Xp = xp;
            _currentNode = currentNode;
            ToNext = NextLevel.Required - Xp;
        }

        #endregion

        #region IProgressionSystem

        public Level CurrentLevel => _currentNode.Value;

        public event EventHandler<Stats> LeveledUp;
        public Level NextLevel => _currentNode.Next.Value;

        public Xp ToNext { get; }
        public Xp Xp { get; }

        public IProgressionSystem Add(Xp xp)
        {
            var newXp = Xp + xp;

            var leveledUp = newXp.Value > Xp.Value && newXp == NextLevel.Required;

            if (!leveledUp)
                return new ProgressionSystem(newXp, _currentNode);

            LeveledUp?.Invoke(this, NextLevel.CombatStatReward);
            return new ProgressionSystem(newXp, _currentNode.Next);
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) => throw new NotImplementedException();

        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
