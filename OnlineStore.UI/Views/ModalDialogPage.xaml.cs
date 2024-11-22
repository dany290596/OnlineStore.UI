using OnlineStore.UI.Models;
using OnlineStore.UI.Services;
using OnlineStore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnlineStore.UI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ModalDialogPage : ContentDialog
    {
        public ModalDialogViewModel ViewModel { get; set; }
        public Product Product { get; set; }
        public ModalDialogPage()
        {
            this.InitializeComponent();


            //var viewModel = new ModalDialogViewModel();


            //this.DataContext = new ModalDialogViewModel();


          
            //var viewModel = (ModalDialogViewModel)this.DataContext;

            //this.DataContext = viewModel;
            //viewModel.CloseRequested += OnCloseRequested;


            //viewModel.CommandAddCart = new Helpers.RelayCommand(CloseDialog);
            // Suscribirse al mensaje de cierre
            //MessengerService.Subscribe("CerrarDialogo", OnCerrarDialogo);
            //MessengerService.Subscribe("AbrirDialogo", OnAbrirDialogo);
            //this.DataContext = viewModel;

            ////// Asignar el delegado al método que cierra el ContentDialog
            //ViewModel.CloseDialogAction = CloseDialog;


            //this.DataContext = viewModel;

            // Suscribirse al evento CloseRequested del ViewModel


            ////var viewModel = new ModalDialogViewModel();
            ////viewModel.CloseRequested += ViewModel_CloseRequested;
            ////this.DataContext = viewModel;
            //this.DataContext = new ModalDialogViewModel();
            ////(this.DataContext as ModalDialogViewModel).OnDialogRequested += MyViewModel_OnDialogRequested;
            //(this.DataContext as ModalDialogViewModel).CloseDialogRequested += MyViewModel_CloseDialogRequested;
            //(this.DataContext as ModalDialogViewModel).ShowDialogRequested += MyViewModel_ShowDialogRequested;
        }

        public  void InitializeDialog(Product product)
        {
            ViewModel = new ModalDialogViewModel();
            ViewModel.Product = product;
            // Inicializa el ViewModel
            this.DataContext = ViewModel;
            ViewModel.EstablecerDialogo(this);

        }

        private void OnCloseRequested()
        {
            // Cerramos el ContentDialog
            this.Hide();  // O puedes usar 'this.Close()' dependiendo del contexto
        }

        public void CloseDialog()
        {
            this.Hide();  // Cierra el diálogo
        }

        public async void Close()
        {
            await Task.Delay(500);
            Debug.WriteLine("Cerrando el ContentDialog...");
            MyDialog.Hide();
        }
        //private void CloseDialog()
        //{
        //    Debug.WriteLine("Cerrando el ContentDialog...");
        //    //// Aquí cerramos el ContentDialog
        //    //// MyDialog.Hide();  // O usa Close() si lo prefieres
        //    //var contentDialog = (ContentDialog)Window.Current("MyDialog");
        //    //if (contentDialog != null)
        //    //{
        //    //    contentDialog.Hide();
        //    //}
        //}

        private async void MyViewModel_ShowDialogRequested(object sender, EventArgs e)
        {
            Debug.WriteLine("Cerrando el ContentDialog...");
            await MyDialog.ShowAsync();
        }

        private void MyViewModel_CloseDialogRequested(object sender, EventArgs e)
        {
            Debug.WriteLine("Cerrando el ContentDialog...");
            // Aquí ocultamos el ContentDialog
            MyDialog.Hide();  // O myContentDialog.Close() si prefieres cerrar el diálogo
        }

        private void MyViewModel_OnDialogRequested(object sender, EventArgs e)
        {
            Debug.WriteLine("Cerrando el ContentDialog...");
            // Cerrar el ContentDialog
            MyDialog.Hide();
        }

        //private void ViewModel_CloseRequested()
        //{
        //    // Close the ContentDialog when the event is triggered
        //    ContentDialog dialog = FindName("MyDialog") as ContentDialog;
        //    if (dialog != null)
        //    {
        //        dialog.Hide();
        //    }
        //}


        private  void OnCerrarDialogo(object parameter)
        {
            // Aquí puedes cerrar el ContentDialog o realizar otras acciones
             this.Hide();
        }
        private async void OnAbrirDialogo(object parameter)
        {
            // Aquí puedes abrir el ContentDialog o hacer cualquier otra acción
            // Por ejemplo, si deseas mostrar un mensaje en el ContentDialog, puedes usar el parámetro
            this.Content = parameter?.ToString() ?? "¡Dialogo abierto!";
            await this.ShowAsync();
        }
        //// Asegúrate de desuscribirte
        //protected override void OnUnload()
        //{
        //    MessengerService.Unsubscribe("CerrarDialogo", OnCerrarDialogo);
        //    base.OnUnload();
        //}



        private void ViewModel_CloseRequested(object sender, EventArgs e)
        {
            this.Hide(); // Cerrar el ContentDialog
        }
    }
}