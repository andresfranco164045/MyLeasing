﻿using MyLeasing.Common.Helpers;
using MyLeasing.Common.Models;
using MyLeasing.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Prism.ViewModels
{
    public class RememberPasswordPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private readonly INavigationService _navigationService;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _recoverCommand;

        public RememberPasswordPageViewModel(
            IApiService apiService,
            INavigationService navigationService) : base(navigationService)
        {
            _apiService = apiService;
            _navigationService = navigationService;
            Title = "Recover Password";
            _isEnabled = true;
        }
        public DelegateCommand RecoverCommand => _recoverCommand ?? (_recoverCommand = new DelegateCommand(Recover));

        public string Email { get; set; }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Recover()
        {
            var isValid = await ValidateData();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new EmailRequest
            {
                Email = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.RecoverPasswordAsync(
                url,
                "/api",
                "/Account/RecoverPassword",
                request);

            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            await App.Current.MainPage.DisplayAlert(
                "Ok",
                response.Message,
                "Accept");
            await _navigationService.GoBackAsync();
        }

        private async Task<bool> ValidateData()
        {
            if (string.IsNullOrEmpty(Email) || !RegexHelper.IsValidEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You Must Enter a Valid Email.", "Accept");
                return false;
            }

            return true;
        }
    }
}