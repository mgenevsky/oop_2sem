#include <iostream>
#include "Expression.h"

using namespace std;

int main()
{
    try
    {
        int size = 4;
        Expression* objArray = new Expression[size];
        objArray[0] = Expression(4, 9, 5);
        objArray[1] = Expression(-1, 7, -2);
        objArray[2] = Expression(3, -2, 1);
        objArray[3] = Expression();
        objArray[3].A = 5;
        objArray[3].C = 8;
        objArray[3].D = 1;
        for (int i = 0; i < size; i++)
        {
            cout << objArray[i].GetTheResultExpression() << endl;
        }
    }
    catch (logic_error ex)
    {
        cout << ex.what() << endl;
    }
    catch (underflow_error ex)
    {
        cout << ex.what() << endl;
    }
    catch (exception)
    {
        cout << "Unreal get result. Please, check your input variables." << endl;
    }
}