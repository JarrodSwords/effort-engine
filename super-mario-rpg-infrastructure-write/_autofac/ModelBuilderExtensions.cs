using Microsoft.EntityFrameworkCore;

namespace SuperMarioRpg.Infrastructure.Write
{
    public static class ModelBuilderExtensions
    {
        #region Static Interface

        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
                entity.SetTableName(entity.DisplayName());
        }

        #endregion
    }
}
