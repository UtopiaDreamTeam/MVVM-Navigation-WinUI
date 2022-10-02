using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using MvvmNavigation.ViewModel;
using MvvmNavigation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNavigation.Converters
{
    internal class DisplayPageToView
    {
        private static readonly Dictionary<Type, Type> pairs = new Dictionary<Type, Type>()
        {
            {typeof(Page1ViewModel),typeof(Page1)},
            {typeof(Page1_1ViewModel),typeof(Page1_1)},
            {typeof(Page1_2ViewModel),typeof(Page1_2)},
            {typeof(Page1_3ViewModel),typeof(Page1_3)},
            {typeof(Page1_4ViewModel),typeof(Page1_4)},
            {typeof(Page2ViewModel),typeof(Page2)},
        };
        public static Page Convert(IPageViewModel value)
        {
            pairs.TryGetValue(value.GetType(), out var page);
            var x=Activator.CreateInstance(page);
            return (Page)x;
        }

    }
}
