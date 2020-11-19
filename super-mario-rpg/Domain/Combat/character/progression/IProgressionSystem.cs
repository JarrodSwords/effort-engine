using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IProgressionSystem
    {
        Level CurrentLevel { get; }
        event EventHandler<Stats> LeveledUp;
        Level NextLevel { get; }
        Xp ToNext { get; }
        Xp Xp { get; }

        IProgressionSystem Add(Xp xp);
    }
}
