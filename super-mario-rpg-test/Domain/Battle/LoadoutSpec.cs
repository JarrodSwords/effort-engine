using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class LoadoutSpec : ValueObjectSpec<Loadout>
    {
        #region Protected Interface

        protected override ValueObject<Loadout> CreateValueObject() => new Loadout();

        #endregion
    }

    public class CharacterBuilder2Spec
    {
        #region Test Methods

        [Fact]
        public void WhenInstantiating_WithDuplicateSlot_ExceptionIsThrown()
        {
            var builder = new HighLevelCharacterBuilder(Characters.Mario)
                .WithEquipment(
                    EquipmentFactory.Instance.Create(EquipmentType.Shirt),
                    EquipmentFactory.Instance.Create(EquipmentType.Shirt)
                );

            Action createInvalidLoadout = () => { new Director().ConfigureCharacter(builder); };

            createInvalidLoadout.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}
