using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public abstract class Account : IAccount
    {
        //Событие, возникающее при возврате книги
        protected internal event AccountStateHandler Returned;
        // Событие возникающее при взятии книги
        protected internal event AccountStateHandler Took;
        // Событие возникающее при открытии аккаунта
        protected internal event AccountStateHandler Opened;
        // Событие возникающее при удалении аккаунта
        protected internal event AccountStateHandler Closed;

        static int usercounter = 0;

        public Account(string log)
        {
            Login = log;
            Sum = 0;
            IdUser = ++usercounter;
        }

        // Текущие кол-ство книг на счету
        public int Sum { get; private set; }
        //Логин
        public string Login { get; private set; }
        //id пользователя
        public int IdUser { get; private set; }
        // вызов событий
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }
        // вызов отдельных событий. Для каждого события определяется свой витуальный метод
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnReturned(AccountEventArgs e)
        {
            CallEvent(e, Returned);
        }
        protected virtual void OnTook(AccountEventArgs e)
        {
            CallEvent(e, Took);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        // метод взятия книги
        public virtual void Take(int idbook)
        {
            Sum += 1;
            OnTook(new AccountEventArgs($"Пользователь под ником {Login} взял книгу с id " + idbook,Login,idbook));
        }
        // метод возврата книги
        public virtual void Return(int idbook)
        {
            if (Sum >= 1)
            {
                Sum -= 1;
                OnReturned(new AccountEventArgs($"Пользователь под ником {Login} отдал книгу с id " + idbook, Login, idbook));
            }
            else
            {
                OnReturned(new AccountEventArgs($"Пользователь под ником {Login} не брал ещё книг",Login, idbook));
            }
        }
        // открытие счета
        protected internal virtual void Open()
        {
            OnOpened(new AccountEventArgs($"Создан новый аккаунт пользователя! Логин пользователя: {Login} Id пользователя: {IdUser}", Login,0));
        }
        // закрытие счета
        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Аккаунт с Логином {Login} и Id {IdUser} закрыт.  Он ушел и не отдал: {Sum} книг(у)", Login, Sum));
        }
    }
}
