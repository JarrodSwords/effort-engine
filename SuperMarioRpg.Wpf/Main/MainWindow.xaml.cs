using System.Windows;

namespace SuperMarioRpg.Wpf.Main
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Creation

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        #endregion
    }
}
