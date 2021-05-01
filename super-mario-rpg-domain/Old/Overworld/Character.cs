namespace SuperMarioRpg.Domain.Old.Overworld
{
    public class Character
    {
        #region Public Interface

        public Location Location { get; private set; }

        public void Move(Location location)
        {
            Location = location;
        }

        #endregion
    }
}
