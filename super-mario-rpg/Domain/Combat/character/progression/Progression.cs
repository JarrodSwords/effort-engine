using System;
using System.Collections.Generic;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public abstract class Progression : ValueObject<Progression>
    {
        private static Xp _max = CreateXp(9999);

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
            Xp = CreateXp(Math.Min(xp.Value, _max.Value));
            ToNext = NextLevel is null ? CreateXp() : NextLevel.Required - Xp;
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

        protected override bool EqualsExplicit(Progression other) => throw new NotImplementedException();
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
