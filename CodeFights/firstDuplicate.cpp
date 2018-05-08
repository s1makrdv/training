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
