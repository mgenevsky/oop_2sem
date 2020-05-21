using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public class AdminAccount : Account
    {
        // Ctor.
        public AdminAccount(string log) : base(log) { AccType = 1; }

        // Override account creation method.
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new Admin account has been created! Account Login: {Login} Account Id: {IdUser}", Login, 0));
        }

        // Override account login in method.
        protected internal override void LoginIn()
        {
            OnReturned(new AccountEventArgs($"You are logged in Admin account with login \"{Login}\" ", Login, 0));
        }

        // Override account login out method.
        protected internal override void LoginOut()
        {
            OnReturned(new AccountEventArgs($"You are logged out from Admin account with login \"{Login}\" ", Login, 0));
        }
    }
}
