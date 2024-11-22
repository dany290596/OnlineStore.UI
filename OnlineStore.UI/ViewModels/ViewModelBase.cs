using OnlineStore.UI.Helpers;
using OnlineStore.UI.Models;
using OnlineStore.UI.Services;
using OnlineStore.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineStore.UI.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand ShowModalCommand { get; }
        public ICommand CloseModalCommand { get; }

        public ViewModelBase()
        {
            ShowModalCommand = new RelayCommand<Product>(ShowModal);
            CloseModalCommand = new RelayCommand<CarouselItem>(CloseModal);
        }

        private bool _isModalVisible;
        public bool IsModalVisible
        {
            get { return _isModalVisible; }
            set
            {
                if (_isModalVisible != value)
                {
                    _isModalVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _subtitle;

        public string Subtitle
        {
            get { return _subtitle; }
            set
            {
                if (_subtitle != value)
                {
                    _subtitle = value;
                    OnPropertyChanged();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private async void ShowModal(Product product)
        {
            var modalDialog = new ModalDialogPage
            {
                DataContext = new ModalDialogViewModel { Product = product }
            };
            modalDialog.Width = 600;   // Establece el ancho
            modalDialog.Height = 400;
            await modalDialog.ShowAsync();
        }

        private void CloseModal(CarouselItem carouselItem)
        {
        }
    }
}