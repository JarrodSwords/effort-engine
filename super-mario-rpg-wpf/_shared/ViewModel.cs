using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperMarioRpg.Wpf
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        #region Public Interface

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Interface

        protected void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (Equals(member, val))
                return;

            member = val;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
