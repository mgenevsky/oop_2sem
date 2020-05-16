using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            library.AddBook("Arm","lolowtg", "xd");
            library.AddBook("Points", "NS", "idk");
            library.AddBook("Sit", "Stray", "xd");
            library.AddBook("Arm", "Versyta", "lmao");
            library.AddBook("Arm", "Aloha", "lol");
            library.AddBook("cassette", "lolowtg", "xd");
            library.AddBook("Sit", "Stray", "lmao");

            bool alive = true;
            Console.WriteLine("Вас приветствует Библиотека КПИ");
            while (alive)
            {
                Console.WriteLine();
                ConsoleColor color = Console.ForegroundColor;
                //Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Создать аккаунт \t   2. Взять книгу \t    3. Вернуть книгу");
                Console.WriteLine("4. Поиск книги \t   5. Посмотреть список книг в нашей библиотеке\t 6. Удалить аккаунт");
                Console.WriteLine("7. Выйти из программы");
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
                            Search(library);
                            break;
                        case 5:
                            LookAll(library);
                            break;
                        case 6:
                            CloseAccount(library);
                            break;
                        case 7:
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
            Console.WriteLine("Введите id аккаунта с которого хотите вернуть книгу:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            library.Return(idbook, idUser);
            library.AddBook(idbook);
            library.Sort();
        }

        private static void Take(Atheneum<Account> library)
        {
            Console.WriteLine("Укажите id книги которую хотите взять:");
            int idbook = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите id аккаунта на которых хотят взять книгу:");
            int idUser = Convert.ToInt32(Console.ReadLine());
            library.Take(idbook, idUser);
            library.Remove(idbook);
            library.Sort();
        }
        
        private static void CloseAccount(Atheneum<Account> library)
        {
            Console.WriteLine("Введите id счета, который надо закрыть:");
            int id = Convert.ToInt32(Console.ReadLine());

            library.Close(id);
        }
        private static void Search(Atheneum<Account> library)
        {
            Console.WriteLine("Укажите вид поиска книги:");
            Console.WriteLine("1. Поиск книги по названию 2. Поиск книги по автору 3. Поиск книги по жанру ");
            int flag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ключевое слово поиска: ");
            string key = Console.ReadLine();
            library.Search(flag, key);
        }
        private static void LookAll(Atheneum<Account> library)
        {
            Console.WriteLine("Список всех книг нашей библиотеки:");
            library.LookAll();
        }
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
