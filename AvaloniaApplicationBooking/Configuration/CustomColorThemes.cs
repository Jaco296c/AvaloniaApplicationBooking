using Avalonia.Media;
using AvaloniaApplicationBooking.ViewModels.LoginViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Configuration
{
    public class CustomColorThemes
    {
        public static SolidColorBrush defaultTextColorBlueTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffffff");
    // Blue Color theme
        public static Avalonia.Media.Color mainColorBlueTheme { get; } = Colors.DodgerBlue;
        public static Avalonia.Media.Color secondColorBlueTheme { get; } = Colors.LightSkyBlue;
        public static Avalonia.Media.Color buttonClickColorBlueTheme { get; } = Colors.SteelBlue;
        public static SolidColorBrush highlightColorBlueTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#15c2e0");
        public static SolidColorBrush borderBackgroundColorBlueTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#171C2C");

    // Red Color Theme
        public static Avalonia.Media.Color mainColorRedTheme { get; } = Colors.Firebrick;
        public static Avalonia.Media.Color secondColorRedTheme { get; } = Colors.Red;
        public static Avalonia.Media.Color buttonClickColorRedTheme { get; } = Colors.Firebrick;
        public static SolidColorBrush highlightColorRedTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5733");
        public static SolidColorBrush borderBackgroundColorRedTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#171C2C");

        // Green Color Theme
        public static Avalonia.Media.Color mainColorGreenTheme { get; } = Colors.LimeGreen;
        public static Avalonia.Media.Color secondColorGreenTheme { get; } = Colors.ForestGreen;
        public static Avalonia.Media.Color buttonClickColorGreenTheme { get; } = Colors.Lime;
        public static SolidColorBrush highlightColorGreenTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#34e141");
        public static SolidColorBrush borderBackgroundColorGreenTheme { get; } = (SolidColorBrush)new BrushConverter().ConvertFrom("#171C2C");
    }
}
