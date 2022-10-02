using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmNavigation.ViewModel
{
    internal abstract class BasePageViewModel:ObservableObject
    {
        public PageNavigation ParentPageNavigation { get; set; }
    }
}