#include <iostream>
#include "Expression.h"

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
            cout << obj[i].GetTheResultExpression() << endl;
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