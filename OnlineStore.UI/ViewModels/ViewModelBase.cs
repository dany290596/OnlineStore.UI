using Newtonsoft.Json;
using OnlineStore.UI.Helpers;
using OnlineStore.UI.Models;
using OnlineStore.UI.Services;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public List<ProductDetail> ProductDetail { get; set; }

        public ICommand CommandCloseModal { get; }
        public ICommand CommandCloseModalGoPreview { get; }
        public ICommand CommandGoShoppingCart { get; }
        public ModalDialogPage _modalDialogPage { get; set; }
        public ModalShoppingCartPage _modalShoppingCartPage { get; set; }

        public ViewModelBase()
        {
            SharedService.Instance.OnShoppingCartCountChanged += OnShoppingCartCountChanged;
            SyncShoppingCart();
            CommandCloseModal = new RelayCommand<CarouselItem>(CloseModal);
            CommandCloseModalGoPreview = new RelayCommand(CloseModalGoPreview);
            CommandGoShoppingCart = new RelayCommand(NavigateToGoShoppingCart);
        }
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

        public int _shoppingCartCount;
        public int ShoppingCartCount
        {
            get { return _shoppingCartCount; }
            set
            {
                if (_shoppingCartCount != value)
                {
                    _shoppingCartCount = value;
                    Debug.WriteLine($"DialogResult cambiado a: {_shoppingCartCount}");
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
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

        private void CloseModalGoPreview()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(PayPage));
            }
        }

        private async void NavigateToGoShoppingCart()
        {
            var windowWidth = Window.Current.Bounds.Width;
            var windowHeight = Window.Current.Bounds.Height;
            _modalShoppingCartPage.InitializeDialog();
            _modalShoppingCartPage.Width = windowWidth * 0.9;
            _modalShoppingCartPage.Height = windowHeight * 0.9;
            await _modalShoppingCartPage.ShowAsync();
        }

        public List<ProductDetail> StorageShoppingCart()
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("StorageShopping"))
            {
                var json = ApplicationData.Current.LocalSettings.Values["StorageShopping"] as string;
                return JsonConvert.DeserializeObject<List<ProductDetail>>(json);
            }
            return new List<ProductDetail>();
        }

        public void SyncShoppingCart()
        {
            ProductDetail = StorageShoppingCart();
            SharedService.Instance.ShoppingCartCount = ProductDetail.Count();
            ShoppingCartCount = ProductDetail.Count();
        }

        public void OnShoppingCartCountChanged(int value)
        {
            ShoppingCartCount = value;
        }
    }
}