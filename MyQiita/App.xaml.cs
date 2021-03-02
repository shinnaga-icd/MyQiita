using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyQiita.View;
using MyQiita.ViewModel;
using Prism;
using Prism.Ioc;

namespace MyQiita
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<ItemPage, ItemViewModel>();
        }
    }
}
