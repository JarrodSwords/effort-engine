namespace SuperMarioRpg.Domain.Battle
{
    public interface ICharacterBuilder
    {
        void CalculateEffectiveStats();
        void CreateLoadout();
        void CreateNaturalStats();
    }
}
