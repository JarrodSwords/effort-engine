using System;

namespace SuperMarioRpg.Api
{
    public record CharacterDto
    {
        #region Public Interface

        public CombatStatsDto CombatStats { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }

        #endregion
    }
}
