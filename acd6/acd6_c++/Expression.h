#pragma once
#include <exception>
#include <stdexcept>
#include <math.h>

using namespace std;

class Expression
{
public:
    double A, C, D;

    Expression() {A = 0;C = 0;D = 0;}
    Expression(double a, double c, double d){A = a;C = c;D = d;}

    float GetTheResultExpression()
    {
        if (A == 4)
            throw logic_error("Division on Zero!");
        if (A < 0)
            throw underflow_error("Negative square root!");
        return (double)((2 * C - D + sqrt(23 * A)) / (A / 4 - 1));
    }
};