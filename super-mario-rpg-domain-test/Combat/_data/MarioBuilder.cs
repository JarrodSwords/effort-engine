using Effort.Domain;
using SuperMarioRpg.Domain.Old.Combat;
using CombatStats = SuperMarioRpg.Domain.Combat.CombatStats;

namespace SuperMarioRpg.Domain.Test.Combat
{
    internal class MarioBuilder : CharacterBuilder
    {
        #region Public Interface

        public override CharacterTypes GetCharacterTypes() => CharacterTypes.Mario;
        public override CombatStats GetCombatStats() => default;
        public override Name GetName() => "Mario";

        #endregion
    }
}
