using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace OnlineStore.UI.Helpers
{
    public class BooleanToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool isVisible && isVisible)
            {
                return new GridLength(1, GridUnitType.Star); // Si es true, será "1*" (ocupa el espacio disponible)
            }
            return new GridLength(1, GridUnitType.Auto); // Si es false, será "Auto" (ajustará a su contenido)
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null; // No necesitamos la conversión inversa
        }
    }
}