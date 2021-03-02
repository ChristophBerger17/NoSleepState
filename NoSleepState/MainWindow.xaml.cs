using System.ComponentModel;
using System.Windows;

namespace NoSleepState
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isExit;

        public MainWindow()
        {
            _isExit = false;

            InitializeComponent();

            SleepState.EnableAwayMode();

            Closed += (s, e) => { SleepState.DisableAwayMode(); };
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void ButtonHide_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Exit()
        {
            _isExit = true;
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!_isExit)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
