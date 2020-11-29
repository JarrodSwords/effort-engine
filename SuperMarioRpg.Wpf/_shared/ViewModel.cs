using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperMarioRpg.Wpf
{
    public abstract class ViewModel
    {
        #region Public Interface

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Interface

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
