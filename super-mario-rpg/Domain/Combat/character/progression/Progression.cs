using System;
using System.Collections.Generic;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class Progression : ValueObject
    {
        protected static readonly Xp Max = CreateXp(9999);

        #region Creation

        protected Progression(Character character) : this(
            character,
            character.Progression.Xp
        )
        {
        }

        protected Progression(Character character, Xp xp)
        {
            Character = character;
            CurrentNode = GetCurrentNode(xp);
            Xp = xp;
            ToNext = NextLevel.Required - Xp;
        }

        protected Progression(Character character, Xp xp, Xp toNext)
        {
            CurrentNode = GetCurrentNode(xp);
            Character = character;
            Xp = xp;
            ToNext = toNext;
        }

        #endregion

        #region Public Interface

        public Level CurrentLevel => CurrentNode.Value;
        public Xp ToNext { get; }
        public Xp Xp { get; }

        public event EventHandler<Stats> LeveledUp;

        public abstract Progression Add(Xp xp);

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

                if (node is null)
                    return;

                LeveledUp?.Invoke(this, node.Value.CombatStatReward);
            }
        }

        #endregion

        #region Private Interface

        private Level NextLevel => CurrentNode.Next?.Value;

        private static LinkedListNode<Level> GetCurrentNode(Xp xp)
        {
            var node = Level.Levels.First;

            while (node.Next?.Value.Required.Value <= xp.Value)
                node = node.Next;

            return node;
        }

        #endregion

        #region Equality, Operators

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CurrentLevel;
            yield return ToNext;
            yield return Xp;
        }

        #endregion
    }
}
