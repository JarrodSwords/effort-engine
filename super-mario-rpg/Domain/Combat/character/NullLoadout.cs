namespace SuperMarioRpg.Domain.Combat
{
    public partial class Loadout
    {
        #region Nested type: NullLoadout

        private class NullLoadout : Loadout
        {
            #region Core

            public NullLoadout() : base(
                Equipment.NullAccessory,
                Equipment.NullArmor,
                Equipment.NullWeapon
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
