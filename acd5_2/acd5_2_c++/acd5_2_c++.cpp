#include <iostream>
#include "MyString.h"
#include "MyCapitalLetter.h"
#include "MySmallLetter.h"

using namespace std;

int main()
{
    setlocale(LC_ALL, "");
    MyString str1 = MyString("щузьпизуцЗЩПЫЬПЩЗшцйп");
    MySmallLetter str2 = MySmallLetter("ПЗщшВЫМиуйЧЩФО");
    MyCapitalLetter str3 = MyCapitalLetter("ОИМЗупшцрЩШПТШцп");
    cout << "Длинна строчки 1 - " << str1.GetLength() << endl;
    str1.Sort();
    cout << "Длинна строчки 2 - " << str2.GetLength() << endl;
    str2.Sort();
    cout << "Длинна строчки 3 - " << str3.GetLength() << endl;
    str3.Sort();
}

