using System;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public class NonPlayerCharacterBuilder : ICharacterBuilder
    {
        private CreateNonPlayerCharacterArgs _args;

        #region Public Interface

        public NonPlayerCharacter Build()
        {
            return new(this);
        }

        public NonPlayerCharacterBuilder From(CreateNonPlayerCharacterArgs args)
        {
            _args = args;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            throw new NotSupportedException();
        }

        public Guid GetId()
        {
            return Guid.Empty;
        }

        public string GetName()
        {
            return _args.Name;
        }

        #endregion
    }

    public class FluentCharacterBuilder : ICharacterBuilder
    {
        #region Public Interface

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public NonPlayerCharacter BuildNonPlayerCharacter()
        {
            return new(this);
        }

        public FluentCharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public FluentCharacterBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        #endregion

        #region ICharacterBuilder Implementation

        public Stats GetCombatStats()
        {
            throw new NotImplementedException();
        }

        public Guid GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        #endregion
    }
}
