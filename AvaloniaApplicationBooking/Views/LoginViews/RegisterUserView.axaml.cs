using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationBooking.ViewModels.LoginViewModels;

namespace AvaloniaApplicationBooking.Views.LoginViews;

public partial class RegisterUserView : UserControl
{
    public RegisterUserView()
    {
        InitializeComponent();
        DataContext = new RegistarUserViewModel();
    }
}