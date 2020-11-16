namespace SuperMarioRpg.Domain.Battle
{
    public partial class Equipment
    {
        #region Nested type: NullEquipment

        private class NullEquipment : Equipment
        {
            #region Core

            public NullEquipment(Slot slot, string name = "None") : base(
                name,
                slot,
                new Stats(),
                Characters.All
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
