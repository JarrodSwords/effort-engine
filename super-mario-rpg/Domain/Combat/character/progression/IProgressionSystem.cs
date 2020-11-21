using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IProgressionSystem
    {
        Level CurrentLevel { get; }
        Level NextLevel { get; }
        Xp ToNext { get; }
        Xp Xp { get; }
        event EventHandler<Stats> LeveledUp;

        IProgressionSystem Add(Xp xp);
        IProgressionSystem Create(Xp xp);
        IProgressionSystem Set(IGrowth growth);
    }
}
