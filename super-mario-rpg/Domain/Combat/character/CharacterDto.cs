using System;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterDto
    {
        #region Core

        public CharacterDto(
            Guid id = default,
            CharacterTypes characterType = default,
            ushort experiencePoints = default,
            byte level = default,
            short attack = default,
            short defense = default,
            short hitPoints = default,
            short specialAttack = default,
            short specialDefense = default,
            short speed = default,
            Guid accessoryId = default,
            Guid armorId = default,
            Guid weaponId = default
        )
        {
            Id = id;
            CharacterType = characterType;
            ExperiencePoints = experiencePoints;
            Level = level;
            Attack = attack;
            Defense = defense;
            HitPoints = hitPoints;
            SpecialAttack = specialAttack;
            SpecialDefense = specialDefense;
            Speed = speed;
            AccessoryId = accessoryId;
            ArmorId = armorId;
            WeaponId = weaponId;
        }

        #endregion

        #region Public Interface

        public Guid AccessoryId { get; }
        public Guid ArmorId { get; }
        public short Attack { get; }
        public CharacterTypes CharacterType { get; }
        public short Defense { get; }
        public ushort ExperiencePoints { get; }
        public short HitPoints { get; }
        public Guid Id { get; }
        public byte Level { get; }
        public short SpecialAttack { get; }
        public short SpecialDefense { get; }
        public short Speed { get; set; }
        public Guid WeaponId { get; }

        #endregion
    }
}