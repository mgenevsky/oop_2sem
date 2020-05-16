using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public class AdminAccount : Account
    {
        // Ctor.
        public AdminAccount(string log) : base(log) { }

        // Override account creation method.
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new Admin account has been created! User Login: {Login} User Id: {IdUser}", Login, 0));
        }
    }
}
