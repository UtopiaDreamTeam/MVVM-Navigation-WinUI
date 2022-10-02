using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using MvvmNavigation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNavigation
{
    internal class PageNavigation:ObservableObject
    {
        private readonly HistoryStack<BasePageViewModel> historyStates;
        private readonly HistoryStack<Type> historyTypes;
        private readonly BackwardNavigationCompatibleMode backNavigationCompatiblity;
        private BasePageViewModel viewModel;
        public PageNavigation(BasePageViewModel viewModel,BackwardNavigationCompatibleMode mode=BackwardNavigationCompatibleMode.None,int maxHistory=5)
        {
            backNavigationCompatiblity = mode;
            if (mode==BackwardNavigationCompatibleMode.StoreStates)
                historyStates = new HistoryStack<BasePageViewModel>(maxHistory);
            else if (mode == BackwardNavigationCompatibleMode.StoreTypes)
                historyTypes = new HistoryStack<Type>(maxHistory);
            ViewModel = viewModel;
        }

        public BasePageViewModel ViewModel
        {
            get => viewModel;
            set
            {
                if (viewModel != null)
                {
                    if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreStates)
                        historyStates.Push(viewModel);
                    else if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreTypes)
                        historyTypes.Push(viewModel.GetType());
                }
                ChangeViewModel(value);
            }
        }

        private void ChangeViewModel(BasePageViewModel value)
        {
            SetProperty(ref viewModel, value,nameof(ViewModel));
            viewModel.ParentPageNavigation = this;
            PageContainer = Converters.DisplayPageToView.Convert(viewModel);
            PageContainer.DataContext = viewModel;
        }

        private Page pageContainer;

        public Page PageContainer
        {
            get => pageContainer;
            set => SetProperty(ref pageContainer, value);
        }

        public void GoBack()
        {
            if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreStates
                && historyStates.TryPop(out var oldVm))
                ChangeViewModel(oldVm);
            if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreTypes
                && historyTypes.TryPop(out var oldVmType))
                ChangeViewModel((BasePageViewModel)Activator.CreateInstance(oldVmType));
        }
        public bool CanGoBack()
        {
            if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreStates)
                return historyStates.Items.Count > 0;
            else if (backNavigationCompatiblity == BackwardNavigationCompatibleMode.StoreTypes)
                return historyTypes.Items.Count > 0;
            return false;
        }
    }
    public enum BackwardNavigationCompatibleMode
    {
        None,StoreTypes,StoreStates
    }
}
