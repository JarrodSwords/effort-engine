using System;
using Effort.Domain;
using Effort.Domain.Test;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;
using CombatStats = SuperMarioRpg.Domain.Combat.CombatStats;

namespace SuperMarioRpg.Domain.Test.Combat
{
    public abstract class CharacterSpec : EntitySpec
    {
    }

    public class PlayableCharacterSpec : CharacterSpec
    {
        private readonly MarioBuilder _marioBuilder = new();

        #region Protected Interface

        protected override Entity CreateEntity() => _marioBuilder;
        protected override Entity CreateEntity(Guid id) => _marioBuilder.With(id);

        #endregion
    }

    internal abstract class CharacterBuilder : IPlayableCharacterBuilder
    {
        private Id _id;

        #region Public Interface

        public CharacterBuilder With(Id id)
        {
            _id = id;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public abstract CharacterTypes GetCharacterTypes();
        public Id GetId() => _id;
        public abstract Name GetName();

        #endregion

        #region IPlayableCharacterBuilder Implementation

        public abstract CombatStats GetCombatStats();

        #endregion

        #region Static Interface

        public static implicit operator PlayableCharacter(CharacterBuilder builder) => new(builder);

        #endregion
    }

    internal class MarioBuilder : CharacterBuilder
    {
        #region Public Interface

        public override CharacterTypes GetCharacterTypes() => CharacterTypes.Mario;
        public override CombatStats GetCombatStats() => default;
        public override Name GetName() => "Mario";

        #endregion
    }
}
