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
using Windows.Foundation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace OnlineStore.UI.ViewModels
{
    public class ModalShoppingCartViewModel : ViewModelBase
    {
        public ObservableCollection<Product> Product { get; }
        public ICommand CommandGoRemove { get; }
        public ICommand CommandGoShoppingOverview { get; }
        private ContentDialog _dialog { get; set; }
        public ModalShoppingCartViewModel()
        {

            ProductDetail = StorageShoppingCart();
            CommandGoRemove = new Helpers.RelayCommand<ProductDetail>(NavigateToGoRemove);
            CommandGoShoppingOverview = new Helpers.RelayCommand(NavigateToGoShoppingOverview);
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
                        CloseButtonStyle = CrearEstiloBoton()
                    };

                    await contentDialog.ShowAsync();
                }
            }
        }

        public void EstablecerDialogo(ContentDialog dialog)
        {
            _dialog = dialog;
        }

        public void NavigateToGoShoppingOverview()
        {
            _dialog.Hide();
            MostrarDetalleCompra(ProductDetail);
        }

        public async void MostrarDetalleCompra(List<ProductDetail> articulos)
        {
            // Crear el ContentDialog
            ContentDialog dialog = new ContentDialog
            {
                Title = "Detalles de Compra",
                Content = CrearContenidoDetalleCompra(articulos),
                CloseButtonText = "Aceptar",
                CloseButtonStyle = CrearEstiloBoton()
            };

            // Mostrar el ContentDialog
            await dialog.ShowAsync();
        }

        // Método para crear el contenido del ContentDialog
        private ScrollViewer CrearContenidoDetalleCompra(List<ProductDetail> articulos)
        {
            // Crear un StackPanel principal que contendrá todo
            StackPanel stackPanel = new StackPanel()
            {
                Background = new SolidColorBrush(Windows.UI.Colors.White), // Fondo blanco
                Padding = new Windows.UI.Xaml.Thickness(0)
            };

            // Verificar si no hay artículos en la compra
            if (articulos == null || articulos.Count == 0)
            {
                // Mostrar mensaje si no hay artículos
                TextBlock mensaje = new TextBlock
                {
                    Text = "No hay artículos en esta compra.",
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Windows.UI.Xaml.Thickness(0),
                    TextAlignment = TextAlignment.Center,
                };

                // Crear una card para el mensaje
                Border card = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 255, 255)), // Verde Primario
                    BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray), // Verde más oscuro
                    BorderThickness = new Windows.UI.Xaml.Thickness(1),
                    // CornerRadius = new Windows.UI.Xaml.CornerRadius(10),
                    Padding = new Windows.UI.Xaml.Thickness(20),
                    Margin = new Windows.UI.Xaml.Thickness(0)
                };

                // Agregar el mensaje dentro de la card
                card.Child = mensaje;

                // Agregar la card al StackPanel
                stackPanel.Children.Add(card);
            }
            else
            {
                // Crear el encabezado de la tabla
                StackPanel encabezadoPanel = new StackPanel
                {
                    CornerRadius = new Windows.UI.Xaml.CornerRadius(0),
                    Orientation = Orientation.Horizontal,
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 5),
                    Padding = new Windows.UI.Xaml.Thickness(5),
                    BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                    BorderThickness = new Windows.UI.Xaml.Thickness(1),
                    Background = new LinearGradientBrush
                    {
                        StartPoint = new Point(0, 0),
                        EndPoint = new Point(1, 1),
                        GradientStops =
                    {
                        new GradientStop { Color = Windows.UI.Colors.Indigo, Offset = 1 },
                        new GradientStop { Color = Windows.UI.Colors.Crimson, Offset = 0 },
                    }
                    },
                };

                // Crear y agregar los encabezados
                encabezadoPanel.Children.Add(new TextBlock
                {
                    Text = "Artículo",
                    FontSize = 16,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                    Width = 200,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left
                });
                encabezadoPanel.Children.Add(new TextBlock
                {
                    Text = "Cantidad",
                    FontSize = 16,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                    Width = 100,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
                encabezadoPanel.Children.Add(new TextBlock
                {
                    Text = "Total",
                    FontSize = 16,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.White),
                    Width = 100,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                // Agregar el encabezado al StackPanel principal
                stackPanel.Children.Add(encabezadoPanel);

                // Crear un ListView para mostrar la lista de artículos
                ListView listView = new ListView
                {
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 20),
                    // Background = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 237, 237, 237)), // Fondo gris claro para el ListView
                    BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                    BorderThickness = new Windows.UI.Xaml.Thickness(1),
                    Padding = new Windows.UI.Xaml.Thickness(0)
                };

                // Crear un StackPanel para las cards de cada artículo
                StackPanel cardStackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Spacing = 10 // Espacio entre las cards
                };

                // Añadir un StackPanel para cada artículo
                foreach (var articulo in articulos)
                {
                    // Crear la card (Border)
                    Border card = new Border
                    {
                        Background = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 237, 237, 237)),
                        BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                        BorderThickness = new Windows.UI.Xaml.Thickness(1),
                        CornerRadius = new Windows.UI.Xaml.CornerRadius(0),
                        Padding = new Windows.UI.Xaml.Thickness(10),
                        Margin = new Windows.UI.Xaml.Thickness(0)
                    };

                    // Crear un Grid dentro de la card para organizar el contenido
                    Grid cardGrid = new Grid
                    {
                        ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new Windows.UI.Xaml.GridLength(200) },
                        new ColumnDefinition { Width = new Windows.UI.Xaml.GridLength(100) },
                        new ColumnDefinition { Width = new Windows.UI.Xaml.GridLength(100) },
                        new ColumnDefinition { Width = new Windows.UI.Xaml.GridLength(100) }
                    }
                    };

                    // Crear y agregar el TextBlock para mostrar el nombre del artículo
                    cardGrid.Children.Add(new TextBlock
                    {
                        Width = 200,
                        Text = articulo.Name,
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 12,
                        FontWeight = Windows.UI.Text.FontWeights.Bold,
                        Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                        VerticalAlignment = VerticalAlignment.Center
                    });
                    Grid.SetColumn((FrameworkElement)cardGrid.Children.Last(), 0); // Columna 0

                    // Crear y agregar el TextBlock para mostrar la cantidad
                    cardGrid.Children.Add(new TextBlock
                    {
                        Width = 100,
                        Text = articulo.TotalProduct.ToString(),
                        TextAlignment = TextAlignment.Center,
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 12,
                    });
                    Grid.SetColumn((FrameworkElement)cardGrid.Children.Last(), 1); // Columna 1

                    // Crear y agregar el TextBlock para mostrar el precio
                    cardGrid.Children.Add(new TextBlock
                    {
                        Width = 100,
                        Text = articulo.TotalPriceProduct.ToString("C2"),
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 12,
                    });
                    Grid.SetColumn((FrameworkElement)cardGrid.Children.Last(), 2); // Columna 2

                    // Crear y agregar el TextBlock para mostrar el total
                    //TextBlock totalTextBlock = new TextBlock
                    //{
                    //    Width = 100,
                    //    Text = articulo.TotalPriceProduct.ToString("C2")
                    //};
                    //itemPanel.Children.Add(totalTextBlock);

                    // Agregar el StackPanel al ListView
                    card.Child = cardGrid;

                    // Añadir la card al StackPanel de cards
                    cardStackPanel.Children.Add(card);
                }

                // Agregar el ListView al StackPanel principal
                stackPanel.Children.Add(cardStackPanel);
            }

            // Calcular el total de la compra
            double totalCompra = articulos.Sum(a => a.TotalPriceProduct);

            // Agregar un TextBlock para mostrar el total de la compra
            TextBlock totalCompraTextBlock = new TextBlock
            {
                Text = "Total de la compra: " + totalCompra.ToString("C2"),
                FontWeight = Windows.UI.Text.FontWeights.Bold,
                FontSize = 26,
                Foreground = new SolidColorBrush(Windows.UI.Colors.Black),
                Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };
            stackPanel.Children.Add(totalCompraTextBlock);

            // Devolver el StackPanel envuelto en un ScrollViewer para permitir el desplazamiento
            return new ScrollViewer { Content = stackPanel };
        }

        // Método para crear el estilo con gradiente para el botón
        private Windows.UI.Xaml.Style CrearEstiloBoton()
        {
            // Crear un estilo para el botón
            var estiloBoton = new Windows.UI.Xaml.Style(typeof(Button))
            {
                Setters =
                {
                    // Definir el fondo del botón con un gradiente lineal
                    new Setter
                    {
                        Property = Button.BackgroundProperty,
                        Value = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1),
                            GradientStops =
                            {
                                new GradientStop { Color = Windows.UI.Colors.Indigo, Offset = 0 },
                                new GradientStop { Color = Windows.UI.Colors.Crimson, Offset = 1 }
                            }
                        }
                    },
                    // Establecer color del texto del botón en blanco
                    new Setter
                    {
                        Property = Button.ForegroundProperty,
                        Value = new SolidColorBrush(Windows.UI.Colors.White)
                    },
                    // Hacer el borde del botón redondeado
                    new Setter
                    {
                        Property = Button.BorderBrushProperty,
                        Value = new SolidColorBrush(Windows.UI.Colors.Transparent)
                    },
                    // Establecer el grosor del borde
                    //new Setter
                    //{
                    //    Property = Button.BorderThicknessProperty,
                    //    Value = new Windows.UI.Xaml.Thickness(0)
                    //},
                    // Establecer el radio de esquina para un borde redondeado
                    //new Setter
                    //{
                    //    Property = Button.CornerRadiusProperty,
                    //    Value = new Windows.UI.Xaml.CornerRadius(5)
                    //}
                }
            };
            return estiloBoton;
        }
    }
}