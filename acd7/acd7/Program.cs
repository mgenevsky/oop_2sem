using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd7
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<char> linkedList = new LinkedList<char>();
            // добавляем элементы в начало  
            linkedList.AppendFirst('a');
            linkedList.AppendFirst('!');
            linkedList.AppendFirst('a');
            linkedList.AppendFirst('b');
            linkedList.AppendFirst('q');
            linkedList.AppendFirst('z');
            linkedList.AppendFirst('a');
            linkedList.AppendFirst('!');
            linkedList.AppendFirst('a');
            linkedList.AppendFirst('a');

            Console.WriteLine("Список без изменений:");
            // выводим элементы
            foreach (var item in linkedList)
                Console.WriteLine(item);

            // удаляем элемент
            linkedList.RemoveAllA(linkedList);
            Console.WriteLine("\nСписок без 'a':");
            foreach (var item in linkedList)
                Console.WriteLine(item);

            // проверяем наличие элемента
            if (linkedList.ContainsChar('!') != 0)
                Console.WriteLine("Символ ! содержится в " + linkedList.ContainsChar('!') + " элементе листа");
            else
                Console.WriteLine("Символ ! не содержится в списке");
        }
    }
}
