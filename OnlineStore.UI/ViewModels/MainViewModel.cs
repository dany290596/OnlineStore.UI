using OnlineStore.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.UI.Views;
using System.ComponentModel;
using System.Windows.Input;
using OnlineStore.UI.Helpers;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace OnlineStore.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand NavigateToHomeCommand { get; }
        public ICommand NavigateToPayCommand { get; }

        public MainViewModel()
        {
            Title = "BIENVENIDO";
            Subtitle = "¿Qué te gustaría \nhacer hoy?";
            NavigateToHomeCommand = new RelayCommand(NavigateToHome);
            NavigateToPayCommand = new RelayCommand(NavigateToPay);
        }

        private void NavigateToHome()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(HomePage));
            }
        }

        private void NavigateToPay()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(PayPage));
            }
        }
    }
}