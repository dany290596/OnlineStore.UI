using Newtonsoft.Json;
using OnlineStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ModalShoppingCartViewModel : ViewModelBase
    {
        public ObservableCollection<ProductDetail> ProductDetail { get; set; }
        public ModalShoppingCartViewModel()
        {
            ProductDetail = StorageShoppingCart();
        }
    }
}