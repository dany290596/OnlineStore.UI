using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OnlineStore.UI.Services
{
    public class SharedService : INotifyPropertyChanged
    {
        //public int ShoppingCartCount { get; set; }

        //public event EventHandler ValueChanged;

        //public void SetShoppingCartValue(int value)
        //{
        //    ShoppingCartCount = value;
        //    ValueChanged?.Invoke(this, EventArgs.Empty);
        //}
        public event Action<int> OnShoppingCartCountChanged;

        public static SharedService _instance;
        public static SharedService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SharedService();
                }
                return _instance;
            }
        }

        public int _shoppingCartCount;
        public int ShoppingCartCount
        {
            get => _shoppingCartCount;
            set
            {
                if (_shoppingCartCount != value)
                {
                    _shoppingCartCount = value;
                    Debug.WriteLine($"DialogResult actualizado: {_shoppingCartCount}");  //
                    OnShoppingCartCountChanged?.Invoke(_shoppingCartCount);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}