namespace SuperMarioRpg.Domain
{
    public partial class Enemy
    {
        #region Nested Types

        public interface IRepository : IRepository<Enemy>
        {
            #region Public Interface

            string Create(Enemy enemy);
            void Create(params Enemy[] enemy);

            #endregion
        }

        #endregion
    }
}
