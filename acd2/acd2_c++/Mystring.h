#pragma once
#include <string>
using namespace std;
class Mystring
{
	string mystr;
public:

	void Str(string str)
	{
		mystr = str;
	}
	int Count() 
	{
		return mystr.size();
	}
	string Numbers() 
	{
		string str = "";
		for (int i = 0; i < Count(); i++) 
		{
			if (mystr[i] >= '0' && mystr[i] <= '9')
				str += mystr[i];
		}
		return str;
	}
};