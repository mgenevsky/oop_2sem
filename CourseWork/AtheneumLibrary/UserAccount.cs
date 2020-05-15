using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public class UserAccount : Account
    {
        public UserAccount(string log) : base(log)
        {
        }
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"Создан новый обычный аккаунт пользователя! Логин пользователя: {Login} Id пользователя: {IdUser}", Login, 0));
        }

        public override void Take(int idbook)
        {
            if (Sum<=10)
                base.Take(idbook);
            else
                base.OnTook(new AccountEventArgs($"Обычный пользователь под ником {Login} взял 10 книг и хочет взять 11 но так нельзя! ", Login, 0));
        }

        public override void Return(int idbook)
        {
            if (Sum>0)
                base.Return(idbook);
            else
                base.OnReturned(new AccountEventArgs($"Пользователь под ником {Login} не может вернуть книгу, так как он их не брал", Login, 0));
        }

    }
}
