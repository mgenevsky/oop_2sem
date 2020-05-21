using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AtheneumLibrary
{
    public class RegularAccount : Account
    {
        // Ctor.
        public RegularAccount(string log) : base(log) { AccType = 2; }

        // Override account creation method.
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new Regular account has been created! Account Login: {Login} Account Id: {IdUser}", Login, 0));
        }

        // Overridden method of taking book for account.
        public override void Take(int idbook, Book temp)
        {
            if (Sum < 11)
                base.Take(idbook, temp);
            else
                base.OnTook(new AccountEventArgs($"A Regular account with login \"{Login}\" has taken 10 books and wants to take 11 but it’s impossible!", Login, 0));
        }

        // Override account login in method.
        protected internal override void LoginIn()
        {
            OnReturned(new AccountEventArgs($"You are logged in Regular account with login \"{Login}\" ", Login, 0));
        }

        // Override account login out method.
        protected internal override void LoginOut()
        {
            OnReturned(new AccountEventArgs($"You are logged out from Regular account with login \"{Login}\" ", Login, 0));
        }
    }
}
