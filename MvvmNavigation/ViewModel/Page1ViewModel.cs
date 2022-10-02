using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNavigation.ViewModel
{
    internal class Page1ViewModel : BasePageViewModel
    {
        public RelayCommand GoToPage2Command { get; }
        public RelayCommand GoToPage1_1Command { get; }
        public RelayCommand GoToPage1_2Command { get; }
        public RelayCommand GoToPage1_3Command { get; }
        public RelayCommand GoToPage1_4Command { get; }
        public RelayCommand GoBackCommand { get; }
        public Page1ViewModel(BasePageViewModel viewModel)
        {
            ChildPageNavigation = new PageNavigation(viewModel,BackwardNavigationCompatibleMode.StoreTypes);
            ChildPageNavigation.PropertyChanged += ChildPageNavigation_PropertyChanged;
            GoBackCommand = new RelayCommand(ChildPageNavigation.GoBack,
                ChildPageNavigation.CanGoBack);
            GoToPage2Command = new RelayCommand(() => ParentPageNavigation.ViewModel = new Page2ViewModel());
            GoToPage1_1Command = new RelayCommand(() => ChildPageNavigation.ViewModel = new Page1_1ViewModel(),
                ()=>ChildPageNavigation.ViewModel.GetType()!= typeof(Page1_1ViewModel));
            GoToPage1_2Command = new RelayCommand(() => ChildPageNavigation.ViewModel = new Page1_2ViewModel(),
                ()=>ChildPageNavigation.ViewModel.GetType() != typeof(Page1_2ViewModel));
            GoToPage1_3Command = new RelayCommand(() =>
            {
                ChildPageNavigation.ViewModel = new Page1_3ViewModel();
            },
                () => ChildPageNavigation.ViewModel.GetType() != typeof(Page1_3ViewModel));
            GoToPage1_4Command = new RelayCommand(() => ChildPageNavigation.ViewModel = new Page1_4ViewModel(),
                () => ChildPageNavigation.ViewModel.GetType() != typeof(Page1_4ViewModel));
        }

        private void ChildPageNavigation_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChildPageNavigation.ViewModel))
            {
                GoBackCommand.NotifyCanExecuteChanged();
                GoToPage1_1Command.NotifyCanExecuteChanged();
                GoToPage1_2Command.NotifyCanExecuteChanged();
                GoToPage1_3Command.NotifyCanExecuteChanged();
                GoToPage1_4Command.NotifyCanExecuteChanged();
            }
        }

        public PageNavigation ChildPageNavigation { get; }
    }
}
