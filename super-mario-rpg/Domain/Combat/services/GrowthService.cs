namespace SuperMarioRpg.Domain.Combat
{
    public class GrowthService
    {
        #region Public Interface

        public void DistributeExperience(ExperiencePoints experiencePoints, Character character)
        {
            do
            {
                experiencePoints = character.Add(experiencePoints);
            } while (experiencePoints.Value > 0);
        }

        #endregion
    }
}
