using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ILoadout
    {
        ILoadout Equip(Equipment equipment);
        Equipment GetEquipment(Slot slot);
        Stats GetStats();
        ILoadout Unequip(Id id);
    }
}
