using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.Services
{
    public class NavigationService
    {
        public Frame _frame;

        public NavigationService()
        {
           
        }

        public void NavigateTo<T>(object parameter = null) where T : Page
        {
            _frame.Navigate(typeof(T), parameter);
        }

        public bool CanGoBack()
        {
            return _frame.CanGoBack;
        }

        public void GoBack()
        {
            if (CanGoBack())
            {
                _frame.GoBack();
            }
        }
    }
}