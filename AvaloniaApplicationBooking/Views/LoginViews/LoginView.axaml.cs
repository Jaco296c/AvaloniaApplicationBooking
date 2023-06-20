using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationBooking.ViewModels.LoginViewModels;

namespace AvaloniaApplicationBooking.Views.LoginViews;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }
}