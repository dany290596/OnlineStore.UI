using OnlineStore.UI.Models;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using OnlineStore.UI.Helpers;
namespace OnlineStore.UI.ViewModels
{
    public class PayViewModel : ViewModelBase
    {
        public ICommand CommandGoBack { get; }
        public PayViewModel()
        {
            Title = "Tu carrito te espera, ¡paga y disfruta!";
            ProductDetail = StorageShoppingCart();
            CommandGoBack = new RelayCommand(NavigateToGoBack);
        }

        private void NavigateToGoBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(MainPage));
            }
        }
    }
}