using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    public class AccountEventArgs
    {
        // Message.
        public string Message { get; private set; }

        // User login.
        public string Login { get; private set; }

        // Book counter in logbook.
        public int Sum { get; private set; }

        // Ctor.
        public AccountEventArgs(string _mes, string _log, int _sum) 
        {
            Login = _log;
            Message = _mes;
            Sum = _sum;
        }
    }
}
