using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new int[] { 2, 3 };
            var test2 = new int[] { -1, 150, 190, 170, -1, -1, 160, 180 };
            var test3 = new int[][] { new int[] { 7, 4, 0, 1 }, new int[] { 5, 6, 2, 2 }, new int[] { 6, 10, 7, 8 }, new int[] { 1, 4, 2, 0 } };
            var str = new string[] { "abc", "eee", "abc", "dcd" };

            //foreach (var i in boxBlur(test3))
            //{
            //    foreach(var j in i)
            //    {
            //        Console.Write(j);
            //    }
            //    Console.WriteLine();                
            //}
            str.First(x => x == nameof(String));
            

            Console.ReadLine();
        }

        public static bool isMAC48Address(string inputString)
        {
            var alphabets = "ABCDEF1234567890";            
            var alpDict = new Dictionary<char, char>();
            foreach(var alp in alphabets){
                alpDict.Add(alp, alp);
            }

            var tokens = inputString.Split('-');
            if(tokens.Length != 6)
            {
                return false;
            }

            foreach(var token in tokens)
            {
                if(token.Length != 2)
                {
                    return false;
                }

                if (!alpDict.ContainsKey(token[0]) ||  !alpDict.ContainsKey(token[1]) )
                {
                    return false;
                } 
            }

            return true;
        }

        public static bool variableName(string name)
        {
            string regex = @"[a-zA-Z][a-zA-Z0-9_]*";
            var reg = new Regex(regex);

            return reg.IsMatch(name);
        }

        static bool evenDigitsOnly(int n)
        {

            while (n >= 10)
            {
                int temp = n % 10;

                if (temp != 0 && temp % 2 != 0)
                {
                    return false;
                }

                n /= 10;
            }

            if (n != 0 && n % 2 != 0)
            {
                return false;
            }

            return true;
        }

        public static int[][] boxBlur(int[][] image)
        {
            int y = image.Length;
            int x = image[0].Length;
            var boxBlur = new int[y-2][];

            for (int i = 0; i < y - 2; i++)
            {
                boxBlur[i] = new int[x-2];
            }                

            int xBox = 0;
            int yBox = 0;
            for(int i = 1; i < y - 1; i++)
            {                
                for(int j = 1; j < x - 1; j++)
                {
                    var newPixel =
                        image[i - 1][j - 1] + image[i - 1][j] + image[i - 1][j + 1] +
                        image[i][j - 1] + image[i][j] + image[i][j + 1] +
                        image[i + 1][j - 1] + image[i + 1][j] + image[i + 1][j + 1];

                    boxBlur[yBox][xBox] = newPixel / 9;

                    xBox++;
                }

                xBox = 0;
                yBox++;
            }

            return boxBlur;
        }

        public static List<string> closestStraightCity(List<string> c, List<int> x, List<int> y, List<string> q)
        {
            //iter thru each q
            //iter thru each x and y, keep track of min distance
            //if min distance is same, store cities in List
            //take the alphabettically smallest list, append to AnsList

            int querySize = q.Count;
            int citiesSize = x.Count;
            var ansList = new List<string>();
            for (int i = 0; i < querySize; i++)
            {
                //find city
                int tempIndex = -1;
                for (int j = 0; j < citiesSize; j++)
                {
                    if (q[i] == c[j])
                    {
                        tempIndex = j;
                        break;
                    }
                }

                int tempX = x[tempIndex];
                int tempY = y[tempIndex];
                var tempList = new List<int>();
                int minDist = 214748350;

                //check x
                for (int j = 0; j < citiesSize; j++)
                {
                    if (c[j] == q[i])
                    {
                        continue;
                    }

                    if (tempX == x[j])
                    {

                        if (Math.Abs(tempY - y[j]) < minDist)
                        {
                            minDist = Math.Abs(tempY - y[j]);
                            tempList.Clear();
                            tempList.Add(j);
                        }

                        if (Math.Abs(tempY - y[j]) < minDist)
                        {
                            tempList.Add(j);
                        }
                    }

                    if (tempY == y[j])
                    {
                        minDist = Math.Abs(tempX - x[j]);
                        tempList.Add(j);

                        if (Math.Abs(tempX - x[j]) < minDist)
                        {
                            minDist = Math.Abs(tempX - x[j]);
                            tempList.Clear();
                            tempList.Add(j);
                        }

                        if (Math.Abs(tempX - x[j]) < minDist)
                        {
                            tempList.Add(j);
                        }
                    }

                    if (tempList.Count == 0)
                    {
                        ansList.Add("NONE");
                    }
                    else if (tempList.Count == 1)
                    {
                        ansList.Add(c[tempList[0]]);
                    }
                    else
                    {
                        ansList.Sort();
                        ansList.Add(c[tempList[0]]);
                    }


                }


            }

            return ansList;
        }

        public static int countPairs(List<int> numbers, int k)
        {
            int size = numbers.Count;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < size; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict.Add(numbers[i], numbers[i]);
                }
            }

            int count = 0;
            var doneDict = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < size; i++)
            {

                if (!doneDict.ContainsKey(numbers[i]))
                {
                    doneDict.Add(numbers[i], new Dictionary<int, int>());
                }

                int b = k + numbers[i];
                if (doneDict.TryGetValue(numbers[i], out var specDict) && dict.ContainsKey(b))
                {
                    if (!specDict.ContainsKey(b))
                    {
                        specDict.Add(b,b);
                        count++;
                    }
                }
            }

            return count;
        }

        static void miniMaxSum(int[] arr)
        {
            Array.Sort(arr);

            long min = 0;
            for (int i = 0; i < 4; i++)
            {
                min += arr[i];
            }

            long max = min + arr[4] - arr[0];

            Console.Write(min + " " + max);
        }

        static void staircase(int n)
        {
            int hashAmnt = 1;
            for (int i = 0; i < n; i++)
            {                
                var tempList = new List<char>();
                for (int j = 1; j <= n - hashAmnt; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= hashAmnt; j++)
                {
                    Console.Write("#");
                }
                hashAmnt++;
                Console.WriteLine();
            }
        }

        //hackerrank
        public static int diagonalDifference(List<List<int>> arr)
        {
            int diff = 0;
            int size = arr.Count();
            int end = size - 1;
            for (int i = 0; i < size; i++)
            {
                int left = arr[i][i];
                int right = arr[i][end];
                diff = diff + left - right;
                end--;
            }

            return Math.Abs(diff);
        }
 
        public static int avoidObstacles(int[] inputArray)
        {
            var sortedArr = inputArray.OrderBy(x => x).ToArray();
            var maxNum = sortedArr[sortedArr.Length - 1];
            var size = sortedArr.Length;

            var dict = new Dictionary<int, int>();
            foreach(var val in sortedArr)
            {
                if(!dict.ContainsKey(val))
                    dict.Add(val, val);
            }

            int longOcc = 2;
            
            int traverse = longOcc;
            while(traverse <= maxNum)
            {
                if (!dict.ContainsKey(traverse))
                {
                    traverse += longOcc;
                }
                else
                {
                    longOcc++;
                    traverse = longOcc;
                }
            }

            return longOcc;
        }

        public static bool areSimilar(int[] a, int[] b)
        {
            bool isSimilar = true;
            bool hasDifference = false;
            int differA = -1;
            int differB = -1;
            int size = a.Length;

            for (int i = 0; i < size; i++)
            {
                if (hasDifference && a[i] != b[i]
                && (differA != b[i] || differB != a[i]))
                    return false;

                if (a[i] != b[i])
                {
                    hasDifference = true;
                    differA = a[i];
                    differB = b[i];
                }
            }

            return isSimilar;
        }

        public static string[] addBorder(string[] picture)
        {
            int arrSize = picture.Length;
            int strSize = picture[0].Length;

            var newPict = new string[arrSize + 2];
            var starSb = new StringBuilder();

            for (int i = 0; i < strSize + 2; i++)
                starSb.Append('*');

            newPict[0] = starSb.ToString();
            newPict[arrSize + 1] = starSb.ToString();

            for(int i = 1; i < arrSize + 1; i++)
            {
                var strSb = new StringBuilder();
                strSb.Append('*');
                strSb.Append(picture[i - 1]);
                strSb.Append('*');

                newPict[i] = strSb.ToString();
            }

            return newPict;
        }

        public static int[] alternatingSums(int[] a)
        {
            var weightArr = new int[2];
            bool firstTeam = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (firstTeam)
                {
                    weightArr[0] += a[i];
                    firstTeam = false;
                }
                else
                {
                    weightArr[1] += a[i];
                    firstTeam = true;
                }
            }

            return weightArr;
        }

        public static string reverseInParentheses(string inputString)
        {
            int size = inputString.Length;
            var list = new List<char>();
            for (int i = 0; i < size; i++)
                list.Add(inputString[i]);
            
            var mem = new Stack<int>(size);            
            for(int i = 0; i < size; i++)
            {
                if(list[i] == '(')
                {
                    mem.Push(i);
                }

                if(list[i] == ')')
                {
                    int openBracketIndex = mem.Pop();
                    int closingIndex = i;
                    list = ReverseList(list, openBracketIndex + 1, closingIndex - 1);
                }
            }

            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] == '(' || list[i] == ')')
                {
                    list.RemoveAt(i);
                    i--;
                }                  
            }

            return string.Join("",list.ToArray());
        }
        
        public static List<char> ReverseList(List<char> list, int start, int end)
        {
            int pivot = (start + end) / 2 + 1;                

            for (int i = start; i < pivot; i++)
            {
                while (list[i] == '(')
                    i++;
                while (list[end] == ')')
                    end--;

                var temp = list[i];
                list[i] = list[end];
                list[end] = temp;

                end--;
            }

            return list;
        }

        public static int[] sortByHeight(int[] a)
        {
            var list = new List<int>();

            foreach(var x in a)
            {
                if (x != -1)
                    list.Add(x);
            }

            if(list.Count == 0)
            {
                return a;
            }

            var newArr = list.ToArray();
            var sortedArr = modifiedSort(newArr, 0, newArr.Length-1);

            int sortedIndex = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if(a[i] != -1)
                {
                    a[i] = sortedArr[sortedIndex];
                    sortedIndex++;
                }
            }

            return a;
        }

        public static int[] modifiedSort(int[] a, int l, int r)
        {
            int i, j;
            int pivot;            
            i = l;
            j = r;
            pivot = a[(l + r) / 2];

            while (true)
            {
                while (a[i] < pivot)
                    i++;
                while (pivot < a[j])
                    j--;
                if(i <= j)
                {
                    var temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
                if (i > j)
                    break;
            }

            if(l < j)            
                a = modifiedSort(a, l, j);            
            if(i < r)            
                a = modifiedSort(a, i, r);            

            return a;
        }

        public static int[] QuickSort(int[] data, int l, int r)
        {
            int i, j;
            int pivot;
            i = l;
            j = r;
            pivot = data[(l + r) / 2];

            while (true)
            {
                while (data[i] < pivot)
                    i++;
                while (pivot < data[j])
                    j--;
                if (i <= j)
                {
                    var temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
                if (i > j)
                    break;
            }
            if (l < j)
                data = QuickSort(data, l, j);
            if (i < r)
                data = QuickSort(data, i, r);

            return data;
        }

        public static object BinarySearchIterative(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Nil";
        }

        public static string[] allLongestStrings(string[] inputArray)
        {
            var size = inputArray.Length;
            var result = new List<string>();            
            result.Add(inputArray[0]);
            int longest = inputArray[0].Length;

            for(int i = 1; i < size; i++)
            {
                var strSize = inputArray[i].Length;

                if (strSize > longest)
                {
                    result.Clear();
                    longest = strSize;
                    result.Add(inputArray[i]);
                }
                else if (strSize == longest)
                {
                    result.Add(inputArray[i]);
                }                
            }

            return result.ToArray();
        }

        public static int matrixElementsSum(int[][] matrix)
        {
            int totalCost = 0;
            int numArr = matrix.Length;
            int arrSize = matrix[0].Length;

            for(int i = 0; i < numArr; i++)
            {
                for(int j = 0; j < arrSize; j++)
                {
                    if(matrix[i][j] == 0 && i != numArr-1)
                    {                        
                        matrix[i + 1][j] = 0;
                    }
                    else
                    {
                        totalCost += matrix[i][j];
                    }
                }
            }

            return totalCost;
        }

        public class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }
        
        public static int findMiddleElement(ListNode<int> l)
        {
            var traverseNode = l;
            var nodeDepth = 0;
            var midDepth = 0;
            var dict = new Dictionary<int, int>();

            while(traverseNode.next != null)
            {
                dict.Add(nodeDepth, traverseNode.value);
                traverseNode = traverseNode.next;
                nodeDepth++;
            }
            dict.Add(nodeDepth, traverseNode.value);
            
            if(nodeDepth%2 == 0)
            {
                midDepth = nodeDepth / 2;
            }
            else
            {
                midDepth = (nodeDepth / 2) + 1;
            }

            dict.TryGetValue(midDepth, out var element);

            return element;
        }

        public static int missingNumber(int[] arr)
        {
            var size = arr.Length;
            var dict = new Dictionary<int, int>(size);
            var missingNum = -1;

            for(int i = 0; i < size; i++)
            {
                dict.Add(arr[i], i);
            }

            if(!dict.ContainsKey(0))
            {
                return 0;
            }

            if (!dict.ContainsKey(size))
            {
                return size;
            }

            for(int i = 0; i < size; i++)
            {
                if(arr[i] != size && !dict.ContainsKey(arr[i]+1))
                {
                    missingNum = arr[i] + 1;
                    break;
                }
            }

            if(missingNum == -1)
            {
                missingNum = size;
            }

            return missingNum;
        }

        public static int missingNumber2(int[] arr)
        {
            int size = arr.Length;
            int missingNum = -1;
            var sortedArr = QuickSort(arr, 0, size - 1);

            for(int i = 1; i < size; i++)
            {
                if(sortedArr[i] - sortedArr[i-1] == 2)
                {
                    missingNum = sortedArr[i] - 1;
                }
            }

            return missingNum;
        }

        public static int[] QuickSort2(int[] arr, int leftBound, int rightBound)
        {
            int leftIndex, rightIndex, pivot;

            leftIndex = leftBound;
            rightIndex = rightBound;

            pivot = arr[(leftBound + rightBound) / 2];
            while (true)
            {

                while (arr[leftIndex] < pivot)
                {
                    leftIndex++;
                }

                while (arr[rightIndex] > pivot)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    var temp = arr[leftIndex];
                    arr[leftIndex] = arr[rightIndex];
                    arr[rightIndex] = temp;
                    leftIndex++;
                    rightIndex--;
                }

                if (leftIndex > rightIndex)
                {
                    break;
                }
            }

            return arr;
        }

        bool almostIncreasingSequence(int[] sequence)
        {
            int size = sequence.Length;
            bool broken = false;
            var dict = new Dictionary<int, int>();
            int max = sequence[0];
            int brokenNum = 0;

            dict.Add(sequence[0], 0);

            for (int i = 1; i < size; i++)
            {
                if(broken)
                {
                    if(sequence[i] <= sequence[i - 1])
                    {
                        return false;
                    }
                    else if (sequence[i] != brokenNum && dict.ContainsKey(sequence[i]))
                    {
                        return false;
                    }
                    else if (sequence[i] < max)
                    {
                        return false;
                    }                    
                }

                if(sequence[i] <= sequence[i - 1])
                {
                    broken = true;

                    if(i == 1)
                    {
                        max = sequence[1];
                    }
                    else if(i != 1 && sequence[i-2] < sequence[i])
                    {
                        max = sequence[i];
                        brokenNum = sequence[i - 1];
                    }
                    else if(i != 1)
                    {
                        max = sequence[i-1];
                        brokenNum = sequence[i];
                    }
                }

                if (!dict.ContainsKey(sequence[i]))
                {
                    dict.Add(sequence[i], i);
                }
            }

            return true;
        }

        public static int makeArrayConsecutive2(int[] statues)
        {
            var sortedStatues = Sort(statues);
            int cons = 0;

            for(int i = 1; i < sortedStatues.Length; i++)
            {
                cons = cons + (sortedStatues[i] - sortedStatues[i - 1] - 1);
            }

            return cons;
        }

        public static int[] Sort(int[] data)
        {
            return QuickSort(data, 0, data.Length - 1);
        }

        public static string SortString(string s)
        {
            var result = new StringBuilder();
            
            var alphabets = "abcdefghijklmnopqrstuvwxyz";
            var alpDict = new Dictionary<char, int>();
            var posDict = new Dictionary<int, char>();
            for (int i = 0; i < alphabets.Length; i++)
            {
                alpDict.Add(alphabets[i], i);
                posDict.Add(i, alphabets[i]);
            }

            var sList = new List<char>(s.Length);
            for(int i = 0; i < s.Length; i++)
            {
                sList.Add(s[i]);
            }

            bool smallStart = true;
            int setIndex = 0;
            int smallPos = alphabets.Length - 1;            
            int bigPos = 0;

            for(int i = 0; result.Length != s.Length; i++)
            {

                if(result.Length > 0 && smallPos == result[result.Length - 1])
                {
                    smallPos = sList[0];
                }

                alpDict.TryGetValue(sList[i], out var pos);
                if(result.Length == 0 && pos < smallPos)
                {
                    smallPos = pos;
                    setIndex = i;
                }
                else if (pos < smallPos && pos > result[result.Length - 1])
                {
                    smallPos = pos;
                    setIndex = i;
                }

                if(i == sList.Count - 1)
                {
                    posDict.TryGetValue(smallPos, out var small);
                    result.Append(small);
                    sList.RemoveAt(setIndex);
                    i = 0;                    
                }                
            }

            return result.ToString();
        }

        public class StringProfile
        {
            public char alp;
            public int alpPos;
            public int occurence { get; set; }

            public StringProfile(char alp, int alpPos)
            {
                this.alp = alp;
                this.alpPos = alpPos;
                occurence = 1;
            }
        }

        static public int CountNegatives(int[][] grid)
        {
            var numNeg = 0;
            var m = grid.Length;
            var n = grid[0].Length;
            var totalNum = m * n;            

            return 0;
        }

        static public int Maximum69Number(int num)
        {
            var newNum = 0;
            var numList = new List<int>();

            while(num > 10)
            {
                numList.Add(num % 10);
                num /= 10;
            }
            numList.Add(num);

            bool changed = false;

            for(int i = numList.Count - 1; i >= 0 ; i--)
            {
                if(numList[i] == 6 && !changed)
                {
                    numList[i] = 9;
                    changed = true;
                }                

                newNum += numList[i] * Convert.ToInt32(Math.Pow(10, i));
            }

            return newNum;
        }

        public int[] ReplaceElements(int[] arr)
        {
            var size = arr.Length;
            var newArr = new int[size];
            newArr[size - 1] = -1;

            for(int i = 0; i < size-1; i++)
            {
                var max = 0;

                for(int j = i + 1; j < size; j++)
                {
                    if(arr[j] > max)
                    {
                        max = arr[j];
                    }
                }

                newArr[i] = max;
            }

            return newArr;
        }

        //undone
        public int GetDecimalValue(ListNode head)
        {
            int sum = 0;

            while(head.next != null)
            {
                if(head.val == 1)
                {
                    sum = sum + Convert.ToInt32(Math.Pow(head.val, 2));
                }
                
                head = head.next;
            }
            sum = sum + Convert.ToInt32(Math.Pow(head.val, 2));

            return sum;
        }

        public static int BalancedStringSplit(string s)
        {
            int splits = 0;
            int L = 0;
            int R = 0;

            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == 'L')
                {
                    L++;
                }
                else
                {
                    R++;
                }

                if(L == R)
                {
                    splits++;
                }
            }

            return splits;
        }

        //wrong
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            var tempMax = index.Length;
            for (int i = 1; i < index.Length; i++){
                if(index[i] > tempMax)
                {
                    tempMax = index[i];
                }
            }

            var target = new int[tempMax];
            var targetHit = new bool[tempMax];

            for(int i = 0; i < nums.Length; i++)
            {
                if (!targetHit[index[i]])
                {
                    target[index[i]] = nums[i];
                    targetHit[index[i]] = true;
                }
                else
                {
                    for(int j = index[i]; j < tempMax; j++)
                    {
                        target[j + 1] = target[j];
                        targetHit[j + 1] = true;
                    }

                    target[index[i]] = nums[i];
                    targetHit[index[i]] = true;
                }

            }

            return target;
        }

        public static int FindNumbers(int[] nums)
        {
            var evenNum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var temp = nums[i];
                var isEven = false;

                while (temp >= 10)
                {
                    temp /= 10;

                    if (isEven)
                    {
                        isEven = false;
                    }
                    else
                    {
                        isEven = true;
                    }
                }

                if (isEven)
                {
                    evenNum++;
                }
            }

            return evenNum;
        }

        public static int SubtractProductAndSum(int n)
        {
            var listStr = new List<int>();

            while(n >= 10)
            {
                listStr.Add(n % 10);
                n = n / 10;
            }
            listStr.Add(n);

            var sum = 0;
            var prd = 1;
            for(int i = 0; i < listStr.Count; i++)
            {
                sum += listStr[i];
                prd *= listStr[i];
            }

            return prd-sum;
        }

        public static int[] DecompressRLElist(int[] nums)
        {
            int size = 0;

            for(int i = 0; i < nums.Length; i += 2)
            {
                size = size + nums[i];
            }

            var decompressed = new int[size];
            var lastIndex = 0;

            for(int i = 1; i < nums.Length; i += 2)
            {
                for(int j = 0; j < nums[i-1]; j++)
                {
                    decompressed[lastIndex] = nums[i];
                    lastIndex++;
                }
            }

            return decompressed;
        }

        public int NumJewelsInStones(string J, string S)
        {
            int numOfJewels = 0;
            var dictJewels = new Dictionary<char, int>(J.Length);

            for(int i = 0; i < J.Length; i++)
            {
                dictJewels.Add(J[i], i);
            }

            for(int i = 0; i < S.Length; i++)
            {
                if (dictJewels.ContainsKey(S[i]))
                {
                    numOfJewels++;                    
                }
                
            }

            return numOfJewels;
        }

        static public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var numSmaller = new int[nums.Length];
            int num = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j > nums.Length; j++)
                {
                    if(nums[i] > nums[j])
                    {
                        num++;
                    }
                }

                numSmaller[i] = num;
                num = 0;
            }

            return numSmaller;
        }

        static public string DefangIPaddr(string address)
        {
            var sb = new StringBuilder();

            for(int i = 0; i < address.Length; i++)
            {
                if(address[i] == '.')
                {
                    sb.Append("[.]");
                }
                else
                {
                    sb.Append(address[i]);
                }
            }

            return sb.ToString();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Solution
    {

        public bool IsRouterCriical(List<List<int>> links, int numRouters, int router)
        {
            for (int j = 0; j <= numRouters; j++)
            {
                if(links[j].Contains(router) && links[j + 1].Contains(router))
                {
                    return true;
                }
            }            

            return false;
        }

        public List<int> criticalRouters(int numRouters, int numLinks,
                                         List<List<int>> links)
        {
            List<int> criticalRouters = new List<int>();

            for(int disconnectedIndex = 0; disconnectedIndex < numRouters; disconnectedIndex++)
            {
                if(IsRouterCriical(links, numRouters, disconnectedIndex))
                {
                    criticalRouters.Add(disconnectedIndex + 1);
                }
            }

            return criticalRouters;
        }
    }

    public class Solution2
    {
        public int FindMaxIndex(List<int> list)
        {
            int maxIndex = 0;
            int maxVal = list[maxIndex];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > maxVal)
                {
                    maxVal = list[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public List<int> GetTopIndex(List<int> list, int totalTop)
        {
            var topList = new List<int>();

            for(int i = 0; i < list.Count && topList.Count != totalTop; i++)
            {
                var index = FindMaxIndex(list);
                topList.Add(index);
                list[index] = -1;
            }

            return topList;
        }

        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public List<string> topNCompetitors(int numCompetitors,
                                            int topNCompetitors,
                                            List<string> competitors,
                                            int numReviews,
                                            List<string> reviews)
        {
            var topCompetitors = new List<string>();
            var timesNamedMentioned = new List<int>();

            for(int i = 0; i < numCompetitors; i++)
            {
                timesNamedMentioned.Add(0);
            }

            foreach(var review in reviews)
            {
                for(int i = 0; i < numCompetitors - 1; i++)
                {
                    if (review.Contains(competitors[i]))
                    {
                        timesNamedMentioned[i]++;                        
                    }
                }
            }

            var topIndex = GetTopIndex(timesNamedMentioned, topNCompetitors);

            foreach(var index in topIndex)
            {
                topCompetitors.Add(competitors[index]);
            }

            return topCompetitors;
        }
        // METHOD SIGNATURE ENDS
    }

    public class GCD
    {
        public bool DividesAll(int[] arr, int divisor)
        {            
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] % divisor != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int FindMinValue(int[] arr)
        {
            int minVal = arr[0];

            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] < minVal)
                {
                    minVal = arr[i];
                }
            }

            return minVal;
        }

        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int generalizedGCD(int num, int[] arr)
        {
            var maxHcf = FindMinValue(arr);
            var hcf = 1;

            for (int i = 1; i <= maxHcf; i++)
            {
                if (DividesAll(arr, i))
                {
                    hcf = i;
                }
            }

            return hcf;
        }
        // METHOD SIGNATURE ENDS
    }

    public class Solution1
    {
        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int[] cellCompete(int[] states, int days)
        {
            var currentDayList = new List<int>();
            var nextDayList = new List<int>();

            currentDayList.Add(0);
            nextDayList.Add(0);
            for(int i = 0; i < states.Length; i++)
            {
                currentDayList.Add(states[i]);
                nextDayList.Add(states[i]);
            }
            currentDayList.Add(0);
            nextDayList.Add(0);

            for(int i = 0; i < days; i++)
            {
                for(int j = 1; j < currentDayList.Count - 1; j++)
                {
                    if((currentDayList[j-1] == 0 && currentDayList[j+1] == 0) || (currentDayList[j - 1] == 1 && currentDayList[j + 1] == 1))
                    {
                        nextDayList[j] = 0;
                    }
                    else
                    {
                        nextDayList[j] = 1;
                    }
                }                

                for (int k = 0; k < nextDayList.Count; k++)
                    currentDayList[k] = nextDayList[k];
            }

            
            for(int i = 1; i < nextDayList.Count - 1; i++)
            {
                states[i - 1] = nextDayList[i];
            }

            return states;
        }
        
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node()
        {

        }
        public Node(int data)
        {
            this.Data = data;

        }
    }
    public class BinaryTree
    {
        private Node _root;
        public BinaryTree()
        {
            _root = null;
        }
        public void Insert(int data)
        {
            // 1. If the tree is empty, return a new, single node 
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            // 2. Otherwise, recur down the tree 
            InsertRec(_root, new Node(data));
        }
        private void InsertRec(Node root, Node newNode)
        {
            if (root == null)
                root = newNode;

            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                    root.Left = newNode;
                else
                    InsertRec(root.Left, newNode);

            }
            else
            {
                if (root.Right == null)
                    root.Right = newNode;
                else
                    InsertRec(root.Right, newNode);
            }
        }
        private void DisplayTree(Node root)
        {
            if (root == null) return;

            DisplayTree(root.Left);
            System.Console.Write(root.Data + " ");
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            DisplayTree(_root);
        }

    }

    public class HashTable<T, TU>
    {
        public LinkedList<Tuple<T, TU>>[] _items;
        private int _fillFactor = 3;
        public int _size;

        public HashTable()
        {
            _items = new LinkedList<Tuple<T, TU>>[4];
        }

        public void Add(T key, TU value)
        {
            var pos = GetPosition(key, _items.Length);
            if (_items[pos] == null)
            {
                _items[pos] = new LinkedList<Tuple<T, TU>>();
            }
            if (_items[pos].Any(x => x.Item1.Equals(key)))
            {
                throw new Exception("Duplicate key, cannot insert.");
            }
            _size++;
            if (NeedToGrow())
            {
                GrowAndReHash();
            }
            pos = GetPosition(key, _items.Length);
            if (_items[pos] == null)
            {
                _items[pos] = new LinkedList<Tuple<T, TU>>();
            }
            _items[pos].AddFirst(new Tuple<T, TU>(key, value));
        }

        public void Remove(T key)
        {
            var pos = GetPosition(key, _items.Length);
            if (_items[pos] != null)
            {
                var objToRemove = _items[pos].FirstOrDefault(item => item.Item1.Equals(key));
                if (objToRemove == null) return;
                _items[pos].Remove(objToRemove);
                _size--;
            }
            else
            {
                throw new Exception("Value not in HashTable.");
            }
        }

        public TU Get(T key)
        {
            var pos = GetPosition(key, _items.Length);
            foreach (var item in _items[pos].Where(item => item.Item1.Equals(key)))
            {
                return item.Item2;
            }
            throw new Exception("Key does not exist in HashTable.");
        }

        private void GrowAndReHash()
        {
            _fillFactor *= 2;
            var newItems = new LinkedList<Tuple<T, TU>>[_items.Length * 2];
            foreach (var item in _items.Where(x => x != null))
            {
                foreach (var value in item)
                {
                    var pos = GetPosition(value.Item1, newItems.Length);
                    if (newItems[pos] == null)
                    {
                        newItems[pos] = new LinkedList<Tuple<T, TU>>();
                    }
                    newItems[pos].AddFirst(new Tuple<T, TU>(value.Item1, value.Item2));
                }
            }
            _items = newItems;
        }

        private int GetPosition(T key, int length)
        {
            var hash = key.GetHashCode();
            var pos = Math.Abs(hash % length);
            return pos;
        }

        private bool NeedToGrow()
        {
            return _size >= _fillFactor;
        }
    }
}
