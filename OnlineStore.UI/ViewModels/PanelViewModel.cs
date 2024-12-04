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
        private bool _isPanelVisible;
        public ObservableCollection<Panel> Categories { get; set; }

        public PanelViewModel()
        {
            Categories = new ObservableCollection<Panel>
            {
                new Panel { 
                    Name = "Camisetas", 
                    ImageUrl = "ms-appx:///Assets//shirt-svgrepo-com-two.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("0d009bc2-d25d-4137-b46b-956a306b2806"), Name = "Camiseta Zaga 100% Algodón", Description = "La Camiseta Zaga 100% Algodón.", Price = 128.00, Stock = 9, ImageUrl = new List<string> { "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png", "ms-appx:///Assets/rb_38538.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel { 
                    Name = "Pantalones", 
                    ImageUrl = "ms-appx:///Assets//pants-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("f5f31b93-02dc-4b83-b8f3-00ba67b2c62d"), Name = "Pantalón Chino Holstone Hombre", Description = "Pantalones confeccionados con tela de gabardina en diferentes colores, es un pantalón premium handcrafted, alta costura, suavizado con stretch.", Price = 728.00, Stock = 3, ImageUrl = new List<string> { "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png", "ms-appx:///Assets/170680847_10556979.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel { 
                    Name = "Chaquetas", 
                    ImageUrl = "ms-appx:///Assets//jacket-with-pockets-svgrepo-com.png",
                    Product = new List<Product>() {
                        new Product() { Id = new Guid("042f40e5-4cf5-426a-9e7d-f8bc0f750693"), Name = "Chamarra Táctica Para Hombre Acolchada Con Múltiples Bolsill", Description = "Se trata de una chaqueta muy recomendable.", Price = 938.00, Stock = 6, ImageUrl = new List<string> { "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png", "ms-appx:///Assets/pngimg-com-jacket-PNG8033.png" }, Estado = 1, ProductTypeId = new Guid("8e909355-b1dc-46d5-9cea-35f4572accb2") },
                    }
                },
                new Panel { Name = "Zapatos", ImageUrl = "ms-appx:///Assets//sports-shoes-2-svgrepo-com.png" },
                new Panel { Name = "Camisas", ImageUrl = "ms-appx:///Assets//clo-polo-svgrepo-com.png" },
                new Panel { 
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

            // Inicializamos el panel como no visible
            IsPanelVisible = false;
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

        public bool IsPanelVisible
        {
            get => _isPanelVisible;
            set
            {
                if (_isPanelVisible != value)
                {
                    _isPanelVisible = value;
                    OnPropertyChanged(nameof(IsPanelVisible));
                }
            }
        }

        public void ToggleCategoryExpansion(Panel category)
        {
            // Si la categoría ya está seleccionada, la ocultamos
            if (SelectedCategory == category)
            {
                IsPanelVisible = false;
                SelectedCategory = null;
            }
            else
            {
                SelectedCategory = category;
            }
        }
    }
}