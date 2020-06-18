using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Microsoft.WindowsAzure.MobileServices;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        Users user;

        public RegisterPage()
            

        {
            InitializeComponent();

            user = new Users();
            containerStackLayout.BindingContext = user;
        }

        private async void registerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (passwordEntry.Text == confirmPasswordEntry.Text)
            {
                //We can register user
                //Users user = new Users()
                //{
                //    Email = emailEntry.Text,
                //    Password = passwordEntry.Text
                //};

                Users.Register(user);
            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}
