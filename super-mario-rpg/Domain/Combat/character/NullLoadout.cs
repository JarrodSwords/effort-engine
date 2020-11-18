namespace SuperMarioRpg.Domain.Combat
{
    public partial class Loadout
    {
        #region Nested type: NullLoadout

        private class NullLoadout : Loadout
        {
            #region Core

            public NullLoadout() : base(
                Equipment.DefaultAccessory,
                Equipment.DefaultArmor,
                Equipment.DefaultWeapon
            )
            {
            }

            #endregion
        }

        #endregion
    }
}
