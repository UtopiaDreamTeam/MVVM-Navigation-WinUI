using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MvvmNavigation.ViewModel
{
    internal class Page1_3ViewModel:BasePageViewModel
    {
        private string text;
        public Page1_3ViewModel()
        {
            Text = Random.Shared.Next(1,200).ToString();
        }

        public string Text
        {
            get=> text;
            set => SetProperty(ref text, value);
        }
    }
}