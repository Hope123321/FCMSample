using FCMSample.Interfaces;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FCMSample.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public readonly ILocalNotificationsService localNotificationsService;
        public ICommand ShowNotificationCommand { get; private set; }

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));


            localNotificationsService = DependencyService.Get<ILocalNotificationsService>();
            ShowNotificationCommand = new DelegateCommand(ShowNotification);
        }
        private void ShowNotification()
        {
            localNotificationsService.ShowNotification("Local Notification", "This a local notification", new Dictionary<string, string>());
        }
        public ICommand OpenWebCommand { get; }
    }
}