using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MvvmNavigation.ViewModel
{
    public class RootPageViewModel:ObservableObject
    {

        public RootPageViewModel()
        {
            ChildPageNavigation = new PageNavigation(new Page2ViewModel());
        }
        public PageNavigation ChildPageNavigation { get; }
    }
}
