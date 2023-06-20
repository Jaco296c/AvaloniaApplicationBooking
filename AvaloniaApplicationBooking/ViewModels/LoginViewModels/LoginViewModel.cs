using AvaloniaApplicationBooking.Configuration;
using AvaloniaApplicationBooking.Database.LoginDatabase;
using AvaloniaApplicationBooking.Database;
using AvaloniaApplicationBooking.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using System.Drawing;
using System.Reactive;

namespace AvaloniaApplicationBooking.ViewModels.LoginViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
#region PROPERTIES
        private string _LoginTitleTXT = Language.Login_TitleEN;
        public string LoginTitleTXT
        {
            get => _LoginTitleTXT;
            set => this.RaiseAndSetIfChanged(ref _LoginTitleTXT, value);
        }

#region ButtonProps
        private bool _btnYes = false;
        public bool btnYes
        {
            get => _btnYes;
            set => this.RaiseAndSetIfChanged(ref _btnYes, value);
        }
        private bool _btnNo = false;
        public bool btnNo
        {
            get => _btnNo;
            set => this.RaiseAndSetIfChanged(ref _btnNo, value);
        }
#endregion

#region TextProps
        //LoginName / Username
        private string? _LoginNameTXT;
        public string? LoginNameTXT
        {
            get => _LoginNameTXT;
            set => this.RaiseAndSetIfChanged(ref _LoginNameTXT, value);
        }

        private string? _LoginNameWaterMarkTXT = Language.Login_LoginnameWatermarkEN;
        public string? LoginNameWaterMarkTXT
        {
            get => _LoginNameWaterMarkTXT;
            set => this.RaiseAndSetIfChanged(ref _LoginNameWaterMarkTXT, value);
        }

        private string? _LoginNameCheckerTXT;
        public string? LoginNameCheckerTXT
        {
            get => _LoginNameCheckerTXT;
            set => this.RaiseAndSetIfChanged(ref _LoginNameCheckerTXT, value);
        }

        //Password
        private string? _PasswordTXT;
        public string? PasswordTXT
        {
            get => _PasswordTXT;
            set => this.RaiseAndSetIfChanged(ref _PasswordTXT, value);
        }
        private string? _PasswordWaterMarkTXT = Language.Login_PasswordWatermarkEN;
        public string? PasswordWaterMarkTXT
        {
            get => _PasswordWaterMarkTXT;
            set => this.RaiseAndSetIfChanged(ref _PasswordWaterMarkTXT, value);
        }

        private string? _PasswordCheckerTXT;
        public string? PasswordCheckerTXT
        {
            get => _PasswordCheckerTXT;
            set => this.RaiseAndSetIfChanged(ref _PasswordCheckerTXT, value);
        }
        //Login BTN text
        private string? _LoginBTNText = Language.Login_BTNLoginEN;
        public string? LoginBTNText
        {
            get => _LoginBTNText;
            set => this.RaiseAndSetIfChanged(ref _LoginBTNText, value);
        }
        // Register a new user - Text BTN
        private string? _RegisterUserP1TXT = Language.Login_TXTLoginRegisterP1EN;
        public string? RegisterUserP1TXT
        {
            get => _RegisterUserP1TXT;
            set => this.RaiseAndSetIfChanged(ref _RegisterUserP1TXT, value);
        }

        private string? _RegisterUserP2TXT = Language.Login_TXTLoginRegisterP2EN;
        public string? RegisterUserP2TXT
        {
            get => _RegisterUserP2TXT;
            set => this.RaiseAndSetIfChanged(ref _RegisterUserP2TXT, value);
        }

        //Info/error

        private string? _InfoTextTXT;
        public string? InfoTextTXT
        {
            get => _InfoTextTXT;
            set => this.RaiseAndSetIfChanged(ref _InfoTextTXT, value);
        }

        private string? _BTNYesTXT;
        public string? BTNYesTXT
        {
            get => _BTNYesTXT;
            set => this.RaiseAndSetIfChanged(ref _BTNYesTXT, value);
        }
        private string? _BTNNoTXT;
        public string? BTNNoTXT
        {
            get => _BTNNoTXT;
            set => this.RaiseAndSetIfChanged(ref _BTNNoTXT, value);
        }

        #endregion
        //public bool Visable { get; private set; }

        #region ColorThemeProp
        private Avalonia.Media.Color _MainColor = CustomColorThemes.mainColorBlueTheme;
        public Avalonia.Media.Color MainColor
        {
            get => _MainColor;
            set => this.RaiseAndSetIfChanged(ref _MainColor, value);
        }

        private Avalonia.Media.Color _SecondColor = CustomColorThemes.secondColorBlueTheme;
        public Avalonia.Media.Color SecondColor
        {
            get => _SecondColor;
            set => this.RaiseAndSetIfChanged(ref _SecondColor, value);
        }

        private Avalonia.Media.Color _ButtonClickColor = CustomColorThemes.buttonClickColorBlueTheme;
        public Avalonia.Media.Color ButtonClickColor
        {
            get => _ButtonClickColor;
            set => this.RaiseAndSetIfChanged(ref _ButtonClickColor, value);
        }

        private SolidColorBrush _HighlightColor = CustomColorThemes.highlightColorBlueTheme;
        public SolidColorBrush HighlightColor
        {
            get => _HighlightColor;
            set => this.RaiseAndSetIfChanged(ref _HighlightColor, value);
        }

        private SolidColorBrush _DefaultTextColor = CustomColorThemes.defaultTextColorBlueTheme;
        public SolidColorBrush DefaultTextColor
        {
            get => _DefaultTextColor;
            set => this.RaiseAndSetIfChanged(ref _DefaultTextColor, value);
        }

        private SolidColorBrush _BorderBackgroundColor = CustomColorThemes.borderBackgroundColorBlueTheme;
        public SolidColorBrush BorderBackgroundColor
        {
            get => _BorderBackgroundColor;
            set => this.RaiseAndSetIfChanged(ref _BorderBackgroundColor, value);
        }
