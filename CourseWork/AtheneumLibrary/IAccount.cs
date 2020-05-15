using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public interface IAccount
    {
        // Взять книгу с библиотеки
        void Take(int idBook);
        // Отдать книгу в библиотеку
        void Return(int idBook);
    }
}
