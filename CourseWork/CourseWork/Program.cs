using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtheneumLibrary;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Atheneum<Account> library = new Atheneum<Account>("Библиотека КПИ");
            bool alive = true;
            Console.WriteLine("Вас приветствует Библиотека КПИ");
            while (alive)
            {
                Console.WriteLine();
                ConsoleColor color = Console.ForegroundColor;
                //Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Создать аккаунт \t   2. Взять книгу \t    3. Вернуть книгу");
                Console.WriteLine("4. Поиск книги по названию 5. Поиск книги по автору 6. Поиск книги по жанру ");
                Console.WriteLine("7. Удалить аккаунт \t   8. Посмотреть список книг в нашей библиотеке\t ");
                Console.WriteLine("9. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            OpenAccount(library);
                            break;
                        case 2:
                            Take(library);
                            break;
                        case 3:
                            Return(library);
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            CloseAccount(library);
                            break;
                        case 8:
                            break;
                        case 9:
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке красным цветом
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void OpenAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Укажите логин для создания аккаунта:");

            string login = Console.ReadLine();
            Console.WriteLine("Выберите тип аккаунта: 1. Админ 2. Обычный");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Simple;
            else
                accountType = AccountType.Admin;

            library.Open(accountType,
                login,
                TookBookHandler,  // обработчик взятия книги
                ReturnBookHandler, // обработчик возвращения книги
                CloseAccountHandler, // обработчик закрытия счета
                OpenAccountHandler); // обработчик открытия счета
        }

        private static void Return(Atheneum<Account> library)
        {
            Console.WriteLine("Укажите id книги которую хотите вернуть:");

            int idbook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите id аккаунта:");
            int idUser = Convert.ToInt32(Console.ReadLine());

            library.Return(idbook, idUser);
        }

        private static void Take(Atheneum<Account> library)
        {
            Console.WriteLine("Укажите id книги которую хотите взять:");

            int idbook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите id аккаунта:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            library.Take(idbook, idUser);
        }

        private static void CloseAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Введите id счета, который надо закрыть:");
            int id = Convert.ToInt32(Console.ReadLine());

            library.Close(id);
        }

        // обработчики событий класса Account
        // обработчик создания аккаунта
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик взятия книги
        private static void TookBookHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик возврата книги
        private static void ReturnBookHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик удаления аккаунта
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
