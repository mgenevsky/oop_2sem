#include <iostream>
#include "Expression.h"
#include <fstream>

ofstream fout("Errors.txt");

using namespace std;

int main()
{
    try
    {
        Expression* obj = new Expression[4];
        obj[0] = Expression(4, 9, 5);
        obj[1] = Expression(-1, 7, -2);
        obj[2] = Expression(3, -2, 1);
        obj[3] = Expression();
        obj[3].A = 5;
        obj[3].C = 8;
        obj[3].D = 1;
        for (int i = 0; i < 4; i++)
        {
            fout << obj[i].GetTheResultExpression() << endl;
        }
    }
    catch (logic_error ex)
    {
        fout << ex.what() << endl;
    }
    catch (underflow_error ex)
    {
        fout << ex.what() << endl;
    }
    catch (exception)
    {
        fout << "Unreal get result. Please, check your input variables." << endl;
    }
}