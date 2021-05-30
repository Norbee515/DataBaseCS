using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Scoala.Converters
{
    class ElevConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {

                return new Elev()
                {
                    IDElev = values[0].ToString(),
                    Nume_pren = values[1].ToString(),
                    Telefon = values[2].ToString(),
                    Adresa = values[3].ToString(),
                    UserN = values[4].ToString(),
                    Passw = values[5].ToString(),
                };
            }
            else
            {
                return null;
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
