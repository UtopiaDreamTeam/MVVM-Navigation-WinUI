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
            ParentPageNavigation = new ParentPageNavigation(new Page2ViewModel());
        }
        public ParentPageNavigation ParentPageNavigation { get; }
    }
}
