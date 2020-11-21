namespace SuperMarioRpg.Domain.Combat
{
    public interface IGrowth
    {
        IProgressionSystem Add(Xp xp);
    }
}