#include <iostream>
#include <vector>
#include <algorithm>
#include <math.h>
#include <sstream>
#include <regex>

int minSubsetSumDiff(std::vector<int> a) {   

    const int size = a.size();
    std::sort(a.begin(), a.end());
    int end = a.size() - 1;
    int endSum = a[end];
    int start = 0;
    int startSum = a[start];
    int diff = abs(startSum - endSum);
    std::vector<int> vecA;
    std::vector<int> vecB;
    vecA.push_back(a[start]);
    vecB.push_back(a[end]);
    start++;
    end--;
    
    while (start <= end) {
        if (abs(startSum + a[start] - endSum) < abs(startSum - a[end] - endSum)) {
            diff = abs(startSum + a[start] - endSum);
            startSum += a[start];
            vecA.push_back(a[start]);
            start++;
        }
        else {
            diff = abs(startSum - a[end] - endSum);
            endSum += a[end];
            vecB.push_back(a[end]);
            end--;
        }
    }    

    if (startSum > endSum) {

        for (int i = 1; i < vecA.size(); i++) {
            int outlier = vecA[i];
            if (vecA[i] == startSum - endSum) {
                return diff - vecA[i];
            }
            else if (vecA[i] > startSum - endSum) {
                return diff - vecA[i - 1];
            }                
        }
    }
    else if(endSum > startSum){

    }

    return diff;
}

bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight) {
    
    int myMax = std::max(yourLeft, yourRight);
    int myMin = std::min(yourLeft, yourRight);

    int friendMax = std::max(friendsLeft, friendsRight);
    int friendMin = std::min(friendsLeft, friendsRight);

    return ((myMax == friendMax) && (myMin == friendMin));
}

int arrayMaximalAdjacentDifference(std::vector<int> inputArray) {
    int absMax = abs(inputArray[0] - inputArray[1]);

    for (int i = 1; i < inputArray.size() - 1; i++) {
        if (absMax < abs(inputArray[i - 1] - inputArray[i])) {
            absMax = abs(inputArray[i - 1] - inputArray[i]);
        }

        if (absMax < abs(inputArray[i] - inputArray[i + 1])) {
            absMax = abs(inputArray[i] - inputArray[i + 1]);
        }
    }

    return absMax;
}

std::vector<std::string> tokeniseString(std::string line, char delim) {
    std::vector <std::string> tokens;
    std::stringstream check1(line);
    std::string intermediate;

    while (getline(check1, intermediate, delim))
    {
        tokens.push_back(intermediate);
    }

    return tokens;
}

bool isIPv4Address(std::string inputString) {
    std::vector<std::string> vec = tokeniseString(inputString, '.');

    std::regex r("[0-9]  {1,3}   (.[0-9] {1,3})   {3}");

    const int size = vec.size();
    if (size != 4) {
        return false;
    }

    for (int i = 0; i < size; i++) {
        try {
            if (vec[i].size() >= 2 && vec[i][0] == '0') {
                return false;
            }

            int temp = std::stoi(vec[i]);

            if (vec[i].compare(std::to_string(temp)) != 0) {
                return false;
            }

            if (temp < 0 || temp > 255) {
                return false;
            }
        }
        catch (...) {
            return false;
        }
    }

    return true;
}

bool isLight(std::string cell) {

    bool isAlpEven = ((cell[0] - 'A' + 1) % 2 == 0);
    bool isNumEven = ((cell[1] - '1' + 1) % 2 == 0);

    if ((isAlpEven && isNumEven) || (!isAlpEven && !isNumEven)) {
        return false;
    }

    return true;
}

bool chessBoardCellColor(std::string cell1, std::string cell2) {

    bool isC1Light = isLight(cell1);
    bool isC2Light = isLight(cell2);

    if ((isC1Light && isC2Light) || (!isC1Light && !isC2Light)) {
        return true;
    }

    return false;
}

bool isAcceptableSequence(std::string s1, std::string s2) {

    int size = s1.length();
    int count = 0;
    for (int i = 0; i < size; i++) {
        if (s1[i] != s2[i]) {
            count++;
        }

        if (count > 1) {
            return false;
        }
    }

    if (count == 1) {
        return true;
    }

    return false;
}

bool stringsRearrangement(std::vector<std::string> inputArray) {

    int size = inputArray.size();
    int count = 0;

    while (next_permutation(inputArray.begin(), inputArray.end())) {

        count = 0;

        for (int i = 0; i < size - 1; i++) {

            if (!isAcceptableSequence(inputArray[i], inputArray[i + 1])) {
                break;
            }
            else {
                count++;
            }
        }

        if (count == size - 1) {
            return true;
        }
    }


    return false;
}

std::vector<int> extractEachKth(std::vector<int> inputArray, int k) {
    std::vector<int> newVec = {};
    int size = inputArray.size();

    for (int i = 0; i < size; i++) {

        if ((i + 1) % k != 0) {
            newVec.push_back(inputArray[i]);
        }
    }

    return newVec;
}


int main()
{
    std::vector<int> vec = { 2, 7, 10, 5, 3 };
    std::vector<std::string> arr = { "bbc",
 "bba",
 "abc" };
    std::string smt = "A1";
    std::string smtB = "H3";   

    //for (int i = 0; i < vec.size(); i++) {
    //    if (vec[i] == 7) {
    //        vec.insert(vec.begin() + i+1, 555); //+1 adds after i 

    //        break;
    //    }
    //}

    //for (int x : vec) {
    //    std::cout << x << " ";
    //} //2 7 555 10 5 3

    //for (int i = 0; i < vec.size(); i++) {
    //    if (vec[i] == 5) {
    //        vec.erase(vec.begin() + i);
    //        break;
    //    }
    //}
    //std::cout << "\n";

    //for (int x : vec) {
    //    std::cout << x << " ";
    //} //2 7 555 10 3    

    std::cout << stringsRearrangement(arr);
    std::cout << "\n" << 'H' - 'A';
    std::string result = "a";
    result[0] += 1;
    std::cout << "\n" << result;
    int x;
    std::cin >> x;

    return 0;
}
