using AvaloniaApplicationBooking.Database.LoginDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaApplicationBooking.Database
{
    public class StatusTimer
    {
        public static void OnlineStatusTimer(string loginname, string password)
        {
            TimerCallback timerCallback = new TimerCallback((_) =>
            {
                DataAccess.UpdateStatusLogin(loginname, password);
            });

            System.Threading.Timer timer = new Timer(timerCallback, null, 2000, 60000);
        }
    }
}
