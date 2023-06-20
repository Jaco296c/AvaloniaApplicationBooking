using AvaloniaApplicationBooking.Configuration;
using AvaloniaApplicationBooking.Database.LoginDatabase;
using AvaloniaApplicationBooking.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.ViewModels.LoginViewModels
{
    internal class RegistarUserViewModel : ViewModelBase
    {
        #region PROP

        private string? _ErrorMessageCodetxt;
        public string? ErrorMessageCodetxt
        {
            get => _ErrorMessageCodetxt;
            set => this.RaiseAndSetIfChanged(ref _ErrorMessageCodetxt, value);
        }
        public string? txtCreateUsername { get; set; }
        private string? _txtCreateUsernameChecker;
        public string? txtCreateUsernameChecker
        {
            get => _txtCreateUsernameChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreateUsernameChecker, value);
        }

        public string? txtCreateFirstName { get; set; }
        private string? _txtCreateFirstNameChecker;
        public string? txtCreateFirstNameChecker
        {
            get => _txtCreateFirstNameChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreateFirstNameChecker, value);
        }

        public string? txtCreateLastName { get; set; }
        private string? _txtCreateLastNameChecker;
        public string? txtCreateLastNameChecker
        {
            get => _txtCreateLastNameChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreateLastNameChecker, value);
        }


        private string? _txtCreatePassword;
        public string? txtCreatePassword
        {
            get => _txtCreatePassword;
            set => this.RaiseAndSetIfChanged(ref _txtCreatePassword, value);
        }
        private string? _txtCreatePasswordChecker;
        public string? txtCreatePasswordChecker
        {
            get => _txtCreatePasswordChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreatePasswordChecker, value);
        }

        public string? txtCreateMail { get; set; }
        private string? _txtCreateMailChecker;
        public string? txtCreateMailChecker
        {
            get => _txtCreateMailChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreateMailChecker, value);
        }

        public string? txtCreatePhoneNumber { get; set; }
        private string? _txtCreatePhoneNumberChecker;
        public string? txtCreatePhoneNumberChecker
        {
            get => _txtCreatePhoneNumberChecker;
            set => this.RaiseAndSetIfChanged(ref _txtCreatePhoneNumberChecker, value);
        }
        private string EmptyPhoneNumberChecker = "";
        #endregion
        public void AlreadyHaveAUser()
        {
            MainView.GoToLogin();
        }

        public void CreateUserBTN()
        {
            ClearInfoCheckers();

            DataAccess db = new DataAccess();
            try
            {
                if (txtCreateUsername != null && txtCreateFirstName != null && txtCreateLastName != null && txtCreateMail != null && txtCreatePassword != null)
                {
                    if (txtCreateUsername.Length > 0 && txtCreateFirstName.Length > 0 && txtCreateLastName.Length > 0 && txtCreateMail.Length > 0 && txtCreatePassword.Length > 0)
                    {
                        if (txtCreatePhoneNumber != null)
                        {
                            EmptyPhoneNumberChecker = txtCreatePhoneNumber;
                        }


                        if (txtCreateUsername.Length <= Config.InstanceOfConfigProp[0].MaxValue
                            && txtCreateMail.Length <= Config.InstanceOfConfigProp[4].MaxValue
                            && txtCreatePassword.Length <= Config.InstanceOfConfigProp[1].MaxValue
                            && EmptyPhoneNumberChecker.Length <= Config.InstanceOfConfigProp[5].MaxValue)
                        {
                            if (true == db.CreateUser(txtCreateUsername, txtCreateFirstName, txtCreateLastName, txtCreateMail, EmptyPhoneNumberChecker, txtCreatePassword))
                            {
                                ClearInfoCheckers();
                                MainView.GoToLogin();
                            }
                        }
                        else
                            throw new DataAccessException { ErrorCode = DataAccessReturnCodes.CreateUserChecker };


                    }
                    else
                        throw new DataAccessException { ErrorCode = DataAccessReturnCodes.CreateUserChecker };

                }
                else
                {
                    if (txtCreateUsername == null)
                        txtCreateUsername = "";
                    if (txtCreateFirstName == null)
                        txtCreateFirstName = "";
                    if (txtCreateLastName == null)
                        txtCreateLastName = "";
                    if (txtCreateMail == null)
                        txtCreateMail = "";
                    if (txtCreatePassword == null)
                        txtCreatePassword = "";

                    throw new DataAccessException { ErrorCode = DataAccessReturnCodes.CreateUserChecker };
                }
            }
            catch (DataAccessException exception)
            { // exception - enum: different options depending on the enum chosen from the enum: DataAccessReturnCodes
                switch (exception.ErrorCode)
                {
                    case DataAccessReturnCodes.UsernameIsAlreadyInUse:
                        txtCreateUsernameChecker = "Username is already in use";
                        break;

                    case DataAccessReturnCodes.MailAlreadyInUse:
                        txtCreateMailChecker = "Mail is already in use";
                        break;

                    case DataAccessReturnCodes.MailAndUsernameAlreadyInUse:
                        txtCreateMailChecker = "Mail is already in use";
                        txtCreateUsernameChecker = "Username is already in use";
                        break;

                    case DataAccessReturnCodes.SomethingWentWrong:
                        ErrorMessageCodetxt = "Something Went Wrong. Please contact support";
                        break;

                    case DataAccessReturnCodes.CreateUserChecker:

                        if (txtCreateUsername.Length > Config.InstanceOfConfigProp[0].MaxValue)
                            txtCreateUsernameChecker = $"Username length is above {Config.InstanceOfConfigProp[0].MaxValue}";
                        if (txtCreateUsername.Length == 0)
                            txtCreateUsernameChecker = "Username is empty";

                        if (txtCreateFirstName.Length > Config.InstanceOfConfigProp[2].MaxValue)
                            txtCreateFirstNameChecker = $"First name length is above {Config.InstanceOfConfigProp[2].MaxValue}";
                        if (txtCreateFirstName.Length == 0)
                            txtCreateFirstNameChecker = "First name is empty";

                        if (txtCreateLastName.Length > Config.InstanceOfConfigProp[3].MaxValue)
                            txtCreateLastNameChecker = $"Last name length is above {Config.InstanceOfConfigProp[3].MaxValue}";
                        if (txtCreateLastName.Length == 0)
                            txtCreateLastNameChecker = "Last name is empty";


                        if (EmptyPhoneNumberChecker.Length > Config.InstanceOfConfigProp[5].MaxValue)
                            txtCreatePhoneNumberChecker = "Phone number length is above 20";

                        if (txtCreateMail.Length > Config.InstanceOfConfigProp[4].MaxValue)
                            txtCreateMailChecker = $"Email length is above {Config.InstanceOfConfigProp[4].MaxValue}";
                        if (txtCreateMail.Length == 0)
                            txtCreateMailChecker = "Email is empty";

                        if (txtCreatePassword.Length > Config.InstanceOfConfigProp[1].MaxValue)
                            txtCreatePasswordChecker = $"Password length is above {Config.InstanceOfConfigProp[1].MaxValue}";
                        if (txtCreatePassword.Length == 0)
                            txtCreatePasswordChecker = "Password is empty";

                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Used to clear all the information in the Textblocks under each Textbox
        /// </summary>
        private void ClearInfoCheckers()
        {
            txtCreateUsernameChecker = "";
            txtCreateFirstNameChecker = "";
            txtCreateLastNameChecker = "";
            txtCreatePasswordChecker = "";
            txtCreateMailChecker = "";
            txtCreatePhoneNumberChecker = "";
        }
    }
}
