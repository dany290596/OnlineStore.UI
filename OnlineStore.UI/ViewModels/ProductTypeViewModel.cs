using OnlineStore.UI.Models;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using OnlineStore.UI.Helpers;
using System.Windows.Input;

namespace OnlineStore.UI.ViewModels
{
    public class ProductTypeViewModel : ViewModelBase
    {
        public ObservableCollection<ProductType> ProductType { get; }
        public ObservableCollection<ProductType> _productTypeFilter;
        public ObservableCollection<ProductType> ProductTypeFilter
        {
            get { return _productTypeFilter; }
            set
            {
                _productTypeFilter = value;
                OnPropertyChanged(nameof(ProductTypeFilter));
            }
        }
        private ProductType _selectedProductType;
        public ProductType SelectedProductType
        {
            get => _selectedProductType;
            set
            {
                if (_selectedProductType != value)
                {
                    _selectedProductType = value;
                    OnPropertyChanged(nameof(SelectedProductType));
                    OnSelectionProductTypeChanged();
                }
            }
        }

        public ICommand CommandGoBack { get; }

        public ProductTypeViewModel()
        {
            _modalShoppingCartPage = new ModalShoppingCartPage();
            Title = "¡Cuéntanos! \n¿Qué tipo de ropa buscas?";
            ProductType = new ObservableCollection<ProductType>(){
            new ProductType() { Id = new Guid("506c1f23-564c-4869-9140-558eb7d367c5"), Name = "Camisetas", ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("d81ed918-6302-480e-afac-cc5fba9263b7"), Name = "Pantalones", ImageUrl = "ms-appx:///Assets/jeans-pants-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("2da36a68-fa34-40ed-9427-fcc99fe5a857"), Name = "Camisas", ImageUrl = "ms-appx:///Assets/basketball-jersey-shirt-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("f0abed0d-1df5-4426-93cb-0177c51103da"), Name = "Suéteres", ImageUrl = "ms-appx:///Assets/parka-coat-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("11b95c25-15a4-491f-a0e3-4790748c0dfa"), Name = "Abrigos y chaquetas",  ImageUrl = "ms-appx:///Assets/coat-jacket-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("81f1e5a9-c684-4e61-913b-4fe4b43a6350"), Name = "Ropa interior",  ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("87fd937c-234e-4751-a349-ece6535b4271"), Name = "Trajes", ImageUrl = "ms-appx:///Assets/suit-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("36eb873a-df6a-473a-9714-b1551c74ef1a"), Name = "Zapatillas", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("de67481a-ea55-4d31-bb6a-d324cac02f21"), Name = "Accesorios", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, CategoryId = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b") },
            new ProductType() { Id = new Guid("309232bc-c15f-4f49-8d9b-be5c48a936c5"), Name = "Blusas", ImageUrl = "ms-appx:///Assets/blouse-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("bf4a3e56-7f35-4b9c-a8c2-f7d11dcfa383"), Name = "Jeans y pantalones", ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("0266ed2e-6b40-4e7a-985a-16738527975e"), Name = "Faldas", ImageUrl = "ms-appx:///Assets/slit-skirt-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("a6f4a21a-53e9-4c57-9df1-d9b0b340702a"), Name = "Vestidos", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("02d20d23-f951-419d-a7bb-2fd1cacf3f26"), Name = "Chaquetas y abrigos", ImageUrl = "ms-appx:///Assets/coat-jacket-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("b0a8457a-85fd-4533-808f-a94c1b868995"), Name = "Ropa interior", ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("85307630-e753-4d37-bcf9-ca1dfd2b90d9"), Name = "Lencería", ImageUrl = "ms-appx:///Assets/lingerie-underwear-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("ad0f50a2-1e17-4948-ad9a-aca6ac64c88d"), Name = "Calzado ", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("226804c0-d8bc-48b1-a945-c233d7d3b785"), Name = "Accesorios", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, CategoryId = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800") },
            new ProductType() { Id = new Guid("4ecafc40-abc2-484d-b8ee-bdfd2e4180fe"), Name = "Camisetas", ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("152eb49b-2429-4570-94b7-cc7eda2ea1d8"), Name = "Pantalones cortos/bermudas", ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("88ee12f2-7c7e-4f87-b1a1-2fe3b377a4ea"), Name = "Vestidos y faldas", ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("f2d897e0-bf42-4710-ac6e-eaf0d037813c"), Name = "Suéteres y sudaderas", ImageUrl = "ms-appx:///Assets/sweatshirt-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("a333b084-25d5-4708-b535-71235f51de6c"), Name = "Chaquetas", ImageUrl = "ms-appx:///Assets/parka-coat-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("252c822b-e8af-4af2-a785-c2dd57c286e9"), Name = "Calzado", ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("d898bde7-db10-486f-8d3a-38fa11878856"), Name = "Ropa de cama (en algunos casos)", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, CategoryId = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79") },
            new ProductType() { Id = new Guid("43f6e0f2-1321-47c2-a2c4-1ceab37408ab"), Name = "Ropa deportiva (pantalones, leggings, tops)", ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1, CategoryId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new ProductType() { Id = new Guid("9f434e2b-96ba-49a6-869b-f200ecdd2739"), Name = "Sudaderas y chaquetas deportivas", ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1, CategoryId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new ProductType() { Id = new Guid("de383de4-236e-4ee0-9479-216bf29f8906"), Name = "Zapatillas deportivas", ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, CategoryId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new ProductType() { Id = new Guid("faa56538-fd5f-4bfc-8a12-1e795b7ea9df"), Name = "Accesorios deportivos (gorras, mochilas)", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, CategoryId = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d") },
            new ProductType() { Id = new Guid("7eb78533-51a4-477a-aa9c-edbca135ea7a"), Name = "Zapatos de vestir", ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1, CategoryId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new ProductType() { Id = new Guid("bc76201a-b590-4946-95e1-93d4ef4c2d57"), Name = "Zapatillas", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, CategoryId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new ProductType() { Id = new Guid("44a157bf-7d90-44bc-9e6e-a8dc2a711a9e"), Name = "Sandalias", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1, CategoryId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new ProductType() { Id = new Guid("7b4ea839-d5cd-4a77-9ebc-1ce16026f79f"), Name = "Botas", ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1, CategoryId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new ProductType() { Id = new Guid("0c4742f0-0d61-4a69-9d80-55b405dbf2e4"), Name = "Calzado casual", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1, CategoryId = new Guid("79e82319-e1f7-4506-b329-30f7018967cf") },
            new ProductType() { Id = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2"), Name = "Gorras", ImageUrl = "ms-appx:///Assets/cap-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new ProductType() { Id = new Guid("2240a0dc-baf6-4981-9eed-f46977a6f485"), Name = "Bufandas y pañuelos", ImageUrl = "ms-appx:///Assets/scarf-cold-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new ProductType() { Id = new Guid("bdf39dfe-35d5-4c67-b4c1-b8735ed0c9d1"), Name = "Relojes", ImageUrl = "ms-appx:///Assets/watch-round-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new ProductType() { Id = new Guid("47f4e051-cbac-4437-9d1a-a4bae9e86e28"), Name = "Cinturones", ImageUrl = "ms-appx:///Assets/belt-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new ProductType() { Id = new Guid("48036648-c326-49dc-b31f-a58574a1aedb"), Name = "Bolsos y carteras", ImageUrl = "ms-appx:///Assets/bag-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") },
            new ProductType() { Id = new Guid("b22ba327-2a7d-44d7-a577-c0aef67287f9"), Name = "Gafas de sol", ImageUrl = "ms-appx:///Assets/sunglasses-svgrepo-com.png", Estado = 1, CategoryId = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8") }
            };
            ProductTypeFilter = new ObservableCollection<ProductType>();
            CommandGoBack = new RelayCommand(NavigateToGoBack);
        }

        public void Initialize(Category category)
        {
            _productTypeFilter.Clear();
            if (ProductType.Count() > 0)
            {
                foreach (var item in ProductType)
                {
                    if (category.Id == item.CategoryId)
                    {
                        _productTypeFilter.Add(item);
                    }
                }
            }
        }

        private void OnSelectionProductTypeChanged()
        {
            if (SelectedProductType != null)
            {
                var frame = Window.Current.Content as Frame;
                if (frame != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Selected: {SelectedProductType.Name}");
                    frame.Navigate(typeof(ProductPage), SelectedProductType);
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
    }
}