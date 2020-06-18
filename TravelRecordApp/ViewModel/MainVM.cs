using System;
using System.ComponentModel;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        private Users user;

        public Users User {
            get { return user; }
            set {
                user = value;
                OnPropertyChanged("User");
            }
        }


        public object MyProperty { get; set; }


        public LoginCommand LoginCommand { get; set; }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set {
                password = value;
                User = new Users()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
                OnPropertyChanged("Password");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainVM()
        {
            User = new Users();
            LoginCommand = new LoginCommand(this);
        }

        public async System.Threading.Tasks.Task LoginAsync()
        {
            bool canLogin = await Users.CheckLogin(User.Email, User.Password);

            if (canLogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
            }
        }
        public async void Login()
        {
            bool canLogin = await Users.CheckLogin(User.Email, User.Password);

            if (canLogin)
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Try again", "Ok");
            }
        }
    }
}
