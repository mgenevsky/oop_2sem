using System;
using System.Collections.Generic;
using System.Text;

namespace AtheneumLibrary
{
    public enum AccountType
    {
        Admin,
        Simple 
    }
    public class Atheneum<T> where T : Account
    {
        T[] accounts;

        public string Name { get; private set; }

        public Atheneum(string name)
        {
            Name = name;
        }
        // метод создания счета
        public void Open(AccountType accountType, string login,
            AccountStateHandler tookBookHandler, AccountStateHandler returnBookHandler,
            AccountStateHandler closeAccountHandler, AccountStateHandler openAccountHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case AccountType.Admin:
                    newAccount = new AdminAccount(login) as T;
                    break;
                case AccountType.Simple:
                    newAccount = new UserAccount(login) as T;
                    break;
            }

            if (newAccount == null)
                throw new Exception("Ошибка создания счета");
            // добавляем новый счет в массив счетов      
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                    tempAccounts[i] = accounts[i];
                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }
            // установка обработчиков событий счета
            newAccount.Took += tookBookHandler;
            newAccount.Returned += returnBookHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;

            newAccount.Open();
        }
        //добавление средств на счет
        public void Take(int idbook, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аккаунт не найдет");
            account.Take(idbook);
        }
        // вывод средств
        public void Return(int idbook, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Аккаунт не найдет");
            account.Return(idbook);
        }
        // закрытие счета
        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
                throw new Exception("Аккаунт не найдет");

            account.Close();

            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                // уменьшаем массив счетов, удаляя из него закрытый счет
                T[] tempAccounts = new T[accounts.Length - 1];
                for (int i = 0, j = 0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }

        // поиск счета по id
        public T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                    return accounts[i];
            }
            return null;
        }
        // перегруженная версия поиска аккаунта
        public T FindAccount(int id, out int index)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].IdUser == id)
                {
                    index = i;
                    return accounts[i];
                }
            }
            index = -1;
            return null;
        }
    }
}
