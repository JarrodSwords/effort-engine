using Effort.Domain;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Domain.Test.Combat
{
    internal class MarioBuilder : CharacterBuilder
    {
        #region Public Interface

        public override CharacterTypes GetCharacterTypes() => CharacterTypes.Mario;
        public override Name GetName() => "Mario";
        public override Statistics GetStatistics() => default;

        #endregion
    }
}
