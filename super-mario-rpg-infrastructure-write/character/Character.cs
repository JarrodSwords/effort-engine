namespace SuperMarioRpg.Infrastructure.Write
{
    public class Character : Entity
    {
        #region Public Interface

        public string Name { get; set; }

        public static Character From(Domain.Character character)
        {
            return new()
            {
                Id = character.Id.Value,
                Name = character.Name.Value
            };
        }

        public static Domain.Character To(Character character)
        {
            return null;
        }

        #endregion
    }
}
