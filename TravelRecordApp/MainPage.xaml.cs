﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TravelRecordApp
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var assembly = typeof(MainPage);

            //iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                var user = (await App.MobileService.GetTable<Users>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == passwordEntry.Text)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Email or password are incorrect", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "There was an error logging you in, perhaps Emailaddress is unknown", "Ok");
                }
                
            }
        }

        void registerUserButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
