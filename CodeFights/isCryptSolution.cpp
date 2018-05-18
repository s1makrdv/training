#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <map>
using namespace std;

bool isCryptSolution(vector<string> crypt, vector<vector<char>> solution) {
   map<char, char> solutionMap;
   for (auto i : solution) {
      solutionMap.insert(pair<char, char>(i[0], i[1]));
   }

   int sum = 0;
   string stringArr[3] = { "","","" };
   for (size_t i = 0; i < 3; i++) {
      size_t stringSize = crypt[i].size();
      for (size_t j = 0; j < stringSize; j++) {
         stringArr[i] += solutionMap.at(crypt[i][j]);
      }
      if ((stringArr[i][0] == '0') && (stringSize > 1) ) {
         return false;
      }
   }
   sum = stoi(stringArr[0]) + stoi(stringArr[1]); 
   
   if (stoi(stringArr[2]) != sum) {
      return false;
   }
   else {
      return true;
   }
}

int main()
{

   /*
   vector<string> crypt = { "SEND", "MORE", "MONEY" };
   vector<vector<char>> solution =   { {'O', '0'},
                                       {'M', '1'},
                                       {'Y', '2'},
                                       {'E', '5'},
                                       {'N', '6'},
                                       {'D', '7'},
                                       {'R', '8'},
                                       {'S', '9'} };
   */
  
   vector<string> crypt = { "TEN","TWO","ONE" };
   vector<vector<char>> solution = { { "O","1" },
                                    { "T","0" },
                                    { "W","9" },
                                    { "E","5" },
                                    { "N","4" } };
  

   cout << "IsCryptSolution: "
      << (isCryptSolution(crypt, solution) ? "true" : "false")
      << endl;


   //system("pause");
   return 0;
}
