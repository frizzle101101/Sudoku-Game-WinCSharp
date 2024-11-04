namespace Sudoku.Converters; 

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

public class BoolToVisibilityConverter : MarkupExtension, IValueConverter {
    private static BoolToVisibilityConverter? _instance;

    public override object ProvideValue(IServiceProvider serviceProvider)
        => _instance ??= new BoolToVisibilityConverter();

    // IValueConverter
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool key
            ? key ? Visibility.Visible : Visibility.Collapsed
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}