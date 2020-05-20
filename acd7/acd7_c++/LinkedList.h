#pragma once
#include "Node.h"
#include <iostream>

using namespace std;

class LinkedList
{
public:
	Node* head; // головной/первый элемент
	Node* tail; // последний/хвостовой элемент
	int count;  // количество элементов в списке

	void RemoveAllA(LinkedList Linkedlist)
	{
		Node* temp = head;
		while (temp != NULL) {
			Linkedlist.Remove('a');
		}
	}
	void PrintList() {
		Node* temp = head;
		while (temp != NULL) {
			cout << temp->Data << endl;
			temp = temp->Link;
		}
	}

	int ContainsChar(char data)
	{
		int counter = 1;
		Node* temp = head;
		while (temp != NULL)
		{
			if (temp->Data == data)
				return counter;
			temp = temp->Link;
			counter++;
		}
		return 0;
	}

	void AppendFirst(Node *node) {

		Node* prevhead = head;
		head = node;
		head->Link = prevhead;
		bool flag = true;
		while(flag)
		{
			if (prevhead->Link == NULL) flag = false;
			else
			{
				prevhead->Link = prevhead->Link->Link;
			}
		}
	}
private:
	bool Remove(char data)
	{
		Node* temp = head->Link;
		Node* previous= head;

		while (temp != NULL)
		{
			if (temp->Data == data)
			{
				previous->Link = temp->Link;
				if (temp->Link == NULL)
					head = previous;
				return true;
			}
			previous = temp;
			temp = temp->Link;
		}
		return false;
	}

};