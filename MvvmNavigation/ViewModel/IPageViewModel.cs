using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmNavigation.ViewModel
{
    internal abstract class IPageViewModel:ObservableObject
    {
        public ParentPageNavigation ParentPageNavigation { get; set; }
    }
}