using Newtonsoft.Json;
using OnlineStore.UI.Helpers;
using OnlineStore.UI.Models;
using OnlineStore.UI.Services;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

       
        public ICommand CloseModalCommand { get; }
        private ModalDialogPage _dialog;

        public ViewModelBase()
        {
           
            CloseModalCommand = new RelayCommand<CarouselItem>(CloseModal);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _subtitle;
        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                if (_subtitle != value)
                {
                    _subtitle = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

     

        private void CloseModal(CarouselItem carouselItem)
        {
        }

        public void SaveCart(ProductDetail data)
        {
            if (data != null)
            {
                _dialog = new ModalDialogPage { };
                List<ProductDetail> productDetail = new List<ProductDetail>();
                productDetail.Add(data);
                //List<ShoppingCart> shoppingCart = new List<ShoppingCart>
                //{
                //    new ShoppingCart { Id = Guid.NewGuid(), Estado = 1, ProductDetail = productDetail }
                //};
                 Task.Delay(2000);
                var json = JsonConvert.SerializeObject(productDetail);
                ApplicationData.Current.LocalSettings.Values["StorageShoppingCart"] = json;
                if (_dialog != null)
                {
                    _dialog.Hide(); // Esto debe cerrar el diálogo
                }
            }
        }
    }
}