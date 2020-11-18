namespace SuperMarioRpg.Domain.Combat
{
    public class GrowthService
    {
        #region Public Interface

        public void DistributeXp(Xp xp, Character character)
        {
            do
            {
                xp = character.Add(xp);
            } while (xp.Value > 0);
        }

        #endregion
    }
}
