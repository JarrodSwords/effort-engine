using Effort.Domain;

namespace SuperMarioRpg.Domain.Overworld
{
    public record Region
    {
        #region Creation

        public Region(string name)
        {
            Name = Name.CreateName(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion
    }
}
