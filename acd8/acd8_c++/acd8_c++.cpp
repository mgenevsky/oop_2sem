#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int* Sort(int arr[],int size)
{
    for (int i = 0; i < size - 1; i++) {
        for (int j = 0; j < size - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
    return arr;
}
int main()
{
    srand(time(NULL));
    int size = 10;
    int* arr=new int[size];
    for (int i = 0; i < size; i++){
        arr[i] = rand() % size;
        cout << arr[i] << " ";
    }
    cout << endl;
    int* (*sort)(int[],int) = Sort;
    arr = (sort)(arr, size);
    for (int i = 0; i < size; i++)
        cout << arr[i]<<" ";
    cout << endl;
}