#endregion
#endregion
        public void SetColorTheme(int themeID)
        {
            switch (themeID)
            {
                case 0:
                    ChangeColorTheme(CustomColorThemes.mainColorBlueTheme, CustomColorThemes.secondColorBlueTheme, CustomColorThemes.buttonClickColorBlueTheme, CustomColorThemes.highlightColorBlueTheme, CustomColorThemes.borderBackgroundColorBlueTheme);
                    break;
                case 1:
                    ChangeColorTheme(CustomColorThemes.mainColorRedTheme, CustomColorThemes.secondColorRedTheme, CustomColorThemes.buttonClickColorRedTheme, CustomColorThemes.highlightColorRedTheme, CustomColorThemes.borderBackgroundColorRedTheme);
                    break;
                case 2:
                    ChangeColorTheme(CustomColorThemes.mainColorGreenTheme, CustomColorThemes.secondColorGreenTheme, CustomColorThemes.buttonClickColorGreenTheme, CustomColorThemes.highlightColorGreenTheme, CustomColorThemes.borderBackgroundColorGreenTheme);
                    break;
                default:
                    ChangeColorTheme(CustomColorThemes.mainColorBlueTheme, CustomColorThemes.secondColorBlueTheme, CustomColorThemes.buttonClickColorBlueTheme, CustomColorThemes.highlightColorBlueTheme, CustomColorThemes.borderBackgroundColorBlueTheme);
                    break;
            }
        }

        public void SetLanguage(int languageID)
        {
            switch (languageID)
            {
                case 0:
                    ChangeLanguage(Language.Login_TitleEN, Language.Login_LoginnameWatermarkEN, Language.Login_PasswordWatermarkEN, Language.Login_BTNLoginEN, Language.Login_TXTLoginRegisterP1EN, Language.Login_TXTLoginRegisterP2EN);
                    break;
                case 1:
                    ChangeLanguage(Language.Login_TitleDK, Language.Login_LoginnameWatermarkDK, Language.Login_PasswordWatermarkDK, Language.Login_BTNLoginDK, Language.Login_TXTLoginRegisterP1DK, Language.Login_TXTLoginRegisterP2DK);
                    break;
            }
        }

        public void RegisterAUserBTN()
        {
            MainView.GoToRegister();
        }

        public void LoginBTN()
        {
            DataAccess db = new DataAccess();
            ClearInfoCheckers();

            if (!string.IsNullOrEmpty(LoginNameTXT) && PasswordTXT.Length < Config.InstanceOfConfigProp[0].MaxValue && !string.IsNullOrEmpty(PasswordTXT) && PasswordTXT.Length < Config.InstanceOfConfigProp[1].MaxValue)
            {
                try
                {
                    switch (db.FindUserForLogin(LoginNameTXT, PasswordTXT))
                    {
                        case DataAccessReturnCodes.UserLogin:
                            StatusTimer.OnlineStatusTimer(LoginNameTXT, PasswordTXT);
                            break;
                        default:
                            break;
                    }
                }
                catch (DataAccessException exc)
                {
                    switch (exc.ErrorCode)
                    {
                        case DataAccessReturnCodes.UserAlreadyOnline:
                            InfoTextTXT = "User is already online. Do you wish to login anyways?";
                            btnYes = true;
                            btnNo = true;
                            break;
                        case DataAccessReturnCodes.UserOrPasswordIncorrect:
                            InfoTextTXT = "Username or password is incorrect.";
                            break;
                        case DataAccessReturnCodes.SomethingWentWrong:
                            InfoTextTXT = "Something Went Wrong. Please contact support.";
                            break;
                        case DataAccessReturnCodes.UserLogin:
                            break;
                        default:
                            break;
                    }
                }

            }
            else
            {

                if (!string.IsNullOrEmpty(LoginNameTXT) && LoginNameTXT.Length > Config.InstanceOfConfigProp[0].MaxValue)
                    LoginNameCheckerTXT = $"Username length is above {Config.InstanceOfConfigProp[0].MaxValue}";


                if (!string.IsNullOrEmpty(PasswordTXT) && PasswordTXT.Length > Config.InstanceOfConfigProp[1].MaxValue)
                    PasswordCheckerTXT = $"Password length is above {Config.InstanceOfConfigProp[1].MaxValue}";

                if (string.IsNullOrEmpty(LoginNameTXT))
                    LoginNameCheckerTXT = "Username is empty";
                if (string.IsNullOrEmpty(PasswordTXT))
                    PasswordCheckerTXT = "Password is empty";
            }
        }
        private void ClearInfoCheckers()
        {
            InfoTextTXT = "";
            LoginNameCheckerTXT = "";
            PasswordCheckerTXT = "";
            btnYes = false;
            btnNo = false;
        }
        private void ChangeColorTheme(Avalonia.Media.Color mainColor, Avalonia.Media.Color secondColor, Avalonia.Media.Color buttonClickColor,
                                     SolidColorBrush highlight, SolidColorBrush BorderColorBackground)
        {
            MainColor = mainColor;
            SecondColor = secondColor;
            ButtonClickColor = buttonClickColor;
            HighlightColor = highlight;
            BorderBackgroundColor = BorderColorBackground;

        }
        private void ChangeLanguage(string title, string loginWatermark, string passwordWatermark, string btnLogin, string loginRegisterP1, string loginRegisterP2)
        {
            LoginTitleTXT = title;
            LoginNameWaterMarkTXT = loginWatermark;
            PasswordWaterMarkTXT = passwordWatermark;
            LoginBTNText = btnLogin;
            RegisterUserP1TXT = loginRegisterP1;
            RegisterUserP2TXT = loginRegisterP2;
        }
    }
}
