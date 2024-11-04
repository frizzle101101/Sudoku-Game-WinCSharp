namespace Sudoku.Converters;

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

public class InvertedBoolToVisibilityConverter : MarkupExtension, IValueConverter {
    private static InvertedBoolToVisibilityConverter? _instance;

    public override object ProvideValue(IServiceProvider serviceProvider)
        => _instance ??= new InvertedBoolToVisibilityConverter();

    // IValueConverter
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is bool key
            ? !key ? Visibility.Visible : Visibility.Collapsed
            : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}