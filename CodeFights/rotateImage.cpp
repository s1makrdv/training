//You are given an n x n 2D matrix that represents an image.Rotate the image by 90 degrees(clockwise).
#include "stdafx.h"
#include <iostream>
#include <iomanip>
#include <vector>

using namespace std;

void printMatrix(const vector<vector<int>> a)
{
   for (auto i : a) {
      for (auto j : i) {
         cout << setw(2) << j << ' ';
      }
      cout << endl;
   }
}

vector<vector<int>> rotateImage(vector<vector<int>> a) 
{
   vector<vector<int>> v(a);
   size_t size = v[0].size();
   int k = 0;
   for (int i = 0; i <= (size - 1); i++) {
      for (int j = i + 1; j < (size - i); j++) {
         k = v[j][size - i - 1];
         v[j][size - i - 1] = v[i][j];
         v[i][j]            = v[size - j - 1][i];
         v[size - j - 1][i] = v[size - 1 - i][size - 1 - j];
         v[size - 1 - i][size - 1 - j] = k;
      }
   }
   return v;
}

int main()
{
   vector<vector<int>> matrix = { {1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16} };
   printMatrix(matrix);
   cout << endl;
   printMatrix(rotateImage(matrix));
   system("pause");
   return 0;
}

/*Best Solve
std::vector<std::vector<int>> rotateImage(std::vector<std::vector<int>> a) {
    int n = a.size();
    for(int i = 0; i < n; ++i)
    {
        for(int j = i; j < n-i-1; ++j)
        {
            swap(a[i][j],a[j][n-i-1]);
            swap(a[i][j],a[n-i-1][n-j-1]);
            swap(a[i][j],a[n-j-1][i]);
        }
    }
    return a;
}

*/
