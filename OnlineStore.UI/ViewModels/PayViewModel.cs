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
        public string TotalMXN { get; }
        public DateTime DateTime { get; }
        public PayViewModel()
        {
            Title = "Tu carrito te espera, \n¡Paga y disfruta!";
            ProductDetail = StorageShoppingCart();
            double total = 0;
            foreach (var item in ProductDetail)
            {
                total += item.TotalPriceProduct;
            }
            CommandGoBack = new RelayCommand(NavigateToGoBack);
            TotalMXN = "$" + total.ToString();
            DateTime = DateTime.Now;
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