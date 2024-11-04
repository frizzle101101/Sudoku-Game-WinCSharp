namespace Sudoku.Converters;

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

public class ButtonBackgroundConverter : MarkupExtension, IValueConverter {
    private static SolidColorBrush Blue = new SolidColorBrush(Colors.LightBlue);
    private static SolidColorBrush Green = new SolidColorBrush(Colors.LimeGreen);
    private static SolidColorBrush WhiteSmoke = new SolidColorBrush(Colors.WhiteSmoke);

    private static ButtonBackgroundConverter? _instance;

    public override object ProvideValue(IServiceProvider serviceProvider)
        => _instance ??= new ButtonBackgroundConverter();

    // IValueConverter
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        try {
            int activeButton = int.MaxValue;
            int thisButton = int.MinValue;

            if (value.GetType() == typeof(int))
                activeButton = (int)value;
            else if (value.GetType() == typeof(bool))
                activeButton = (bool)value ? 1 : 0;

            if (parameter.GetType() == typeof(string))
                thisButton = int.Parse(parameter.ToString());
            else if (value.GetType() == typeof(bool))
                thisButton = (bool)parameter ? 1 : 0;

            return activeButton == thisButton
                ? Green
                : WhiteSmoke;
        } catch {
            return WhiteSmoke;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
