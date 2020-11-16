namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment
    {
        #region Nested type: NullEquipment

        private class NullEquipment : Equipment
        {
            #region Core

            public NullEquipment(Slot slot, string name = "None") : base(
                name,
                EquipmentType.None,
                slot,
                Characters.All
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
