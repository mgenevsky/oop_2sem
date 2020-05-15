using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);

    public class AccountEventArgs
    {
        // Сообщение
        public string Message { get; private set; }
        //логин юзера
        public string Login { get; private set; }
        // Кол-ство книг в формуляре, на которое изменился счетчик
        public int Sum { get; private set; }
        public AccountEventArgs(string _mes, string _log, int _sum) 
        {
            Login = _log;
            Message = _mes;
            Sum = _sum;
        }
    }
}
