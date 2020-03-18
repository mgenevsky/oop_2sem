#include <iostream>
#include "Mystring.h"
#include "Mytext.h"

using namespace std;

int main()
{
	Mystring str1, str2, str3, str4;
	Mytext text;
	str1.Str("adafaf");
	str2.Str("123123");
	str3.Str("!#!$$");
	str4.Str("asdasfdfwfwew123");
	text.AddString(str1);
	text.AddString(str2);
	text.AddString(str3);
	text.AddString(str4);
	cout << text.NumberinText()<<endl ;
	//  text.RemoveString(1);
	// text.Erase();
}