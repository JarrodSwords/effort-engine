﻿using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private Enemy.IRepository _enemies;
        private NonPlayableCharacter.IRepository _nonPlayerCharacters;
        private PlayableCharacter.IRepository _playableCharacters;

        #region Creation

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Implementation

        public Enemy.IRepository Enemies => _enemies ??= new Character.EnemyRepository(_context);

        public NonPlayableCharacter.IRepository NonPlayerCharacters =>
            _nonPlayerCharacters ??= new Character.NonPlayableCharacterRepository(_context);

        public PlayableCharacter.IRepository PlayableCharacters =>
            _playableCharacters ??= new Character.PlayableCharacterRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
