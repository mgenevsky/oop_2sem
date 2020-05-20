#include <iostream>
#include "LinkedList.h"
using namespace std;

int main()
{
    setlocale(LC_ALL, "");
    LinkedList linkedlist;
    linkedlist.head = new Node('a');
    Node* node1 = new Node('!');
    Node* node2 = new Node('a');
    Node* node3 = new Node('b');
    Node* node4 = new Node('q');
    Node* node5 = new Node('z');
    Node* node6 = new Node('a');
    Node* node7 = new Node('!');
    Node* node8 = new Node('a');
    Node* node9 = new Node('a');
    linkedlist.AppendFirst(node1);
    linkedlist.AppendFirst(node2);
    linkedlist.AppendFirst(node3);
    linkedlist.AppendFirst(node4);
    linkedlist.AppendFirst(node5);
    linkedlist.AppendFirst(node6);
    linkedlist.AppendFirst(node7);
    linkedlist.AppendFirst(node8);
    linkedlist.AppendFirst(node9);
    cout << "Список без изменений:"<<endl;
    linkedlist.PrintList();

    // удаляем элемент
    linkedlist.RemoveAllA(linkedlist);
    cout << "\nСписок без 'a':"<<endl;
    linkedlist.PrintList();

    // проверяем наличие элемента
    if (linkedlist.ContainsChar('!') != 0)
        cout << "Символ ! содержится в " << linkedlist.ContainsChar('!') << " элементе листа" << endl;
    else
        cout << "Символ ! не содержится в списке" << endl;
}