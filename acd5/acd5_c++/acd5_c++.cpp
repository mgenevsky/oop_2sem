#include <iostream>
#include "MyLine.h"
#include "MySection.h"
#include <math.h>

using namespace std;
    
int main()
{
    setlocale(LC_ALL, "");
    MyLine A = MyLine(1, 6, 1, 2); //(x1,y1,x2,y2);
    cout << "Длинна прямой A = " << A.Lenght() << endl;
    MySection B = MySection(1, 1, 3, 3); //(x1,y1,x2,y2);
    MySection C = MySection(2, 2, 4, 4); //(x1,y1,x2,y2);
    cout << "Угл между отрезками B и C = " << MySection::Angle(B, C) << " радиан " << endl;
    cout << "Угл между отрезками B и осью Oy = " << MySection::AngleOy(B) << " радиан " << endl;
    cout << "Отрезок C имеет такие координаты - "; C.Parameters();
}
