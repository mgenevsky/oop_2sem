#include <iostream>
#include "MyVector.h"

using namespace std;

int main()
{
	MyVector B1 = MyVector();
	MyVector B2 = MyVector(10, 45);
	MyVector B3 = MyVector(B2);
	B2 = B2 / 2;
	B3.Rotation(45);
	B1 = B2 + B3;
	cout << B1.CountLength() << " " << B1.CountCorner() << endl;
	cout << B2.CountLength() << " " << B2.CountCorner() << endl;
	cout << B3.CountLength() << " " << B3.CountCorner() << endl;
}

