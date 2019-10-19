using Prism;
using Prism.Ioc;
using MyLeasing.Prism.ViewModels;
using MyLeasing.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyLeasing.Common.Services;
using Newtonsoft.Json;
using MyLeasing.Common.Models;
using MyLeasing.Common.Helpers;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyLeasing.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            //Trial License
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQyNjc5QDMxMzcyZTMyMmUzMGRWRW1QVmgwZnQvN2VTeThXSmRhdkFoT21nYjFabUE1WkJzZXhrcVk2QWM9");
            //Comunity License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ2MTQ4QDMxMzcyZTMyMmUzME9PSjdTRlg3MTF3aTNVQlU3dmQrcUtyTE9mVTV2MTJEaWhsakhTRE9iVUU9;MTQ2MTQ5QDMxMzcyZTMyMmUzMFVZdWxLNE9BVnEyNGJocTFQZ0tSY0hwV1FMSkZDbVhPNDIwcDJscTU4RWM9;MTQ2MTUwQDMxMzcyZTMyMmUzMFo5S1QzaHFnN3FJanBZb3QzRjFLZVdOWTE4SU1hakM3WGtTejZWam5rVW89;MTQ2MTUxQDMxMzcyZTMyMmUzMGVPM1g4R3FwVldjeE16RTI1eDE2YWgraXA4c0JZaVB1cmNCUUg5SUt1RE09;MTQ2MTUyQDMxMzcyZTMyMmUzMEkwVkhtQmc3eUJPaDYwWjhTRlBKUCtEWXRRamFqM3pFTjluYXNqamNKSmc9;MTQ2MTUzQDMxMzcyZTMyMmUzMElBVkhXYS9pb25YK3ZDWXFGaFlXejNXWjc0UThPNTBZSldPbjVBSHlVUUE9;MTQ2MTU0QDMxMzcyZTMyMmUzMFpmWGJPTS9KUWhwcVlkdzNkQzBCMkp5cUlDKzNEMWhqcVNQYjRIbTdneFU9;MTQ2MTU1QDMxMzcyZTMyMmUzMFJkUjR6WXhvOVRNTkpOOXFHYUlkaFl3ZXlBZjRuamZNSGNOZzB1bzZlMWM9;MTQ2MTU2QDMxMzcyZTMyMmUzMGNGTVV5N2huSms1b0RFZm1rT09qLzU0TUtSWFN4WEQ5ak5HeHQwcXZDQ3M9;MTQ2MTU3QDMxMzcyZTMyMmUzMEkwVkhtQmc3eUJPaDYwWjhTRlBKUCtEWXRRamFqM3pFTjluYXNqamNKSmc9");

            InitializeComponent();

            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/LeasingMasterDetailPage/NavigationPage/PropertiesPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertiesPage, PropertiesPageViewModel>();
containerRegistry.RegisterForNavigation<PropertyPage, PropertyPageViewModel>(); containerRegistry.RegisterForNavigation<ContractsPage, ContractsPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractPage, ContractPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyTabbedPage, PropertyTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<LeasingMasterDetailPage, LeasingMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
        }
    }
}
