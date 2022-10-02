using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MvvmNavigation.ViewModel
{
    public abstract class BasePageViewModel:ObservableObject
    {
        public PageNavigation ParentPageNavigation { get; set; }
    }
}