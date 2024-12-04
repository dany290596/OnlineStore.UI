using OnlineStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public PanelViewModel()
        {
            MenClothing = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Camisetas",
                    ImageUrl = "ms-appx:///Assets//shirt-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("0d009bc2-d25d-4137-b46b-956a306b2806"), Name = "Camiseta Zaga 100% Algodón", Description = "La Camiseta Zaga 100% Algodón.", Price = 128.00, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Pantalones",
                    ImageUrl = "ms-appx:///Assets//pants-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("f5f31b93-02dc-4b83-b8f3-00ba67b2c62d"), Name = "Pantalón Chino Holstone Hombre", Description = "Pantalones confeccionados con tela de gabardina en diferentes colores, es un pantalón premium handcrafted, alta costura, suavizado con stretch.", Price = 728.00, Stock = 3, ImageUrl = new List<string> { "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("391e1a1e-250a-4292-b52b-3f495c21fd90"), Name = "Pantalones Tácticos Impermeables Con Varios Bolsillos", Description = "Estos pantalones de trabajo con múltiples bolsillos son la opción ideal para el desplazamiento urbano, ya que combinan un aspecto moderno con un rendimiento excepcional.", Price = 91.00, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg", "ms-appx:///Assets/pants.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Chaquetas",
                    ImageUrl = "ms-appx:///Assets//jacket-with-pockets-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("042f40e5-4cf5-426a-9e7d-f8bc0f750693"), Name = "Chamarra Táctica Para Hombre Acolchada Con Múltiples Bolsill", Description = "Se trata de una chaqueta muy recomendable.", Price = 938.00, Stock = 6, ImageUrl = new List<string> { "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                //new Panel {
                //    CategoryName = "MenClothing",
                //    Name = "Zapatos",
                //    ImageUrl = "ms-appx:///Assets//sports-shoes-2-svgrepo-com.png",
                //    Product = new List<Product>() {
                //        new Product() { Id = new Guid("9127983d-3722-4cb2-ac2e-c3041d99150e"), Name = "Zapatos De Vestir Cómodo Mocasines Caballero Casual Oxford", Description = "Estos zapatos formales tienen correas elásticas dobles en los lados para un gran ajuste y construyen una silueta fácil de llevar.", Price = 1148.00, Stock = 2, ImageUrl = new List<string> { "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //        new Product() { Id = new Guid("e32dcb3f-aa9b-4b08-8223-3d085f249db3"), Name = "Zapatos Casuales Hombre Derby Florsheim F011330103", Description = "Zapato casual tipo derby confeccionado en piel de borrego, en interiores forros de borrego suaves y transpirables, plantilla removible con esponja de poliuretano completamente acojinada.", Price = 9148.00, Stock = 276, ImageUrl = new List<string> { "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //        new Product() { Id = new Guid("7e7bc48d-4535-4ee3-b383-cdefc0cc9c19"), Name = "Zapatos Casuales Perry Ellis Suela Chunky Ligera Pe6445", Description = "Zapatos casuales súper ligeros Marca Perry Ellis.", Price = 6298.00, Stock = 52, ImageUrl = new List<string> { "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //    }
                //},
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Camisas",
                    ImageUrl = "ms-appx:///Assets//clo-polo-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("294d26a4-6d50-4057-a9c7-9e16af1a7589"), Name = "Camisas De Vestir Manga Larga Slim Fit Hombre", Description = "Hay recomendaciones de talla para la altura y el peso, así como información detallada sobre el tallaje en las fotos.", Price = 68.00, Stock = 5, ImageUrl = new List<string> { "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67b772ee-7fcb-44c6-8cf5-9594d24f91ca"), Name = "Camisa Hombre Casual Vestir Slim Fit Moda Formal Algodon", Description = "Las tallas disponibles son las que están publicadas, si no te permite seleccionar alguna talla o color es que ya no hay stock. Manejamos de la S a 2XL.", Price = 92.00, Stock = 21, ImageUrl = new List<string> { "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("45e84c7f-b3ed-473d-9531-1a968d5e20e2"), Name = "Camisa Business Casual Scappino Stretch Slim Fit 774", Description = "Camisa de vestir slim fit 96% algodón 4% elastano que le proporciona al tejido suavidad, elasticidad y propicia que la camisa en general tenga libertad de movimiento.", Price = 423.00, Stock = 73, ImageUrl = new List<string> { "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e042e54f-aa18-4697-93d9-df6cda32540e"), Name = "Camisa Cuello Mao White John Leopard Slim Fit Envío Gratis", Description = "Escoge color y talla de la primera, ponla en tu carrito de compras, elige la segunda y ponla en tu carrito de compras, así sucesivamente todas las que desees.", Price = 201.00, Stock = 4, ImageUrl = new List<string> { "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("289001b1-fd22-4526-be3b-9b64e3603439"), Name = "Camisa Hombre Manga Larga Cuadros Franela Casual Moda", Description = "Diseño: camisa de franela con botones de invierno para hombre (cuadros clásicos occidentales).", Price = 42.00, Stock = 111, ImageUrl = new List<string> { "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "MenClothing",
                    Name = "Gorras",
                    ImageUrl = "ms-appx:///Assets//cap-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("19a43857-4a31-42de-9848-87eac0b9a4e8"), Name = "Gorra Deportiva", Description = "Ideal para: Comprar ahora y llevar tu estilo al siguiente nivel.", Price = 12328.00, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6677ed00-307f-414c-9f7b-3c5239b79a67"), Name = "Gorra Deportiva Clásica Unisex", Description = "Ideal para: Correr, ciclismo, deportes al aire libre, y uso diario.", Price = 211, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0a8f1e99-2801-4f3b-8216-557fa25eef08"), Name = "Gorra de Beisbol Deportiva", Description = "Ideal para: Beisbol, fútbol, golf, y entrenamientos en exteriores.", Price = 656, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/18965881.jpg", "ms-appx:///Assets/18965881.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("8956ff30-9ffc-4e42-a27b-64cebef20fcb"), Name = "Gorra Running Pro", Description = "Ideal para: Correr, senderismo, entrenamiento al aire libre, y uso diario.", Price = 322, Stock = 22, ImageUrl = new List<string> { "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("53c20519-b9eb-4c6b-a3cc-9d75c046fc28"), Name = "Gorra Deportiva Con Logo", Description = "Ideal para: Uso diario, deportes casuales, y estilo urbano.", Price = 767, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg", "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("a0b3e1e1-4721-4654-bf2e-f7e81487be63"), Name = "Gorra de Golf Premium", Description = "Ideal para: Golf, deportes al aire libre, y actividades bajo el sol.", Price = 98, Stock = 55, ImageUrl = new List<string> { "ms-appx:///Assets/hat-visor-textile-sign-background.jpg", "ms-appx:///Assets/hat-visor-textile-sign-background.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("ca7cf43b-f4e8-4aec-b0e3-d7b4c092cb56"), Name = "Gorra Deportiva para Niños", Description = "Ideal para: Fútbol, paseos al parque, actividades al aire libre.", Price = 45, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67e6e1ea-1307-40da-85dc-47899cddc419"), Name = "Gorra Deportiva de Running Reflectante", Description = "Ideal para: Running, ciclismo, deportes nocturnos, caminatas.", Price = 334, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") }
                    }
                }
            };

            WomenClothing = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Camisetas",
                    ImageUrl = "ms-appx:///Assets//shirt-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("0d009bc2-d25d-4137-b46b-956a306b2806"), Name = "Camiseta Zaga 100% Algodón", Description = "La Camiseta Zaga 100% Algodón.", Price = 128.00, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Pantalones",
                    ImageUrl = "ms-appx:///Assets//pants-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("f5f31b93-02dc-4b83-b8f3-00ba67b2c62d"), Name = "Pantalón Chino Holstone Hombre", Description = "Pantalones confeccionados con tela de gabardina en diferentes colores, es un pantalón premium handcrafted, alta costura, suavizado con stretch.", Price = 728.00, Stock = 3, ImageUrl = new List<string> { "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Chaquetas",
                    ImageUrl = "ms-appx:///Assets//jacket-with-pockets-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("042f40e5-4cf5-426a-9e7d-f8bc0f750693"), Name = "Chamarra Táctica Para Hombre Acolchada Con Múltiples Bolsill", Description = "Se trata de una chaqueta muy recomendable.", Price = 938.00, Stock = 6, ImageUrl = new List<string> { "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                //new Panel {
                //    CategoryName = "WomenClothing",
                //    Name = "Zapatos",
                //    ImageUrl = "ms-appx:///Assets//sports-shoes-2-svgrepo-com.png",
                //    Product = new List<Product>() {
                //        new Product() { Id = new Guid("9127983d-3722-4cb2-ac2e-c3041d99150e"), Name = "Zapatos De Vestir Cómodo Mocasines Caballero Casual Oxford", Description = "Estos zapatos formales tienen correas elásticas dobles en los lados para un gran ajuste y construyen una silueta fácil de llevar.", Price = 1148.00, Stock = 2, ImageUrl = new List<string> { "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //        new Product() { Id = new Guid("e32dcb3f-aa9b-4b08-8223-3d085f249db3"), Name = "Zapatos Casuales Hombre Derby Florsheim F011330103", Description = "Zapato casual tipo derby confeccionado en piel de borrego, en interiores forros de borrego suaves y transpirables, plantilla removible con esponja de poliuretano completamente acojinada.", Price = 9148.00, Stock = 276, ImageUrl = new List<string> { "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //        new Product() { Id = new Guid("7e7bc48d-4535-4ee3-b383-cdefc0cc9c19"), Name = "Zapatos Casuales Perry Ellis Suela Chunky Ligera Pe6445", Description = "Zapatos casuales súper ligeros Marca Perry Ellis.", Price = 6298.00, Stock = 52, ImageUrl = new List<string> { "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                //    }
                //},
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Camisas",
                    ImageUrl = "ms-appx:///Assets//clo-polo-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("294d26a4-6d50-4057-a9c7-9e16af1a7589"), Name = "Camisas De Vestir Manga Larga Slim Fit Hombre", Description = "Hay recomendaciones de talla para la altura y el peso, así como información detallada sobre el tallaje en las fotos.", Price = 68.00, Stock = 5, ImageUrl = new List<string> { "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png", "ms-appx:///Assets/rb_2787.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67b772ee-7fcb-44c6-8cf5-9594d24f91ca"), Name = "Camisa Hombre Casual Vestir Slim Fit Moda Formal Algodon", Description = "Las tallas disponibles son las que están publicadas, si no te permite seleccionar alguna talla o color es que ya no hay stock. Manejamos de la S a 2XL.", Price = 92.00, Stock = 21, ImageUrl = new List<string> { "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg", "ms-appx:///Assets/men-s-formal-wear-collection.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("45e84c7f-b3ed-473d-9531-1a968d5e20e2"), Name = "Camisa Business Casual Scappino Stretch Slim Fit 774", Description = "Camisa de vestir slim fit 96% algodón 4% elastano que le proporciona al tejido suavidad, elasticidad y propicia que la camisa en general tenga libertad de movimiento.", Price = 423.00, Stock = 73, ImageUrl = new List<string> { "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg", "ms-appx:///Assets/garment-casual-material-wear-blue.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e042e54f-aa18-4697-93d9-df6cda32540e"), Name = "Camisa Cuello Mao White John Leopard Slim Fit Envío Gratis", Description = "Escoge color y talla de la primera, ponla en tu carrito de compras, elige la segunda y ponla en tu carrito de compras, así sucesivamente todas las que desees.", Price = 201.00, Stock = 4, ImageUrl = new List<string> { "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg", "ms-appx:///Assets/shirt.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("289001b1-fd22-4526-be3b-9b64e3603439"), Name = "Camisa Hombre Manga Larga Cuadros Franela Casual Moda", Description = "Diseño: camisa de franela con botones de invierno para hombre (cuadros clásicos occidentales).", Price = 42.00, Stock = 111, ImageUrl = new List<string> { "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg", "ms-appx:///Assets/baby-clothes-isolated-white-background.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel {
                    CategoryName = "WomenClothing",
                    Name = "Gorras",
                    ImageUrl = "ms-appx:///Assets//cap-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("19a43857-4a31-42de-9848-87eac0b9a4e8"), Name = "Gorra Deportiva", Description = "Ideal para: Comprar ahora y llevar tu estilo al siguiente nivel.", Price = 12328.00, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg", "ms-appx:///Assets/474.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("6677ed00-307f-414c-9f7b-3c5239b79a67"), Name = "Gorra Deportiva Clásica Unisex", Description = "Ideal para: Correr, ciclismo, deportes al aire libre, y uso diario.", Price = 211, Stock = 45, ImageUrl = new List<string> { "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg", "ms-appx:///Assets/red-cap-protection-background-clothes.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("0a8f1e99-2801-4f3b-8216-557fa25eef08"), Name = "Gorra de Beisbol Deportiva", Description = "Ideal para: Beisbol, fútbol, golf, y entrenamientos en exteriores.", Price = 656, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/18965881.jpg", "ms-appx:///Assets/18965881.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("8956ff30-9ffc-4e42-a27b-64cebef20fcb"), Name = "Gorra Running Pro", Description = "Ideal para: Correr, senderismo, entrenamiento al aire libre, y uso diario.", Price = 322, Stock = 22, ImageUrl = new List<string> { "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg", "ms-appx:///Assets/old-fedora-hat.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("53c20519-b9eb-4c6b-a3cc-9d75c046fc28"), Name = "Gorra Deportiva Con Logo", Description = "Ideal para: Uso diario, deportes casuales, y estilo urbano.", Price = 767, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg", "ms-appx:///Assets/canvas-hat-blank-fashion-sport.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("a0b3e1e1-4721-4654-bf2e-f7e81487be63"), Name = "Gorra de Golf Premium", Description = "Ideal para: Golf, deportes al aire libre, y actividades bajo el sol.", Price = 98, Stock = 55, ImageUrl = new List<string> { "ms-appx:///Assets/hat-visor-textile-sign-background.jpg", "ms-appx:///Assets/hat-visor-textile-sign-background.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("ca7cf43b-f4e8-4aec-b0e3-d7b4c092cb56"), Name = "Gorra Deportiva para Niños", Description = "Ideal para: Fútbol, paseos al parque, actividades al aire libre.", Price = 45, Stock = 0, ImageUrl = new List<string> { "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg", "ms-appx:///Assets/pretty-blue-hat.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("67e6e1ea-1307-40da-85dc-47899cddc419"), Name = "Gorra Deportiva de Running Reflectante", Description = "Ideal para: Running, ciclismo, deportes nocturnos, caminatas.", Price = 334, Stock = 32, ImageUrl = new List<string> { "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg", "ms-appx:///Assets/female-beauty-brown-cap-summer.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") }
                    }
                }
            };

            Footwear = new ObservableCollection<Panel>
            {
                new Panel {
                    CategoryName = "Footwear",
                    Name = "Zapatos",
                    ImageUrl = "ms-appx:///Assets//sports-shoes-2-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("9127983d-3722-4cb2-ac2e-c3041d99150e"), Name = "Zapatos De Vestir Cómodo Mocasines Caballero Casual Oxford", Description = "Estos zapatos formales tienen correas elásticas dobles en los lados para un gran ajuste y construyen una silueta fácil de llevar.", Price = 1148.00, Stock = 2, ImageUrl = new List<string> { "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg", "ms-appx:///Assets/1354.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("e32dcb3f-aa9b-4b08-8223-3d085f249db3"), Name = "Zapatos Casuales Hombre Derby Florsheim F011330103", Description = "Zapato casual tipo derby confeccionado en piel de borrego, en interiores forros de borrego suaves y transpirables, plantilla removible con esponja de poliuretano completamente acojinada.", Price = 9148.00, Stock = 276, ImageUrl = new List<string> { "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg", "ms-appx:///Assets/8754.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                        new Product() { Id = new Guid("7e7bc48d-4535-4ee3-b383-cdefc0cc9c19"), Name = "Zapatos Casuales Perry Ellis Suela Chunky Ligera Pe6445", Description = "Zapatos casuales súper ligeros Marca Perry Ellis.", Price = 6298.00, Stock = 52, ImageUrl = new List<string> { "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg", "ms-appx:///Assets/1352.jpg" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
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
    }
}