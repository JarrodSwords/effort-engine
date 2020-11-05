using Effort.Domain;

namespace Effort.Test.Domain
{
    public class BarSpec : ValueObjectSpec<Bar>
    {
        #region Protected Interface

        protected override ValueObject<Bar> CreateValueObject() => new Bar(1);

        #endregion
    }
}
