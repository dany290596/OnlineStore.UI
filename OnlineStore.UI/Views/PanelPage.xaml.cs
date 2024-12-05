using OnlineStore.UI.Models;
using OnlineStore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Drawing;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnlineStore.UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PanelPage : Page
    {
        public PanelPage()
        {
            this.InitializeComponent();
            this.DataContext = new PanelViewModel();
        }

        private void OnCategoryClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var category = button.DataContext as Models.Panel;
                switch (category.CategoryName)
                {
                    case "MenClothing":
                        if (category != null)
                        {
                            var viewModel = (PanelViewModel)this.DataContext;
                            // Si la categoría es la misma, ocultamos el panel, si es diferente, mostramos el panel
                            if (viewModel.SelectedCategory == category)
                            {
                                viewModel.IsPanelVisibleMenClothing = false; // Ocultamos el panel si la misma categoría fue seleccionada
                                viewModel.IsPanelVisibleWomenClothing = false;
                                viewModel.IsPanelVisibleFootwear = false;
                                viewModel.SelectedCategory = null; // Desmarcamos la categoría
                            }
                            else
                            {
                                viewModel.SelectedCategory = category; // Seleccionamos una nueva categoría
                                viewModel.IsPanelVisibleMenClothing = true; // Mostramos el panel
                                viewModel.IsPanelVisibleWomenClothing = false;
                                viewModel.IsPanelVisibleFootwear = false;
                                if (viewModel.SelectedCategory != null)
                                {
                                    if (viewModel.SelectedCategory.Product != null)
                                    {
                                        if (viewModel.SelectedCategory.Product.Count() > 0)
                                        {
                                            InitializeCardGrid(viewModel.SelectedCategory, viewModel);
                                        }
                                    }
                                    else
                                    {
                                        ClearCardGrid();
                                    }
                                }
                                else
                                {
                                    ClearCardGrid();
                                }
                            }
                        }
                        break;
                    case "WomenClothing":
                        if (category != null)
                        {
                            var viewModel = (PanelViewModel)this.DataContext;
                            // Si la categoría es la misma, ocultamos el panel, si es diferente, mostramos el panel
                            if (viewModel.SelectedCategory == category)
                            {
                                viewModel.IsPanelVisibleWomenClothing = false; // Ocultamos el panel si la misma categoría fue seleccionada
                                viewModel.IsPanelVisibleMenClothing = false;
                                viewModel.IsPanelVisibleFootwear = false;
                                viewModel.SelectedCategory = null; // Desmarcamos la categoría
                            }
                            else
                            {
                                viewModel.SelectedCategory = category; // Seleccionamos una nueva categoría
                                viewModel.IsPanelVisibleWomenClothing = true; // Mostramos el panel
                                viewModel.IsPanelVisibleMenClothing = false;
                                viewModel.IsPanelVisibleFootwear = false;
                                if (viewModel.SelectedCategory != null)
                                {
                                    if (viewModel.SelectedCategory.Product != null)
                                    {
                                        if (viewModel.SelectedCategory.Product.Count() > 0)
                                        {
                                            InitializeCardGridWomenClothing(viewModel.SelectedCategory);
                                        }
                                    }
                                    else
                                    {
                                        ClearCardGrid();
                                    }
                                }
                                else
                                {
                                    ClearCardGrid();
                                }
                            }
                        }
                        break;
                    case "Footwear":
                        if (category != null)
                        {
                            var viewModel = (PanelViewModel)this.DataContext;
                            // Si la categoría es la misma, ocultamos el panel, si es diferente, mostramos el panel
                            if (viewModel.SelectedCategory == category)
                            {
                                viewModel.IsPanelVisibleFootwear = false;
                                viewModel.IsPanelVisibleMenClothing = false; // Ocultamos el panel si la misma categoría fue seleccionada
                                viewModel.IsPanelVisibleWomenClothing = false;
                                viewModel.SelectedCategory = null; // Desmarcamos la categoría
                            }
                            else
                            {
                                viewModel.SelectedCategory = category; // Seleccionamos una nueva categoría
                                viewModel.IsPanelVisibleFootwear = true;
                                viewModel.IsPanelVisibleMenClothing = false; // Mostramos el panel
                                viewModel.IsPanelVisibleWomenClothing = false;
                                if (viewModel.SelectedCategory != null)
                                {
                                    if (viewModel.SelectedCategory.Product != null)
                                    {
                                        if (viewModel.SelectedCategory.Product.Count() > 0)
                                        {
                                            InitializeCardGridFootwear(viewModel.SelectedCategory);
                                        }
                                    }
                                    else
                                    {
                                        ClearCardGrid();
                                    }
                                }
                                else
                                {
                                    ClearCardGrid();
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ClearCardGrid()
        {
            // Limpiar las filas del Grid
            CardGrid.RowDefinitions.Clear();
            CardGridWomenClothing.RowDefinitions.Clear();
            CardGridFootwear.RowDefinitions.Clear();

            CardGrid.ColumnDefinitions.Clear();
            CardGridWomenClothing.ColumnDefinitions.Clear();
            CardGridFootwear.ColumnDefinitions.Clear();

            // Limpiar los elementos hijos del Grid
            CardGrid.Children.Clear();
            CardGridWomenClothing.Children.Clear();
            CardGridFootwear.Children.Clear();
        }

        private void InitializeCardGrid(Models.Panel panel, PanelViewModel viewModel)
        {
            ClearCardGrid();

            int rowCount = 0;

            // Obtener las tarjetas desde el ViewModel
            // var cards = ((PanelViewModel)this.DataContext).Cards;
            var cards = panel.Product;

            // Calcular cuántas filas necesitamos (4 tarjetas por fila)
            rowCount = (int)Math.Ceiling(cards.Count / 4.0);

            // Definir las filas dinámicamente en el Grid
            for (int i = 0; i < rowCount; i++)
            {
                CardGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            // Definir las columnas del Grid (4 columnas)
            for (int i = 0; i < 4; i++)
            {
                CardGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Añadir las tarjetas al Grid
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];

                // Crear un nuevo Border para cada tarjeta
                Border cardBorder = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.White),
                    Padding = new Windows.UI.Xaml.Thickness(10),
                    Margin = new Windows.UI.Xaml.Thickness(5),
                    CornerRadius = new Windows.UI.Xaml.CornerRadius(5)
                };

                StackPanel stackPanel = new StackPanel();
                // Crear un FlipView para mostrar varias imágenes en forma de carrusel
                FlipView imageCarousel = new FlipView
                {
                    Height = 150,  // Altura del carrusel (puedes ajustarlo según sea necesario)
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10),  // Margen inferior
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = new SolidColorBrush(Windows.UI.Colors.White)
                };

                // Crear las imágenes dentro del carrusel (FlipView)
                foreach (var imageUrl in card.ImageUrl)  // Suponiendo que `card.ImageUrls` es una lista de URLs de imágenes
                {
                    var image = new Image
                    {
                        Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(imageUrl)),
                        Stretch = Windows.UI.Xaml.Media.Stretch.Uniform,  // Asegura que la imagen se ajuste bien
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    imageCarousel.Items.Add(image);
                }

                stackPanel.Children.Add(imageCarousel);

                // Línea horizontal separadora entre el carrusel y la información
                Border separatorLine = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.Gray), // Color de la línea
                    Height = 1,  // Grosor de la línea
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10),  // Margen alrededor de la línea
                    Opacity = 0.3
                };

                // Añadir la línea al StackPanel
                stackPanel.Children.Add(separatorLine);

                // Añadir el título, la descripción, precio y existencias
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Name,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    TextWrapping = TextWrapping.Wrap
                });

                #region SECCIÓN - DESCRIPCIÓN
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Description,
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - TALLA
                if (card.Size != null)
                {
                    if (card.Size.Count() > 0)
                    {
                        // Crear un StackPanel para mostrar la selección de talla
                        StackPanel sizeSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar la talla seleccionada
                        TextBlock selectedSizeTextBlock = new TextBlock
                        {
                            Name = "SelectedSizeTextBlock",  // Para acceder luego al texto
                            Text = "Talla: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 10,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        sizeSelectionPanel.Children.Add(selectedSizeTextBlock);

                        // Crear un StackPanel para los botones de tallas
                        StackPanel sizePanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        // Añadir las tallas como botones o cuadros con borde
                        foreach (var size in card.Size)  // card.Sizes es una lista de tamaños disponibles
                        {
                            Button sizeButton = new Button
                            {
                                FontSize = 10,
                                Content = size,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Background = new SolidColorBrush(Windows.UI.Colors.White),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(8),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Margin = new Windows.UI.Xaml.Thickness(0)
                            };

                            // Cambiar el color del botón al pasar el mouse por encima
                            sizeButton.PointerEntered += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
                            };

                            sizeButton.PointerExited += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                            };

                            // Añadir el evento para cambiar el texto de la talla seleccionada
                            sizeButton.Click += (sender, e) =>
                            {
                                selectedSizeTextBlock.Text = "Talla seleccionada: " + size;

                                // Cambiar el fondo del botón de talla seleccionada con gradiente
                                var gradient = new Windows.UI.Xaml.Media.LinearGradientBrush
                                {
                                    StartPoint = new Windows.Foundation.Point(0, 0),
                                    EndPoint = new Windows.Foundation.Point(1, 1),
                                    GradientStops =
                                    {
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 }, // Naranja
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 33, 150, 243), Offset = 1.0 }  // Azul
                                    }
                                };

                                // Cambiar el fondo del botón de talla seleccionada a un color sólido
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.Orange); // Color sólido

                                // Restaurar los colores de los demás botones
                                foreach (var btn in sizePanel.Children.OfType<Button>())
                                {
                                    if (btn != sizeButton)
                                    {
                                        btn.Background = new SolidColorBrush(Windows.UI.Colors.White);
                                    }
                                }
                            };

                            // Añadir el botón de talla al panel
                            sizePanel.Children.Add(sizeButton);
                        }

                        // Añadir el panel de tallas al StackPanel
                        sizeSelectionPanel.Children.Add(sizePanel);

                        // Añadir el panel de tallas (con el texto y los botones) al StackPanel
                        stackPanel.Children.Add(sizeSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - COLOR
                if (card.Color != null)
                {
                    if (card.Color.Count() > 0)
                    {
                        StackPanel colorSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar el color seleccionado en un cuadro
                        TextBlock selectedColorTextBlock = new TextBlock
                        {
                            Text = "Color: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            FontSize = 10,
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        colorSelectionPanel.Children.Add(selectedColorTextBlock);

                        StackPanel colorPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        foreach (var colorHex in card.Color)
                        {
                            Button colorButton = new Button
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Background = new SolidColorBrush(ColorHelper.FromArgb(
                                    255,
                                    Convert.ToByte(colorHex.Substring(1, 2), 16),
                                    Convert.ToByte(colorHex.Substring(3, 2), 16),
                                    Convert.ToByte(colorHex.Substring(5, 2), 16))),
                                //Width = 40,
                                //Height = 40,
                                Margin = new Windows.UI.Xaml.Thickness(0),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(5),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                            };
                            colorButton.Click += (s, e) =>
                            {
                                //stackPanel.Children.Remove(selectedColorBox);
                                card.SelectedColor = colorHex;

                                // Actualizar el cuadro de color con el color hexadecimal seleccionado
                                if (!string.IsNullOrEmpty(colorHex))
                                {
                                    var cleanHex = colorHex.StartsWith("#") ? colorHex.Substring(1) : colorHex;

                                    if (cleanHex.Length == 6)
                                    {
                                        var color = ColorHelper.FromArgb(
                                            255,
                                            (byte)Convert.ToInt32(cleanHex.Substring(0, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(2, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(4, 2), 16)
                                        );
                                        selectedColorTextBlock.Text = "Color seleccionado: " + color;
                                    }
                                }
                            };

                            colorPanel.Children.Add(colorButton);
                        }

                        colorSelectionPanel.Children.Add(colorPanel);
                        stackPanel.Children.Add(colorSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - PRECIO
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"${card.Price:F2}",  // Mostrar el precio con 2 decimales
                    FontSize = 20,
                    //FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0),  // Margen superior
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - EXISTENCIAS
                // Crear un TextBlock para mostrar las existencias (debajo del precio)
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"{card.Stock} unidades disponibles",  // Mostrar el número de unidades disponibles
                    FontWeight = Windows.UI.Text.FontWeights.Normal,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),  // Color gris para las existencias
                    VerticalAlignment = VerticalAlignment.Center,  // Centrar verticalmente
                    HorizontalAlignment = HorizontalAlignment.Left,  // Alinear a la derecha
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 0),  // Margen superior para separar del precio
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - BOTÓN ::: AGREGAR AL CARRITO
                // Crear un botón en la parte inferior
                Button addToCartButton = new Button
                {
                    Content = "Agregar al carrito",
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 30,
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 255, 255)) // Color personalizado (Rojo, Verde, Azul, Alfa)
                };

                // Establecer un gradiente para el fondo del botón
                var gradientBrush = new Windows.UI.Xaml.Media.LinearGradientBrush
                {
                    StartPoint = new Windows.Foundation.Point(0, 0),
                    EndPoint = new Windows.Foundation.Point(1, 1),
                    GradientStops =
                    {
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 },
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 1.0 }
                    }
                };

                // Aplicar el gradiente al fondo del botón
                addToCartButton.Background = gradientBrush;

                // Evento Click para agregar al carrito
                addToCartButton.Click += (sender, e) =>
                {
                    // Crear un nuevo producto a partir de la tarjeta
                    //Shopping shopping = new Shopping
                    //{
                    //    Name = card.Name,
                    //    Price = card.Price,
                    //};
                    if (card != null) {
                        viewModel.CloseDialog(card);
                    }
                    // Agregar el producto al carrito
                    //shoppingCart.AddProduct(productToAdd);

                    // Opcional: Mostrar un mensaje o actualizar UI (Ejemplo: notificación de éxito)
                    //var messageDialog = new Windows.UI.Popups.MessageDialog($"{productToAdd.Name} ha sido agregado al carrito.");
                    //messageDialog.ShowAsync();
                };

                // Añadir el botón al StackPanel
                stackPanel.Children.Add(addToCartButton);
                #endregion

                cardBorder.Child = stackPanel;

                // Calcular la fila y la columna
                int row = i / 4;
                int col = i % 4;

                // Añadir la tarjeta al Grid en la fila y columna correspondientes
                Grid.SetRow(cardBorder, row);
                Grid.SetColumn(cardBorder, col);

                // Añadir el Border al Grid
                CardGrid.Children.Add(cardBorder);
            }
        }

        private void InitializeCardGridWomenClothing(Models.Panel panel)
        {
            ClearCardGrid();

            int rowCount = 0;

            // Obtener las tarjetas desde el ViewModel
            // var cards = ((PanelViewModel)this.DataContext).Cards;
            var cards = panel.Product;

            // Calcular cuántas filas necesitamos (4 tarjetas por fila)
            rowCount = (int)Math.Ceiling(cards.Count / 4.0);

            // Definir las filas dinámicamente en el Grid
            for (int i = 0; i < rowCount; i++)
            {
                CardGridWomenClothing.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            // Definir las columnas del Grid (4 columnas)
            for (int i = 0; i < 4; i++)
            {
                CardGridWomenClothing.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Añadir las tarjetas al Grid
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];

                // Crear un nuevo Border para cada tarjeta
                Border cardBorder = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.White),
                    Padding = new Windows.UI.Xaml.Thickness(10),
                    Margin = new Windows.UI.Xaml.Thickness(5),
                    CornerRadius = new Windows.UI.Xaml.CornerRadius(5)
                };

                StackPanel stackPanel = new StackPanel();
                // Crear un FlipView para mostrar varias imágenes en forma de carrusel
                FlipView imageCarousel = new FlipView
                {
                    Height = 150,  // Altura del carrusel (puedes ajustarlo según sea necesario)
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10),  // Margen inferior
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = new SolidColorBrush(Windows.UI.Colors.White)
                };

                // Crear las imágenes dentro del carrusel (FlipView)
                foreach (var imageUrl in card.ImageUrl)  // Suponiendo que `card.ImageUrls` es una lista de URLs de imágenes
                {
                    var image = new Image
                    {
                        Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(imageUrl)),
                        Stretch = Windows.UI.Xaml.Media.Stretch.Uniform,  // Asegura que la imagen se ajuste bien
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    imageCarousel.Items.Add(image);
                }

                stackPanel.Children.Add(imageCarousel);

                // Línea horizontal separadora entre el carrusel y la información
                Border separatorLine = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.Gray), // Color de la línea
                    Height = 1,  // Grosor de la línea
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10),  // Margen alrededor de la línea
                    Opacity = 0.3
                };

                // Añadir la línea al StackPanel
                stackPanel.Children.Add(separatorLine);

                // Añadir el título, la descripción, precio y existencias
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Name,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    TextWrapping = TextWrapping.Wrap
                });

                #region SECCIÓN - DESCRIPCIÓN
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Description,
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - TALLA
                if (card.Size != null)
                {
                    if (card.Size.Count() > 0)
                    {
                        // Crear un StackPanel para mostrar la selección de talla
                        StackPanel sizeSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar la talla seleccionada
                        TextBlock selectedSizeTextBlock = new TextBlock
                        {
                            Name = "SelectedSizeTextBlock",  // Para acceder luego al texto
                            Text = "Talla: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 10,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        sizeSelectionPanel.Children.Add(selectedSizeTextBlock);

                        // Crear un StackPanel para los botones de tallas
                        StackPanel sizePanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        // Añadir las tallas como botones o cuadros con borde
                        foreach (var size in card.Size)  // card.Sizes es una lista de tamaños disponibles
                        {
                            Button sizeButton = new Button
                            {
                                FontSize = 10,
                                Content = size,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Background = new SolidColorBrush(Windows.UI.Colors.White),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(8),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Margin = new Windows.UI.Xaml.Thickness(0)
                            };

                            // Cambiar el color del botón al pasar el mouse por encima
                            sizeButton.PointerEntered += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
                            };

                            sizeButton.PointerExited += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                            };

                            // Añadir el evento para cambiar el texto de la talla seleccionada
                            sizeButton.Click += (sender, e) =>
                            {
                                selectedSizeTextBlock.Text = "Talla seleccionada: " + size;

                                // Cambiar el fondo del botón de talla seleccionada con gradiente
                                var gradient = new Windows.UI.Xaml.Media.LinearGradientBrush
                                {
                                    StartPoint = new Windows.Foundation.Point(0, 0),
                                    EndPoint = new Windows.Foundation.Point(1, 1),
                                    GradientStops =
                                    {
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 }, // Naranja
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 33, 150, 243), Offset = 1.0 }  // Azul
                                    }
                                };

                                // Cambiar el fondo del botón de talla seleccionada a un color sólido
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.Orange); // Color sólido

                                // Restaurar los colores de los demás botones
                                foreach (var btn in sizePanel.Children.OfType<Button>())
                                {
                                    if (btn != sizeButton)
                                    {
                                        btn.Background = new SolidColorBrush(Windows.UI.Colors.White);
                                    }
                                }
                            };

                            // Añadir el botón de talla al panel
                            sizePanel.Children.Add(sizeButton);
                        }

                        // Añadir el panel de tallas al StackPanel
                        sizeSelectionPanel.Children.Add(sizePanel);

                        // Añadir el panel de tallas (con el texto y los botones) al StackPanel
                        stackPanel.Children.Add(sizeSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - COLOR
                if (card.Color != null)
                {
                    if (card.Color.Count() > 0)
                    {
                        StackPanel colorSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar el color seleccionado en un cuadro
                        TextBlock selectedColorTextBlock = new TextBlock
                        {
                            Text = "Color: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            FontSize = 10,
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        colorSelectionPanel.Children.Add(selectedColorTextBlock);

                        StackPanel colorPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        foreach (var colorHex in card.Color)
                        {
                            Button colorButton = new Button
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Background = new SolidColorBrush(ColorHelper.FromArgb(
                                    255,
                                    Convert.ToByte(colorHex.Substring(1, 2), 16),
                                    Convert.ToByte(colorHex.Substring(3, 2), 16),
                                    Convert.ToByte(colorHex.Substring(5, 2), 16))),
                                //Width = 40,
                                //Height = 40,
                                Margin = new Windows.UI.Xaml.Thickness(0),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(5),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                            };
                            colorButton.Click += (s, e) =>
                            {
                                //stackPanel.Children.Remove(selectedColorBox);
                                card.SelectedColor = colorHex;

                                // Actualizar el cuadro de color con el color hexadecimal seleccionado
                                if (!string.IsNullOrEmpty(colorHex))
                                {
                                    var cleanHex = colorHex.StartsWith("#") ? colorHex.Substring(1) : colorHex;

                                    if (cleanHex.Length == 6)
                                    {
                                        var color = ColorHelper.FromArgb(
                                            255,
                                            (byte)Convert.ToInt32(cleanHex.Substring(0, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(2, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(4, 2), 16)
                                        );
                                        selectedColorTextBlock.Text = "Color seleccionado: " + color;
                                    }
                                }
                            };

                            colorPanel.Children.Add(colorButton);
                        }

                        colorSelectionPanel.Children.Add(colorPanel);
                        stackPanel.Children.Add(colorSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - PRECIO
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"${card.Price:F2}",  // Mostrar el precio con 2 decimales
                    FontSize = 20,
                    //FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0),  // Margen superior
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - EXISTENCIAS
                // Crear un TextBlock para mostrar las existencias (debajo del precio)
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"{card.Stock} unidades disponibles",  // Mostrar el número de unidades disponibles
                    FontWeight = Windows.UI.Text.FontWeights.Normal,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),  // Color gris para las existencias
                    VerticalAlignment = VerticalAlignment.Center,  // Centrar verticalmente
                    HorizontalAlignment = HorizontalAlignment.Left,  // Alinear a la derecha
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 0),  // Margen superior para separar del precio
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - BOTÓN ::: AGREGAR AL CARRITO
                // Crear un botón en la parte inferior
                Button addToCartButton = new Button
                {
                    Content = "Agregar al carrito",
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 30,
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 255, 255)) // Color personalizado (Rojo, Verde, Azul, Alfa)
                };

                // Establecer un gradiente para el fondo del botón
                var gradientBrush = new Windows.UI.Xaml.Media.LinearGradientBrush
                {
                    StartPoint = new Windows.Foundation.Point(0, 0),
                    EndPoint = new Windows.Foundation.Point(1, 1),
                    GradientStops =
                    {
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 },
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 1.0 }
                    }
                };

                // Aplicar el gradiente al fondo del botón
                addToCartButton.Background = gradientBrush;

                // Añadir el botón al StackPanel
                stackPanel.Children.Add(addToCartButton);
                #endregion

                cardBorder.Child = stackPanel;

                // Calcular la fila y la columna
                int row = i / 4;
                int col = i % 4;

                // Añadir la tarjeta al Grid en la fila y columna correspondientes
                Grid.SetRow(cardBorder, row);
                Grid.SetColumn(cardBorder, col);

                // Añadir el Border al Grid
                CardGridWomenClothing.Children.Add(cardBorder);
            }
        }

        private void InitializeCardGridFootwear(Models.Panel panel)
        {
            ClearCardGrid();

            int rowCount = 0;

            // Obtener las tarjetas desde el ViewModel
            // var cards = ((PanelViewModel)this.DataContext).Cards;
            var cards = panel.Product;

            // Calcular cuántas filas necesitamos (4 tarjetas por fila)
            rowCount = (int)Math.Ceiling(cards.Count / 4.0);

            // Definir las filas dinámicamente en el Grid
            for (int i = 0; i < rowCount; i++)
            {
                CardGridFootwear.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }

            // Definir las columnas del Grid (4 columnas)
            for (int i = 0; i < 4; i++)
            {
                CardGridFootwear.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            // Añadir las tarjetas al Grid
            for (int i = 0; i < cards.Count; i++)
            {
                var card = cards[i];

                // Crear un nuevo Border para cada tarjeta
                Border cardBorder = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.White),
                    Padding = new Windows.UI.Xaml.Thickness(10),
                    Margin = new Windows.UI.Xaml.Thickness(5),
                    CornerRadius = new Windows.UI.Xaml.CornerRadius(5)
                };

                StackPanel stackPanel = new StackPanel();
                // Crear un FlipView para mostrar varias imágenes en forma de carrusel
                FlipView imageCarousel = new FlipView
                {
                    Height = 150,  // Altura del carrusel (puedes ajustarlo según sea necesario)
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10),  // Margen inferior
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Background = new SolidColorBrush(Windows.UI.Colors.White)
                };

                // Crear las imágenes dentro del carrusel (FlipView)
                foreach (var imageUrl in card.ImageUrl)  // Suponiendo que `card.ImageUrls` es una lista de URLs de imágenes
                {
                    var image = new Image
                    {
                        Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(imageUrl)),
                        Stretch = Windows.UI.Xaml.Media.Stretch.Uniform,  // Asegura que la imagen se ajuste bien
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    imageCarousel.Items.Add(image);
                }

                stackPanel.Children.Add(imageCarousel);

                // Línea horizontal separadora entre el carrusel y la información
                Border separatorLine = new Border
                {
                    Background = new SolidColorBrush(Windows.UI.Colors.Gray), // Color de la línea
                    Height = 1,  // Grosor de la línea
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10),  // Margen alrededor de la línea
                    Opacity = 0.3
                };

                // Añadir la línea al StackPanel
                stackPanel.Children.Add(separatorLine);

                // Añadir el título, la descripción, precio y existencias
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Name,
                    FontWeight = Windows.UI.Text.FontWeights.Bold,
                    FontFamily = new Windows.UI.Xaml.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    TextWrapping = TextWrapping.Wrap
                });

                #region SECCIÓN - DESCRIPCIÓN
                stackPanel.Children.Add(new TextBlock
                {
                    Text = card.Description,
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - TALLA
                if (card.Size != null)
                {
                    if (card.Size.Count() > 0)
                    {
                        // Crear un StackPanel para mostrar la selección de talla
                        StackPanel sizeSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar la talla seleccionada
                        TextBlock selectedSizeTextBlock = new TextBlock
                        {
                            Name = "SelectedSizeTextBlock",  // Para acceder luego al texto
                            Text = "Talla: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            FontSize = 10,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        sizeSelectionPanel.Children.Add(selectedSizeTextBlock);

                        // Crear un StackPanel para los botones de tallas
                        StackPanel sizePanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        // Añadir las tallas como botones o cuadros con borde
                        foreach (var size in card.Size)  // card.Sizes es una lista de tamaños disponibles
                        {
                            Button sizeButton = new Button
                            {
                                FontSize = 10,
                                Content = size,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Background = new SolidColorBrush(Windows.UI.Colors.White),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(8),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                                Margin = new Windows.UI.Xaml.Thickness(0)
                            };

                            // Cambiar el color del botón al pasar el mouse por encima
                            sizeButton.PointerEntered += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
                            };

                            sizeButton.PointerExited += (sender, e) =>
                            {
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                            };

                            // Añadir el evento para cambiar el texto de la talla seleccionada
                            sizeButton.Click += (sender, e) =>
                            {
                                selectedSizeTextBlock.Text = "Talla seleccionada: " + size;

                                // Cambiar el fondo del botón de talla seleccionada con gradiente
                                var gradient = new Windows.UI.Xaml.Media.LinearGradientBrush
                                {
                                    StartPoint = new Windows.Foundation.Point(0, 0),
                                    EndPoint = new Windows.Foundation.Point(1, 1),
                                    GradientStops =
                                    {
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 }, // Naranja
                                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 33, 150, 243), Offset = 1.0 }  // Azul
                                    }
                                };

                                // Cambiar el fondo del botón de talla seleccionada a un color sólido
                                sizeButton.Background = new SolidColorBrush(Windows.UI.Colors.Orange); // Color sólido

                                // Restaurar los colores de los demás botones
                                foreach (var btn in sizePanel.Children.OfType<Button>())
                                {
                                    if (btn != sizeButton)
                                    {
                                        btn.Background = new SolidColorBrush(Windows.UI.Colors.White);
                                    }
                                }
                            };

                            // Añadir el botón de talla al panel
                            sizePanel.Children.Add(sizeButton);
                        }

                        // Añadir el panel de tallas al StackPanel
                        sizeSelectionPanel.Children.Add(sizePanel);

                        // Añadir el panel de tallas (con el texto y los botones) al StackPanel
                        stackPanel.Children.Add(sizeSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - COLOR
                if (card.Color != null)
                {
                    if (card.Color.Count() > 0)
                    {
                        StackPanel colorSelectionPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 10)
                        };

                        // Mostrar el color seleccionado en un cuadro
                        TextBlock selectedColorTextBlock = new TextBlock
                        {
                            Text = "Color: ",
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),
                            FontSize = 10,
                            Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 10)
                        };

                        colorSelectionPanel.Children.Add(selectedColorTextBlock);

                        StackPanel colorPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Spacing = 5
                        };

                        foreach (var colorHex in card.Color)
                        {
                            Button colorButton = new Button
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Background = new SolidColorBrush(ColorHelper.FromArgb(
                                    255,
                                    Convert.ToByte(colorHex.Substring(1, 2), 16),
                                    Convert.ToByte(colorHex.Substring(3, 2), 16),
                                    Convert.ToByte(colorHex.Substring(5, 2), 16))),
                                //Width = 40,
                                //Height = 40,
                                Margin = new Windows.UI.Xaml.Thickness(0),
                                BorderBrush = new SolidColorBrush(Windows.UI.Colors.LightGray),
                                Padding = new Windows.UI.Xaml.Thickness(10),
                                BorderThickness = new Windows.UI.Xaml.Thickness(1),
                                CornerRadius = new Windows.UI.Xaml.CornerRadius(5),
                                HorizontalContentAlignment = HorizontalAlignment.Center,
                                VerticalContentAlignment = VerticalAlignment.Center,
                            };
                            colorButton.Click += (s, e) =>
                            {
                                //stackPanel.Children.Remove(selectedColorBox);
                                card.SelectedColor = colorHex;

                                // Actualizar el cuadro de color con el color hexadecimal seleccionado
                                if (!string.IsNullOrEmpty(colorHex))
                                {
                                    var cleanHex = colorHex.StartsWith("#") ? colorHex.Substring(1) : colorHex;

                                    if (cleanHex.Length == 6)
                                    {
                                        var color = ColorHelper.FromArgb(
                                            255,
                                            (byte)Convert.ToInt32(cleanHex.Substring(0, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(2, 2), 16),
                                            (byte)Convert.ToInt32(cleanHex.Substring(4, 2), 16)
                                        );
                                        selectedColorTextBlock.Text = "Color seleccionado: " + color;
                                    }
                                }
                            };

                            colorPanel.Children.Add(colorButton);
                        }

                        colorSelectionPanel.Children.Add(colorPanel);
                        stackPanel.Children.Add(colorSelectionPanel);
                    }
                }
                #endregion

                #region SECCIÓN - PRECIO
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"${card.Price:F2}",  // Mostrar el precio con 2 decimales
                    FontSize = 20,
                    //FontWeight = Windows.UI.Text.FontWeights.Bold,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34)),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Windows.UI.Xaml.Thickness(0, 10, 0, 0),  // Margen superior
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - EXISTENCIAS
                // Crear un TextBlock para mostrar las existencias (debajo del precio)
                stackPanel.Children.Add(new TextBlock
                {
                    Text = $"{card.Stock} unidades disponibles",  // Mostrar el número de unidades disponibles
                    FontWeight = Windows.UI.Text.FontWeights.Normal,
                    Foreground = new SolidColorBrush(Windows.UI.Colors.Gray),  // Color gris para las existencias
                    VerticalAlignment = VerticalAlignment.Center,  // Centrar verticalmente
                    HorizontalAlignment = HorizontalAlignment.Left,  // Alinear a la derecha
                    Margin = new Windows.UI.Xaml.Thickness(0, 0, 0, 0),  // Margen superior para separar del precio
                    FontSize = 10,
                    TextWrapping = TextWrapping.Wrap
                });
                #endregion

                #region SECCIÓN - BOTÓN ::: AGREGAR AL CARRITO
                // Crear un botón en la parte inferior
                Button addToCartButton = new Button
                {
                    Content = "Agregar al carrito",
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Height = 30,
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Windows.UI.ColorHelper.FromArgb(255, 255, 255, 255)) // Color personalizado (Rojo, Verde, Azul, Alfa)
                };

                // Establecer un gradiente para el fondo del botón
                var gradientBrush = new Windows.UI.Xaml.Media.LinearGradientBrush
                {
                    StartPoint = new Windows.Foundation.Point(0, 0),
                    EndPoint = new Windows.Foundation.Point(1, 1),
                    GradientStops =
                    {
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 0.0 },
                        new Windows.UI.Xaml.Media.GradientStop { Color = Windows.UI.ColorHelper.FromArgb(255, 255, 87, 34), Offset = 1.0 }
                    }
                };

                // Aplicar el gradiente al fondo del botón
                addToCartButton.Background = gradientBrush;

                // Añadir el botón al StackPanel
                stackPanel.Children.Add(addToCartButton);
                #endregion

                cardBorder.Child = stackPanel;

                // Calcular la fila y la columna
                int row = i / 4;
                int col = i % 4;

                // Añadir la tarjeta al Grid en la fila y columna correspondientes
                Grid.SetRow(cardBorder, row);
                Grid.SetColumn(cardBorder, col);

                // Añadir el Border al Grid
                CardGridFootwear.Children.Add(cardBorder);
            }
        }
    }
}