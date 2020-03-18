#pragma once
#include <vector>
#include "MyString.h"

class Mytext
{
	vector<Mystring> text;

public:
	void AddString(Mystring str) 
	{
		text.push_back(str);
	}
	void RemoveString(int index) 
	{
		text.erase(text.begin() + index - 1);
	}
	void Erase()
	{
		vector<Mystring> new_text;
		text = new_text;
	}
	string NumberinText()
	{
		string str = "";
		for (int i = 0; i < text.size(); i++)
		{
			str += text[i].Numbers();
		}
		return str;
	}
	int Numberofcolums()
	{
		return text.size();
	}
	void Replace(int index, Mystring str)
	{
		text[index] = str;
	}
};