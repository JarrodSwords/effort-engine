namespace SuperMarioRpg.Domain.Combat
{
    public partial class Equipment
    {
        #region Nested Types

        private class NullEquipment : Equipment
        {
            #region Creation

            public NullEquipment(Slot slot, string name = "None") : base(
                name,
                EquipmentType.None,
                slot,
                CharacterTypes.All
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
