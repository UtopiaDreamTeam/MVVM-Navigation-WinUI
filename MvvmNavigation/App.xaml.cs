using Microsoft.UI.Xaml;
using MvvmNavigation.Views;

namespace MvvmNavigation
{

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new Window();
            m_window.Content = new RootPage();
            m_window.Activate();
        }

        private Window m_window;
    }
}
