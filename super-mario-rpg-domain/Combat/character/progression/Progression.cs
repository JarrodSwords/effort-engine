using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract record Progression
    {
        public static readonly Xp Max = new(9999);

        #region Creation

        protected Progression(Xp xp)
        {
            CurrentNode = GetCurrentNode(xp);
            Xp = xp;
        }

        #endregion

        #region Public Interface

        public Level CurrentLevel => CurrentNode.Value;
        public Xp ToNext => CurrentNode.Next is null ? new() : CurrentNode.Next.Value.Required - Xp;
        public Xp Xp { get; }

        public event EventHandler<Stats> LeveledUp;

        public abstract Progression Add(Xp xp);

        #endregion

        #region Protected Interface

        protected LinkedListNode<Level> CurrentNode { get; }

        protected void LevelUp(Xp xp)
        {
            var node = CurrentNode.Next;

            while (node.Value.Required <= xp)
            {
                node = node.Next;

                if (node is null)
                    return;

                LeveledUp?.Invoke(this, node.Value.CombatStatReward);
            }
        }

        #endregion

        #region Static Interface

        private static LinkedListNode<Level> GetCurrentNode(Xp xp)
        {
            var node = Level.Levels.First;

            while (node is not null && node.Next?.Value.Required <= xp)
                node = node.Next;

            return node;
        }

        #endregion
    }
}
