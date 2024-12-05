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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ModalDialogViewModel : ViewModelBase
    {
        private ContentDialog _dialog { get; set; }
        private readonly ModalDialogPage _modalDialogPage;
        public Action CloseDialogAction { get; set; }
        public event EventHandler OnDialogRequested;
        public event EventHandler ShowDialogRequested;
        public event Action CloseRequested;
        public event EventHandler CloseDialogRequested;
        private ObservableCollection<CarouselItem> _carouselItem;
        public ObservableCollection<CarouselItem> CarouselItem
        {
            get { return _carouselItem; }
            set
            {
                _carouselItem = value;
                OnPropertyChanged(nameof(CarouselItem));
            }
        }
        public ObservableCollection<Quantity> QuantityItem { get; set; }
        public Product Product { get; set; }
        public ICommand CommandAddCart { get; set; }
        private Action _closeAction;
        private Quantity _selectedQuantityItem;
        public Quantity SelectedQuantityItem
        {
            get { return _selectedQuantityItem; }
            set
            {
                _selectedQuantityItem = value;
                OnPropertyChanged(nameof(SelectedQuantityItem));
            }
        }

        public ModalDialogViewModel()
        {
            ProductDetail = StorageShoppingCart();
            CarouselItem = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 1", Description = "Description 1" },
                new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 2", Description = "Description 2" },
                new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 3", Description = "Description 3" }
            };
            QuantityItem = new ObservableCollection<Quantity>
            {
                new Quantity { Id = 1, Name = "1" },
                new Quantity { Id = 2, Name = "2" },
                new Quantity { Id = 3, Name = "3" },
                new Quantity { Id = 4, Name = "4" },
                new Quantity { Id = 5, Name = "5" },
                new Quantity { Id = 6, Name = "6" },
                new Quantity { Id = 7, Name = "7" },
                new Quantity { Id = 8, Name = "8" },
                new Quantity { Id = 9, Name = "9" },
                new Quantity { Id = 10, Name = "10" },
                new Quantity { Id = 11, Name = "11" },
                new Quantity { Id = 12, Name = "12" }
            };
            CommandAddCart = new RelayCommand(CloseDialog);
        }

        private void OnCerrarDialogo(object parameter)
        {
            // Aquí recibimos el mensaje de "CerrarDialogo" y hacemos algo con él
            var message = parameter as string;
            if (message != null)
            {
                // Realiza las acciones necesarias, como cerrar un ContentDialog o actualizar algo en la vista
                Debug.WriteLine($"Mensaje recibido: {message}");
            }
        }

        public void CloseDialog()
        {
            var quantity = SelectedQuantityItem;
            if (quantity != null)
            {
                if (ProductDetail.Count() > 0)
                {
                    var searchProduct = ProductDetail.FirstOrDefault(f => f.Shopping.Id == Product.Id);
                    if (searchProduct == null)
                    {
                        ProductDetail productDetail = new ProductDetail();
                        productDetail.Id = Guid.NewGuid();
                        productDetail.Name = Product.Name;
                        //productDetail.Product = Product;
                        productDetail.TotalProduct = quantity.Id;
                        productDetail.TotalPriceProduct = quantity.Id * Product.Price;
                        productDetail.Estado = 1;
                        ProductDetail.Add(productDetail);
                        var json = JsonConvert.SerializeObject(ProductDetail);
                        ApplicationData.Current.LocalSettings.Values["StorageShoppingCart"] = json;
                        SyncShoppingCart();
                    }
                    else
                    {
                        double totalPriceProduct = quantity.Id * Product.Price;
                        searchProduct.TotalProduct = searchProduct.TotalProduct + quantity.Id;
                        searchProduct.TotalPriceProduct = searchProduct.TotalPriceProduct + totalPriceProduct;
                        var json = JsonConvert.SerializeObject(ProductDetail);
                        ApplicationData.Current.LocalSettings.Values["StorageShoppingCart"] = json;
                        SyncShoppingCart();
                    }
                }
                else
                {
                    ProductDetail productDetail = new ProductDetail();
                    productDetail.Id = Guid.NewGuid();
                    productDetail.Name = Product.Name;
                    //productDetail.Product = Product;
                    productDetail.TotalProduct = quantity.Id;
                    productDetail.TotalPriceProduct = quantity.Id * Product.Price;
                    productDetail.Estado = 1;
                    ProductDetail.Add(productDetail);
                    var json = JsonConvert.SerializeObject(ProductDetail);
                    ApplicationData.Current.LocalSettings.Values["StorageShoppingCart"] = json;
                    SyncShoppingCart();
                }
            }

            if (_dialog != null)
            {
                _dialog.Hide();
            }
        }

        public void EstablecerDialogo(ContentDialog dialog)
        {
            _dialog = dialog;
        }
    }
}