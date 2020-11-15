using System;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterFactory
    {
        #region Singleton

        public static CharacterFactory Instance => new CharacterFactory();

        #endregion

        #region Public Interface

        public Character Create(CharacterType characterType)
        {
            var character = characterType switch
            {
                CharacterType.Mario => new Character(stats: new Stats(20, 0, 20, 10, 2, 20)),
                _ => throw new ArgumentOutOfRangeException(nameof(characterType), characterType, null)
            };

            return character;
        }

        #endregion
    }
}
