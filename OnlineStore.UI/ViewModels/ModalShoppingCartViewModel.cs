using Newtonsoft.Json;
using OnlineStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ModalShoppingCartViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Product { get; }
        public ObservableCollection<ProductDetail> ProductDetail { get; set; }
        public ICommand CommandGoRemove { get; }
        private ContentDialog _dialog { get; set; }
        public ModalShoppingCartViewModel()
        {
            ProductDetail = StorageShoppingCart();
            CommandGoRemove = new Helpers.RelayCommand<ProductDetail>(NavigateToGoRemove);
        }

        private void NavigateToGoRemove(ProductDetail productDetail)
        {
            if (productDetail != null)
            {
                ProductDetail.Remove(productDetail);
                var json = JsonConvert.SerializeObject(ProductDetail);
                ApplicationData.Current.LocalSettings.Values["StorageShoppingCart"] = json;
                if (_dialog != null)
                {
                    ShoppingCartCount = ProductDetail.Count();
                    _dialog.Hide();
                }
            }
        }

        public void EstablecerDialogo(ContentDialog dialog)
        {
            _dialog = dialog;
        }
    }
}