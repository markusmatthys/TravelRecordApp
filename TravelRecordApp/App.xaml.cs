﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using TravelRecordApp.Model;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://travelrecordappxamarin.azurewebsites.net");

        public static Users user = new Users();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
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
    }
}
