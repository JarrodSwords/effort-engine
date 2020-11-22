using System;
using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class ProgressionSystem : ValueObject<ProgressionSystem>
    {
        #region Creation

        protected ProgressionSystem(Character character) : this(
            character,
            character.ProgressionSystem.Xp
        )
        {
        }

        protected ProgressionSystem(Character character, Xp xp)
        {
            Character = character;
            CurrentNode = GetCurrentNode(xp);
            Xp = xp;
            ToNext = NextLevel.Required - Xp;
        }

        #endregion

        #region Public Interface

        public Level CurrentLevel => CurrentNode.Value;
        public Level NextLevel => CurrentNode.Next.Value;
        public Xp ToNext { get; }
        public Xp Xp { get; }

        public event EventHandler<Stats> LeveledUp;

        public abstract ProgressionSystem Add(Xp xp);

        #endregion

        #region Protected Interface

        protected Character Character { get; }
        protected LinkedListNode<Level> CurrentNode { get; }

        protected void LevelUp(Xp xp)
        {
            var node = CurrentNode.Next;

            while (node.Value.Required.Value <= xp.Value)
            {
                node = node.Next;
                LeveledUp?.Invoke(this, node.Value.CombatStatReward);
            }
        }

        #endregion

        #region Private Interface

        private static LinkedListNode<Level> GetCurrentNode(Xp xp)
        {
            var node = Level.Levels.First;

            while (node.Next.Value.Required.Value <= xp.Value)
                node = node.Next;

            return node;
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) => throw new NotImplementedException();
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
