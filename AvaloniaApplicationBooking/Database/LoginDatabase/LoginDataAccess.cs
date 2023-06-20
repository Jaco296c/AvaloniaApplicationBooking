using AvaloniaApplicationBooking.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Database.LoginDatabase
{
    public class DataAccess
    {
        public static void UpdateStatusLogin(string loginname, string password)
        {
            DateTime statusDateTime = DateTime.Now;
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("AvaloniaAppCross")))
                {
                    var input = connection.Execute($"dbo.UpdateLoginStatus @StatusDateTime, @Loginname, @Password", new { StatusDateTime = statusDateTime, Loginname = loginname, Password = password });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataAccessReturnCodes FindUserForLogin(string loginname, string password)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("AvaloniaAppCross")))
                {
                    var input = connection.Query<User>($"dbo.Login @Loginname, @Password", new { Loginname = loginname, Password = password }).FirstOrDefault(); //Stored Procedure

                    if (input != null)
                    {
                        DateTime fiveMinutesAgo = DateTime.Now - TimeSpan.FromMinutes(5);
                        if (input.StatusDate == DateTime.Now || input.StatusDate <= fiveMinutesAgo)
                        {
                            throw new DataAccessException { ErrorCode = DataAccessReturnCodes.UserAlreadyOnline };
                        }

                        User user = new User();
                        user.UserId = input.UserId;
                        DateTime statusDateTime = DateTime.Now;
                        user.StatusDate = statusDateTime;
                        var input2 = connection.Execute($"dbo.UpdateLoginStatus @StatusDateTime", new { StatusDateTime = statusDateTime });
                        return DataAccessReturnCodes.UserLogin;
                    }
                    else
                    {
                        throw new DataAccessException { ErrorCode = DataAccessReturnCodes.UserOrPasswordIncorrect };
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataAccessException { ErrorCode = DataAccessReturnCodes.SomethingWentWrong }; //SKAL LAVES OM SÅ DEN VIRKER
            }
        }

        public bool CreateUser(string username, string firstname, string lastname, string email, string? phonenumber, string password)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("AvaloniaAppCross")))
                {
                    //checks if mail or usename is already in use - if not creates a new account
                    var outputMailCheck = connection.Query<User>($"dbo.CheckUserEmail @Email", new { Email = email });
                    var outputUsernameCheck = connection.Query<User>($"dbo.CheckUsername @Username", new { Username = username });


                    if (outputMailCheck.Count() < 1 && outputUsernameCheck.Count() < 1)
                    {
                        DateTime statusDateTime = DateTime.Now;
                        connection.Execute($"dbo.CreateUser @UserName, @FirstName, @LastName, @Email, @PhoneNumber, @Password, @StatusDateTime",
                            new { UserName = username, FirstName = firstname, LastName = lastname, Email = email, PhoneNumber = phonenumber, Password = password, StatusDateTime = statusDateTime });
                        return true;
                    }
                    else
                    {
                        if (outputMailCheck.Count() > 0 && outputUsernameCheck.Count() > 0)
                            throw new DataAccessException { ErrorCode = DataAccessReturnCodes.MailAndUsernameAlreadyInUse };

                        if (outputMailCheck.Count() > 0)
                            throw new DataAccessException { ErrorCode = DataAccessReturnCodes.MailAlreadyInUse };

                        if (outputUsernameCheck.Count() > 0)
                            throw new DataAccessException { ErrorCode = DataAccessReturnCodes.UsernameIsAlreadyInUse };


                    }
                    throw new DataAccessException { ErrorCode = DataAccessReturnCodes.SomethingWentWrong };

                }
            }
            catch (SqlException)
            {
                throw new DataAccessException { ErrorCode = DataAccessReturnCodes.SomethingWentWrong };
            }
        }
    }

    public class DataAccessException : Exception
    {
        public DataAccessReturnCodes ErrorCode { get; set; }
    }

    public enum DataAccessReturnCodes
    {
        UserAlreadyOnline,
        UserOrPasswordIncorrect,
        MailAlreadyInUse,
        SomethingWentWrong,
        CreateUserChecker,
        UsernameIsAlreadyInUse,
        MailAndUsernameAlreadyInUse,
        UserLogin
    }
}
