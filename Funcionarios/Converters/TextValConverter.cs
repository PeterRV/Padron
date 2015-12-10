using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Funcionarios.Converters
{
    public class TextValConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string
                theString = (string)value;
                theString = theString.Trim();

                return VerificationUtilities.TextBoxStringValidation(theString);
            }
            return String.Empty;

        }

        public object
        ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}