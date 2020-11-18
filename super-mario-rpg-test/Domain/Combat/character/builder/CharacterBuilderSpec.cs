using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Combat
{
    public abstract class CharacterBuilderSpec
    {
        #region Core

        protected readonly Director Director;

        protected CharacterBuilderSpec()
        {
            Director = new Director();
        }

        #endregion

        #region Test Methods

        [Fact]
        public abstract void WhenBuilding_WithEquipment_ItemsAreEquipped();

        #endregion
    }
}
