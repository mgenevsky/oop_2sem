#include <iostream>
using namespace std;
void foo1(int&);
bool foo2(int, int);
int main()
{
	int number, a, b;
	cout << "Enter number:" << endl;
	cin >> number;
	foo1(number);
	cout << "Answer: " << number << endl;
	cout << "Enter two numbers:" << endl;
	cin >> a >> b;
	bool answer = foo2(a, b);
	cout << "Answer:" << endl << answer << endl;
	system("pause");
}
void foo1(int& number)
{
	int temp = 1;
	while (number & temp) {
		number ^= temp;
		temp = temp << 1;
	}
	number ^= temp;
}

bool foo2(int a, int b)
{
	bool output = false;
	char res = '=';
	if (!(a >> 31) && !(b >> 31))
	{
		for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
		{
			int z = 1 << i;
			res = res == '=' ? (
				(a & z ^ b & z) ? ((a & z) ? '>' : '<') : '=') : res;
		}
	}
	else if ((a >> 31) && (b >> 31))
	{
		for (int i = sizeof(int) * 8 - 1; i >= 0; --i)
		{
			int z = 1 << i;
			res = res == '=' ? (
				(~a & z ^ ~b & z) ? ((~a & z) ? '<' : '>') : '=') : res;
		}
	}
	else if (!(a >> 31) && (b >> 31)) res = '>'; else res = '<';
	cout << a << res << b;
	output = (res == '=') ? (false) : (res == '>' ? true : false);
	return output;
}

