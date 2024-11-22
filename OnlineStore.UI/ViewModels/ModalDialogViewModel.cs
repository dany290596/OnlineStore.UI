using OnlineStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.UI.ViewModels
{
    public class ModalDialogViewModel : ViewModelBase
    {
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
        public Product Product { get; set; }
        public ModalDialogViewModel()
        {


            CarouselItem = new ObservableCollection<CarouselItem>
        {
            new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 1", Description = "Description 1" },
            new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 2", Description = "Description 2" },
            new CarouselItem { ImageUrl = "ms-appx:///Assets/old-fedora-hat.jpg", Title = "Imagen 3", Description = "Description 3" }
        };
        }
    }
}