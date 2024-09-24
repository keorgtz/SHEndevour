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
                // Verifica si el parámetro es para el Foreground o Background
                string colorType = parameter as string ?? "Background"; // Por defecto será Background

                if (colorType.Equals("Foreground", StringComparison.OrdinalIgnoreCase))
                {
                    // Colores para el Foreground (letras)
                    switch (status)
                    {
                        case RoomStatus.OcupadoSucio:
                            return Brushes.Black;

                        case RoomStatus.OcupadoLimpio:
                            return Brushes.White;

                        case RoomStatus.VacioSucio:
                            return Brushes.Black;

                        case RoomStatus.VacioLimpio:
                            return Brushes.White;

                        case RoomStatus.Bloqueado:
                            return Brushes.White;

                        case RoomStatus.Mantenimiento:
                            return Brushes.White;

                        default:
                            return Brushes.Black;
                    }
                }
                else
                {
                    // Colores para el Background (fondo)
                    switch (status)
                    {
                        case RoomStatus.OcupadoSucio:
                            System.Diagnostics.Debug.WriteLine("Convert: OcupadoSucio -> Cyan");
                            return Brushes.Cyan;

                        case RoomStatus.OcupadoLimpio:
                            System.Diagnostics.Debug.WriteLine("Convert: OcupadoLimpio -> Midnight");
                            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00589B")); // Color azul personalizado

                        case RoomStatus.VacioSucio:
                            System.Diagnostics.Debug.WriteLine("Convert: VacioSucio -> Orange");
                            return Brushes.Orange;

                        case RoomStatus.VacioLimpio:
                            System.Diagnostics.Debug.WriteLine("Convert: VacioLimpio -> Green");
                            return Brushes.Green;

                        case RoomStatus.Bloqueado:
                            System.Diagnostics.Debug.WriteLine("Convert: Bloqueado -> Purple");
                            return Brushes.Purple;

                        case RoomStatus.Mantenimiento:
                            System.Diagnostics.Debug.WriteLine("Convert: Mantenimiento -> MediumPurple");
                            return Brushes.MediumPurple;

                        default:
                            return Brushes.Black;
                    }
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