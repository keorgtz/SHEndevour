using SHEndevour.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace SHEndevour
{
    public class RoomStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RoomStatus status)
            {
                switch (status)
                {
                    case RoomStatus.OcupadoSucio:
                        System.Diagnostics.Debug.WriteLine("Convert: OcupadoSucio -> Red");
                        return Brushes.Cyan;

                    case RoomStatus.OcupadoLimpio:
                        System.Diagnostics.Debug.WriteLine("Convert: OcupadoSucio -> Green");
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00589B")); // Color azul personalizado

                    case RoomStatus.VacioSucio:
                        System.Diagnostics.Debug.WriteLine("Convert: VacioSucio -> Orange");
                        return Brushes.Orange;

                    case RoomStatus.VacioLimpio:
                        System.Diagnostics.Debug.WriteLine("Convert: VacioLimpio -> Pink");
                        return Brushes.LightGreen;

                    case RoomStatus.Bloqueado:
                        System.Diagnostics.Debug.WriteLine("Convert: Bloqueado -> Gray");
                        return Brushes.DarkViolet;

                    case RoomStatus.Mantenimiento:
                        System.Diagnostics.Debug.WriteLine("Convert: Mantenimiento -> Yellow");
                        return Brushes.MediumPurple;

                    default:
                        return Brushes.Black;
                }
            }
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
