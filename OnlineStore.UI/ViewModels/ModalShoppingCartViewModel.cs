using Newtonsoft.Json;
using OnlineStore.UI.Models;
using OnlineStore.UI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OnlineStore.UI.ViewModels
{
    public class ModalShoppingCartViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Product { get; }
        public ICommand CommandGoRemove { get; }
        private ContentDialog _dialog { get; set; }
        public ModalShoppingCartViewModel()
        {

            ProductDetail = StorageShoppingCart();
            CommandGoRemove = new Helpers.RelayCommand<ProductDetail>(NavigateToGoRemove);
        }

        private async void NavigateToGoRemove(ProductDetail productDetail)
        {
            if (productDetail != null)
            {
                ProductDetail.Remove(productDetail);
                var json = JsonConvert.SerializeObject(ProductDetail);
                ApplicationData.Current.LocalSettings.Values["StorageShopping"] = json;
                if (_dialog != null)
                {
                    if (ProductDetail.Count() > 0)
                    {
                        SharedService.Instance.ShoppingCartCount = ProductDetail.Count();
                    }
                    else
                    {
                        SharedService.Instance.ShoppingCartCount = 0;
                    }
                    _dialog.Hide();
                    ContentDialog contentDialog = new ContentDialog
                    {
                        Title = "¡Listo!",
                        Content = new TextBlock
                        {
                            TextWrapping = TextWrapping.Wrap,
                            Text = "El artículo " + productDetail.Name + " ha sido retirado de tu bolsa.",
                            TextAlignment = TextAlignment.Center, // Centrar el texto
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Windows.UI.Xaml.Thickness(0, 20, 0, 20)
                        },
                        CloseButtonText = "Cerrar",
                        //CloseButtonStyle = (Style)this.Resources["GradientButtonStyle"]
                    };

                    await contentDialog.ShowAsync();
                }
            }
        }

        public void EstablecerDialogo(ContentDialog dialog)
        {
            _dialog = dialog;
        }
    }
}