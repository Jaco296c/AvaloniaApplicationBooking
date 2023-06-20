using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApplicationBooking.Views;
using AvaloniaApplicationBooking.Views.LoginViews;

namespace AvaloniaApplicationBooking.Views;

public partial class MainView : UserControl
{
    public static string MainColorTheme { get; set; } = "Blue";
    public static MainView? Current { get; private set; } = null;
    private static LoginView loginView = new();
    private static RegisterUserView registerView = new();
    public static void Navigate(UserControl userControl)
    {
        Current.ContentArea.Children.Clear();
        Current.ContentArea.Children.Add(userControl);
    }
    public MainView()
    {
        InitializeComponent();
        loginView = new LoginView();
        registerView = new RegisterUserView();
        if (Current == null)
            Current = this;

        Navigate(new LoginView());
    }
    public static void GoToLogin()
    {
        Navigate(loginView);
    }
    public static void GoToRegister()
    {
        Navigate(registerView);
    }
}