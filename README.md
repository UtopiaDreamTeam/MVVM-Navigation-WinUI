This sample shows how to implement navigation in WinUI 3 using MVVM.

It uses ViewModel First approch

It has 3 mode of backward navigation :

-None

-StoreTypes (ViewModels are not stored only their types and then are inistited)

-StoreStates (ViewModels are stored)

It also supports Nested Views.

<h1>Quick Tuto</h1>

1.Create a root Page:
```xml
<Page
    x:Class="MvvmNavigation.Views.RootPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MvvmNavigation.Views"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" xmlns:viewmodel="using:MvvmNavigation.ViewModel" xmlns:converters="using:MvvmNavigation.Converters"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Page.DataContext>
        <viewmodel:RootPageViewModel/>
    </Page.DataContext>
    <Frame Content="{Binding ChildPageNavigation.PageContainer,Mode=OneWay}"/>
</Page>
```

2.Create the ViewModel for the root Page

```csharp
internal class RootPageViewModel:ObservableObject
{
        public RootPageViewModel()
        {
            ChildPageNavigation = new PageNavigation(new Page2ViewModel());
        }
        public PageNavigation ChildPageNavigation { get; }
}
```
3. Create two ViewModels for the child Pages
```csharp
internal class Page1ViewModel:BasePageViewModel
{
        public Page1ViewModel()
        {
        }
}
internal class Page2ViewModel:BasePageViewModel
{
        public Page2ViewModel()
        {
        }
}
```
    
4.To bind new Page to its view model, just add it to The Dictionary in ViewModelToView class:
```csharp
private static readonly Dictionary<Type, Type> pairs = new Dictionary<Type, Type>()
        {
            {typeof(Page1ViewModel),typeof(Page1)},
            {typeof(Page2ViewModel),typeof(Page2)},
        };
```

5. To navigate to new Page from View Model 
```csharp
ParentPageNavigation.ViewModel = new Page2ViewModel()
```
