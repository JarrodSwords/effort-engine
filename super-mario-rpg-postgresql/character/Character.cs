using DomainCharacter = SuperMarioRpg.Domain.Combat.Character;

namespace SuperMarioRpg.Postgresql
{
    public class Character : Entity
    {
        #region Public Interface

        public string Name { get; set; }

        public static Character From(DomainCharacter character)
        {
            return new()
            {
                Id = character.Id.Value,
                Name = character.Name.Value
            };
        }

        public static DomainCharacter To(Character character)
        {
            return null;
        }

        #endregion
    }
}
