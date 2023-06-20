using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Configuration
{
    public class Language
    {
        //Login English
        public static string Login_TitleEN { get; } = "User Login";
        public static string Login_LoginnameWatermarkEN { get; } = "Username / Email";
        public static string Login_PasswordWatermarkEN { get; } = "Password";
        public static string Login_BTNLoginEN { get; } = "Login";
        public static string Login_TXTLoginRegisterP1EN { get; } = "Register a new";
        public static string Login_TXTLoginRegisterP2EN { get; } = "User";

        //Login Dansk
        public static string Login_TitleDK { get; } = "Bruger log ind";
        public static string Login_LoginnameWatermarkDK { get; } = "Brugernavn / Email";
        public static string Login_PasswordWatermarkDK { get; } = "Adgangskode";
        public static string Login_BTNLoginDK { get; } = "Log ind";
        public static string Login_TXTLoginRegisterP1DK { get; } = "Opret en ny";
        public static string Login_TXTLoginRegisterP2DK { get; } = "Bruger";
    }
}
