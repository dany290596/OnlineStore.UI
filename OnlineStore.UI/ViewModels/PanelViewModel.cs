﻿using Newtonsoft.Json;
using OnlineStore.UI.Models;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OnlineStore.UI.ViewModels
{
    public class PanelViewModel : ViewModelBase
    {
        private Panel _selectedCategory;
        private bool _isPanelVisibleMenClothing;
        private bool _isPanelVisibleWomenClothing;
        private bool _isPanelVisibleFootwear;
        public ObservableCollection<Panel> MenClothing { get; set; }
        public ObservableCollection<Panel> WomenClothing { get; set; }
        public ObservableCollection<Panel> Footwear { get; set; }
        public ObservableCollection<Panel> Accessory { get; set; }

        public PanelViewModel()
        {
            ProductDetail = StorageShoppingCart();
            _modalShoppingCartPage = new ModalShoppingCartPage();
            MenClothing = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Camisetas",
                    ImageUrl = "ms-appx:///Assets//sleeveless-sleeveless-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("27c25559-cbb1-40b8-ada2-b71289004aef"), Name = "Camiseta Atletica Hombre Fruit Of The Loom Bl261cm, 4 Pza", Description = "Nuestras Camisetas Atléticas para hombre son cómodas y versátiles.", Price = 45.00, Stock = 83, ImageUrl = new List<string> { "ms-appx:///Assets/verde-escotada.png", "ms-appx:///Assets/verde-escotada.png", "ms-appx:///Assets/verde-escotada.png", "ms-appx:///Assets/verde-escotada.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("84c97856-6480-409d-91aa-befca4d46c1f"), Name = "Elcoo Camiseta Faja Playera Reductora Moldeadora Hombre", Description = "Hecho de 80% poliéster y 20% elastano. La parte superior del tanque de compresión es de excelente elasticidad con un rango de movimiento mejorado, cómodo y duradero.", Price = 654.00, Stock = 1, ImageUrl = new List<string> { "ms-appx:///Assets/ghjhjjjjjjjjj.jpg", "ms-appx:///Assets/ghjhjjjjjjjjj.jpg", "ms-appx:///Assets/ghjhjjjjjjjjj.jpg", "ms-appx:///Assets/ghjhjjjjjjjjj.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("300a38a8-0a19-49a6-856c-d67bced6386c"), Name = "Paquete De 3 Playeras Blancas Cuello Redondo Marca Rinbros", Description = "Cool Touch regula la sensación de temperatura.", Price = 27.00, Stock = 46, ImageUrl = new List<string> { "ms-appx:///Assets/undervest-wool-avocado-98-152.jpg", "ms-appx:///Assets/undervest-wool-avocado-98-152.jpg", "ms-appx:///Assets/undervest-wool-avocado-98-152.jpg", "ms-appx:///Assets/undervest-wool-avocado-98-152.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0d009bc2-d25d-4137-b46b-956a306b2806"), Name = "Camiseta Zaga 100% Algodón", Description = "La Camiseta Zaga 100% Algodón.", Price = 128.00, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/51qSxzJ+wDL._AC_UY580_.jpg", "ms-appx:///Assets/51qSxzJ+wDL._AC_UY580_.jpg", "ms-appx:///Assets/51qSxzJ+wDL._AC_UY580_.jpg", "ms-appx:///Assets/51qSxzJ+wDL._AC_UY580_.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("94b2e9ee-3c78-4042-aa83-32a63368a4c3"), Name = "Paquete De 3 Camisetas Blancas Rinbros Para Hombre", Description = "Ultra fresco neutraliza el olor del sudor.", Price = 54.00, Stock = 75, ImageUrl = new List<string> { "ms-appx:///Assets/undervest-wool-grey-98-152.jpg", "ms-appx:///Assets/undervest-wool-grey-98-152.jpg", "ms-appx:///Assets/undervest-wool-grey-98-152.jpg", "ms-appx:///Assets/undervest-wool-grey-98-152.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Pantalones",
                    ImageUrl = "ms-appx:///Assets//pants-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("f5f31b93-02dc-4b83-b8f3-00ba67b2c62d"), Name = "Pantalón Chino Holstone Hombre", Description = "Pantalones confeccionados con tela de gabardina en diferentes colores, es un pantalón premium handcrafted, alta costura, suavizado con stretch.", Price = 728.00, Stock = 3, ImageUrl = new List<string> { "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("391e1a1e-250a-4292-b52b-3f495c21fd90"), Name = "Pantalones Tácticos Impermeables Con Varios Bolsillos", Description = "Estos pantalones de trabajo con múltiples bolsillos son la opción ideal para el desplazamiento urbano, ya que combinan un aspecto moderno con un rendimiento excepcional.", Price = 91.00, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0b8d4432-ca2a-483b-82ad-f0c1d893bf95"), Name = "Pantalón American Eagle Airflex+ Skinny Rasgado Con Parches", Description = "Las tallas y colores en stock son los que aparecen debajo del precio.", Price = 32.00, Stock = 7, ImageUrl = new List<string> { "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Chaquetas",
                    ImageUrl = "ms-appx:///Assets//jacket-with-pockets-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("042f40e5-4cf5-426a-9e7d-f8bc0f750693"), Name = "Chamarra Táctica Para Hombre Acolchada Con Múltiples Bolsill", Description = "Se trata de una chaqueta muy recomendable.", Price = 938.00, Stock = 6, ImageUrl = new List<string> { "ms-appx:///Assets/61b38CrmDAL._AC_SX679_436B95.jpg", "ms-appx:///Assets/61DVdXp4spL._AC_SX679_436B95.jpg", "ms-appx:///Assets/81k0UK8XH+L._AC_SX679_436B95.jpg", "ms-appx:///Assets/71xQ8SgxGIL._AC_SX679_436B95.jpg", "ms-appx:///Assets/61J2GbxX-BL._AC_SX679_B4BCC0.jpg", "ms-appx:///Assets/61Wgl4pKOtL._AC_SX679_B4BCC0.jpg", "ms-appx:///Assets/71ADfVgB7FL._AC_SX679_B4BCC0.jpg", "ms-appx:///Assets/71wBx9xbI3L._AC_SX679_B4BCC0.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#436B95", "#B4BCC0" }, SelectedColor = "#436B95", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("333faae4-d43e-4874-9ff1-9bc5d9cc7e0e"), Name = "Chaqueta Cálida Impermeable Táctica Militar Para Hombre", Description = "Transpirable, impermeable, resistente al desgaste y al viento.", Price = 3276.00, Stock = 89, ImageUrl = new List<string> { "ms-appx:///Assets/71Db5BQOtjL._AC_SX679_F43D42.jpg", "ms-appx:///Assets/71apYQNF8IL._AC_SX679_F43D42.jpg", "ms-appx:///Assets/81MaB-NvWeL._AC_SX679_F43D42.jpg", "ms-appx:///Assets/71Ws++RiAtL._AC_SX679_F43D42.jpg", "ms-appx:///Assets/71f2TcJMEoL._AC_SX679_4997D0.jpg", "ms-appx:///Assets/71DaOzBVs2L._AC_SX679_4997D0.jpg", "ms-appx:///Assets/71mXYqq+3nL._AC_SX679_4997D0.jpg", "ms-appx:///Assets/71AX33wNynL._AC_SX679_4997D0.jpg", "ms-appx:///Assets/71wCw0nchLL._AC_SX679_A1CAF1.jpg", "ms-appx:///Assets/71f2C0f5s-L._AC_SX679_A1CAF1.jpg", "ms-appx:///Assets/81dUayX1cUL._AC_SX679_A1CAF1.jpg", "ms-appx:///Assets/711GUFFXZ-L._AC_SX679_A1CAF1.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#F43D42", "#4997D0", "#A1CAF1" }, SelectedColor = "#F43D42", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("c7446fad-d862-4b27-94ed-470c09db019c"), Name = "Calvin Klein - chamarra ligera y resistente al agua para hombre", Description = "Rendimiento de calidad: chaquetas con bolsillo en el pecho y 2 bolsillos inferiores ribeteados con cierres de cierre para mantener tus objetos de valor seguros; puños y dobladillo con bandas elásticas que proporcionan un aspecto a medida sin sacrificar la comodidad.", Price = 765.00, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/000000.jpg", "ms-appx:///Assets/71yrDzPD+WS._AC_SX679_000000.jpg", "ms-appx:///Assets/71Jbve7T7qS._AC_SX679_000000.jpg", "ms-appx:///Assets/61JdQ1dCvjS._AC_SX679_000000.jpg", "ms-appx:///Assets/81DaGa6oNYL._AC_SX569_FF0000.jpg",  "ms-appx:///Assets/71eXWx5cMVS._AC_SX679_FF0000.jpg", "ms-appx:///Assets/71vrbqBuygS._AC_SX679_FF0000.jpg", "ms-appx:///Assets/81Z7PuVs6TL._AC_SX569_FF0000.jpg", "ms-appx:///Assets/71yH4-yt0uL._AC_SX679_FFFFFF.jpg", "ms-appx:///Assets/71slRPx881L._AC_SX679_FFFFFF.jpg", "ms-appx:///Assets/81zx12BIpTL._AC_SX679_FFFFFF.jpg", "ms-appx:///Assets/81PSFy4IJWL._AC_SX679_FFFFFF.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF" }, SelectedColor = "#FF0000", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("aa9ecc67-2617-4e8d-94fe-7ba83f143f28"), Name = "Hurley - chamarra con capucha para hombre, ligera, con forro sherpa para exteriores, con capucha y botones (S-XL)", Description = "Elegante chamarra deportiva con capucha para hombre para hombre; nuestra mezcla única de estilo y rendimiento nos convierte en un punto de referencia global para el rendimiento dentro y fuera del agua.", Price = 32.00, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/71eqZaZCFVL._AC_SX569_593319.jpg", "ms-appx:///Assets/710PZsz2XrL._AC_SX569_593319.jpg", "ms-appx:///Assets/71rYZmGgcUL._AC_SX569_593319.jpg", "ms-appx:///Assets/714bBphvNmL._AC_SX569_593319.jpg", "ms-appx:///Assets/61FHmr8yZpL._AC_SX569_000000.jpg", "ms-appx:///Assets/61tnSTc4sqL._AC_SX569_000000.jpg", "ms-appx:///Assets/71QV0NYMXyL._AC_SX569_000000.jpg", "ms-appx:///Assets/61OPinFINyL._AC_SX569_000000.jpg", "ms-appx:///Assets/61PT8-khLzL._AC_SX569_555555.jpg", "ms-appx:///Assets/81MOSxH7niL._AC_SX569_555555.jpg", "ms-appx:///Assets/71+h1ddoR6L._AC_SX569_555555.jpg", "ms-appx:///Assets/71DzAmDszwL._AC_SX569_555555.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#593319", "#000000", "#555555" }, SelectedColor = "#593319", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Camisas",
                    ImageUrl = "ms-appx:///Assets//clo-polo-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("294d26a4-6d50-4057-a9c7-9e16af1a7589"), Name = "Camisas De Vestir Manga Larga Slim Fit Hombre", Description = "Hay recomendaciones de talla para la altura y el peso, así como información detallada sobre el tallaje en las fotos.", Price = 68.00, Stock = 5, ImageUrl = new List<string> { "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67b772ee-7fcb-44c6-8cf5-9594d24f91ca"), Name = "Camisa Hombre Casual Vestir Slim Fit Moda Formal Algodon", Description = "Las tallas disponibles son las que están publicadas, si no te permite seleccionar alguna talla o color es que ya no hay stock. Manejamos de la S a 2XL.", Price = 92.00, Stock = 21, ImageUrl = new List<string> { "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("45e84c7f-b3ed-473d-9531-1a968d5e20e2"), Name = "Camisa Business Casual Scappino Stretch Slim Fit 774", Description = "Camisa de vestir slim fit 96% algodón 4% elastano que le proporciona al tejido suavidad, elasticidad y propicia que la camisa en general tenga libertad de movimiento.", Price = 423.00, Stock = 73, ImageUrl = new List<string> { "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e042e54f-aa18-4697-93d9-df6cda32540e"), Name = "Camisa Cuello Mao White John Leopard Slim Fit Envío Gratis", Description = "Escoge color y talla de la primera, ponla en tu carrito de compras, elige la segunda y ponla en tu carrito de compras, así sucesivamente todas las que desees.", Price = 201.00, Stock = 4, ImageUrl = new List<string> { "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("289001b1-fd22-4526-be3b-9b64e3603439"), Name = "Camisa Hombre Manga Larga Cuadros Franela Casual Moda", Description = "Diseño: camisa de franela con botones de invierno para hombre (cuadros clásicos occidentales).", Price = 42.00, Stock = 111, ImageUrl = new List<string> { "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Gorras",
                    ImageUrl = "ms-appx:///Assets//cap-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("19a43857-4a31-42de-9848-87eac0b9a4e8"), Name = "Gorra Deportiva", Description = "Ideal para: Comprar ahora y llevar tu estilo al siguiente nivel.", Price = 12328.00, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6677ed00-307f-414c-9f7b-3c5239b79a67"), Name = "Gorra Deportiva Clásica Unisex", Description = "Ideal para: Correr, ciclismo, deportes al aire libre, y uso diario.", Price = 211, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0a8f1e99-2801-4f3b-8216-557fa25eef08"), Name = "Gorra de Beisbol Deportiva", Description = "Ideal para: Beisbol, fútbol, golf, y entrenamientos en exteriores.", Price = 656, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/18965881.jpg", "ms-appx:///Assets/18965881.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("8956ff30-9ffc-4e42-a27b-64cebef20fcb"), Name = "Gorra Running Pro", Description = "Ideal para: Correr, senderismo, entrenamiento al aire libre, y uso diario.", Price = 322, Stock = 22, ImageUrl = new List<string> { "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("53c20519-b9eb-4c6b-a3cc-9d75c046fc28"), Name = "Gorra Deportiva Con Logo", Description = "Ideal para: Uso diario, deportes casuales, y estilo urbano.", Price = 767, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg", "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("a0b3e1e1-4721-4654-bf2e-f7e81487be63"), Name = "Gorra de Golf Premium", Description = "Ideal para: Golf, deportes al aire libre, y actividades bajo el sol.", Price = 98, Stock = 55, ImageUrl = new List<string> { "ms-appx:///Assets/hat-visor-textile-sign-background.jpg", "ms-appx:///Assets/hat-visor-textile-sign-background.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("ca7cf43b-f4e8-4aec-b0e3-d7b4c092cb56"), Name = "Gorra Deportiva para Niños", Description = "Ideal para: Fútbol, paseos al parque, actividades al aire libre.", Price = 45, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67e6e1ea-1307-40da-85dc-47899cddc419"), Name = "Gorra Deportiva de Running Reflectante", Description = "Ideal para: Running, ciclismo, deportes nocturnos, caminatas.", Price = 334, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6d07f9d6-39ed-4dbe-8435-1e60c7b7da61"), Name = "Gorras Cap Carrier 6 Pack Woodcamo Color Camuflaje", Description = "Este accesorio cuenta con capacidad para seis gorras, incluye ojales de ventilación, una agarradera de plástico y una correa de hombro desmontable para un transporte cómodo.", Price = 980, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/ttttt.png", "ms-appx:///Assets/ttttt.png", "ms-appx:///Assets/ttttt.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") }
                    }
                }
            };

            WomenClothing = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Blusas",
                    ImageUrl = "ms-appx:///Assets//women-sleeveless-shirt-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("a08d93a1-5d25-4438-9034-d006ab40d922"), Name = "Blusa Niña 2/8", Description = "Divertida y adorable blusa con estampado de caritas de corazones para niñas de 2 a 8 años. Perfecta para lucir tierna y a la moda.", Price = 124.00, Stock = 675, ImageUrl = new List<string> { "ms-appx:///Assets/1400233242-5.jpeg", "ms-appx:///Assets/1400233242-5.jpeg", "ms-appx:///Assets/1400233242-5.jpeg", "ms-appx:///Assets/1400233242-5.jpeg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("b22ba027-b39f-497d-889a-c9d40fc622c4"), Name = "Blusa chontal de Tabasco", Description = "Las blusas chontales tabasqueñas tradicionales tienen como característica principal un tira bordada a mano de colores variados sobre un fondo negro, ejemplo de ello es esta blusa realizada por la artesana chontal tabasqueña Yamili Pérez.", Price = 188.00, Stock = 394, ImageUrl = new List<string> { "ms-appx:///Assets/blusa-chontal-de-tabasco.jpg", "ms-appx:///Assets/blusa-chontal-de-tabasco.jpg", "ms-appx:///Assets/blusa-chontal-de-tabasco.jpg", "ms-appx:///Assets/blusa-chontal-de-tabasco.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("18afe2f8-5d5d-47e4-b3c5-75097132cbdc"), Name = "Blusa Casual Tipo Sueter Maria Bela Modelo Moldova", Description = "Las tallas son flexibles debido a la tela y al diseño de las mismas, los contornos de pecho, cintura y cadera que habitualmente son los que más definen la talla, no son limitantes.", Price = 984.00, Stock = 896, ImageUrl = new List<string> { "ms-appx:///Assets/78876756.jpg", "ms-appx:///Assets/78876756.jpg", "ms-appx:///Assets/78876756.jpg", "ms-appx:///Assets/78876756.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("94e409e8-04a0-4468-a8c4-778f8c853103"), Name = "Blusa Casual Maria Bela Modelo Luxor", Description = "La blusa casual Maria Bela modelo Luxor es la prenda perfecta para mujeres que buscan estilo y comodidad en una sola pieza.", Price = 187.00, Stock = 321, ImageUrl = new List<string> { "ms-appx:///Assets/blusaninaconmona10094343034011009429.jpg", "ms-appx:///Assets/blusaninaconmona10094343034011009429.jpg", "ms-appx:///Assets/blusaninaconmona10094343034011009429.jpg", "ms-appx:///Assets/blusaninaconmona10094343034011009429.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Pantalones",
                    ImageUrl = "ms-appx:///Assets//pants-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("f5f31b93-02dc-4b83-b8f3-00ba67b2c62d"), Name = "Pantalón Chino Holstone Hombre", Description = "Pantalones confeccionados con tela de gabardina en diferentes colores, es un pantalón premium handcrafted, alta costura, suavizado con stretch.", Price = 728.00, Stock = 3, ImageUrl = new List<string> { "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("391e1a1e-250a-4292-b52b-3f495c21fd90"), Name = "Pantalones Tácticos Impermeables Con Varios Bolsillos", Description = "Estos pantalones de trabajo con múltiples bolsillos son la opción ideal para el desplazamiento urbano, ya que combinan un aspecto moderno con un rendimiento excepcional.", Price = 91.00, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0b8d4432-ca2a-483b-82ad-f0c1d893bf95"), Name = "Pantalón American Eagle Airflex+ Skinny Rasgado Con Parches", Description = "Las tallas y colores en stock son los que aparecen debajo del precio.", Price = 32.00, Stock = 7, ImageUrl = new List<string> { "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png", "ms-appx:///Assets/trousers.png" }, Estado = 1, Size = new List<string> { "28", "30", "32", "34", "36" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Chaquetas",
                    ImageUrl = "ms-appx:///Assets//jacket-with-zipper-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("042f40e5-4cf5-426a-9e7d-f8bc0f750693"), Name = "Chamarra Táctica Para Mujer Acolchada Con Múltiples Bolsill", Description = "Se trata de una chaqueta muy recomendable.", Price = 938.00, Stock = 6, ImageUrl = new List<string> { "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Camisas",
                    ImageUrl = "ms-appx:///Assets//clo-polo-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("294d26a4-6d50-4057-a9c7-9e16af1a7589"), Name = "Camisas De Vestir Manga Larga Slim Fit Hombre", Description = "Hay recomendaciones de talla para la altura y el peso, así como información detallada sobre el tallaje en las fotos.", Price = 68.00, Stock = 5, ImageUrl = new List<string> { "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67b772ee-7fcb-44c6-8cf5-9594d24f91ca"), Name = "Camisa Hombre Casual Vestir Slim Fit Moda Formal Algodon", Description = "Las tallas disponibles son las que están publicadas, si no te permite seleccionar alguna talla o color es que ya no hay stock. Manejamos de la S a 2XL.", Price = 92.00, Stock = 21, ImageUrl = new List<string> { "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("45e84c7f-b3ed-473d-9531-1a968d5e20e2"), Name = "Camisa Business Casual Scappino Stretch Slim Fit 774", Description = "Camisa de vestir slim fit 96% algodón 4% elastano que le proporciona al tejido suavidad, elasticidad y propicia que la camisa en general tenga libertad de movimiento.", Price = 423.00, Stock = 73, ImageUrl = new List<string> { "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e042e54f-aa18-4697-93d9-df6cda32540e"), Name = "Camisa Cuello Mao White John Leopard Slim Fit Envío Gratis", Description = "Escoge color y talla de la primera, ponla en tu carrito de compras, elige la segunda y ponla en tu carrito de compras, así sucesivamente todas las que desees.", Price = 201.00, Stock = 4, ImageUrl = new List<string> { "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("289001b1-fd22-4526-be3b-9b64e3603439"), Name = "Camisa Hombre Manga Larga Cuadros Franela Casual Moda", Description = "Diseño: camisa de franela con botones de invierno para hombre (cuadros clásicos occidentales).", Price = 42.00, Stock = 111, ImageUrl = new List<string> { "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Gorras",
                    ImageUrl = "ms-appx:///Assets//cap-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("19a43857-4a31-42de-9848-87eac0b9a4e8"), Name = "Gorra Deportiva", Description = "Ideal para: Comprar ahora y llevar tu estilo al siguiente nivel.", Price = 12328.00, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6677ed00-307f-414c-9f7b-3c5239b79a67"), Name = "Gorra Deportiva Clásica Unisex", Description = "Ideal para: Correr, ciclismo, deportes al aire libre, y uso diario.", Price = 211, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0a8f1e99-2801-4f3b-8216-557fa25eef08"), Name = "Gorra de Beisbol Deportiva", Description = "Ideal para: Beisbol, fútbol, golf, y entrenamientos en exteriores.", Price = 656, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/18965881.jpg", "ms-appx:///Assets/18965881.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("8956ff30-9ffc-4e42-a27b-64cebef20fcb"), Name = "Gorra Running Pro", Description = "Ideal para: Correr, senderismo, entrenamiento al aire libre, y uso diario.", Price = 322, Stock = 22, ImageUrl = new List<string> { "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("53c20519-b9eb-4c6b-a3cc-9d75c046fc28"), Name = "Gorra Deportiva Con Logo", Description = "Ideal para: Uso diario, deportes casuales, y estilo urbano.", Price = 767, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg", "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("a0b3e1e1-4721-4654-bf2e-f7e81487be63"), Name = "Gorra de Golf Premium", Description = "Ideal para: Golf, deportes al aire libre, y actividades bajo el sol.", Price = 98, Stock = 55, ImageUrl = new List<string> { "ms-appx:///Assets/hat-visor-textile-sign-background.jpg", "ms-appx:///Assets/hat-visor-textile-sign-background.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("ca7cf43b-f4e8-4aec-b0e3-d7b4c092cb56"), Name = "Gorra Deportiva para Niños", Description = "Ideal para: Fútbol, paseos al parque, actividades al aire libre.", Price = 45, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67e6e1ea-1307-40da-85dc-47899cddc419"), Name = "Gorra Deportiva de Running Reflectante", Description = "Ideal para: Running, ciclismo, deportes nocturnos, caminatas.", Price = 334, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6d07f9d6-39ed-4dbe-8435-1e60c7b7da61"), Name = "Gorras Cap Carrier 6 Pack Woodcamo Color Camuflaje", Description = "Este accesorio cuenta con capacidad para seis gorras, incluye ojales de ventilación, una agarradera de plástico y una correa de hombro desmontable para un transporte cómodo.", Price = 980, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/ttttt.png", "ms-appx:///Assets/ttttt.png", "ms-appx:///Assets/ttttt.png" }, Estado = 1, Size = new List<string> { "S", "M", "L", "XL", "XXL" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, SelectedColor = "0000FF", ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") }
                    }
                }
            };

            Footwear = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "Footwear",
                    Name = "Zapatos de \nHombre",
                    ImageUrl = "ms-appx:///Assets//sports-shoes-2-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("9127983d-3722-4cb2-ac2e-c3041d99150e"), Name = "Zapatos De Vestir Cómodo Mocasines Caballero Casual Oxford", Description = "Estos zapatos formales tienen correas elásticas dobles en los lados para un gran ajuste y construyen una silueta fácil de llevar.", Price = 1148.00, Stock = 2, ImageUrl = new List<string> { "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg" }, Estado = 1, Size = new List<string> { "23", "24", "25", "26", "27", "28" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e32dcb3f-aa9b-4b08-8223-3d085f249db3"), Name = "Zapatos Casuales Hombre Derby Florsheim F011330103", Description = "Zapato casual tipo derby confeccionado en piel de borrego, en interiores forros de borrego suaves y transpirables, plantilla removible con esponja de poliuretano completamente acojinada.", Price = 9148.00, Stock = 276, ImageUrl = new List<string> { "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg" }, Estado = 1, Size = new List<string> { "23", "24", "25", "26", "27", "28" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("7e7bc48d-4535-4ee3-b383-cdefc0cc9c19"), Name = "Zapatos Casuales Perry Ellis Suela Chunky Ligera Pe6445", Description = "Zapatos casuales súper ligeros Marca Perry Ellis.", Price = 6298.00, Stock = 52, ImageUrl = new List<string> { "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg" }, Estado = 1, Size = new List<string> { "23", "24", "25", "26", "27", "28" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("737dc8c5-834a-44bd-bb84-af3df833aa4f"), Name = "Zapato De Seguridad Tenis Botas Industrial Para Hombre", Description = "No comprometas tu seguridad, elige los Tenis De Seguridad Industrial Hombre Zapatos De Kevlar de Huella.", Price = 1285.00, Stock = 5, ImageUrl = new List<string> { "ms-appx:///Assets/eeeee.jpg", "ms-appx:///Assets/eeeee.jpg", "ms-appx:///Assets/eeeee.jpg", "ms-appx:///Assets/eeeee.jpg" }, Estado = 1, Size = new List<string> { "23", "24", "25", "26", "27", "28" }, Color = new List<string> { "#FF0000", "#000000", "#FFFFFF", "#0000FF", "#FFFF00", "#00FF00", "#FF5722" }, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "Footwear",
                    Name = "Zapatos de \nMujer",
                    ImageUrl = "ms-appx:///Assets//high-heel-shoes-svgrepo-com.png"
                },
                new Panel {
                    CategoryName = "Footwear",
                    Name = "Zapatos de \nNiño",
                    ImageUrl = "ms-appx:///Assets//sportive-shoe-svgrepo-com.png"
                }
            };

            Accessory = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "Accessory",
                    Name = "Cinturones",
                    ImageUrl = "ms-appx:///Assets//belt-svgrepo-com-tho.png",
                },
                new Panel {
                    CategoryName = "Accessory",
                    Name = "Gafas de Sol",
                    ImageUrl = "ms-appx:///Assets//glasses-eyeglasses-svgrepo-com.png",
                },
                new Panel {
                    CategoryName = "Accessory",
                    Name = "Guantes",
                    ImageUrl = "ms-appx:///Assets//pair-of-gloves-svgrepo-com.png",
                }
            };

            // Inicializamos el panel como no visible
            IsPanelVisibleMenClothing = false;
            IsPanelVisibleWomenClothing = false;
            IsPanelVisibleFootwear = false;
        }

        public Panel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        public bool IsPanelVisibleMenClothing
        {
            get => _isPanelVisibleMenClothing;
            set
            {
                if (_isPanelVisibleMenClothing != value)
                {
                    _isPanelVisibleMenClothing = value;
                    OnPropertyChanged(nameof(IsPanelVisibleMenClothing));
                }
            }
        }

        public bool IsPanelVisibleWomenClothing
        {
            get => _isPanelVisibleWomenClothing;
            set
            {
                if (_isPanelVisibleWomenClothing != value)
                {
                    _isPanelVisibleWomenClothing = value;
                    OnPropertyChanged(nameof(IsPanelVisibleWomenClothing));
                }
            }
        }

        public bool IsPanelVisibleFootwear
        {
            get => _isPanelVisibleFootwear;
            set
            {
                if (_isPanelVisibleFootwear != value)
                {
                    _isPanelVisibleFootwear = value;
                    OnPropertyChanged(nameof(IsPanelVisibleFootwear));
                }
            }
        }

        public void ToggleCategoryExpansion(Panel category)
        {
            // Si la categoría ya está seleccionada, la ocultamos
            if (SelectedCategory == category)
            {
                IsPanelVisibleMenClothing = false;
                IsPanelVisibleWomenClothing = false;
                IsPanelVisibleFootwear = false;
                SelectedCategory = null;
            }
            else
            {
                SelectedCategory = category;
            }
        }

        public void CloseDialog(Product product, int selectedArticle)
        {
            if (ProductDetail != null)
            {
                if (ProductDetail.Count() > 0)
                {
                    var searchProduct = ProductDetail.FirstOrDefault(f => f.Shopping.Id == product.Id);
                    if (searchProduct == null)
                    {
                        ProductDetail productDetail = new ProductDetail();
                        productDetail.Id = Guid.NewGuid();
                        productDetail.Name = product.Name;
                        productDetail.Shopping = new Shopping()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Stock = product.Stock
                        };
                        productDetail.TotalProduct = selectedArticle;
                        productDetail.TotalPriceProduct = selectedArticle * product.Price;
                        productDetail.Estado = 1;
                        ProductDetail.Add(productDetail);
                        var json = JsonConvert.SerializeObject(ProductDetail);
                        ApplicationData.Current.LocalSettings.Values["StorageShopping"] = json;
                        SyncShoppingCart();
                    }
                    else
                    {
                        double totalPriceProduct = selectedArticle * product.Price;
                        searchProduct.TotalProduct = searchProduct.TotalProduct + selectedArticle;
                        searchProduct.TotalPriceProduct = searchProduct.TotalPriceProduct + totalPriceProduct;
                        var json = JsonConvert.SerializeObject(ProductDetail);
                        ApplicationData.Current.LocalSettings.Values["StorageShopping"] = json;
                        SyncShoppingCart();
                    }
                }
                else
                {
                    ProductDetail productDetail = new ProductDetail();
                    productDetail.Id = Guid.NewGuid();
                    productDetail.Name = product.Name;
                    productDetail.Shopping = new Shopping()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    };
                    productDetail.TotalProduct = selectedArticle;
                    productDetail.TotalPriceProduct = selectedArticle * product.Price;
                    productDetail.Estado = 1;
                    ProductDetail.Add(productDetail);
                    var json = JsonConvert.SerializeObject(ProductDetail);
                    ApplicationData.Current.LocalSettings.Values["StorageShopping"] = json;
                    SyncShoppingCart();
                }
            }
        }
    }
}