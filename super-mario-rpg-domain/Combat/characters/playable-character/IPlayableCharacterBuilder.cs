namespace SuperMarioRpg.Domain.Combat
{
    public interface IPlayableCharacterBuilder : ICharacterBuilder
    {
        Statistics GetStatistics();
    }
}
