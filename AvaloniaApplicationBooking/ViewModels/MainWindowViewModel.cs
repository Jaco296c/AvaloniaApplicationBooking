using AvaloniaApplicationBooking.Configuration;

namespace AvaloniaApplicationBooking.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Config config = new Config();
            config.SaveConfig();
            config.LoadConfig();
        }
    }
}