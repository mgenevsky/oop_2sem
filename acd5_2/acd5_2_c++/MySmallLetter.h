#pragma once
#include <iostream>
#include "MyString.h"

using namespace std;

class MySmallLetter : public MyString
{
    string Str;
public:
    MySmallLetter(string str) : MyString(str)
    {
        if (str != "")
        {
            for (size_t i = 0; i < str.length(); i++)
            {
                Str += tolower(str[i]);
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