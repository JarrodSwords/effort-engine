namespace SuperMarioRpg.Domain.Combat
{
    public class GrowthService
    {
        #region Public Interface

        public void DistributeExperience(ExperiencePoints remainingXp, Character character)
        {
            do
            {
                character.Add(ref remainingXp);
            } while (remainingXp.Value > 0);
        }

        #endregion
    }
}
