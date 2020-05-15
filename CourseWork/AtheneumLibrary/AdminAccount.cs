using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public class AdminAccount : Account
    {
        public AdminAccount(string log) : base(log)
        {
        }
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"Создан новый аккаунт админа! Логин пользователя: {Login} Id пользователя: {IdUser}", Login, 0));
        }
    }
}
