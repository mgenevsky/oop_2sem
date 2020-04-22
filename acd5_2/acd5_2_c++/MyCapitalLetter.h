#pragma once
#include <iostream>
#include "MyString.h"

using namespace std;


class MyCapitalLetter : public MyString
{
    string Str;
public:
    MyCapitalLetter(string str) : MyString(str)
    {
        if (str != "")
        {
            for (size_t i = 0; i < str.length(); i++)
            {
                Str += toupper(str[i]);
            }
        }
    }
    virtual int GetLength() { return Str.length(); };

    void Sort() override
    {
        sort(Str.begin(), Str.end());
        cout << Str << endl;
    }
};