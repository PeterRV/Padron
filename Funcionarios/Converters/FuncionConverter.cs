using PadronApi.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Funcionarios.Converters
{
    class FuncionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                if (number == 0)
                    return " ";

                return (from n in FuncionesSingleton.Funciones
                        where n.IdElemento == number
                        select n.Descripcion).ToList()[0];
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}