using System;
using Effort.Domain;
using Effort.Test.Domain;
using FluentAssertions;
using SuperMarioRpg.Domain.Battle;
using Xunit;

namespace SuperMarioRpg.Test.Domain.Battle
{
    public class CharacterSpec : EntitySpec
    {
        #region Test Methods

        protected override Entity CreateEntity() => new Character();
        protected override Entity CreateEntity(Guid id) => new Character(id);

        [Fact]
        public void WhenInstantiating_WithArmor_LoadoutIsExpected()
        {
            var shirt = EquipmentFactory.Instance.Create(EquipmentType.Shirt);
            var director = new Director();
            var characterBuilder = new CharacterBuilder(CharacterType.Mario)
                .WithEquipment(shirt);

            director.ConfigureCharacter(characterBuilder);

            var character = characterBuilder.Build();

            character.Loadout.Armor.Should().Be(shirt);
        }

        #endregion
    }
}
