using System.Linq;
using Effort.Domain;
using Microsoft.EntityFrameworkCore;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Infrastructure.Write
{
    public partial class Character
    {
        public class Repository :
            Repository<Character>,
            IEnemyRepository,
            INonPlayableCharacterRepository,
            IPlayableCharacterRepository
        {
            #region Creation

            public Repository(Context context) : base(context)
            {
            }

            #endregion

            #region IEnemyRepository Implementation

            public string Create(Enemy enemy) => base.Create(enemy).Name;

            public void Create(params Enemy[] enemies)
            {
                Create(enemies.Select(AsCharacter).ToArray());
            }

            #endregion

            #region INonPlayableCharacterRepository Implementation

            public string Create(NonPlayableCharacter nonPlayableCharacter) => base.Create(nonPlayableCharacter).Name;

            public void Create(params NonPlayableCharacter[] nonPlayerCharacters)
            {
                var characters = nonPlayerCharacters.Select(AsCharacter).ToArray();

                Create(characters);
            }

            #endregion

            #region IPlayableCharacterRepository Implementation

            public string Create(PlayableCharacter playableCharacter) => base.Create(playableCharacter).Name;

            public void Create(params PlayableCharacter[] playableCharacters)
            {
                Create(playableCharacters.Select(AsCharacter).ToArray());
            }

            public PlayableCharacter Find(Name name)
            {
                return Context.Character
                    .Include(x => x.Statistics)
                    .Single(x => x.IsPlayable && x.Name == name);
            }

            public void Update(PlayableCharacter playableCharacter)
            {
                var character = Context.Character
                    .Include(x => x.Statistics)
                    .Single(x => x.IsPlayable && x.Name == playableCharacter.Name)
                    .Update(playableCharacter);

                base.Update(character);
            }

            #endregion
        }
    }
}
