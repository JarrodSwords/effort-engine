using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterBuilder : CharacterBuilderBase, ICharacterBuilder
    {
        #region Core

        public CharacterBuilder()
        {
            Equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public CharacterBuilder Add(params Equipment[] equipment)
        {
            Equipment.AddRange(equipment);
            return this;
        }

        public CharacterBuilder For(Characters characterType)
        {
            CharacterType = characterType;
            return this;
        }

        public CharacterBuilder WithId(Guid id)
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
