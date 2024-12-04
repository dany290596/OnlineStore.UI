using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace OnlineStore.UI.Helpers
{
    public class StringToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed; // Si el valor no es un booleano, lo ocultamos
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.Equals(Visibility.Visible);
        }
    }
}