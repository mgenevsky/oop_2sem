#pragma once
#include <iostream>
#include <math.h>
#include "MyLine.h"
using namespace std;



class MySection : MyLine
{
    double x1, y1, x2, y2;
public:
    MySection(double a, double b, double c, double d) : MyLine(a, b, c, d)// (0;0) (1;1) //
    {
        x1 = a;
        x2 = c;
        y1 = b;
        y2 = d;
    }
    static double Angle(MySection A, MySection B)
    {
        return acos(((A.x2 - A.x1) * (A.y2 - A.y1) + (B.x2 - B.x1) * (B.y2 - B.y1)) / (sqrt(pow((A.x2 - A.x1), 2) + pow((B.x2 - B.x1), 2)) * (sqrt(pow((A.y2 - A.y1), 2) + pow((B.y2 - B.y1), 2)))));
    }
    static double AngleOy(MySection A)
    {
        MySection Oy = MySection(0, 0, 0, 1);
        MySection NewA = MySection(0, 0, A.x2 - A.x1, A.y2 - A.y1);
        return Angle(NewA, Oy);
    }
    void Parameters()
    {
        cout << "начало (" << x1 << "," << y1 << ") " << "конец (" << x2 << "," << y2 << ")" << endl;
    }
};