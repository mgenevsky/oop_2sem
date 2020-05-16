using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public class RegularAccount : Account
    {
        // Ctor.
        public RegularAccount(string log) : base(log) { }

        // Override account creation method.
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new Regular user account has been created! User Login: {Login} User Id: {IdUser}", Login, 0));
        }

        // Overridden method of taking book for account.
        public override void Take(int idbook, Book temp)
        {
            if (Sum < 11)
                base.Take(idbook, temp);
            else
                base.OnTook(new AccountEventArgs($"A regular user with login \"{Login}\" has taken 10 books and wants to take 11 but it’s impossible!", Login, 0));
        }
    }
}
