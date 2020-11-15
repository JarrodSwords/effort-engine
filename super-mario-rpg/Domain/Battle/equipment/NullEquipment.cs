namespace SuperMarioRpg.Domain.Battle
{
    public class NullEquipment : Equipment
    {
        #region Core

        public NullEquipment(Slot slot) : base(
            "None",
            slot,
            new Stats(),
            Characters.All
        )
        {
        }

        #endregion
    }
}
