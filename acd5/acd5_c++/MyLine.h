#pragma once
#include <iostream>
#include <math.h>
using namespace std;



class MyLine
{
    double x1, x2, y1, y2;
public:
    MyLine(double a, double b, double c, double d)// (0;0) (1;1) //
    {
        x1 = a;
        x2 = c;
        y1 = b;
        y2 = d;
    }
    double Lenght()
    {
        return sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
    }
};