using OnlineStore.UI.Helpers;
using OnlineStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using OnlineStore.UI.Views;

namespace OnlineStore.UI.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Category> Category { get; }
       = new ObservableCollection<Category>();

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                    OnSelectionCategoryChanged();
                }
            }
        }

        public ICommand CommandSelectedCategory { get; set; }
        public ICommand CommandGoBack { get; }

        public HomeViewModel()
        {
            Title = "¿En qué categoría \npodemos ayudarte hoy?";
            CommandSelectedCategory = new RelayCommand(OnSelectionCategoryChanged);
            this.Category.Add(new Category() { Id = new Guid("dd19669a-d361-4dce-bcec-c3da967e187b"), Name = "Hombres", ImageUrl = "ms-appx:///Assets/two-men-standing-svgrepo-com.png", Estado = 1 });
            this.Category.Add(new Category() { Id = new Guid("13a81ee7-6edb-471f-98c9-1c4b68f62800"), Name = "Mujeres", ImageUrl = "ms-appx:///Assets/woman-svgrepo-com.png", Estado = 1 });
            this.Category.Add(new Category() { Id = new Guid("d7d293e6-248b-49eb-a17b-7488196caa79"), Name = "Niños", ImageUrl = "ms-appx:///Assets/team-svgrepo-com.png", Estado = 1 });
            this.Category.Add(new Category() { Id = new Guid("9b7be686-8855-46e9-b99b-0aa37b94d37d"), Name = "Deportes", ImageUrl = "ms-appx:///Assets/sport-faculty-svgrepo-com.png", Estado = 1 });
            this.Category.Add(new Category() { Id = new Guid("79e82319-e1f7-4506-b329-30f7018967cf"), Name = "Calzado", ImageUrl = "ms-appx:///Assets/bridal-shoe-svgrepo-com.png", Estado = 1 });
            this.Category.Add(new Category() { Id = new Guid("f6251291-fc36-4087-8d53-09ae9c8797d8"), Name = "Accesorios", ImageUrl = "ms-appx:///Assets/women-accesories-svgrepo-com.png", Estado = 1 });
            CommandGoBack = new RelayCommand(NavigateToGoBack);
        }

        private void OnSelectionCategoryChanged()
        {
            if (SelectedCategory != null)
            {
                var frame = Window.Current.Content as Frame;
                if (frame != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Selected: {SelectedCategory.Name}");
                    frame.Navigate(typeof(ProductTypePage), SelectedCategory);
                }
            }
        }

        private void NavigateToGoBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null)
            {
                frame.Navigate(typeof(MainPage));
            }
        }
    }
}