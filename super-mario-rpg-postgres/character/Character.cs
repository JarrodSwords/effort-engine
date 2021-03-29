using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgres
{
    public class Character : Entity<DomainCharacter>
    {
        #region Public Interface

        public string Name { get; set; }

        public static Character From(DomainCharacter entity)
        {
            return new()
            {
                Id = entity.Id.Value,
                Name = entity.Name.Value
            };
        }

        public override DomainCharacter To()
        {
            return null;
        }

        #endregion
    }
}
