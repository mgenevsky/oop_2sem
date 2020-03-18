using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acd2_c
{
    class Mytext
    {
        Mystring[] Text;
        int size;
        public void AddString(Mystring str)
        {
            Array.Resize(ref Text, ++size);
            Text[size - 1] = str;
        }
        public void DelString(int index)
        {
            index--;
            var newData = new Mystring[Text.Length - 1];
            for (int i = 0; i < index; i++)
                newData[i] = Text[i];
            for (int i = index; i < newData.Length; i++)
                newData[i] = Text[i + 1];
            Text = newData;
            size--;
        }
        public void ReplaceString(int index,Mystring str)
        {
            Text[index - 1] = str;
        }
        public void Erase()
        {
            Mystring[] text = new Mystring[0];
            Text = text;
            size = 0;
        }
        public int Number_of_strings()
        {
            return size;
        }
        public string DigitString()
        {
            String str = "";
            foreach (var item in Text)
                str += item.Numbers();
            return str;
        }
    }
}
