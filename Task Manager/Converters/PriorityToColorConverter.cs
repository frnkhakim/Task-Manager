using System.Globalization;
using Task_Manager.Models.Enums;

namespace Task_Manager.Converters
{
    public class PriorityToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Priority priority)
            {
                return priority switch
                {
                    Priority.High => Colors.Red,
                    Priority.Medium => Colors.Orange,
                    Priority.Low => Colors.Green,
                    _ => Colors.Gray
                };
            }

            return Colors.Gray;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
