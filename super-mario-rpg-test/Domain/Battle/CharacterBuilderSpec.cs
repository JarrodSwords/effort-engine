using System;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class CharacterBuilderSpec
    {
        #region Test Methods

        [Fact]
        public void WhenInstantiating_WithDuplicateSlot_ExceptionIsThrown()
        {
            var builder = new CharacterBuilder(Characters.Mario)
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
