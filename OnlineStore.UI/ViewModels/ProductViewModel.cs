using OnlineStore.UI.Controls;
using OnlineStore.UI.Helpers;
using OnlineStore.UI.Models;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace OnlineStore.UI.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private Action _openAction;
        public Category SelectedCategory { get; set; }
        public ObservableCollection<Product> Product { get; }
        public ObservableCollection<Product> _productFilter;
        public ModalDialogPage _modalDialogPage { get; set; }
        public ModalShoppingCartPage _modalShoppingCartPage { get; set; }
        public ObservableCollection<Product> ProductFilter
        {
            get { return _productFilter; }
            set
            {
                _productFilter = value;
                OnPropertyChanged(nameof(ProductFilter));
            }
        }
        private int _pivotProductIndex;
        public int PivotProductIndex
        {
            get => _pivotProductIndex;
            set
            {
                if (_pivotProductIndex != value)
                {
                    _pivotProductIndex = value;
                    OnPropertyChanged(nameof(PivotProductIndex));
                }
            }
        }
        private TaskCompletionSource<bool> _tcs;
        public ICommand ShowModalCommand { get; }
        public ICommand CommandGoBack { get; }
        public ICommand CommandGoShoppingCart { get; }
        public ObservableCollection<ProductDetail> ProductDetail { get; set; }
        public ProductViewModel()
        {
            ProductDetail = StorageShoppingCart();
            _modalDialogPage = new ModalDialogPage();
            _modalShoppingCartPage = new ModalShoppingCartPage();
            Product = new ObservableCollection<Product>() {
            new Product() { Id = new Guid("19a43857-4a31-42de-9848-87eac0b9a4e8"), Name = "Gorra Deportiva", Description = "Ideal para: Comprar ahora y llevar tu estilo al siguiente nivel.", Price = 12328.00, Stock = 12, ImageUrl = "ms-appx:///Assets/474.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("6677ed00-307f-414c-9f7b-3c5239b79a67"), Name = "Gorra Deportiva Clásica Unisex", Description = "Ideal para: Correr, ciclismo, deportes al aire libre, y uso diario.", Price = 12328.00, Stock = 45, ImageUrl = "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("0a8f1e99-2801-4f3b-8216-557fa25eef08"), Name = "Gorra de Beisbol Deportiva", Description = "Ideal para: Beisbol, fútbol, golf, y entrenamientos en exteriores.", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/18965881.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("8956ff30-9ffc-4e42-a27b-64cebef20fcb"), Name = "Gorra Running Pro", Description = "Ideal para: Correr, senderismo, entrenamiento al aire libre, y uso diario.", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("53c20519-b9eb-4c6b-a3cc-9d75c046fc28"), Name = "Gorra Deportiva Con Logo", Description = "Ideal para: Uso diario, deportes casuales, y estilo urbano.", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("a0b3e1e1-4721-4654-bf2e-f7e81487be63"), Name = "Gorra de Golf Premium", Description = "Ideal para: Golf, deportes al aire libre, y actividades bajo el sol.", Price = 12328.00, Stock = 55, ImageUrl = "ms-appx:///Assets/hat-visor-textile-sign-background.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("ca7cf43b-f4e8-4aec-b0e3-d7b4c092cb56"), Name = "Gorra Deportiva para Niños", Description = "Ideal para: Fútbol, paseos al parque, actividades al aire libre.", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/pretty-blue-hat.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("67e6e1ea-1307-40da-85dc-47899cddc419"), Name = "Gorra Deportiva de Running Reflectante", Description = "Ideal para: Running, ciclismo, deportes nocturnos, caminatas.", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
            new Product() { Id = new Guid("bc6c1fc9-4c3e-4d4e-9600-b70423fd91ef"), Name = "Accesorios", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new Product() { Id = new Guid("bdd9447f-2358-4f3b-87a8-9d8df33c0cbf"), Name = "Blusas", Description = "", Price = 12328.00, Stock = 12, ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("c2cd43d5-eca4-461e-a78d-3e3d54eb866f"), Name = "Jeans y pantalones", Description = "", Price = 12328.00, Stock = 45, ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("1fed2c6f-bc41-4b1b-a571-2d4cf548cdea"), Name = "Faldas", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("09a7230d-7b9b-496d-9783-f1d03b851794"), Name = "Vestidos", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("d9d513aa-1d82-415d-833d-455a4554c3d9"), Name = "Chaquetas y abrigos", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("b9ee99a9-50e1-4b58-89f0-018ff9d35413"), Name = "Ropa interior", Description = "", Price = 12328.00, Stock = 55, ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("c639d691-01c5-4669-812d-7f7a97f9a795"), Name = "Lencería", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("68cd403d-acd5-4fff-9acb-1c9baf1b055a"), Name = "Calzado ", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("65b06e5e-5b1e-4c95-87b0-facd6ca94c5f"), Name = "Accesorios", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new Product() { Id = new Guid("06dd28cd-89fa-4df9-9717-3ecd083fe810"), Name = "Camisetas", Description = "", Price = 12328.00, Stock = 12, ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("77a09279-60cb-42fc-87a6-50230f3f3699"), Name = "Pantalones cortos/bermudas", Description = "", Price = 12328.00, Stock = 45, ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("e0821256-19ca-4f98-a1de-ac1ce2127780"), Name = "Vestidos y faldas", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("9dbc8090-d404-4dfb-91c6-dac7f2ce2a13"), Name = "Suéteres y sudaderas", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("03877000-0d12-43c8-a26d-c9c6f310374a"), Name = "Chaquetas", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("1dd7ec9f-8202-4ea5-a0ad-5caefd64e15e"), Name = "Calzado", Description = "", Price = 12328.00, Stock = 55, ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("fc5c2141-284e-44cb-b849-8076c8f1541c"), Name = "Ropa de cama (en algunos casos)", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new Product() { Id = new Guid("aaf3fcc2-d77d-449a-be18-1d8a6271b8fc"), Name = "Ropa deportiva (pantalones, leggings, tops)", Description = "", Price = 12328.00, Stock = 12, ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new Product() { Id = new Guid("b8638a69-3a80-4efa-b6ec-841cc081655c"), Name = "Sudaderas y chaquetas deportivas", Description = "", Price = 12328.00, Stock = 45, ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new Product() { Id = new Guid("3ac2e12a-5106-4df7-9653-ce1114cf07ea"), Name = "Zapatillas deportivas", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new Product() { Id = new Guid("01f87261-7537-44a4-a924-5c775de23f17"), Name = "Accesorios deportivos (gorras, mochilas)", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new Product() { Id = new Guid("5252ec35-d20e-4737-92b1-17b4a2853416"), Name = "Zapatos de vestir", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new Product() { Id = new Guid("32bc09c5-aaba-4ae1-830a-2a8148a4f768"), Name = "Zapatillas", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new Product() { Id = new Guid("14c0bf8b-0a7f-4246-adc7-2872d7d7d878"), Name = "Sandalias", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new Product() { Id = new Guid("49f12292-8a36-44eb-a907-c55462bc9977"), Name = "Botas", Description = "", Price = 12328.00, Stock = 55, ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new Product() { Id = new Guid("d43efcd9-e62b-4683-a432-1aa496230ec0"), Name = "Calzado casual", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new Product() { Id = new Guid("f9e43d9b-e6de-4e80-ac02-a31f329daf48"), Name = "Gorras", Description = "", Price = 12328.00, Stock = 45, ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new Product() { Id = new Guid("ba538a44-56a2-4dcb-ab2c-77461518a444"), Name = "Bufandas y pañuelos", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new Product() { Id = new Guid("701b07a4-25b7-4827-aaa0-3445f73fd90f"), Name = "Relojes", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new Product() { Id = new Guid("c2f42ece-cd10-4a16-aa9d-cd09affad928"), Name = "Cinturones", Description = "", Price = 12328.00, Stock = 32, ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new Product() { Id = new Guid("f702a9a2-889c-4987-a865-b33e3d2f0d18"), Name = "Bolsos y carteras", Description = "", Price = 12328.00, Stock = 55, ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new Product() { Id = new Guid("0a903fc3-9445-4f21-a79e-f451cf5b2be2"), Name = "Gafas de sol", Description = "", Price = 12328.00, Stock = 22, ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, ProductTypeId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") }
            };

            ProductFilter = new ObservableCollection<Product>();
            PivotProductIndex = 0;
            Title = "¡Ordena ahora!";
            CommandGoBack = new RelayCommand(NavigateToGoBack);
            CommandGoShoppingCart = new RelayCommand(NavigateToGoShoppingCart);
            ShowModalCommand = new RelayCommand<Product>(ShowModal);

            ShoppingCartCount = ProductDetail.Count();
        }

        public void Initialize(ProductType productType)
        {
            _productFilter.Clear();
            if (Product.Count() > 0)
            {
                foreach (var item in Product)
                {
                    if (productType.Id == item.ProductTypeId)
                    {
                        _productFilter.Add(item);
                    }
                }
            }
        }

        private void NavigateToGoBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(HomePage));
            }
        }

        private async void NavigateToGoShoppingCart()
        {
            //var sdcds = "";
            //var modalDialog = new ModalShoppingCartPage
            //{
            //    DataContext = new ModalShoppingCartViewModel { }
            //};
            //modalDialog.Width = 600;   // Establece el ancho
            //modalDialog.Height = 400;
            var windowWidth = Window.Current.Bounds.Width;
            var windowHeight = Window.Current.Bounds.Height;
            _modalShoppingCartPage.InitializeDialog();
            _modalShoppingCartPage.Width = windowWidth * 0.9;
            _modalShoppingCartPage.Height = windowHeight * 0.9;
            await _modalShoppingCartPage.ShowAsync();
        }

        private async void ShowModal(Product product)
        {
            var windowWidth = Window.Current.Bounds.Width;
            var windowHeight = Window.Current.Bounds.Height;
            _modalDialogPage.Width = windowWidth * 0.9;
            _modalDialogPage.Height = windowHeight * 0.9;
            _modalDialogPage.InitializeDialog(product);
            await _modalDialogPage.ShowAsync();


            //_tcs = new TaskCompletionSource<bool>();
            //_modalDialogPage = new ModalDialogPage
            //{
            //    DataContext = new ModalDialogViewModel { Product = product }
            //};
            //_modalDialogPage.Width = 600;   // Establece el ancho
            //_modalDialogPage.Height = 400;
            //await _modalDialogPage.ShowAsync();



            //_modalDialogPage.Closed += (sender, args) =>
            //{
            //    _tcs.SetResult(true);
            //};

            //bool result = await _tcs.Task;
        }
    }
}