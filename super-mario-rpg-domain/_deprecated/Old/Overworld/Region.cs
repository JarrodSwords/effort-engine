using Effort.Domain;

namespace SuperMarioRpg.Domain.Old.Overworld
{
    public record Region
    {
        #region Creation

        public Region(string name)
        {
            Name = new(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
