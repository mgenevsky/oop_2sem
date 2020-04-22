#pragma once
#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

class MyString
{
    string Str;
public:

    MyString(string str)
    {
        Str = str;
    }
    virtual int GetLength() { return Str.length(); };

    virtual void Sort() {
        sort(Str.begin(), Str.end());
        cout << Str << endl;
    }
};