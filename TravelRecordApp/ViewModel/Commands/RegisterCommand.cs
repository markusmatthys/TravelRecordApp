﻿using System;
using System.Windows.Input;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterVM viewModel;

        public event EventHandler CanExecuteChanged;

        public RegisterCommand(RegisterVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            Users user = (Users)parameter;

            if (user != null)
            {
                if (user.Password == user.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(user.Password) || (string.IsNullOrEmpty(user.Email))){
                        return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Users user = (Users)parameter;
            viewModel.Register(user);
        }
    }
}
