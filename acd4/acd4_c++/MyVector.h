#pragma once
#include <iostream>
using namespace std;

class MyVector
{
	int length = 0, corner = 0;
public:
	MyVector()
	{

	}
	MyVector(int a, int b)
	{
		length = a;
		corner = b;
	}
	MyVector(const MyVector& a)
	{
		length = a.length;
		corner = a.corner;
	}
	int CountLength()
	{
		return length;
	}
	int CountCorner()
	{
		return corner;
	}
	void Rotation(int a)
	{
		corner += a;
	}
	MyVector operator +(MyVector vec1)
	{
		MyVector vec = MyVector();
		vec.length = vec1.length + this->length;
		vec.corner = vec1.corner + this->corner;
		return vec;
	}

	MyVector operator /(int number)
	{
		MyVector vec = MyVector();
		vec.length = this->length / number;
		vec.corner = this->corner;
		return vec;
	}


};