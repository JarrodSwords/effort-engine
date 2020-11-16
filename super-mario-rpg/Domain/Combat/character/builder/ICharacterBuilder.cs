namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        void CreateLoadout();
        void CreateNaturalStats();
        void InitializeGrowth();
    }
}
