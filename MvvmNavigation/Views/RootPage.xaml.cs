using Microsoft.UI.Xaml.Controls;
using MvvmNavigation.ViewModel;

namespace MvvmNavigation.Views
{
    public sealed partial class RootPage : Page
    {
        private readonly RootPageViewModel rootviewModel;
        public RootPage()
        {
            InitializeComponent();
            rootviewModel = new RootPageViewModel();
        }
    }
}
