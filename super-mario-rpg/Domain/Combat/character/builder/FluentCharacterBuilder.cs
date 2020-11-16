using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class FluentCharacterBuilder : CharacterBuilder, ICharacterBuilder
    {
        #region Core

        public FluentCharacterBuilder()
        {
            Equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public FluentCharacterBuilder Add(params Equipment[] equipment)
        {
            Equipment.AddRange(equipment);
            return this;
        }

        public FluentCharacterBuilder For(Characters characterType)
        {
            CharacterType = characterType;
            return this;
        }

        public FluentCharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        #endregion

        #region Protected Interface

        protected override void ResetExplicit()
        {
            Equipment?.Clear();
        }

        #endregion

        #region Private Interface

        private List<Equipment> Equipment { get; }

        #endregion

        #region ICharacterBuilder

        public void CreateLoadout()
        {
            Loadout = new Loadout(Equipment.ToArray());
        }

        #endregion
    }
}
