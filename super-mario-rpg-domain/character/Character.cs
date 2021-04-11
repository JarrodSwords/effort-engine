using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain
{
    public abstract class Character : AggregateRoot
    {
        #region Creation

        protected Character(ICharacterBuilder builder) : base(builder.GetId())
        {
            CharacterTypes = builder.GetCharacterTypes();
            Name = new Name(builder.GetName());
        }

        #endregion

        #region Public Interface

        public CharacterTypes CharacterTypes { get; }
        public Name Name { get; }

        #endregion

        #region Nested Types

        public interface IRepository : IRepository<Character>
        {
            #region Public Interface

            IRepository Delete(Name name);

            #endregion
        }

        #endregion
    }
}
