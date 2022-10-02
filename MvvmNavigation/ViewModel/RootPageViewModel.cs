using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNavigation.ViewModel
{
    internal class RootPageViewModel:ObservableObject
    {

        public RootPageViewModel()
        {
            ChildPageNavigation = new PageNavigation(new Page2ViewModel());
        }
        public PageNavigation ChildPageNavigation { get; }
    }
}
