using System;
using System.Linq;
using System.Windows.Data;
using PadronApi.Singletons;

namespace Organismos.Converters
{
    class CiudadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                

                return (from n in PaisesSingleton.Ciudades
                        where n.IdCiudad == number
                        select n.CiudadDesc).ToList()[0];
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}