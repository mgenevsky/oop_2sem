using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd4
{
    class MyVector
    {
        int length=0, corner=0;
        public MyVector()
        {

        }
        public MyVector(int a, int b)
        {
            length = a;
            corner = b;
        }
        public MyVector(MyVector a)
        {
            length = a.length;
            corner = a.corner;
        }
        public int CountLength()
        {
            return length;
        }
        public int CountCorner()
        {
            return corner;
        }
        public void Rotation(int a)
        {
            corner += a;
        }
        public static MyVector operator +(MyVector vec1, MyVector vec2)
        {
            var vec = new MyVector();
            vec.length = vec1.length + vec2.length;
            vec.corner = vec1.corner + vec2.corner;
            return vec;
        }

        public static MyVector operator /(MyVector vec, int number)
        {
            vec.length = vec.length / 2;

            return vec;
        }
    }
}
