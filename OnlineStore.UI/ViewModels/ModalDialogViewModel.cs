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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ModalDialogViewModel : ViewModelBase
    {

        private ContentDialog _dialog;
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
                new Quantity { Id = 6, Name = "6" }
            };
            CommandAddCart = new RelayCommand(CloseDialog);
            //MessengerService.Subscribe("CerrarDialogo", OnCerrarDialogo);

            //_modalDialogPage = new ModalDialogPage();
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
            //var quantity = SelectedQuantityItem;
            //ProductDetail productDetail = new ProductDetail();
            //productDetail.Id = Guid.NewGuid();
            //productDetail.Product = Product;
            //productDetail.TotalProduct = quantity.Id * Product.Price;
            //productDetail.Estado = 1;
            //  _modalDialogPage?.CloseDialog();
            //var dialog = Application.Current.Resources["MyDialog"] as ContentDialog;
            //if (dialog != null)
            //{
            //    dialog.Hide(); // Close dialog
            //}
            // SaveCart(productDetail);
            // Disparar el evento CloseRequested
            //CloseRequested?.Invoke(this, EventArgs.Empty);
            //Product.Send(new CloseDialogMessage());

            var dssd = _dialog;
            _dialog.Hide();

        }
        public event PropertyChangedEventHandler PropertyChanged;

       
            public void EstablecerDialogo(ContentDialog dialog)
        {
            _dialog = dialog;
        }
    }
}