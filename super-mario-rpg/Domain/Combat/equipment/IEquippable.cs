using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IEquippable<out T>
    {
        T Equip(Equipment equipment);
        bool IsEquipped(Equipment equipment);
        T Unequip(Id id);
    }
}
