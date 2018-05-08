/*
Note: Write a solution with O(n) time complexity and O(1) additional space complexity, 
since this is what you would be asked to do during a real interview.
Given an array a that contains only numbers in the range from 1 to a.length, 
find the first duplicate number for which the second occurrence has the minimal index. 
In other words, if there are more than 1 duplicated numbers, 
return the number for which the second occurrence has a smaller index than the second occurrence of the other number does. 
If there are no such elements, return -1.
*/
#include "stdafx.h"
#include <iostream>
#include <vector>
#include <map>

using namespace std;

int firstDuplicate(vector<int> a)
{
	map<int, int> dict;
	for (int i = 0; i < a.size(); i++) {
		if (dict.find(a[i]) != dict.end()) {
			dict.at(a[i]) += 1;
		}
		else {
			dict.insert(pair<int,int>(a[i],1));
		}
		if (dict.at(a[i]) == 2) {
			return a[i];
		}
	}
	return -1;
}

int main() {
                        //   __________________________
                        //  |   ___________	       |		
                        //  |  |   _____   |           |
                        //  |  |  |     |  |           |
	vector<int> arr = { 8, 4, 6, 2, 6, 4, 7, 9, 5, 8 };
			//  0  1  2  3  4  5  6  7  8  9
	cout << firstDuplicate(arr) << endl;
	system("pause");
	return 0;
}

//Best solution is:
/*
int firstDuplicate(std::vector<int> a) {
    for(int i=0; i < a.size(); i++){
        int t = abs(a[i]);
        if(a[t - 1] < 0)
            return t;
        a[t - 1] = - a[t - 1];
    }
    return -1;
}
*/
