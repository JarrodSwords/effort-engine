using System;

namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment
    {
        #region Nested Types

        private class NullEquipment : Equipment
        {
            #region Creation

            public NullEquipment(EquipmentSlot equipmentSlot, string name = "None") : base(
                Guid.Empty,
                EquipmentType.None,
                equipmentSlot,
                CharacterTypes.All,
                name,
                null
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
