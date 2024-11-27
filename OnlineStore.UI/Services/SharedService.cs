using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OnlineStore.UI.Services
{
    public class SharedService
    {
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
                    Debug.WriteLine($"DialogResult actualizado: {_shoppingCartCount}");
                    OnShoppingCartCountChanged?.Invoke(_shoppingCartCount);
                }
            }
        }
    }
}