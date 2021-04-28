﻿using Effort.Domain;

namespace SuperMarioRpg.Domain.Characters
{
    public interface IPlayableCharacterRepository : IRepository<PlayableCharacter>
    {
        string Create(PlayableCharacter playableCharacter);
        void Create(params PlayableCharacter[] playableCharacters);
        PlayableCharacter Find(Name name);
        void Update(PlayableCharacter playableCharacter);
    }
}
