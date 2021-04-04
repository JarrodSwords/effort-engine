using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class Character : Entity
    {
        #region Public Interface

        public string Name { get; set; }

        public static Character From(PlayerCharacter playerCharacter)
        {
            return new()
            {
                Id = playerCharacter.Id.Value,
                Name = playerCharacter.Name.Value
            };
        }

        public static PlayerCharacter To(Character character)
        {
            return null;
        }

        #endregion
    }
}
