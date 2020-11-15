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

        protected override Entity CreateEntity() => new CharacterBuilder(CharacterType.Mario).Build();
        protected override Entity CreateEntity(Guid id) => new CharacterBuilder(CharacterType.Mario).WithId(id).Build();

        [Fact]
        public void WhenInstantiating_WithEquipment_LoadoutIsExpected()
        {
            var hammer = EquipmentFactory.Instance.Create(EquipmentType.Hammer);
            var shirt = EquipmentFactory.Instance.Create(EquipmentType.Shirt);
            var jumpShoes = EquipmentFactory.Instance.Create(EquipmentType.JumpShoes);

            var director = new Director();
            var characterBuilder = new CharacterBuilder(CharacterType.Mario)
                .WithEquipment(hammer, shirt, jumpShoes);

            director.ConfigureCharacter(characterBuilder);

            var character = characterBuilder.Build();

            character.Loadout.Weapon.Should().Be(hammer);
            character.Loadout.Armor.Should().Be(shirt);
            character.Loadout.Accessory.Should().Be(jumpShoes);
        }

        #endregion
    }
}
